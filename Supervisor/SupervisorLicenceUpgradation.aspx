<%@ Page Title="" Language="C#" MasterPageFile="~/Supervisor/Supervisor.Master" AutoEventWireup="true" CodeBehind="SupervisorLicenceUpgradation.aspx.cs" Inherits="CEIHaryana.Supervisor.SupervisorLicenceUpgradation" %>

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


    <!---------------------   Dropdown With Search Option   ---------------------->
    <%-- <link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/css/select2.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/js/select2.min.js"></script>--%>

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
        .table {
            width: 100%;
            max-width: 100%;
            margin-bottom: 0rem !important;
            background-color: transparent;
        }

        select#ContentPlaceHolder1_ddlTraningUnder {
            display: block;
            width: 100%;
            font-size: 13PX;
            line-height: 1.5;
            color: #495057;
            background-color: #fff;
            background-clip: padding-box;
            border: 1px solid #ced4da;
            border-radius: 0.25rem;
            transition: border-color .15s ease-in-out,box-shadow .15s ease-in-out;
            height: 30px;
        }

        select#ContentPlaceHolder1_ddlExperiene {
            display: block;
            width: 100%;
            font-size: 13PX;
            line-height: 1.5;
            color: #495057;
            background-color: #fff;
            background-clip: padding-box;
            border: 1px solid #ced4da;
            border-radius: 0.25rem;
            transition: border-color .15s ease-in-out,box-shadow .15s ease-in-out;
            height: 30px;
        }

        .pt-3, .py-3 {
            padding-top: 0rem !important;
        }

        .table td, .jsgrid .jsgrid-table td {
            font-size: 1px;
            padding: 10px 15px 10px 15px;
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
            padding: 13px;
            font-size: 13px;
        }

        input#ContentPlaceHolder1_Button1 {
            border-top-right-radius: 10px;
            border-bottom-right-radius: 10px;
            height: 30px;
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
                <asp:UpdatePanel runat="server" ID="updatePanel">
                    <ContentTemplate>


                        <div class="row">
                            <div class="col-md-4"></div>
                            <div class="col-sm-4" style="text-align: center; box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding-top: 8px; padding-bottom: 8px; border-radius: 10px; top: 0px; left: 0px;">
                                <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important;">CERTIFICATE UPGRADATION APPLICATION</h6>
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
                        <h7 class="card-title fw-semibold mb-4">Personal Details</h7>
                        <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                            <div class="row">
                                <div class="col-4">
                                    <label for="Name">
                                        Applicant Name<samp style="color: red"> * </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtName" runat="server" ReadOnly="true" autocomplete="off" onKeyPress="return alphabetKey(event);" TabIndex="1"
                                        MaxLength="20" Style="margin-left: 18px;">
                                    </asp:TextBox>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtName" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Name</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-4">
                                    <label for="Name">
                                        Certificate No.<samp style="color: red"> * </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtCertificate" ReadOnly="true" runat="server" autocomplete="off" TabIndex="1"
                                        MaxLength="20" Style="margin-left: 18px;">
                                    </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCertificate" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Certificate No</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-4">
                                    <label for="DateofIssue">
                                        Date of Issue<samp style="color: red"> * </samp>
                                    </label>
                                    <asp:TextBox class="form-control" autocomplete="off" onkeydown="return preventEnterSubmit(event)" ReadOnly="true" ID="txtIssueDate" min='0000-01-01' max='9999-01-01' Type="Date" TabIndex="19" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtIssueDate" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Issue Date</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-4">
                                    <label for="DateofExpiry">
                                        Date of Expiry
                                <samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" autocomplete="off" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" ID="txtExpiryDate" min='0000-01-01' max='9999-01-01' Type="Date" TabIndex="19" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="txtExpiryDate" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Expiry Date</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-4">
                                    <label for="DateofRenewal">
                                        Current Authorized Voltage Level<samp style="color: red"> * </samp>
                                    </label>
                                    <asp:TextBox class="form-control" autocomplete="off" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" ID="txtVoltageLevel" TabIndex="19" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtVoltageLevel" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Current Voltage Level</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-4">
                                    <label for="DateofBirth">
                                        Date of Birth<samp style="color: red"> * </samp>
                                    </label>
                                    <asp:TextBox class="form-control" autocomplete="off" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" ID="txtDOB" min='0000-01-01' max='9999-01-01' Type="Date" TabIndex="19" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="txtDOB" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Date of Birth</asp:RequiredFieldValidator>
                                </div>
                                <div class="col-4" runat="server" id="DivAge" visible="false">
                                    <label for="Age">
                                        Age<samp style="color: red"> * </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtAge" runat="server" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" autocomplete="off" Style="margin-left: 18px" TabIndex="3" MaxLength="300"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAge" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Age</asp:RequiredFieldValidator>
                                </div>

                                <div class="col-4">
                                    <label for="Email">Email</label>
                                    <asp:TextBox class="form-control" ID="txtEmail" onkeydown="return preventEnterSubmit(event)" runat="server" autocomplete="off" Style="margin-left: 18px" TabIndex="6" onkeyup="return ValidateEmail();"></asp:TextBox>
                                    <span id="lblError" style="color: red"></span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtContactNo" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Email</asp:RequiredFieldValidator>

                                </div>
                                <div class="col-4">
                                    <label for="ContactNo">
                                        Contact No.<samp style="color: red"> * </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtContactNo" runat="server" autocomplete="off" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);"
                                        TabIndex="5"
                                        onkeyup="return isvalidphoneno();" MaxLength="10" Style="margin-left: 18px">
                                    </asp:TextBox>
                                    <span id="lblErrorContect" style="color: red"></span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtContactNo" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Contact No</asp:RequiredFieldValidator>

                                </div>
                                <div class="row" style="margin-left: 2%; margin-bottom: 1%;">
                                    Whether there is any change of Address? &nbsp;&nbsp;
                            <asp:RadioButtonList ID="RadioButtonList1" AutoPostBack="true" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" runat="server" RepeatDirection="Horizontal" TabIndex="25">
                                <asp:ListItem Text="Yes" Value="0"></asp:ListItem>
                                <asp:ListItem Text="No" Value="1" Selected="True"></asp:ListItem>
                            </asp:RadioButtonList>
                                    <%-- <asp:CustomValidator ID="customvalidation1" OnServerValidate="customvalidation1_ServerValidate"  runat="server" ErrorMessage="Select An Option" Display="Dynamic" ControlToValidate="RadioButtonList1" 
                                ValidationGroup="Submit"></asp:CustomValidator>--%>
                                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="RadioButtonList1" ErrorMessage="Please Enter  Address" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                </div>
                                <div class="col-8">
                                    <label for="Address">
                                        Address<samp style="color: red"> * </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="TextAddress" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" runat="server" TabIndex="7"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="TextAddress" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter  Address</asp:RequiredFieldValidator>

                                </div>
                                <div class="col-4">
                                    <label>
                                        State/UT 
            <samp style="color: red">* </samp>
                                    </label>
                                    <asp:DropDownList Style="width: 100% !important;" class="form-control select-form select2" OnSelectedIndexChanged="DdlState_SelectedIndexChanged" ID="DdlState" TabIndex="8" runat="server" AutoPostBack="true">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" Text="Please Select State" ErrorMessage="RequiredFieldValidator" ControlToValidate="DdlState" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                </div>
                                <div class="col-4">
                                    <label>
                                        District
            <samp style="color: red">* </samp>
                                    </label>
                                    <asp:DropDownList Style="width: 100% !important;" class="form-control  select-form select2" ID="DdlDistrict" runat="server" TabIndex="9">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator17" Text="Please Select District" ErrorMessage="RequiredFieldValidator" ControlToValidate="DdlDistrict" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />

                                </div>
                                <div class="col-4">
                                    <label for="PinCode">PinCode </label>
                                    <asp:TextBox class="form-control" ID="txtpincode" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" runat="server" autocomplete="off" MaxLength="6" onkeyup="ValidatePincode();" onkeypress="return isNumberKey(event);" TabIndex="10"></asp:TextBox>
                                    <span id="lblPinError" style="color: red"></span>
                                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPinCode"  ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red" >(*)</asp:RequiredFieldValidator>
                                    --%>
                                </div>
                                <%--<div class="row" style="margin-left: 2%; margin-top: 2%;">
    Whether there Address has to be changed in the Licence also as same as the new Address? &nbsp;&nbsp;
    <asp:RadioButtonList ID="RadioButtonList3" AutoPostBack="true" runat="server" RepeatDirection="Horizontal" TabIndex="25">
        <asp:ListItem Text="Yes" Value="0"></asp:ListItem>
        <asp:ListItem Text="No" Value="1" Selected="True"></asp:ListItem>
    </asp:RadioButtonList>
