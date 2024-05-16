<%@ Page Title="" Language="C#" MasterPageFile="~/Contractor/Contractor.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="ContractorRenewal.aspx.cs" Inherits="CEIHaryana.Contractor.ContractorRenewal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="shortcut icon" type="image/png" href="/css2/style.min.css" />
    <link rel="stylesheet" href="/css2/style.css" />
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css" />
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <!------ Include the above in your HEAD tag ---------->
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
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
    <script type="text/javascript">
        function alertWithRedirectdata() {
            if (confirm('Data Added Successfully')) {
                window.location.href = "/Admin/AddContractorDetails.aspx";
            } else {
            }
        }
    </script>
    <style>
        input#ContentPlaceHolder1_BtnEquipCertificate {
    padding: 0px;
    font-size: 13px;
    padding-left: 10px;
    padding-right: 10px;
    border-top-right-radius: 8px;
    border-bottom-right-radius: 8px;
    box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
}
        input#ContentPlaceHolder1_btnIncomeTax {
    padding: 0px;
    font-size: 13px;
    padding-left: 10px;
    padding-right: 10px;
    border-top-right-radius: 8px;
    border-bottom-right-radius: 8px;
    box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
}
        input#ContentPlaceHolder1_btnBalanceSheet {
    padding: 0px;
    font-size: 13px;
    padding-left: 10px;
    padding-right: 10px;
    border-top-right-radius: 8px;
    border-bottom-right-radius: 8px;
    box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
}
        input#ContentPlaceHolder1_btnCalibCertificate {
    padding: 0px;
    font-size: 13px;
    padding-left: 10px;
    padding-right: 10px;
    border-top-right-radius: 8px;
    border-bottom-right-radius: 8px;
    box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
}
        input#ContentPlaceHolder1_btnWorkDetails {
    padding: 0px;
    font-size: 13px;
    padding-left: 10px;
    padding-right: 10px;
    border-top-right-radius: 8px;
    border-bottom-right-radius: 8px;
    box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
}
        input#ContentPlaceHolder1_btnAnnexureIII {
    padding: 0px;
    font-size: 13px;
    padding-left: 10px;
    padding-right: 10px;
    border-top-right-radius: 8px;
    border-bottom-right-radius: 8px;
    box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
}
        input#ContentPlaceHolder1_btnForm_E {
    padding: 0px;
    font-size: 13px;
    padding-left: 10px;
    padding-right: 10px;
    border-top-right-radius: 8px;
    border-bottom-right-radius: 8px;
    box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
}
        input#ContentPlaceHolder1_btnTreasuryChallan {
    padding: 0px;
    font-size: 13px;
    padding-left: 10px;
    padding-right: 10px;
    border-top-right-radius: 8px;
    border-bottom-right-radius: 8px;
    box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
}
       select#ContentPlaceHolder1_DdlState {
    box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
    margin-left: 0px !important;
    height: 30px;
    font-size: 12px !important;
    box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
    width: 100% !important;
    background: #e7e7e7;
    color: black;
    border-radius: 3px;
    box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
}
       select#ContentPlaceHolder1_DdlDistrict {
    box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
    margin-left: 0px !important;
    height: 30px;
    font-size: 12px !important;
    box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
    width: 100% !important;
    background: #e7e7e7;
    color: black;
    border-radius: 3px;
    box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
}
        input#ContentPlaceHolder1_RadioButtonList1_0 {
            margin-right: 5px;
        }

        input#ContentPlaceHolder1_RadioButtonList1_1 {
            margin-left: 10px;
            margin-right: 5px;
        }

        input#ContentPlaceHolder1_RadioButtonList3_0 {
            margin-right: 5px;
        }

        input#ContentPlaceHolder1_RadioButtonList3_1 {
            margin-left: 10px;
            margin-right: 5px;
        }

        input#ContentPlaceHolder1_RadioButtonList2_1 {
            margin-left: 10px;
            margin-right: 3px;
        }

        input#ContentPlaceHolder1_RadioButtonList2_0 {
            margin-left: 10px;
            margin-right: 3px;
        }

        .col-md-4 {
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
            height: 30px !important;
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

        .select2-container .select2-selection--single .form-control {
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

        span.select2-dropdown.select2-dropdown--below {
            margin-top: 50px !important;
        }

        input#ContentPlaceHolder1_btnMedicalCertificate {
            padding: 6px 5px 0px 5px;
            padding-top: 0px;
            border-top-right-radius: 5px;
            border-bottom-right-radius: 5px;
        }

            input#ContentPlaceHolder1_btnMedicalCertificate:Hover {
                padding: 6px 5px 0px 5px;
                padding-top: 0px;
                border-top-right-radius: 5px;
                border-bottom-right-radius: 5px;
                box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px !important;
            }

        input#ContentPlaceHolder1_txtMedicalCertificate {
            background: white;
        }

        .table-bordered td, .table-bordered th {
            border: 1px solid #dee2e6;
            padding: 1px;
            padding-left: 10px;
            padding-right: 50px;
        }

        input#ContentPlaceHolder1_btnUploadFeeReciept {
            border-top-right-radius: 10px;
    border-bottom-right-radius: 10px;
    height: 30px;
    padding: 0px;
    padding-left: 5px;
    padding-right: 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
    <div class="content-wrapper">
        <div class="card" style="box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px; border-radius: 5px !important">
            <div class="card-body">
                <div class="row">
                    <div class="col-md-4"></div>
                    <div class="col-sm-4" style="text-align: center; box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding-top: 8px; padding-bottom: 8px; border-radius: 10px; top: 0px; left: 0px;">
                        <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important;">LICENCE RENEWAL APPLICATION</h6>
                    </div>
                    <br />
                    <div class="col-md-4"></div>
                </div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="row">
                            <div class="col-md-4"></div>
                            <div class="col-sm-4" style="text-align: center;">
                                <label id="DataUpdated" runat="server" visible="false" style="color: red; font-size: 1.125rem">
                                    Data Updated Successfully !!!.
                                </label>
                                <label id="DataSaved" runat="server" visible="false" style="color: red; font-size: 1.125rem">
                                    Data Saved Successfully !!!.
                                </label>
                            </div>
                        </div>
                        <br />
                        <h7 class="card-title fw-semibold mb-4">Personal Details</h7>
                        <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                            <div class="row">
                                <div class="col-md-4">
                                    <label>
                                        Applicant Name
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtName" runat="server" autocomplete="off" ReadOnly="true" onKeyPress="return alphabetKey(event);" MaxLength="200" Style="margin-left: 18px;">
                                    </asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <label>
                                        Licence No.
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtLicenceNo" runat="server" ReadOnly="true" autocomplete="off" onKeyPress="return alphabetKey(event);" MaxLength="200" Style="margin-left: 18px;">
                                    </asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <label>
                                        Date of Issue
                                    </label>
                                    <asp:TextBox class="form-control" autocomplete="off" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" ID="txtIssueDate" min='0000-01-01' max='9999-01-01' Type="Date" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                </div>
                                <div class="col-md-4" style="margin-top: 23px;">
                                    <label>
                                        Date of Expiry
                                    </label>
                                    <asp:TextBox class="form-control" autocomplete="off" onkeydown="return preventEnterSubmit(event)" ReadOnly="true" ID="txtExpiryDate" min='0000-01-01' max='9999-01-01' Type="Date" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                </div>
                                <div class="col-md-4" id="divExtended" visible="false" runat="server" style="margin-top: 23px;">
                                    <label>
                                        Extended By (From Date of Expiry)
                                    </label>
                                    <asp:TextBox class="form-control" autocomplete="off" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" ID="txtExtendedBy" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtExtendedBy" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                </div>
                                <div class="col-md-4" style="margin-top: 23px;">
                                    <label>
                                        Date of Birth<samp style="color: red"> * </samp>
                                    </label>
                                    <asp:TextBox class="form-control" autocomplete="off" onkeydown="return preventEnterSubmit(event)" ID="txtDOB" min='0000-01-01' max='9999-01-01' Type="Date" OnTextChanged="txtDOB_TextChanged" AutoPostBack="true"  runat="server" Style="margin-left: 18px" TabIndex="1"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="txtDOB" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please enter Date of Birth</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-4">
                                    <label>
                                        Age<samp style="color: red"> * </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtAge" runat="server" onkeydown="return preventEnterSubmit(event)" ReadOnly="true" autocomplete="off" Style="margin-left: 18px" MaxLength="300"></asp:TextBox>
                                    <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAge" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Firm Name</asp:RequiredFieldValidator>--%>
                                </div>
                                <div class="col-md-4">
                                    <label for="Email">
                                        Email<samp style="color: red"> * </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtEmail" onkeydown="return preventEnterSubmit(event)" runat="server" autocomplete="off" Style="margin-left: 18px" onkeyup="return ValidateEmail();" TabIndex="2"></asp:TextBox>
                                    <span style="color: red"></span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtContactNo" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please enter Email</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-4">
                                    <label for="ContactNo">
                                        Contact No.<samp style="color: red"> * </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtContactNo" runat="server" autocomplete="off" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);"
                                         onkeyup="return isvalidphoneno();" MaxLength="10" Style="margin-left: 18px" TabIndex="3">
                                    </asp:TextBox>
                                    <span style="color: red"></span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtContactNo" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please enter Contact No</asp:RequiredFieldValidator>
                                </div>
                                <div class="row" style="margin-left: 2%; margin-bottom: 1%; font-size: 13px;">
                                    Whether there is any change of Address? &nbsp;&nbsp;
                            <asp:RadioButtonList ID="RadioButtonList1" AutoPostBack="true" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" runat="server" RepeatDirection="Horizontal" TabIndex="4">
                                <asp:ListItem Text="Yes" Value="0"></asp:ListItem>
                                <asp:ListItem Text="No" Value="1" Selected="True"></asp:ListItem>
                            </asp:RadioButtonList>
                                </div>
                                <div class="col-md-8">
                                    <label>
                                        Address<samp style="color: red"> * </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtAddress" onkeydown="return preventEnterSubmit(event)" ReadOnly="true" autocomplete="off" runat="server" TabIndex="5"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtAddress" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please enter Registered Office Address</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-4">
                                    <label>
                                        State/UT 
                            <samp style="color: red">* </samp>
                                    </label>
                                    <asp:DropDownList Style="width: 100% !important;" class="form-control select-form select2" ID="DdlState" Enabled="false" OnSelectedIndexChanged="DdlState_SelectedIndexChanged" runat="server" AutoPostBack="true" TabIndex="6">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" Text="Please select State" ErrorMessage="RequiredFieldValidator" ControlToValidate="DdlState" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                </div>
                                <div class="col-md-4">
                                    <label>
                                        District
                            <samp style="color: red">* </samp>
                                    </label>
                                    <asp:DropDownList Style="width: 100% !important;" class="form-control  select-form select2" ID="DdlDistrict" Enabled="false" runat="server" TabIndex="7" >
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator17" Text="Please select District" ErrorMessage="RequiredFieldValidator" ControlToValidate="DdlDistrict" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                </div>
                                <div class="col-md-4">
                                    <label for="PinCode">
                                        PinCode<samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtpincode" onkeydown="return preventEnterSubmit(event)" ReadOnly="true" runat="server" autocomplete="off" MaxLength="6" onkeyup="ValidatePincode();" onkeypress="return isNumberKey(event);" TabIndex="8"></asp:TextBox>
                                    <span id="lblPinError" style="color: red"></span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtpincode" runat="server" ValidationGroup="Submit" ForeColor="Red">Please enter Pin Code </asp:RequiredFieldValidator>
                                </div>
                                <div class="row" style="margin-left: 2%; margin-top: 2%; font-size: 13px;">
                                    Whether there Address has to be changed in the Licence also as same as the new Address? &nbsp;&nbsp;
                        <asp:RadioButtonList ID="RadioButtonList3" AutoPostBack="true" runat="server" RepeatDirection="Horizontal" TabIndex="9" >
                            <asp:ListItem Text="Yes" Value="0"></asp:ListItem>
                            <asp:ListItem Text="No" Value="1" Selected="True"></asp:ListItem>
                        </asp:RadioButtonList>
                                </div>
                            </div>
                        </div>
                        <h7 class="card-title fw-semibold mb-4">Fee Details</h7>
                        <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                            <div class="row" style="margin-left: 0px; /* margin-top: 2%; */ font-size: 13px; margin-bottom: 10px;">
                                Mode of Payment &nbsp;&nbsp;
                                <asp:RadioButtonList ID="RadioButtonList2" AutoPostBack="true" runat="server" OnSelectedIndexChanged="RadioButtonList2_SelectedIndexChanged" RepeatDirection="Horizontal" TabIndex="10" >
                                    <asp:ListItem Text="Online" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Offline" Value="1" Selected="True"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                            <div class="row" id="divPaymentMode" visible="true" runat="server">
                                <div class="col-md-4">
                                    <label>
                                        Name of Treasury<samp style="color: red"> * </samp>
                                    </label>
                                    <asp:TextBox class="form-control" autocomplete="off" onkeydown="return preventEnterSubmit(event)" ID="txtTreasuryName" min='0000-01-01' max='9999-01-01' MaxLength="50" runat="server" Style="margin-left: 18px" TabIndex="11"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtTreasuryName" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please enter Name of Treasury</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-4">
                                    <label>
                                        Challan GRN No.<samp style="color: red"> * </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtchallanNo" runat="server" autocomplete="off" MaxLength="30" Style="margin-left: 18px;" TabIndex="12">
                                    </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtchallanNo" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please enter Challan GRN No</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-4">
                                    <label>
                                        Date of Challan<samp style="color: red"> * </samp>
                                    </label>
                                    <asp:TextBox class="form-control" autocomplete="off" onkeydown="return preventEnterSubmit(event)" ID="txtChallanDate" min='0000-01-01' max='9999-01-01' Type="Date" runat="server" Style="margin-left: 18px" TabIndex="13"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtChallanDate" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please enter Date of Challan</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-4">
                                    <label>
                                        Amount Remitted<samp style="color: red"> * </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtRemittedAmount" runat="server" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" autocomplete="off" Style="margin-left: 18px"  MaxLength="4" TabIndex="14"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtRemittedAmount" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please enter Amount Remitted</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-4" style="margin-top: auto;">
                                    <div class="input-group col-xs-12">
                                        <asp:TextBox ID="txtFeeReciept" runat="server" CssClass="form-control file-upload-info" Enabled="false" placeholder="Upload Payment Reciept" Style="width: 50%;" ></asp:TextBox>
                                        <span class="input-group-append">
                                            <asp:Button ID="btnUploadFeeReciept" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick="FeeRecieptDialog(); return false;" TabIndex="15" />
                                            <input type="file" id="FeeReciept" name="FeeRecieptInput" accept=".jpg, .jpeg, .png, .pdf" style="display: none; border-top-right-radius: 10px; border-bottom-right-radius: 10px;"
                                                onchange="FeeRecieptDialogName()" runat="server" />
                                        </span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtFeeReciept"
                                            ValidationGroup="Submit" ForeColor="Red">Please Upload Payment Reciept</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <h7 class="card-title fw-semibold mb-4">Staff Details</h7>
                        <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">

                            <%-- Add Grid View Here --%>
                            <asp:GridView ID="GridView1" class="table-responsive table table-hover table-striped" runat="server" Width="100%" AutoGenerateColumns="false" BorderWidth="1px" BorderColor="#dbddff">
                                <Columns>
                                    <asp:TemplateField HeaderText="Id" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCategory" runat="server" Text='<%#Eval("Category") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="REID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblREID" runat="server" Text='<%#Eval("REID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="REID" HeaderText="ID" Visible="False">
                                        <HeaderStyle HorizontalAlign="center" Width="10%" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="center" Width="10%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="LicenseNo" HeaderText="License">
                                        <HeaderStyle HorizontalAlign="left" Width="20%" CssClass="headercolor textalignleft" />
                                        <ItemStyle HorizontalAlign="left" Width="20%" CssClass="textalignleft" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Name" HeaderText="Name">
                                        <HeaderStyle HorizontalAlign="Left" Width="34%" CssClass="headercolor textalignleft" />
                                        <ItemStyle HorizontalAlign="Left" Width="34%" CssClass="textalignleft" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DateOfExpiry" HeaderText="Expiry Date">
                                        <HeaderStyle HorizontalAlign="center" Width="19%" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="center" Width="19%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DateofRenewal" HeaderText="Valid Upto">
                                        <HeaderStyle HorizontalAlign="center" Width="18%" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="center" Width="18%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Category" HeaderText="Category">
                                        <HeaderStyle HorizontalAlign="left" Width="17%" CssClass="headercolor textalignleft" />
                                        <ItemStyle HorizontalAlign="left" Width="17%" CssClass="textalignleft" />
                                    </asp:BoundField>
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
                            <%-- End Before This Tag --%>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <h7 class="card-title fw-semibold mb-4">Documents</h7>
                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                    <div class="row">
                        <div class="table-responsive">
                            <table class="table table-bordered table-striped">
                                <tbody>
                                    <tr>
                                        <td style="padding-top: 45px;">Equipment tested certificate.(<span style="color: red;">★</span>)
                                        </td>
                                        <td>
                                            <input type="file" name="img[]" class="file-upload-default" style="display: none;" />
                                            <div class="form-group">
                                                <label style="font-size: 9px;">(PLEASE UPLOAD PDF ONLY NO MORE THAN 2MB)</label>
                                                <input type="file" name="img[]" class="file-upload-default" />
                                                <div class="input-group col-xs-12">
                                                    <asp:TextBox ID="txtEquipCertificate" runat="server" CssClass="form-control file-upload-info"
                                                        Enabled="false" placeholder="Upload Equipment tested certificate" Style="width: 85%;"></asp:TextBox>
                                                    <span class="input-group-append">
                                                        <asp:Button ID="BtnEquipCertificate" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick="PhotoDialog(); return false;" TabIndex="16" />
                                                        <input type="file" id="EquipCertificate" name="EquipCertificateInput" accept=".jpg, .jpeg, .png, .pdf" style="display: none;" runat="server" onchange="PhotoDialogName()" />
                                                    </span>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" ControlToValidate="txtEquipCertificate" ValidationGroup="Submit" ForeColor="Red">Please Upload Equipment tested certificate</asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </td>
                                        <asp:HiddenField ID="HiddenField1" runat="server" />
                                    </tr>
                                    <tr>
                                        <td style="padding-top: 45px;">Income Tax Returns(<span
                                            style="color: red;">★</span>)
                                        </td>
                                        <td>
                                            <input type="file" name="img[]" class="file-upload-default" style="display: none;" />
                                            <div class="form-group">
                                                <label style="font-size: 9px;">
                                                    (PLEASE UPLOAD PDF ONLY NO MORE THAN 2MB)</label>
                                                <input type="file" name="img[]" class="file-upload-default" />
                                                <div class="input-group col-xs-12">
                                                    <asp:TextBox ID="txtIncomeTax" runat="server" CssClass="form-control file-upload-info" Enabled="false" placeholder="Upload Income Tax Returns certificate" Style="width: 50%;"></asp:TextBox>
                                                    <span class="input-group-append">
                                                        <asp:Button ID="btnIncomeTax" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick="IncomeTaxDialog(); return false;" TabIndex="17"/>
                                                        <input type="file" id="IncomeTax" name="IncomeTaxInput" accept=".jpg, .jpeg, .png, .pdf" style="display: none;" runat="server" onchange="IncomeTaxDialogName()" />
                                                    </span>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="txtIncomeTax"
                                                        ValidationGroup="Submit" ForeColor="Red">Please Upload Your Income Tax Returns certificate</asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </td>
                                        <asp:HiddenField ID="HiddenField2" runat="server" />
                                    </tr>
                                    <tr>
                                        <td style="padding-top: 45px;">Balance Sheet(<span style="color: red;">★</span>)
                                        </td>
                                        <td>
                                            <input type="file" name="img[]" class="file-upload-default" style="display: none;" />
                                            <div class="form-group">
                                                <label style="font-size: 9px;">
                                                    (PLEASE UPLOAD PDF ONLY NO MORE THAN 2MB)</label>
                                                <input type="file" name="img[]" class="file-upload-default" />
                                                <div class="input-group col-xs-12">
                                                    <asp:TextBox ID="txtBalanceSheet" runat="server" CssClass="form-control file-upload-info" Enabled="false" placeholder="Upload Balance Sheet" Style="width: 85%;"></asp:TextBox>
                                                    <span class="input-group-append">
                                                        <asp:Button ID="btnBalanceSheet" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick="BalanceSheetDialog(); return false;" TabIndex="18"/>
                                                        <input type="file" id="BalanceSheet" name="BalanceSheetInput" accept=".jpg, .jpeg, .png, .pdf" style="display: none; border-top-right-radius: 10px; border-bottom-right-radius: 10px;" onchange="BalanceSheetDialogName()" runat="server" />
                                                    </span>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtBalanceSheet"
                                                        ValidationGroup="Submit" ForeColor="Red">Please Upload Balance Sheet</asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding-top: 45px;">Calibration Certificate.(<span style="color: red;">★</span>)
                                        </td>
                                        <td>
                                            <input type="file" name="img[]" class="file-upload-default" style="display: none;" />
                                            <div class="form-group">
                                                <label style="font-size: 9px;">
                                                    (PLEASE UPLOAD PDF ONLY NO MORE THAN 2MB)</label>
                                                <input type="file" name="img[]" class="file-upload-default" />
                                                <div class="input-group col-xs-12">
                                                    <asp:TextBox ID="txtCalibCertificate" runat="server" CssClass="form-control file-upload-info" Enabled="false" placeholder="Upload Calibration Certificate" Style="width: 85%;"></asp:TextBox>
                                                    <span class="input-group-append">
                                                        <asp:Button ID="btnCalibCertificate" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick="CalibCertificateDialog(); return false;" TabIndex="19"/>
                                                        <input type="file" id="CalibCertificate" name="CalibCertificateInput" accept=".jpg, .jpeg, .png, .pdf" style="display: none; border-top-right-radius: 10px; border-bottom-right-radius: 10px;"
                                                            onchange="CalibCertificateDialogName()" runat="server" />
                                                    </span>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtCalibCertificate"
                                                        ValidationGroup="Submit" ForeColor="Red">Please Upload Calibration Certificate</asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding-top: 45px;">Details of Works.(<span style="color: red;">★</span>)
                                        </td>
                                        <td>
                                            <input type="file" name="img[]" class="file-upload-default" style="display: none;" />
                                            <div class="form-group">
                                                <label style="font-size: 9px;">
                                                    (PLEASE UPLOAD PDF ONLY NO MORE THAN 2MB)</label>
                                                <input type="file" name="img[]" class="file-upload-default" />
                                                <div class="input-group col-xs-12">
                                                    <asp:TextBox ID="txtWorkDetails" runat="server" CssClass="form-control file-upload-info" Enabled="false" placeholder="Upload Details of Works" Style="width: 85%;"></asp:TextBox>
                                                    <span class="input-group-append">
                                                        <asp:Button ID="btnWorkDetails" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick="WorkDetailsDialog(); return false;" TabIndex="20"/>
                                                        <input type="file" id="WorkDetails" name="WorkDetailsInput" accept=".jpg, .jpeg, .png, .pdf" style="display: none; border-top-right-radius: 10px; border-bottom-right-radius: 10px;"
                                                            onchange="WorkDetailsDialogName()" runat="server" />
                                                    </span>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtWorkDetails"
                                                        ValidationGroup="Submit" ForeColor="Red">Please Upload Details of Works</asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding-top: 45px;">Copy of Annexure III.(<span style="color: red;">★</span>)
                                        </td>
                                        <td>
                                            <input type="file" name="img[]" class="file-upload-default" style="display: none;" />
                                            <div class="form-group">
                                                <label style="font-size: 9px;">
                                                    (PLEASE UPLOAD PDF ONLY NO MORE THAN 2MB)</label>
                                                <input type="file" name="img[]" class="file-upload-default" />
                                                <div class="input-group col-xs-12">
                                                    <asp:TextBox ID="txtAnnexureIII" runat="server" CssClass="form-control file-upload-info"
                                                        Enabled="false" placeholder="Upload Copy of Annexure III" Style="width: 85%;"></asp:TextBox>
                                                    <span class="input-group-append">
                                                        <asp:Button ID="btnAnnexureIII" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick="AnnexureIIIDialog(); return false;" TabIndex="21"/>
                                                        <input type="file" id="AnnexureIII" name="AnnexureIIIInput" accept=".jpg, .jpeg, .png, .pdf" style="display: none; border-top-right-radius: 10px; border-bottom-right-radius: 10px;"
                                                            onchange="AnnexureIIIDialogName()" runat="server" />
                                                    </span>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtAnnexureIII"
                                                        ValidationGroup="Submit" ForeColor="Red">Please Upload Copy of Annexure III</asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding-top: 45px;">Copy of Form_E.(<span style="color: red;">★</span>)
                                        </td>
                                        <td>
                                            <input type="file" name="img[]" class="file-upload-default" style="display: none;" />
                                            <div class="form-group">
                                                <label style="font-size: 9px;">
                                                    (PLEASE UPLOAD PDF ONLY NO MORE THAN 2MB)</label>
                                                <input type="file" name="img[]" class="file-upload-default" />
                                                <div class="input-group col-xs-12">
                                                    <asp:TextBox ID="txtForm_E" runat="server" CssClass="form-control file-upload-info"
                                                        Enabled="false" placeholder="Upload Copy of Form_E" Style="width: 85%;"></asp:TextBox>
                                                    <span class="input-group-append">
                                                        <asp:Button ID="btnForm_E" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick="Form_EDialog(); return false;" TabIndex="22"/>
                                                        <input type="file" id="Form_E" name="Form_EInput" accept=".jpg, .jpeg, .png, .pdf" style="display: none; border-top-right-radius: 10px; border-bottom-right-radius: 10px;"
                                                            onchange="Form_EDialogName()" runat="server" />
                                                    </span>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtForm_E"
                                                        ValidationGroup="Submit" ForeColor="Red">Please Upload Copy of Form_E</asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding-top: 45px;">Deposited Treasury Challan of Fees.(<span style="color: red;">★</span>)
                                        </td>
                                        <td>
                                            <input type="file" name="img[]" class="file-upload-default" style="display: none;" />
                                            <div class="form-group">
                                                <label style="font-size: 9px;">
                                                    (PLEASE UPLOAD PDF ONLY NO MORE THAN 2MB)</label>
                                                <input type="file" name="img[]" class="file-upload-default" />
                                                <div class="input-group col-xs-12">
                                                    <asp:TextBox ID="txtTreasuryChallan" runat="server" CssClass="form-control file-upload-info"
                                                        Enabled="false" placeholder="Upload Deposited Treasury Challan of Fees" Style="width: 85%;"></asp:TextBox>
                                                    <span class="input-group-append">
                                                        <asp:Button ID="btnTreasuryChallan" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick="TreasuryChallanDialog(); return false;" TabIndex="23"/>
                                                        <input type="file" id="TreasuryChallan" name="TreasuryChallanInput" accept=".jpg, .jpeg, .png, .pdf" style="display: none; border-top-right-radius: 10px; border-bottom-right-radius: 10px;"
                                                            onchange="TreasuryChallanDialogName()" runat="server" />
                                                    </span>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtTreasuryChallan"
                                                        ValidationGroup="Submit" ForeColor="Red">Please Upload Deposited Treasury Challan of Fees</asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
                <div class="row" style="margin-left: 1%; margin-bottom: 20px;">
                    <asp:CheckBox ID="Check" runat="server" TabIndex="24" />&nbsp;
                    <text>
                        I hereby declare that the information furnished in the application is correct.
                    </text>
                </div>
                <div class="row">
                    <div class="col-md-4"></div>
                    <div class="col-md-4" style="text-align: center;">
                        <asp:Button ID="btnSubmit" Text="Submit" runat="server" ValidationGroup="Submit" OnClick="btnSubmit_Click" class="btn btn-primary mr-2" TabIndex="25" />
                        <asp:Button ID="BtnReset" Text="Reset" runat="server" class="btn btn-primary mr-2" Style="padding-left: 17px; padding-right: 17px;" TabIndex="26" />
                    </div>
                    <div class="col-md-4">
                        <asp:HiddenField ID="hdnId" runat="server" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- partial:../../partials/_footer.html -->
    <footer class="footer">
    </footer>
    <script>
        function preventEnterSubmit(event) {
            if (event.keyCode === 13) {
                event.preventDefault(); // Prevent form submission
                return false;
            }
        }
    </script>
    <!-- partial -->
    <script>
        $('.select2').select2();
    </script>
    <script type="text/javascript">
        function ValidateEmail() {
            debugger
            var email1 = document.getElementById("<%=txtEmail.ClientID %>");
            email = email1.value;
            var lblError = document.getElementById("lblError");
            lblError.innerHTML = "";
            var expr = /\w+([-+.']\w+)@\w+([-.]\w+)\.\w+([-.]\w+)*/;
            if (email == "") {
                lblError.innerHTML = "Please enter Email" + "\n";
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

            var Phone1 = document.getElementById("<%=txtContactNo.ClientID %>");
            phoneNo = Phone1.value;
            var lblErrorContect = document.getElementById("lblErrorContect");
            lblErrorContect.innerHTML = "";
            var expr = /^[6-9]\d{9}$/;
            if (phoneNo == "") {
                lblErrorContect.innerHTML = "Please enter Contact Number" + "\n";
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
        function alertWithRedirect() {
            if (confirm('Not able to find Your Information Please Login Again or Try Again later')) {
                window.location.href = "/Login.aspx";
            } else {
            }
        }
    </script>
    <script type="text/javascript">
        function PhotoDialog() {
            document.getElementById('<%= EquipCertificate.ClientID %>').click();
        }

        function PhotoDialogName() {
            var EquipCertificate = document.getElementById('<%= EquipCertificate.ClientID %>');
            var selectedFileName = document.getElementById('<%= txtEquipCertificate.ClientID %>');

            if (EquipCertificate.files.length > 0) {
                selectedFileName.value = EquipCertificate.files[0].name;
            }
        }

        function IncomeTaxDialog() {
            document.getElementById('<%= IncomeTax.ClientID %>').click();
        }

        function IncomeTaxDialogName() {
            var IncomeTax = document.getElementById('<%= IncomeTax.ClientID %>');
            var selectedFileName = document.getElementById('<%= txtIncomeTax.ClientID %>');

            if (IncomeTax.files.length > 0) {
                selectedFileName.value = IncomeTax.files[0].name;
            }
        }

        function BalanceSheetDialog() {
            document.getElementById('<%= BalanceSheet.ClientID %>').click();
        }

        function BalanceSheetDialogName() {
            var BalanceSheet = document.getElementById('<%= BalanceSheet.ClientID %>');
            var selectedFileName = document.getElementById('<%= txtBalanceSheet.ClientID %>');

            if (BalanceSheet.files.length > 0) {
                selectedFileName.value = BalanceSheet.files[0].name;
            }
        }

        function CalibCertificateDialog() {
            document.getElementById('<%= CalibCertificate.ClientID %>').click();
        }

        function CalibCertificateDialogName() {
            var CalibCertificate = document.getElementById('<%= CalibCertificate.ClientID %>');
            var selectedFileName = document.getElementById('<%= txtCalibCertificate.ClientID %>');

            if (CalibCertificate.files.length > 0) {
                selectedFileName.value = CalibCertificate.files[0].name;
            }
        }

        function WorkDetailsDialog() {
            document.getElementById('<%= WorkDetails.ClientID %>').click();
        }

        function WorkDetailsDialogName() {
            var WorkDetails = document.getElementById('<%= WorkDetails.ClientID %>');
            var selectedFileName = document.getElementById('<%= txtWorkDetails.ClientID %>');

            if (WorkDetails.files.length > 0) {
                selectedFileName.value = WorkDetails.files[0].name;
            }
        }

        function AnnexureIIIDialog() {
            document.getElementById('<%= AnnexureIII.ClientID %>').click();
        }

        function AnnexureIIIDialogName() {
            var AnnexureIII = document.getElementById('<%= AnnexureIII.ClientID %>');
            var selectedFileName = document.getElementById('<%= txtAnnexureIII.ClientID %>');

            if (AnnexureIII.files.length > 0) {
                selectedFileName.value = AnnexureIII.files[0].name;
            }
        }

        function Form_EDialog() {
            document.getElementById('<%= Form_E.ClientID %>').click();
        }

        function Form_EDialogName() {
            var Form_E = document.getElementById('<%= Form_E.ClientID %>');
            var selectedFileName = document.getElementById('<%= txtForm_E.ClientID %>');

            if (Form_E.files.length > 0) {
                selectedFileName.value = Form_E.files[0].name;
            }
        }

        function TreasuryChallanDialog() {
            document.getElementById('<%= TreasuryChallan.ClientID %>').click();
        }

        function TreasuryChallanDialogName() {
            var TreasuryChallan = document.getElementById('<%= TreasuryChallan.ClientID %>');
            var selectedFileName = document.getElementById('<%= txtTreasuryChallan.ClientID %>');

            if (TreasuryChallan.files.length > 0) {
                selectedFileName.value = TreasuryChallan.files[0].name;
            }
        }

      function FeeRecieptDialog() {
    document.getElementById('<%= FeeReciept.ClientID %>').click();
}

function FeeRecieptDialogName() {
    var UploadFeeReciept = document.getElementById('<%= FeeReciept.ClientID %>');
    var selectedFileName = document.getElementById('<%= txtFeeReciept.ClientID %>');

    if (UploadFeeReciept.files.length > 0) {
        selectedFileName.value = UploadFeeReciept.files[0].name;
    }
}
    </script>
    <script>
        function allowOnlyNumbersAndHyphen(event) {
            // Get the key code of the pressed key
            var keyCode = event.which || event.keyCode;

            // Allow only numbers (48-57), backspace (8), and hyphen (45)
            if ((keyCode >= 48 && keyCode <= 57) || keyCode === 8 || keyCode === 45) {
                return true;
            } else {
                event.preventDefault();
                return false;
            }
        }
    </script>
</asp:Content>