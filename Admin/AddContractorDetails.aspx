<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin_Master.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="AddContractorDetails.aspx.cs" Inherits="CEI_PRoject.Admin.AddContractorDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="shortcut icon" type="image/png" href="/css2/style.min.css" />
    <link rel="stylesheet" href="/css2/style.css" />
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <!------ Include the above in your HEAD tag ---------->
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/css/select2.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/js/select2.min.js"></script>

    <link href="ScriptCalendar/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="ScriptCalender/jquery-1.11.0.min.js"></script>
    <script type="text/javascript" src="ScriptCalender/jquery-ui.min.js"></script>


    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=txtDateofIntialissue.ClientID%>").datepicker({
                dateFormat: "dd/mm/yy",
                changeMonth: true,
                changeYear: true,
                minDate: -7,
                maxDate: +7
            });
            $("#<%=txtDateofIntialissue.ClientID%>").keydown(function () {
                //code to not allow any changes to be made to input field
                return false;
            });

            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
            function EndRequestHandler(sender, args) {
                $("#<%=txtDateofIntialissue.ClientID%>").datepicker({
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                    minDate: -7,
                    maxDate: +7
                });
                $("#<%=txtDateofIntialissue.ClientID%>").keydown(function () {
                    //code to not allow any changes to be made to input field
                    return false;
                });
            }
        });
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
     <script type="text/javascript">
         function alertWithRedirectdata() {
             if (confirm('Data Added Successfully')) {
                 window.location.href = "/Admin/AddContractorDetails.aspx";
             } else {
             }
         }
     </script>
    <%--     <script>
        
         function printDiv(printableDiv) {
             var printContents = document.getElementById(printableDiv).innerHTML;
             var originalContents = document.body.innerHTML;

             document.body.innerHTML = printContents;

             window.print();

             document.body.innerHTML = originalContents;
         }
     </script>--%>

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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
    <div class="content-wrapper">
        <%--        <div class="card-header" style="background: linear-gradient(341deg, rgba(0,255,103,1) 0%, rgba(70,85,252,1) 100%); color: white; margin-bottom: 15px; border-radius: 5px;">
            <h4 style="font-weight: 600; text-align: center;">CONTRACTOR DETAILS</h4>
        </div>--%>

        <div class="card" style="box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px; border-radius: 5px !important">
            <div class="card-body">
            
                <div class="row">
                    <div class="col-md-4"></div>
                    <div class="col-sm-4" style="text-align: center; box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding-top: 8px; padding-bottom: 8px; border-radius: 10px; top: 0px; left: 0px;">
                        <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important;">CONTRACTOR DETAILS</h6>
                    </div>
                    <br />
                   
                    <div class="col-md-4"></div>

                </div>
                    <div class="row">
                    <div class="col-md-4"></div>
                     <div class="col-sm-4" style="text-align: center;">
                        
                  <label id="DataUpdated" runat="server" visible="false" style="color: red; font-size:1.125rem">
                                                Data Updated Successfully !!!.
                                            </label>
                         <label id="DataSaved" runat="server" visible="false" style="color: red; font-size:1.125rem">
                                                Data Saved Successfully !!!.
                                            </label>
                         </div>
                    </div>
                <br />
                <h7 class="card-title fw-semibold mb-4">Personal Details</h7>
                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                    <div class="row">
                        <div class="col-4">
                            <label for="Name">
                                Name of Owner (Authorised Person)<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtName" runat="server" autocomplete="off" onKeyPress="return alphabetKey(event);" TabIndex="1"
                                MaxLength="200" Style="margin-left: 18px;">
                            </asp:TextBox>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtName" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Name</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-4">
                            <label for="FatherName">Father's Name</label>

                            <asp:TextBox class="form-control" ID="txtFatherName" autocomplete="off" runat="server" onKeyPress="return alphabetKey(event);" TabIndex="2"
                                MaxLength="30" Style="margin-left: 18px">
                            </asp:TextBox>
                        </div>
                        <div class="col-4">
                            <label for="FirmName">
                                Firm's Name<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtFirmName" runat="server" onkeydown="return preventEnterSubmit(event)" autocomplete="off" Style="margin-left: 18px" TabIndex="3" MaxLength="300"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFirmName" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Firm Name</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-4">
                            <label for="GST">
                                GST Number<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtGST" runat="server" TabIndex="4" autocomplete="off" onkeydown="return preventEnterSubmit(event)"
                                MaxLength="30" Style="margin-left: 18px; text-transform: uppercase">
                            </asp:TextBox>
                            <asp:RegularExpressionValidator ID="regexValidatorGST" runat="server" ControlToValidate="txtGST"
                                ValidationExpression="^(06)[A-Z]{5}[0-9]{4}[A-Z]{1}[1-9A-Z]{1}Z[0-9A-Z]{1}$" ValidationGroup="Submit"
                                ErrorMessage="GST is incorrect. Only Haryana's GST is valid" ForeColor="Red" Display="Dynamic">
                            </asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtGST" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter GST</asp:RequiredFieldValidator>

                        </div>
                        <div class="col-4">
                            <label for="ContactNo">Contact No.<samp style="color: red"> * </samp></label>
                            <asp:TextBox class="form-control" ID="txtContactNo" runat="server" autocomplete="off" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);"
                                TabIndex="5"
                                onkeyup="return isvalidphoneno();" MaxLength="10" Style="margin-left: 18px">
                            </asp:TextBox>
                            <span id="lblErrorContect" style="color: red"></span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtContactNo" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Contact No</asp:RequiredFieldValidator>

                        </div>
                        <div class="col-4">
                            <label for="Email">Email</label>

                            <asp:TextBox class="form-control" ID="txtEmail" onkeydown="return preventEnterSubmit(event)" runat="server" autocomplete="off" Style="margin-left: 18px" TabIndex="6" onkeyup="return ValidateEmail();"></asp:TextBox>

                            <span id="lblError" style="color: red"></span>

                        </div>
                    </div>
                </div>
                <h7 class="card-title fw-semibold mb-4">Communication Address</h7>
                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                    <h7 class="card-title fw-semibold mb-4">Registered Office Address</h7>
                    <br />
                    <asp:UpdatePanel ID="UpdatePanelCalculatedYears" runat="server">
                        <ContentTemplate>
                            <div class="row" style="margin-top: 15px;">
                                <div class="col-8">
                                    <label for="RegisteredOffice">
                                        Address<samp style="color: red"> * </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtRegisteredOffice" onkeydown="return preventEnterSubmit(event)" autocomplete="off" runat="server" TabIndex="7" ></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtRegisteredOffice" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Registered Office Address</asp:RequiredFieldValidator>

                                </div>
                                <div class="col-4">
                                    <label>
                                        State/UT 
                                        <samp style="color: red">* </samp>
                                    </label>
                                    <asp:DropDownList Style="width: 100% !important;" class="form-control select-form select2" ID="ddlState" TabIndex="8" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="Req" Text="Please Select State" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlState" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                </div>

                            </div>
                            <div class="row">
                                <div class="col-4">
                                    <label>
                                        District
                                        <samp style="color: red">* </samp>
                                    </label>
                                    <asp:DropDownList Style="width: 100% !important;" class="form-control  select-form select2" ID="ddlDistrict" runat="server" TabIndex="9">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" Text="Please Select District" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlDistrict" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                            
                                </div>
                                <div class="col-4">
                                    <label for="PinCode">PinCode </label>
                                    <asp:TextBox class="form-control" ID="txtPinCode" onkeydown="return preventEnterSubmit(event)" runat="server" autocomplete="off" MaxLength="6" onkeyup="ValidatePincode();" onkeypress="return isNumberKey(event);" TabIndex="10"></asp:TextBox>
                                    <span id="lblPinError" style="color: red"></span>
                                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPinCode"  ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red" >(*)</asp:RequiredFieldValidator>
                                    --%>
                                </div>

                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <h7 class="card-title fw-semibold mb-4">Branch (Haryana) Office Address</h7>
                    <samp>
                        &nbsp;&nbsp;<asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="true" Text="&nbsp;&nbsp;(Same as Registered Office)" OnCheckedChanged="CheckBox1_CheckedChanged" Font-Size="Medium" Font-Bold="True" />
                        &nbsp;</samp>

                    <br />
                    <div class="row" style="margin-top:15px;">
                        <div class="col-8">
                            <label for="BranchOffice">
                                Address<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtBranchOffice" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="11" runat="server" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtBranchOffice" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Your Branch Office Address</asp:RequiredFieldValidator>

                        </div>
                        <div class="col-4">
                            <label>
                                State/UT<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtState1" onkeydown="return preventEnterSubmit(event)" autocomplete="off" runat="server" Text="Haryana" ReadOnly="true"></asp:TextBox>

                        </div>

                    </div>
                    <div class="row">
                        <div class="col-4">

                            <label>
                                District<samp style="color: red"> * </samp>
                            </label>
                            <asp:DropDownList Style="width: 100% !important;" class="form-control  select-form select2" TabIndex="12" ID="ddlDistrict1" runat="server">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Text="Please Select Branch District" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlDistrict1" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />

                        </div>
                        <div class="col-4">
                            <label for="PinCode">PinCode</label>
                            <asp:TextBox class="form-control" ID="txtPinCode1" onkeydown="return preventEnterSubmit(event)" autocomplete="off" runat="server" MaxLength="6" onkeyup="ValidatePincode1();" onkeypress="return isNumberKey(event);" TabIndex="13"></asp:TextBox>
                            <span id="lblPin2Error" style="color: red"></span>
                            <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPinCode1"  ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red" >(*)</asp:RequiredFieldValidator>--%>
                            <%--<asp:TextBox class="form-control" ID="txtPinCode1" runat="server" MaxLength="6" onkeypress="return isNumberKey(event);" Style="margin-left: 18px" TabIndex="6"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPinCode"  ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red" >(*)</asp:RequiredFieldValidator>--%>
                        </div>

                    </div>

                </div>
                <h7 class="card-title fw-semibold mb-4">LICENCE DETAILS</h7>
                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                    <div class="row">
                        <div class="col-4">
                            <label for="LicenceOld">
                                Licence no (Old)<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" MaxLength="20" onkeydown="return preventEnterSubmit(event)" ID="txtLicenceOld" autocomplete="off" TabIndex="14" runat="server" Style="margin-left: 18px"></asp:TextBox>
                             
                        </div>
                        <div class="col-4">
                            <label for="LicenceNew">
                                Licence No. (New)<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" MaxLength="20" onkeydown="return preventEnterSubmit(event)" ID="txtLicenceNew" autocomplete="off" runat="server" Style="margin-left: 18px" TabIndex="15"></asp:TextBox>
                         <asp:CustomValidator ID="cvBothEmpty" runat="server" ClientValidationFunction="validateBothEmpty" ErrorMessage=" Add Atleast one License" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red"></asp:CustomValidator>
                            
                        </div>

                        <div class="col-4">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <label>
                                        Current Authorised Voltage Level<samp style="color: red"> * </samp>
                                    </label>
                                    <asp:DropDownList Style="width: 100% !important;" class="form-control  select-form select2" ID="ddlVoltageLevel" runat="server" TabIndex="16">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" Text="Please Select Voltage level" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlVoltageLevel" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />

                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>

                    </div>
                    <div class="row">
                        <div class="col-4">
                            <label for="VoltageLevelWithEffect">
                                Current Authorised Voltage Level(with effect from)<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox Style="width: 100% !important; margin-left: 18px;" onkeydown="return preventEnterSubmit(event)" class="form-control" autocomplete="off" ID="txtVoltageLevelWithEffect" min='0000-01-01' max='9999-01-01' Type="Date" TabIndex="17" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtVoltageLevelWithEffect" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Select Current Authorised Voltage level</asp:RequiredFieldValidator>

                        </div>

                        <div class="col-4">
                            <label for="DateofIntialissue">
                                Date of Initial Issue<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" autocomplete="off" onkeydown="return preventEnterSubmit(event)" ID="txtDateofIntialissue" min='0000-01-01' max='9999-01-01' Type="Date" TabIndex="18" runat="server" Style="margin-left: 18px">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtDateofIntialissue" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Date of Initial Issue </asp:RequiredFieldValidator>

                        </div>


                        <div class="col-4">
                            <label for="DateofRenewal">
                                Date of Renewal<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" autocomplete="off" onkeydown="return preventEnterSubmit(event)" ID="txtDateofRenewal" min='0000-01-01' max='9999-01-01' Type="Date" TabIndex="19" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtDateofRenewal" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Date of Renewal</asp:RequiredFieldValidator>

                        </div>

                    </div>
                    <div class="row" >
                        <div class="col-4">
                            <label for="DateofExpiry">
                                Date of Expiry<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" autocomplete="off" onkeydown="return preventEnterSubmit(event)" ID="txtDateofExpiry" min='0000-01-01' max='9999-01-01' Type="Date" runat="server" TabIndex="20" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtDateofExpiry" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Date of Expiry</asp:RequiredFieldValidator>

                        </div>
                    </div>

                </div>

                <div class="row">
                    <div class="col-4"></div>
                    <div class="col-4" style="text-align: center;">
                        
                        <asp:Button ID="btnSubmit" Text="Submit" runat="server" ValidationGroup="Submit" class="btn btn-primary mr-2"
                           
                            OnClick="btnSubmit_Click"  />
                        <asp:Button ID="BtnReset" Text="Reset" runat="server" class="btn btn-primary mr-2"
                            Style="padding-left: 17px; padding-right: 17px;"
                            OnClick="BtnReset_Click" />

                        <%--                              <asp:Button ID="btnPrint" Text="Print" runat="server" class="btn btn-primary mr-2" 
                                Style="background: linear-gradient(135deg, hsla(318, 44%, 51%, 1) 0%, hsla(347, 94%, 48%, 1) 100%); border-color: #d42766;" OnClientClick="printDiv('printableDiv');"/>--%>
                    </div>

                    <div class="col-4">
                        <asp:HiddenField ID="hdnId" runat="server" />

                    </div>
                </div>
            </div>

        </div>
    </div>

    <!-- partial:../../partials/_footer.html -->
    <footer class="footer">
    </footer>
    <script type="text/javascript">
        function validateBothEmpty(source, args) {
            var textBox1Value = document.getElementById('<%= txtLicenceOld.ClientID %>').value;
     var textBox2Value = document.getElementById('<%= txtLicenceNew.ClientID %>').value;

            // Check if both textboxes are empty
            if (textBox1Value.trim() === '' && textBox2Value.trim() === '') {
                args.IsValid = false;
            } else {
                args.IsValid = true;
            }
        }
 </script>
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
        function validateForm() {

            var emptyFields = [];
            
            var CertifacateOld = document.getElementById('<%= txtLicenceOld.ClientID %>').value;
            var CertificateNew = document.getElementById('<%= txtLicenceNew.ClientID %>').value;
           

            if (CertifacateOld.trim() === '' && CertificateNew.trim() === '') {
                emptyFields.push('Certificate No.(Old or New)');

            }
            if (emptyFields.length > 0) {
                var message = 'Please enter values for the following fields:\n\n';
                message += emptyFields.join('\n');
                alert(message);
                return false;
            }


            return true;




        }

    </script>
    <script type="text/javascript">
        function ValidateEmail() {
            debugger
            var email1 = document.getElementById("<%=txtEmail.ClientID %>");
            email = email1.value;
            var lblError = document.getElementById("lblError");
            lblError.innerHTML = "";
            var expr = /\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/;
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
        function ValidatePincode() {
            var Pin1 = document.getElementById("<%=txtPinCode.ClientID %>");
            Pincode = Pin1.value;
            var lblPinError = document.getElementById("lblPinError");
            lblPinError.innerHTML = "";
            var expr = /\d{6}/;;
            if (Pincode == "") {
                lblPinError.innerHTML = "" + "\n";
                return false;
            }
            else if (expr.test(Pincode)) {
                lblPinError.innerHTML = "";
                return true;
            }
            else {
                lblPinError.innerHTML = "Invalid Pin code must be 6 numeric digits" + "\n";
                return false;
            }
        }
    </script>
    <script type="text/javascript">
        function ValidatePincode1() {
            var Pin2 = document.getElementById("<%=txtPinCode1.ClientID %>");
            Pincode1 = Pin2.value;
            var lblPin2Error = document.getElementById("lblPin2Error");
            lblPin2Error.innerHTML = "";
            var expr = /\d{6}/;;
            if (Pincode1 == "") {
                lblPin2Error.innerHTML = "" + "\n";
                return false;
            }
            else if (expr.test(Pincode1)) {
                lblPin2Error.innerHTML = "";
                return true;
            }
            else {
                lblPin2Error.innerHTML = "Invalid Pin code must be 6 numeric digits" + "\n";
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
          function alertWithRedirect() {
              if (confirm('Not able to find Your Information Please Login Again or Try Again later')) {
                  window.location.href = "/Login.aspx";
              } else {
              }
          }
      </script>
</asp:Content>