</div>--%>
                            </div>
                        </div>
                        <h7 class="card-title fw-semibold mb-4">Upgradation Details</h7>
                        <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                            <div class="row" style="margin-bottom: 20px;">
                                <div class="col-4">
                                    <label>
                                        Requested Voltage for Upgradation 
            <samp style="color: red">* </samp>
                                    </label>
                                    <asp:DropDownList Style="width: 100% !important;" class="form-control select-form select2"  ID="ddlRequestVoltageUpgradation" TabIndex="8" runat="server" AutoPostBack="true">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Text="Please Select State" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlRequestVoltageUpgradation" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                </div>
                            </div>
                            <div class="row" style="margin-left: 1%; margin-bottom: 1%; font-size: 13px;">
                                Whether Applied fro Upgradation earlier? &nbsp;&nbsp;
    <asp:RadioButtonList ID="RadioButtonList2" AutoPostBack="true" runat="server" OnSelectedIndexChanged="RadioButtonList2_SelectedIndexChanged" RepeatDirection="Horizontal" TabIndex="25">
        <asp:ListItem Text="Yes" Value="0"></asp:ListItem>
        <asp:ListItem Text="No" Value="1" Selected="True"></asp:ListItem>
    </asp:RadioButtonList>
                            </div>
                            <div class="row" runat="server" id="DivUpgradationEarlier" visible="false">
                                <div class="col-4">
                                    <label for="InterviewDate">Date of Interview</label>
                                    <asp:TextBox class="form-control" ID="txtInterviewDate" onkeydown="return preventEnterSubmit(event)" min='0000-01-01' max='9999-01-01' Type="date" runat="server" autocomplete="off" MaxLength="6" TabIndex="10"></asp:TextBox>
                                    <span id="lblInterview" style="color: red"></span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator56" runat="server" ControlToValidate="txtInterviewDate" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Interview Date</asp:RequiredFieldValidator>

                                </div>
                                <div class="col-4">
                                    <label for="VoltageLevel">Voltage Level Applied for</label>
                                    <asp:DropDownList Style="width: 100% !important;" class="form-control select-form select2"  ID="ddlVoltageBeforeUpgradation" TabIndex="8" runat="server" AutoPostBack="true">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator28" Text="Please Select State" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlVoltageBeforeUpgradation" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                </div>
                            </div>
                        </div>
                        <h7 class="card-title fw-semibold mb-4">Experience Details</h7>
                        <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                            <div class="row">
                                <div class="table table-bordered table-striped table-responsive pt-3">
                                    <table class="table table-striped">
                                        <thead>
                                            <tr>
                                                <th>Experience In
                                                </th>
                                                <th>Training Under
                                                </th>
                                                <th>Employer Name
                                                </th>
                                                <th>Post Description
                                                </th>
                                                <th>From
                                                </th>
                                                <th>To
                                                </th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <%--  <td style="text-align: center; font-size: 13px;">1
