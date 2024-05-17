<%@ Page Title="" Language="C#" MasterPageFile="~/Supervisor/Supervisor.Master" AutoEventWireup="true" CodeBehind="SupervisorDashboard.aspx.cs" Inherits="CEIHaryana.Supervisor.SupervisorDashboard" %>

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
            margin-top: 30px !important;
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
                    <div class="col-sm-4" style="text-align: center; box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding-top: 8px; padding-bottom: 8px; border-radius: 10px;">
                        <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important;">TEST REPORT</h6>
                    </div>
                    <br />

                    <div class="col-md-4"></div>

                </div>
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
               <%-- <h7 class="card-title fw-semibold mb-4">Personal Details</h7>--%>
             <%--               <div class="row" style="margin-bottom:20px;">
                <div class="col-md-4">
                    <label>
                        Assigned Work details<samp style="color: red">* </samp>
                    </label>
                    <asp:DropDownList Style="width: 100% !important;" class="form-control select-form select2" ID="ddlAssignWork" TabIndex="8" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlAssignedWork_SelectedIndexChanged1">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Text="Please Select State" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlAssignWork" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                </div>                       
            </div>--%>
                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                    
                    <div class="row">
                        <div class="col-md-4">
                            <label>Electrical Installation For<samp style="color: red"> * </samp>
                            </label>
                            <asp:DropDownList ID="ddlworktype" runat="server" AutoPostBack="true" class="form-control  select-form select2" TabIndex="1" Style="width: 100% !important;">
                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                <asp:ListItem Value="1" Text="Individual Person"></asp:ListItem>
                                <asp:ListItem Value="2" Text="Firm/Organization/Company/Department"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Text="Please Select Work Type" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlworktype" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />

                        </div>
                        <div class="col-md-4" id="individual" runat="server">
                            <label for="Name">Name of Owner/ Consumer<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtName" onkeydown="return preventEnterSubmit(event)" placeholder="As Per Demand Notice of Utility or Electricity Bill" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtName" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Name</asp:RequiredFieldValidator>

                        </div>
                        <div class="col-md-4" id="agency" runat="server" visible="false">
                            <label for="agency">Name of Firm/ Org./ Company/ Department</label>
                            <asp:TextBox class="form-control" ID="txtagency" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ControlToValidate="txtagency"
                                ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">*</asp:RequiredFieldValidator>

                        </div>
                        <div class="col-md-4">
                            <label for="Phone">Contact No.(Contractor)
                                <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtPhone" onkeydown="return preventEnterSubmit(event)" onKeyPress="return isNumberKey(event);" TabIndex="4"
                                onkeyup="return isvalidphoneno();" MaxLength="10" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <span id="lblErrorContect" style="color: red"></span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtPhone" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Contact No.</asp:RequiredFieldValidator>

                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-8">
                            <label for="Address">Address of Site(As Per Demand Notice of Utility or Electricity Bill)
                                <samp style="color: red">* </samp>
                            </label>
                            <%-- <asp:TextBox class="form-control" ID="txtAddress" onkeydown="return preventEnterSubmit(event)" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>--%>
                            <asp:TextBox class="form-control" ID="txtAddress" onkeydown="return preventEnterSubmit(event)" autocomplete="off" runat="server" TabIndex="5" Style="margin-left: 18px"></asp:TextBox>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtAddress" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Address</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-4" runat="server">
                            <label for="Pin">PinCode</label>
                            <asp:TextBox class="form-control" ID="txtPin" MaxLength="6" onkeydown="return preventEnterSubmit(event)" onkeyup="ValidatePincode();" onKeyPress="return isNumberKey(event);" autocomplete="off" TabIndex="7" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <span id="lblPinError" style="color: red"></span>

                        </div>


                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <label>Type of Premises
                                <samp style="color: red">* </samp>
                            </label>
                             <asp:TextBox class="form-control" ID="TxtPremises" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="7" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator19" Text="Please Select Premises Type" ErrorMessage="RequiredFieldValidator" ControlToValidate="TxtPremises" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />

                        </div>
                        <div class="col-md-4" id="OtherPremises" runat="server" visible="false">
                            <label for="OtherPremises">Other Premises<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtOtherPremises" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="7" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtOtherPremises" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Other Premises</asp:RequiredFieldValidator>

                        </div>

                        <div class="col-md-4">
                            <label>Highest Voltage Level of Work
                                <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtVoltagelevel" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="7" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator21" Text="Please Select Voltage Level" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtVoltagelevel" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />

                        </div>

                        <div class="col-md-4">

                            <label>Work Details
                                <samp style="color: red">* </samp>
                            </label>
                             <asp:TextBox class="form-control" ID="txtWorkDetail" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="7" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="txtWorkDetail" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Work Details</asp:RequiredFieldValidator>

                            <asp:TextBox class="form-control" ID="WorkDetail" autocomplete="off" onkeydown="return preventEnterSubmit(event)" Visible="false" runat="server" Style="margin-left: 18px"></asp:TextBox>
                        </div>



                    </div>
                    <div class="row">
                        
                        <div class="col-md-4" runat="server">
                            <label for="SiteContact">Contact Details of Site Owner</label>
                            <asp:TextBox class="form-control" ID="txtSiteContact" MaxLength="10" onkeydown="return preventEnterSubmit(event)" onkeyup="return isvalidphoneno2();" onKeyPress="return isNumberKey(event);" TabIndex="10" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <span id="lblErrorContect2" style="color: red"></span>

                        </div>
                        <div class="col-md-4" runat="server">
                            <label for="Email">Email</label>
                            <asp:TextBox class="form-control" ID="txtEmail" onkeydown="return preventEnterSubmit(event)" onkeyup="return ValidateEmail();" TabIndex="10" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <span id="lblError" style="color: red"></span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtEmail" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Other Work Detail</asp:RequiredFieldValidator>

                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <label for="StartDate">Work Start Date<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtStartDate" onkeydown="return preventEnterSubmit(event)" autocomplete="off" Type="Date" TabIndex="11" min='0000-01-01' max='9999-01-01' runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtStartDate" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Work Start Date</asp:RequiredFieldValidator>

                        </div>
                        <div class="col-md-4">
                            <label for="CompletitionDate">Tentative Work Completition Date<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtCompletitionDate" onkeydown="return preventEnterSubmit(event)" autocomplete="off" Type="Date" TabIndex="12" min='0000-01-01' max='9999-01-01' runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtCompletitionDate" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Work Completition Date</asp:RequiredFieldValidator>

                        </div>
                        <div class="col-md-4">
                            <label>If any work issued by any Agency/ Dept. / Owner<samp style="color: red"> * </samp>
                            </label>
                            <asp:DropDownList class="form-control  select-form select2" ID="ddlAnyWork" Style="width: 100% !important;" runat="server" TabIndex="13" AutoPostBack="true">
                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator24" Text="Please Select any work issued" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlAnyWork" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />

                        </div>


                    </div>

                    <div class="row">
                        <div class="col-md-4" id="hiddenfield" runat="server">
                            <label class="form-label" for="customFile">
                                Attached Copy of Work Order<samp style="color: red"> * </samp>
                                <%--                            <asp:TextBox class="form-control" ID="txtcustomFile" Type="file" runat="server" Style="margin-left: 18px"></asp:TextBox>--%>
                                <asp:FileUpload ID="customFile" runat="server" CssClass="form-control" onkeydown="return preventEnterSubmit(event)" TabIndex="14" Style="margin-left: 18px; padding: 0px; font-size: 15px;" />
                                <asp:TextBox class="form-control" ID="customFileLocation" autocomplete="off" runat="server" Style="margin-left: 18px" Visible="false"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="customFile" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Select File</asp:RequiredFieldValidator>
                        </div>

                        <div class="col-md-4" id="hiddenfield1" runat="server">
                            <label for="CompletionDateasperWorkOrder">Completion Date as per Work Order<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtCompletionDateAPWO" onkeydown="return preventEnterSubmit(event)" TabIndex="15" autocomplete="off" Type="Date" min='0000-01-01' max='9999-01-01' runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="txtCompletionDateAPWO" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Completion Date as per Work Order</asp:RequiredFieldValidator>

                        </div>
                    </div>
                    <div class="row">
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4"></div>
                    <div class="col-md-4" style="text-align: center;">

                        <asp:Button ID="btnSubmit" Text="Generate Test Report" runat="server" ValidationGroup="Submit" class="btn btn-primary mr-2" 
                            Style="background: linear-gradient(135deg, hsla(318, 44%, 51%, 1) 0%, hsla(347, 94%, 48%, 1) 100%); border-color: #d42766;"  OnClick="btnSubmit_Click" />
                        
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

    <%--<script type="text/javascript">
        function validateForm() {
            debugger;
            var emptyFields = [];


            var RegisteredOffice = document.getElementById('<%= txtRegisteredOffice.ClientID %>').value;
            var State = document.getElementById('<%= ddlState.ClientID %>').value;

            var District = document.getElementById('<%= ddlDistrict.ClientID %>').value;
            var BranchOffice = document.getElementById('<%= txtBranchOffice.ClientID %>').value;
            var District1 = document.getElementById('<%= ddlDistrict1.ClientID %>').value;
            var CertifacateOld = document.getElementById('<%= txtLicenceOld.ClientID %>').value;
            var CertificateNew = document.getElementById('<%= txtLicenceNew.ClientID %>').value;
            var DateInitialIssue = document.getElementById('<%= txtDateofIntialissue.ClientID %>').value;
            var DateExpiry = document.getElementById('<%= txtDateofExpiry.ClientID %>').value;
            var DateRenewal = document.getElementById('<%= txtDateofRenewal.ClientID %>').value;
            var VoltageLevelWithEffect = document.getElementById('<%= txtVoltageLevelWithEffect.ClientID %>').value;
            var VoltageLevel = document.getElementById('<%= ddlVoltageLevel.ClientID %>');


            var regex = /^(06)[A-Z]{5}[0-9]{4}[A-Z]{1}[1-9A-Z]{1}Z[0-9A-Z]{1}$/;

            if (Gst.trim() === '') {
                emptyFields.push('Gst Number')
            }
            else if (!regex.test(txtGST.value)) {
                emptyFields.push("GST is incorrect. Only Haryana's GST is valid");

            }


            if (name.trim() === '') {
                emptyFields.push('Name');
            }
            if (FirmName.trim() === '') {
                emptyFields.push('Firm Name');
            }


            if (RegisteredOffice.trim() === '') {
                emptyFields.push('Registered Office Address.');

            }
            if (BranchOffice.trim() === '') {
                emptyFields.push('Branch Office Address.');

            }

            if (VoltageLevelWithEffect.trim() === '') {
                emptyFields.push('VoltageLevelWithEffect.');

            }

            if (State && State.selectedIndex === 0) {
                emptyFields.push('State.');

            }
            if (District && District.selectedIndex === 0) {
                emptyFields.push('District.');

            }
            if (District1 && District1.selectedIndex === 0) {
                emptyFields.push('District.');

            }

            if (VoltageLevel && VoltageLevel.selectedIndex === 0) {
                emptyFields.push('VoltageLevel.');

            }

            if (CertifacateOld.trim() === '' && CertificateNew.trim() === '') {
                emptyFields.push('Certificate No.(Old or New)');

            }
            if (DateInitialIssue.trim() === '') {
                emptyFields.push('Date Initial Issue');

            }
            if (DateExpiry.trim() === '') {
                emptyFields.push('Date of Expiry');

            }
            if (DateRenewal.trim() === '') {
                emptyFields.push('Date Renewal');

            }
            if (DateRenewal < DateInitialIssue) {
                emptyFields.push('Date of Renewal is greater then Date of Initial issue');

            }
            if (DateExpiry < DateInitialIssue) {
                emptyFields.push('Date of Expiry is greater then Date of Initial issue');

            }
            if (DateExpiry < DateRenewal) {
                emptyFields.push('Date of Expiry is greater then Date of Renewal');

            }

            if (emptyFields.length > 0) {
                var message = 'Please enter values for the following fields:\n\n';
                message += emptyFields.join('\n');
                alert(message);
                return false;
            }


            return true;




        }

    </script>--%>
    <script type="text/javascript">
        function ValidateEmail() {
            debugger

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
        function isvalidphoneno() {


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

</asp:Content>
