<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/UserPages/Registration.Master" EnableEventValidation="false" CodeBehind="DocumentsForContractor.aspx.cs" Inherits="CEIHaryana.UserPages.DocumentsForContractor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
</asp:content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form id="form1">
        <div>           
            <main id="main">
                <section id="about" class="about section-bg">
                    <div class="container" data-aos="fade-up">
                        <div class="row">
                            <div class="col-md-1"></div>
                            <div class="col-md-12">
                                <p style="text-align: center; margin-top: -40px; font-weight: 700;">
                                    (Please read the instructions carefully as given in Instruction
                            Page before filling the form)
                                </p>
                                <img src="/Assets/capsules/documents.png" alt="NO IMAGE FOUND" style="width: 90%; margin-left: 5%;" />
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
                                                            <td style="text-align: center;">Last Three Year Income Tax Returns and Balance Sheet.(<span style="color: red;">★</span>)
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
                                                            <td style="text-align: center;">PAN Card.(<span style="color: red;">★</span>)
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
                                                            <td style="text-align: center;">Aadhaar No.(<span style="color: red;">★</span>)
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
                                                                    Age Certificate<span
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
                                                            <td style="text-align: center;">
                                                                <p>Calibration Certificate from NABL or Government testing laboratory </p>
                                                                <p>respect of electrical equipment’s(<span style="color: red;">★</span>)</p>
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
                                                            <td style="text-align: center;">Copy of Annexure 3 & 5(<span
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

                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: center;">Attach documents to prove the status of the firm/company.(<span
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
                                                            <td style="text-align: center;">
                                                                <p>
                                                                    Major works carried out in Haryana ( Include details of installations,
                                                              scheme approval   obtained
                                                                </p>
                                                                <p>
                                                                    from electrical inspectorate.etc)(<span
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
                                                                        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control file-upload-info"
                                                                            Enabled="false" placeholder="Upload Candidate Signature" Style="width: 50%;"></asp:TextBox>

                                                                        <span class="input-group-append">

                                                                            <asp:Button ID="Button1" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick="SignaturDialog(); return false;" />
                                                                            <input type="file" id="File1" name="fileInput" accept=".jpg, .jpeg, .png" style="display: none;" runat="server" onchange="SignaturName()" />

                                                                        </span>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="selectedFileName"
                                                                            ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Select Your Signature</asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                            </td>
                                                            <asp:HiddenField ID="HiddenField1" runat="server" />
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: center;">
                                                                <p>
                                                                   Details of works
permitted to be
undertaken

                                                               
                                                               (<span
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
                                                                        <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control file-upload-info"
                                                                            Enabled="false" placeholder="Upload Candidate Signature" Style="width: 50%;"></asp:TextBox>

                                                                        <span class="input-group-append">

                                                                            <asp:Button ID="Button3" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick="SignaturDialog(); return false;" />
                                                                            <input type="file" id="File2" name="fileInput" accept=".jpg, .jpeg, .png" style="display: none;" runat="server" onchange="SignaturName()" />

                                                                        </span>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="selectedFileName"
                                                                            ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Select Your Signature</asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                            </td>
                                                            <asp:HiddenField ID="HiddenField3" runat="server" />
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: center;">
                                                                <p>
                                                                    Copy of Elibrary/library asper ANNEXURE –2                                                               
                                                               <span
                                                                   style="color: red;">★</span>
                                                                </p>
                                                            </td>
                                                            <td>
                                                                <input type="file" name="img[]" class="file-upload-default"
                                                                    style="display: none;">
                                                                <div class="form-group">
                                                                    <label style="font-size: 9px;">
                                                                        (PLEASE UPLOAD PHOTO SIZE20KB TO 50KB)</label>
                                                                    <input type="file" name="img[]" class="file-upload-default">
                                                                    <div class="input-group col-xs-12">
                                                                        <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control file-upload-info"
                                                                            Enabled="false" placeholder="Upload Candidate Signature" Style="width: 50%;"></asp:TextBox>

                                                                        <span class="input-group-append">

                                                                            <asp:Button ID="Button4" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick="SignaturDialog(); return false;" />
                                                                            <input type="file" id="File3" name="fileInput" accept=".jpg, .jpeg, .png" style="display: none;" runat="server" onchange="SignaturName()" />

                                                                        </span>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="selectedFileName"
                                                                            ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Select Your Signature</asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                            </td>
                                                            <asp:HiddenField ID="HiddenField4" runat="server" />
                                                        </tr>
                                                        <tr>
                                                            <td style="text-align: center;">
                                                                <p>
                                                                   Copy of Previously Granted Contractor License
                                                               
                                                               (<span
                                                                        style="color: red;">★</span>)
                                                                </p>
                                                            </td>
                                                            <td>
                                                                <input type="file" name="img[]" class="file-upload-default"
                                                                    style="display: none;">
                                                                <div class="form-group">
                                                                    <label style="font-size: 9px;">
                                                                        (PLEASE UPLOAD PHOTO SIZE20KB TO 50KB)</label>
                                                                    <input type="file" name="img[]" class="file-upload-default">
                                                                    <div class="input-group col-xs-12">
                                                                        <asp:TextBox ID="TextBox10" runat="server" CssClass="form-control file-upload-info"
                                                                            Enabled="false" placeholder="Upload Candidate Signature" Style="width: 50%;"></asp:TextBox>

                                                                        <span class="input-group-append">

                                                                            <asp:Button ID="Button10" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick="SignaturDialog(); return false;" />
                                                                            <input type="file" id="File10" name="fileInput" accept=".jpg, .jpeg, .png" style="display: none;" runat="server" onchange="SignaturName()" />

                                                                        </span>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="selectedFileName"
                                                                            ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Select Your Signature</asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                            </td>
                                                            <asp:HiddenField ID="HiddenField5" runat="server" />
                                                        </tr>
                                                        
                                                    </tbody>
                                                </table>
                                            </div>

                                        </div>
                                        <div class="row" style="margin-top: 15px;">
                                            <div class="col-md-6">
                                                <%--  <button type="button" class="btn btn-primary" style="padding: 10px 20px 10px 20px;
border-radius: 5px;">Back</button>--%>
                                                <asp:Button type="button" ID="btnBack" Text="Back" runat="server" class="btn btn-primary" Style="padding: 10px 20px 10px 20px; border-radius: 5px;" />
                                            </div>
                                            <div class="col-md-6" style="text-align: end;">

                                                <asp:Button type="button" ValidationGroup="Submit" ID="btnNext" Text="Next" runat="server" class="btn btn-primary" Style="padding: 10px 20px 10px 20px; border-radius: 5px;" />
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


</asp:content>