</td>--%>
                                                <td>
                                                    <asp:DropDownList class="select-form select2" ID="ddlExperiene1" runat="server" TabIndex="36" AutoPostBack="true">
                                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="Erection" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="Operation" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="Maintenance of Electrical Installation" Value="3"></asp:ListItem>

                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator52" runat="server" ControlToValidate="ddlExperiene1" InitialValue="0" ForeColor="Red" ValidationGroup="Submit" Display="Dynamic" ErrorMessage="Please Select ExperienceIn"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:DropDownList class="select-form select2" ID="ddlTraningUnder1" runat="server" TabIndex="37" AutoPostBack="true">
                                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="A class licensed electrical contractor" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="Central government" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="State government" Value="3"></asp:ListItem>
                                                        <asp:ListItem Text="Semigovernment department/organisation" Value="4"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator53" runat="server" ControlToValidate="DropDownList1" InitialValue="0" ForeColor="Red" 
        ValidationGroup="Submit" Display="Dynamic"  ErrorMessage="Please Select Traning Under"></asp:RequiredFieldValidator>--%>
                                                </td>
                                                <td>
                                                    <asp:TextBox class="form-control" autocomplete="off" ID="txtExperienceEmployer1" MaxLength="30" TabIndex="38" runat="server"> </asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtExperienceEmployer1"
                                                        ErrorMessage="Please Add Employer Name" ValidationGroup="Submit" ForeColor="Red">Please Add Employer Name</asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:TextBox class="form-control" autocomplete="off" ID="txtPostDescription1" MaxLength="50" TabIndex="39" runat="server"> </asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtPostDescription1"
                                                        ErrorMessage="Please Add Post Description" ValidationGroup="Submit" ForeColor="Red">Please Add Post Description</asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:TextBox class="form-control" autocomplete="off" type="date" min='0000-01-01' max='9999-01-01' ID="txtExperienceFrom1" TabIndex="40" onchange="validateDates2()" runat="server"> </asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtExperienceFrom1"
                                                        ErrorMessage="Please Add From Date" ValidationGroup="Submit" ForeColor="Red">Please Add From Date</asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:TextBox class="form-control" autocomplete="off" type="date" AutoPostBack="true" min='0000-01-01' max='9999-01-01' ID="txtExperienceTo1" TabIndex="41" onchange="validateDates2()" runat="server"> </asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtExperienceTo1"
                                                        ErrorMessage="Please Add To Date" ValidationGroup="Submit" ForeColor="Red">Please Add To Date</asp:RequiredFieldValidator>
                                                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="txtExperienceFrom1" ControlToValidate="txtExperienceTo1" Operator="GreaterThan"
                                                        ErrorMessage="From Date must be greater than to To Date" Display="Dynamic" ForeColor="Red" />

                                                </td>
                                            </tr>
                                            <tr id="trExperience2" runat="server" visible="false">
                                                <%--  <td style="text-align: center; font-size: 13px;">1
