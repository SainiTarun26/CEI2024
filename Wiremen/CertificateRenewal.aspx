<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin_Master.Master" AutoEventWireup="true" CodeBehind="CertificateRenewal.aspx.cs" Inherits="CEIHaryana.Wiremen.CertificateRenewal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="shortcut icon" type="image/png" href="/css2/style.min.css" />
    <link rel="stylesheet" href="/css2/style.css" />
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/css/select2.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/js/select2.min.js"></script>

    <link href="ScriptCalendar/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="ScriptCalender/jquery-1.11.0.min.js"></script>
    <script type="text/javascript" src="ScriptCalender/jquery-ui.min.js"></script>
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

    <style>
        .col-4 {
            top: 0px;
            left: 0px;
        }

        .form-control {
            box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
            margin-left: 0px !important;
            height: 30px;
            font-size: 12px !important;
        }

        select.form-control {
            box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
            margin-left: 0px !important;
            height: 30px;
            font-size: 12px !important;
        }

        label {
            font-size: 13px;
        }

        .form-control:focus {
            border: 2px solid #80bdff;
            font-size: 12px !important;
        }

        select.form-control:focus {
            border: 2px solid #80bdff;
            font-size: 12px !important;
        }

        .select2-container .select2-selection--single {
            height: 30px !important;
        }

        .select2-container--default .select2-selection--single {
            border: 1px solid #ccc !important;
            border-radius: 0px !important;
        }

        span.select2-selection.select2-selection--single {
            padding: 0px 0px 0px 5px;
            box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
            margin-left: 0px !important;
            height: 30px;
            border-radius: 5px !important;
        }

            span.select2-selection.select2-selection--single:focus {
                border: 2px solid #80bdff;
            }

        .card .card-title {
            font-size: 1rem !important;
        }

        .btn-primary:hover {
            box-shadow: rgba(50, 50, 93, 0.25) 0px 30px 60px -12px inset, rgba(0, 0, 0, 0.3) 0px 18px 36px -18px inset;
        }

        button.btn.btn-primary.mr-2 {
            padding: 10px 25px 10px 25px;
            font-size: 18px;
        }

        td {
            padding: 15px 10px 0px 7px !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <%--  <div class="card-header" style="background: linear-gradient(341deg, rgba(0,255,103,1) 0%, rgba(70,85,252,1) 100%); color: white; margin-bottom: 15px; border-radius: 5px;">
            <h4 style="font-weight: 600; text-align: center;">WIREMEN DETAILS</h4>
        </div>--%>
        <div class="card" style="box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px; border-radius: 5px !important">
            <div class="card-body">
                <div class="row">
                    <div class="col-md-4"></div>
                    <div class="col-sm-4" style="text-align: center; box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding-top: 8px; padding-bottom: 8px; border-radius: 10px;">
                        <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important;">RENEWAL OF CERTIFICATE</h6>
                    </div>
                    <div class="col-md-4"></div>
                </div>
                <br />
                <h7 class="card-title fw-semibold mb-4">Personal Details</h7>
                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                    <div class="row">
                        <div class="col-4">
                            <label for="Name">
                                Name of Applicant<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtName" TabIndex="1" runat="server" onKeyPress="return alphabetKey(event);" MaxLength="30" Style="margin-left: 18px;"></asp:TextBox>
                        </div>
                        <div class="col-4">
                            <label for="age">
                                Date Of Birth
                                <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtAge" TabIndex="2" Type="Date" runat="server" min='0000-01-01' max='9999-01-01' Style="margin-left: 18px"></asp:TextBox>
                        </div>
                        <div class="col-4">
                            <label for="Name">
                                Age<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="TextBox1" TabIndex="1" runat="server" onKeyPress="return alphabetKey(event);" MaxLength="30" Style="margin-left: 18px;"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row" style="margin-top: 15px;">
                        <div class="col-4">
                            <label for="Contect">Date on which candidate completes 55 years</label>
                            <asp:TextBox class="form-control" ID="txtContect" runat="server" TabIndex="3" MaxLength="10" onkeypress="return isNumberKey(event)" onkeyup="isvalidphoneno();" Style="margin-left: 18px"></asp:TextBox>
                            <span id="lblErrorContect" style="color: red"></span>
                        </div>

                        <div class="col-8">
                            <label for="Address">
                                Present Address with Pincode<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtAddress" runat="server" TabIndex="4" MaxLength="60" Style="margin-left: 18px"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row" style="margin-top: 15px;">
                        <div class="col-4">
                            <label>
                                Supervisor Competency No./wireman Permit No.<samp style="color: red"> * </samp>
                            </label>
                            <asp:DropDownList class="form-control  select-form select2" ID="ddlDistrict" runat="server" TabIndex="5">
                            </asp:DropDownList>
                        </div>
                        <div class="col-4">
                            <label for="Pincode">
                                Date of Expiry<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtPincode" runat="server" MaxLength="6" onkeypress="return isNumberKey(event);" Style="margin-left: 18px" TabIndex="6"></asp:TextBox>
                            <span id="lblPinError" style="color: red"></span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPinCode" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">(*)</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-4">
                            <label for="Pincode">
                                Name of Treasury<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="TextBox2" runat="server" MaxLength="6" onkeypress="return isNumberKey(event);" Style="margin-left: 18px" TabIndex="6"></asp:TextBox>
                            <span id="lblPinError1" style="color: red"></span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPinCode" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">(*)</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row" style="margin-top: 15px;">
                        <div class="col-4">
                            <label>
                                GRN No. and Date of challan<samp style="color: red"> * </samp>
                            </label>
                            <asp:DropDownList class="form-control  select-form select2" ID="DropDownList1" runat="server" TabIndex="5">
                            </asp:DropDownList>
                        </div>
                        <div class="col-4">
                            <label for="Pincode">
                                Amount Remitted<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="TextBox3" runat="server" MaxLength="6" onkeypress="return isNumberKey(event);" Style="margin-left: 18px" TabIndex="6"></asp:TextBox>
                            <span id="lblPinError2" style="color: red"></span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPinCode" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">(*)</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="card"
                    style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; border-radius: 10px !important;">
                    <div class="card-body">
                        <div class="row">
                            <div class="col-md-12">
                                <h4 class="card-title">Checklist for submission of documents</h4>

                            </div>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="table-responsive">
                                    <table class="table table-bordered table-striped">

                                        <tbody>
                                            <tr>
                                                <td style="text-align: center;">Certificate of Competency/Wireman Permit.(<span
                                                    style="color: red;">★</span>)
                                                </td>
                                                <td>
                                                    <input type="file" name="img[]" class="file-upload-default"
                                                        style="display: none;">
                                                    <div class="form-group">
                                                        <label style="font-size: 9px;">
                                                            UPLOAD certificate (PLEASE UPLOAD PHOTO SIZE
                                                    20KB TO 50KB)</label>
                                                        <input type="file" name="img[]" class="file-upload-default">
                                                        <div class="input-group col-xs-12">
                                                            <asp:TextBox ID="selectedFileName" runat="server" CssClass="form-control file-upload-info"
                                                                Enabled="false" placeholder="Upload" Style="width: 50%;"></asp:TextBox>

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
                                                <td style="text-align: center;">Deposited Treasury Challan of fees, for the purpose in the Head of A/c: 0043-51-800-99-51- Other Reciept.(<span style="color: red;">★</span>)
                                                </td>
                                                <td>
                                                    <input type="file" name="img[]" class="file-upload-default"
                                                        style="display: none;">
                                                    <div class="form-group">
                                                        <label style="font-size: 9px;">
                                                            UPLOAD Signature (PLEASE UPLOAD PHOTO SIZE
                                                    20KB TO 50KB)</label>
                                                        <input type="file" name="img[]" class="file-upload-default">
                                                        <div class="input-group col-xs-12">
                                                            <asp:TextBox ID="txtResidence" runat="server" CssClass="form-control file-upload-info"
                                                                Enabled="false" placeholder="Upload" Style="width: 50%;"></asp:TextBox>

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
                                                <td style="text-align: center;">A Medical Fitness Certificate issued from Government/Government Approved Hospital,<br />
                                                    in case he is
above 55 years of age on the date of submission of application.(<span style="color: red;">★</span>)
                                                </td>
                                                <td>
                                                    <input type="file" name="img[]" class="file-upload-default"
                                                        style="display: none;">
                                                    <div class="form-group">
                                                        <label style="font-size: 9px;">
                                                            UPLOAD Identity Proof (PLEASE UPLOAD PHOTO SIZE
                                                    20KB TO 50KB)</label>
                                                        <input type="file" name="img[]" class="file-upload-default">
                                                        <div class="input-group col-xs-12">
                                                            <asp:TextBox ID="txtIdentity" runat="server" CssClass="form-control file-upload-info"
                                                                Enabled="false" placeholder="Upload" Style="width: 50%;"></asp:TextBox>

                                                            <span class="input-group-append">

                                                                <asp:Button ID="btnIdentity" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick="IdentityDialog(); return false;" />
                                                                <input type="file" id="Identit" name="fileInput" accept=".jpg, .jpeg, .png" style="display: none; border-top-right-radius: 10px; border-bottom-right-radius: 10px;"
                                                                    onchange="IdentityDialogName()" runat="server" />

                                                            </span>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="selectedFileName"
                                                                ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Select Your Identity Proof</asp:RequiredFieldValidator>

                                                        </div>
                                                    </div>
                                                </td>

                                            </tr>
                                            <tr>
                                                <td style="text-align: center;">Undertaking for delay or non-working during cancel period, in case of expiry of the Certificate/Permit.(<span
                                                    style="color: red;">★</span>)
                                                </td>
                                                <td>
                                                    <input type="file" name="img[]" class="file-upload-default"
                                                        style="display: none;">
                                                    <div class="form-group">
                                                        <label style="font-size: 9px;">
                                                            UPLOAD Degree/Diploma (PLEASE UPLOAD PHOTO SIZE
                                                    20KB TO 50KB)</label>
                                                        <input type="file" name="img[]" class="file-upload-default">
                                                        <div class="input-group col-xs-12">
                                                            <asp:TextBox ID="txtDegreeDiploma" runat="server" CssClass="form-control file-upload-info"
                                                                Enabled="false" placeholder="Upload" Style="width: 50%;"></asp:TextBox>

                                                            <span class="input-group-append">

                                                                <asp:Button ID="btnDegreeDiploma" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick="DegreeDiplomaDialog(); return false;" />
                                                                <input type="file" id="DegreeDiploma" name="fileInput" accept=".jpg, .jpeg, .png" style="display: none; border-top-right-radius: 10px; border-bottom-right-radius: 10px;"
                                                                    onchange="DegreeDiplomaName()" runat="server" />

                                                            </span>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtDegreeDiploma"
                                                                ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Select Your Degree/Diploma</asp:RequiredFieldValidator>

                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center;">Present Working Status.(<span style="color: red;">★</span>)
                                                </td>
                                                <td>
                                                    <input type="file" name="img[]" class="file-upload-default"
                                                        style="display: none;">
                                                    <div class="form-group">
                                                        <label style="font-size: 9px;">
                                                            UPLOAD Experience Certificate (PLEASE UPLOAD PHOTO SIZE
                                                    20KB TO 50KB)</label>
                                                        <input type="file" name="img[]" class="file-upload-default">
                                                        <div class="input-group col-xs-12">
                                                            <asp:TextBox ID="txtExperience" runat="server" CssClass="form-control file-upload-info"
                                                                Enabled="false" placeholder="Upload" Style="width: 50%;"></asp:TextBox>

                                                            <span class="input-group-append">

                                                                <asp:Button ID="btnExperience" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick="ExperienceDialog(); return false;" />
                                                                <input type="file" id="Experience" name="fileInput" accept=".jpg, .jpeg, .png" style="display: none; border-top-right-radius: 10px; border-bottom-right-radius: 10px;"
                                                                    onchange="ExperienceDialogName()" runat="server" />

                                                            </span>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="selectedFileName"
                                                                ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">Please Select Your Signature</asp:RequiredFieldValidator>

                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>


                    </div>

                </div>
            </div>

            <div class="card-body" style="text-align: center;">
                <div class="row">
                    <div class="col-md-12">
                        <h3>Declaration</h3>
                    </div>
                </div>
            </div>
            <div class="card-body">
                <div class="row">
                    <div class="col-md-12">
                        <ol type="1">
                            <li>Information furnished in the application is correct.</li>
                            <li>I am authorized t osign the application as Contractor/ on behalf of the Contractor.</li>
                        </ol>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="col-4">
                            <label for="Name">
                                Place:<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="TextBox4" TabIndex="1" runat="server" onKeyPress="return alphabetKey(event);" MaxLength="30" Style="margin-left: 18px;"></asp:TextBox>
                        </div>
                        <div class="col-4">
                            <label for="age">
                                Date:
                                <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="TextBox5" TabIndex="2" Type="Date" runat="server" min='0000-01-01' max='9999-01-01' Style="margin-left: 18px"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="col-4" style="margin-left: auto;">
                            <label for="Name">
                                Signature of Applicant:<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="TextBox6" TabIndex="1" runat="server" onKeyPress="return alphabetKey(event);" MaxLength="30" Style="margin-left: 18px;"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-4"></div>
                <div class="col-4" style="text-align: center;">
                    <asp:Button ID="btnSubmit" Text="Submit" runat="server" class="btn btn-primary mr-2" TabIndex="16"
                        Style="background: linear-gradient(135deg, hsla(318, 44%, 51%, 1) 0%, hsla(347, 94%, 48%, 1) 100%); border-color: #d42766;"
                        ValidationGroup="ValidProject" />
                    <asp:Button ID="BtnReset" Text="Reset" runat="server" class="btn btn-primary mr-2" TabIndex="17"
                        Style="background: linear-gradient(135deg, hsla(318, 44%, 51%, 1) 0%, hsla(347, 94%, 48%, 1) 100%); border-color: #d42766;" />
                </div>
                <asp:HiddenField ID="hdfvalue" runat="server" />
            </div>
            <div class="col-4"></div>
        </div>
    </div>
    <!-- partial:../../partials/_footer.html -->
    <footer class="footer">
    </footer>
    <!-- partial -->
    <script>
        $('.select2').select2();
    </script>





</asp:Content>