</td>--%>
                                                <td>
                                                    <asp:DropDownList class="select-form select2" ID="ddlExperiene2" runat="server" TabIndex="36" AutoPostBack="true">
                                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="Erection" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="Operation" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="Maintenance of Electrical Installation" Value="3"></asp:ListItem>

                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlExperiene2" InitialValue="0" ForeColor="Red" ValidationGroup="Submit" Display="Dynamic" ErrorMessage="Please Select ExperienceIn"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:DropDownList class="select-form select2" ID="ddlTraningUnder2" runat="server" TabIndex="37" AutoPostBack="true">
                                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="A class licensed electrical contractor" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="Central government" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="State government" Value="3"></asp:ListItem>
                                                        <asp:ListItem Text="Semigovernment department/organisation" Value="4"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator53" runat="server" ControlToValidate="DropDownList1" InitialValue="0" ForeColor="Red" 
        ValidationGroup="Submit" Display="Dynamic"  ErrorMessage="Please Select Traning Under"></asp:RequiredFieldValidator>--%>
                                                </td>
                                                <td>
                                                    <asp:TextBox class="form-control" autocomplete="off" ID="txtExperienceEmployer2" MaxLength="30" TabIndex="38" runat="server"> </asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtExperienceEmployer2"
                                                        ErrorMessage="Please Add Employer Name" ValidationGroup="Submit" ForeColor="Red">Please Add Employer Name</asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:TextBox class="form-control" autocomplete="off" ID="txtPostDescription2" MaxLength="50" TabIndex="39" runat="server"> </asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtPostDescription2"
                                                        ErrorMessage="Please Add Post Description" ValidationGroup="Submit" ForeColor="Red">Please Add Post Description</asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:TextBox class="form-control" autocomplete="off" type="date" min='0000-01-01' max='9999-01-01' ID="txtExperienceFrom2" TabIndex="40" onchange="validateDates2()" runat="server"> </asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtExperienceFrom2"
                                                        ErrorMessage="Please Add From Date" ValidationGroup="Submit" ForeColor="Red">Please Add From Date</asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:TextBox class="form-control" autocomplete="off" type="date" AutoPostBack="true" min='0000-01-01' max='9999-01-01' ID="txtExperienceTo2" TabIndex="41" onchange="validateDates2()" runat="server"> </asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtExperienceTo2"
                                                        ErrorMessage="Please Add To Date" ValidationGroup="Submit" ForeColor="Red">Please Add To Date</asp:RequiredFieldValidator>
                                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtExperienceFrom2" ControlToValidate="txtExperienceTo2" Operator="GreaterThan"
                                                        ErrorMessage="From Date must be greater than to To Date" Display="Dynamic" ForeColor="Red" />

                                                </td>
                                            </tr>
                                            <tr id="trExperience3" runat="server" visible="false">
                                                <%--  <td style="text-align: center; font-size: 13px;">1
</td>--%>
                                                <td>
                                                    <asp:DropDownList class="select-form select2" ID="ddlExperiene3" runat="server" TabIndex="36" AutoPostBack="true">
                                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="Erection" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="Operation" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="Maintenance of Electrical Installation" Value="3"></asp:ListItem>

                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="ddlExperiene3" InitialValue="0" ForeColor="Red" ValidationGroup="Submit" Display="Dynamic" ErrorMessage="Please Select ExperienceIn"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:DropDownList class="select-form select2" ID="ddlTraningUnder3" runat="server" TabIndex="37" AutoPostBack="true">
                                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="A class licensed electrical contractor" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="Central government" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="State government" Value="3"></asp:ListItem>
                                                        <asp:ListItem Text="Semigovernment department/organisation" Value="4"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator53" runat="server" ControlToValidate="DropDownList1" InitialValue="0" ForeColor="Red" 
        ValidationGroup="Submit" Display="Dynamic"  ErrorMessage="Please Select Traning Under"></asp:RequiredFieldValidator>--%>
                                                </td>
                                                <td>
                                                    <asp:TextBox class="form-control" autocomplete="off" ID="txtExperienceEmployer3" MaxLength="30" TabIndex="38" runat="server"> </asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="txtExperienceEmployer3"
                                                        ErrorMessage="Please Add Employer Name" ValidationGroup="Submit" ForeColor="Red">Please Add Employer Name</asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:TextBox class="form-control" autocomplete="off" ID="txtPostDescription3" MaxLength="50" TabIndex="39" runat="server"> </asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="txtPostDescription3"
                                                        ErrorMessage="Please Add Post Description" ValidationGroup="Submit" ForeColor="Red">Please Add Post Description</asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:TextBox class="form-control" autocomplete="off" type="date" min='0000-01-01' max='9999-01-01' ID="txtExperienceFrom3" TabIndex="40" onchange="validateDates2()" runat="server"> </asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="txtExperienceFrom3"
                                                        ErrorMessage="Please Add From Date" ValidationGroup="Submit" ForeColor="Red">Please Add From Date</asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:TextBox class="form-control" autocomplete="off" type="date" AutoPostBack="true" min='0000-01-01' max='9999-01-01' ID="txtExperienceTo3" TabIndex="41" onchange="validateDates2()" runat="server"> </asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ControlToValidate="txtExperienceTo3"
                                                        ErrorMessage="Please Add To Date" ValidationGroup="Submit" ForeColor="Red">Please Add To Date</asp:RequiredFieldValidator>
                                                    <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToCompare="txtExperienceFrom3" ControlToValidate="txtExperienceTo3" Operator="GreaterThan"
                                                        ErrorMessage="From Date must be greater than to To Date" Display="Dynamic" ForeColor="Red" />

                                                </td>
                                            </tr>
                                            <tr id="trExperience4" runat="server" visible="false">
                                                <%--  <td style="text-align: center; font-size: 13px;">1
</td>--%>
                                                <td>
                                                    <asp:DropDownList class="select-form select2" ID="ddlExperience4" runat="server" TabIndex="36" AutoPostBack="true">
                                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="Erection" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="Operation" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="Maintenance of Electrical Installation" Value="3"></asp:ListItem>

                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="ddlExperience4" InitialValue="0" ForeColor="Red" ValidationGroup="Submit" Display="Dynamic" ErrorMessage="Please Select ExperienceIn"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:DropDownList class="select-form select2" ID="ddlUnderTraning4" runat="server" TabIndex="37" AutoPostBack="true">
                                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="A class licensed electrical contractor" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="Central government" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="State government" Value="3"></asp:ListItem>
                                                        <asp:ListItem Text="Semigovernment department/organisation" Value="4"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator53" runat="server" ControlToValidate="DropDownList1" InitialValue="0" ForeColor="Red" 
        ValidationGroup="Submit" Display="Dynamic"  ErrorMessage="Please Select Traning Under"></asp:RequiredFieldValidator>--%>
                                                </td>
                                                <td>
                                                    <asp:TextBox class="form-control" autocomplete="off" ID="txtExperienceEmployer4" MaxLength="30" TabIndex="38" runat="server"> </asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="txtExperienceEmployer4"
                                                        ErrorMessage="Please Add Employer Name" ValidationGroup="Submit" ForeColor="Red">Please Add Employer Name</asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:TextBox class="form-control" autocomplete="off" ID="txtPostDescription4" MaxLength="35" TabIndex="39" runat="server"> </asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ControlToValidate="txtPostDescription4"
                                                        ErrorMessage="Please Add Post Description" ValidationGroup="Submit" ForeColor="Red">Please Add Post Description</asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:TextBox class="form-control" autocomplete="off" type="date" min='0000-01-01' max='9999-01-01' ID="txtExperienceFrom4" TabIndex="40" onchange="validateDates2()" runat="server"> </asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ControlToValidate="txtExperienceFrom4"
                                                        ErrorMessage="Please Add From Date" ValidationGroup="Submit" ForeColor="Red">Please Add From Date</asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:TextBox class="form-control" autocomplete="off" type="date" AutoPostBack="true" min='0000-01-01' max='9999-01-01' ID="txtExperienceTo4" TabIndex="41" onchange="validateDates2()" runat="server"> </asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator33" runat="server" ControlToValidate="txtExperienceTo4"
                                                        ErrorMessage="Please Add To Date" ValidationGroup="Submit" ForeColor="Red">Please Add To Date</asp:RequiredFieldValidator>
                                                    <asp:CompareValidator ID="CompareValidator4" runat="server" ControlToCompare="txtExperienceFrom4" ControlToValidate="txtExperienceTo4" Operator="GreaterThan"
                                                        ErrorMessage="From Date must be greater than to To Date" Display="Dynamic" ForeColor="Red" />

                                                </td>
                                            </tr>
                                            <tr id="trExperience5" runat="server" visible="false">
                                                <%--  <td style="text-align: center; font-size: 13px;">1
</td>--%>
                                                <td>
                                                    <asp:DropDownList class="select-form select2" ID="ddlExperience5" runat="server" TabIndex="36" AutoPostBack="true">
                                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="Erection" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="Operation" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="Maintenance of Electrical Installation" Value="3"></asp:ListItem>

                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator34" runat="server" ControlToValidate="ddlExperience5" InitialValue="0" ForeColor="Red" ValidationGroup="Submit" Display="Dynamic" ErrorMessage="Please Select ExperienceIn"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:DropDownList class="select-form select2" ID="ddlUnderTraning5" runat="server" TabIndex="37" AutoPostBack="true">
                                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="A class licensed electrical contractor" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="Central government" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="State government" Value="3"></asp:ListItem>
                                                        <asp:ListItem Text="Semigovernment department/organisation" Value="4"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator53" runat="server" ControlToValidate="DropDownList1" InitialValue="0" ForeColor="Red" 
        ValidationGroup="Submit" Display="Dynamic"  ErrorMessage="Please Select Traning Under"></asp:RequiredFieldValidator>--%>
                                                </td>
                                                <td>
                                                    <asp:TextBox class="form-control" autocomplete="off" ID="txtExperienceEmployer5" MaxLength="30" TabIndex="38" runat="server"> </asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server" ControlToValidate="txtExperienceEmployer5"
                                                        ErrorMessage="Please Add Employer Name" ValidationGroup="Submit" ForeColor="Red">Please Add Employer Name</asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:TextBox class="form-control" autocomplete="off" ID="txtPostDescription5" MaxLength="35" TabIndex="39" runat="server"> </asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator36" runat="server" ControlToValidate="txtPostDescription5"
                                                        ErrorMessage="Please Add Post Description" ValidationGroup="Submit" ForeColor="Red">Please Add Post Description</asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:TextBox class="form-control" autocomplete="off" type="date" min='0000-01-01' max='9999-01-01' ID="txtExperienceFrom5" TabIndex="40" onchange="validateDates2()" runat="server"> </asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator37" runat="server" ControlToValidate="txtExperienceFrom5"
                                                        ErrorMessage="Please Add From Date" ValidationGroup="Submit" ForeColor="Red">Please Add From Date</asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:TextBox class="form-control" autocomplete="off" type="date" AutoPostBack="true" min='0000-01-01' max='9999-01-01' ID="txtExperienceTo5" TabIndex="41" onchange="validateDates2()" runat="server"> </asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator38" runat="server" ControlToValidate="txtExperienceTo5"
                                                        ErrorMessage="Please Add To Date" ValidationGroup="Submit" ForeColor="Red">Please Add To Date</asp:RequiredFieldValidator>
                                                    <asp:CompareValidator ID="CompareValidator5" runat="server" ControlToCompare="txtExperienceFrom5" ControlToValidate="txtExperienceTo5" Operator="GreaterThan"
                                                        ErrorMessage="From Date must be greater than to To Date" Display="Dynamic" ForeColor="Red" />

                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" style="font-size: 12px;">
                                                    <asp:Button ID="btnAddMore" runat="server" OnClick="btnAddMore_Click" Text="Add More" class="btn btn-primary"
                                                        Style="padding: 5px 10px 5px 10px; border-radius: 5px;"></asp:Button>
                                                </td>
                                                <td colspan="2" style="font-size: 12px;">
                                                    <p style="font-size: 12px; margin-bottom: 0px;">Total Experience:</p>
                                                    <asp:TextBox class="form-control" ReadOnly="true" autocomplete="off" ID="txtTotalExperience" runat="server"> </asp:TextBox>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>

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
                                        <td style="padding-top: 45px;">Experience Certificate.(<span
                                            style="color: red;">★</span>)
                                        </td>
                                        <td>
                                            <asp:FileUpload ID="fileUpload3" runat="server" CssClass="file-upload-default" Style="display: none;" />
                                            <div class="form-group">
                                                <label style="font-size: 9px;">
                                                    (PLEASE UPLOAD PDF ONLY NO MORE THAN 2MB)
                                                </label>
                                                <asp:FileUpload ID="ExpCertificate" runat="server" class="file-upload-default" onchange="ExperienceCertificateFileInputChange();" />

                                                <div class="input-group col-xs-12">
                                                    <asp:TextBox ID="txtExpCertificate" runat="server" CssClass="form-control file-upload-info"
                                                        Enabled="false" placeholder="Upload Experience certificate" Style="width: 85%;"></asp:TextBox>
                                                    <span class="input-group-append">



                                                        <asp:Button ID="btnUpload" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick=" return false;" />


                                                    </span>


                                                </div>
                                            </div>
                                        </td>

                                        <asp:HiddenField ID="HiddenField1" runat="server" />

                                    </tr>
                                </tbody>
                            </table>
                        </div>

                    </div>
                </div>
                <div class="row" style="margin-left: 1%; margin-bottom: 20px;">
                    <asp:CheckBox ID="Check" runat="server" />&nbsp;
                    <text>
                        I hereby declare that the information furnished in the application is correct.
                    </text>
                </div>
                <%--<div class="row" style="margin-top: 15px; margin-bottom: 15px; margin-left: 1%;">
                    <div class="col-md-6">
                        <div class="form-group row">
                            <label for="exampleInputUsername2" class="col-sm-1 col-form-label" style="padding: 0px;">Place:</label>
                            <div class="col-sm-4">
                                <asp:TextBox class="form-control" autocomplete="off" onkeydown="return preventEnterSubmit(event)" ID="txtplace" min='0000-01-01' max='9999-01-01' Type="text" TabIndex="19" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label for="exampleInputUsername2" class="col-sm-1 col-form-label" style="padding: 0px;">Date:</label>
                            <div class="col-sm-4">
                                <asp:TextBox class="form-control" autocomplete="off" onkeydown="return preventEnterSubmit(event)" ID="txtdeclarationdate"  TabIndex="19" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-6">
                    </div>
                </div>--%>
                <div class="row">
                    <div class="col-4"></div>
                    <div class="col-4" style="text-align: center;">

                        <asp:Button ID="btnSubmit" Text="Submit" runat="server" OnClick="btnSubmit_Click" ValidationGroup="Submit" class="btn btn-primary mr-2" />
                        <asp:Button ID="BtnReset" Text="Reset" runat="server" class="btn btn-primary mr-2" Style="padding-left: 17px; padding-right: 17px;" />

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
        function ExperienceCertificateFileInputChange() {
            var fileUploadVisible = document.getElementById('<%= ExpCertificate.ClientID %>');
            var selectedFileName = document.getElementById('<%= txtExpCertificate.ClientID %>');

            if (fileUploadVisible.files.length > 0) {
                // Update the TextBox value with the selected file name
                selectedFileName.value = fileUploadVisible.files[0].name;
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
