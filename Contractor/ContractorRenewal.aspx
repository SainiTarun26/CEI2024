<%@ Page Title="" Language="C#" MasterPageFile="~/Contractor/Contractor.Master" AutoEventWireup="true" CodeBehind="ContractorRenewal.aspx.cs" Inherits="CEIHaryana.Contractor.ContractorRenewal" %>
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
            padding: 1px;
            padding-left: 10px;
            padding-right: 50px;
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
                            <label>
                                Applicant Name
                            </label>
                            <asp:TextBox class="form-control" ID="txtName" runat="server" autocomplete="off" ReadOnly="true" onKeyPress="return alphabetKey(event);" TabIndex="1"
                                MaxLength="200" Style="margin-left: 18px;">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtName" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Name</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-4">
                            <label>
                                Licence No.
                            </label>
                            <asp:TextBox class="form-control" ID="txtLicenceNo" runat="server" ReadOnly="true" autocomplete="off" onKeyPress="return alphabetKey(event);" TabIndex="1"
                                MaxLength="200" Style="margin-left: 18px;">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtLicenceNo" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Name</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-4">
                            <label>
                                Date of Issue
                            </label>
                            <asp:TextBox class="form-control" autocomplete="off" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" ID="txtIssueDate" min='0000-01-01' max='9999-01-01' Type="Date" TabIndex="19" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtIssueDate" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Date of Renewal</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-4">
                            <label>
                                Date of Expiry
                            </label>
                            <asp:TextBox class="form-control" autocomplete="off" onkeydown="return preventEnterSubmit(event)" ReadOnly="true" ID="txtExpiryDate" min='0000-01-01' max='9999-01-01' Type="Date" TabIndex="19" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="txtExpiryDate" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Date of Renewal</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-4" id="divBelated" visible="false" runat="server">
                            <label>
                                Belated Date
                            </label>
                            <asp:TextBox class="form-control" autocomplete="off" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" ID="txtBelatedDate" min='0000-01-01' max='9999-01-01' TabIndex="19" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtBelatedDate" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Date of Renewal</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-4">
                            <label>
                                Date of Birth<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" autocomplete="off" onkeydown="return preventEnterSubmit(event)" ID="txtDOB" min='0000-01-01' max='9999-01-01' Type="Date" OnTextChanged="txtDOB_TextChanged" AutoPostBack="true" TabIndex="19" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="txtDOB" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Date of Renewal</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-4">
                            <label>
                                Age<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtAge" runat="server" onkeydown="return preventEnterSubmit(event)" autocomplete="off" Style="margin-left: 18px" TabIndex="3" MaxLength="300"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAge" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Firm Name</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-4">
                            <label for="Email">Email</label>
                            <asp:TextBox class="form-control" ID="txtEmail" onkeydown="return preventEnterSubmit(event)" runat="server" autocomplete="off" Style="margin-left: 18px" TabIndex="6" onkeyup="return ValidateEmail();"></asp:TextBox>
                            <span id="lblError" style="color: red"></span>
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
                            Whether there is any chnage of Address? &nbsp;&nbsp;
                            <asp:RadioButtonList ID="RadioButtonList1" AutoPostBack="true" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" runat="server" RepeatDirection="Horizontal" TabIndex="25">
                                <asp:ListItem Text="Yes" Value="0"></asp:ListItem>
                                <asp:ListItem Text="No" Value="1" Selected="True"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                        <div class="col-8">
                            <label>
                                Address<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtAddress" onkeydown="return preventEnterSubmit(event)" ReadOnly="true" autocomplete="off" runat="server" TabIndex="7"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtAddress" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Registered Office Address</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-4">
                            <label>
                                State/UT 
                            <samp style="color: red">* </samp>
                            </label>
                            <asp:DropDownList Style="width: 100% !important;" class="form-control select-form select2" ID="DdlState" ReadOnly="true" OnSelectedIndexChanged="DdlState_SelectedIndexChanged" TabIndex="8" runat="server" AutoPostBack="true">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" Text="Please Select State" ErrorMessage="RequiredFieldValidator" ControlToValidate="DdlState" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                        </div>
                        <div class="col-4">
                            <label>
                                District
                            <samp style="color: red">* </samp>
                            </label>
                            <asp:DropDownList Style="width: 100% !important;" class="form-control  select-form select2" ID="DdlDistrict" ReadOnly="true" runat="server" TabIndex="9">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" Text="Please Select District" ErrorMessage="RequiredFieldValidator" ControlToValidate="DdlDistrict" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                        </div>
                        <div class="col-4">
                            <label for="PinCode">PinCode </label>
                            <asp:TextBox class="form-control" ID="txtpincode" onkeydown="return preventEnterSubmit(event)" ReadOnly="true" runat="server" autocomplete="off" MaxLength="6" onkeyup="ValidatePincode();" onkeypress="return isNumberKey(event);" TabIndex="10"></asp:TextBox>
                            <span id="lblPinError" style="color: red"></span>
                        </div>
                        <div class="row" style="margin-left: 2%; margin-top: 2%;">
                            Whether there Address has to be changed in the Licence also as same as the new Address? &nbsp;&nbsp;
                        <asp:RadioButtonList ID="RadioButtonList3" AutoPostBack="true" runat="server" RepeatDirection="Horizontal" TabIndex="25">
                            <asp:ListItem Text="Yes" Value="0"></asp:ListItem>
                            <asp:ListItem Text="No" Value="1" Selected="True"></asp:ListItem>
                        </asp:RadioButtonList>
                        </div>
                    </div>
                </div>
                <h7 class="card-title fw-semibold mb-4">Fee Details</h7>
                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                    <div class="row">
                        <div class="col-4">
                            <label>
                                Name of Treasury<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" autocomplete="off" onkeydown="return preventEnterSubmit(event)" ID="txtTreasuryName" min='0000-01-01' max='9999-01-01' TabIndex="19" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtTreasuryName" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Date of Renewal</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-4">
                            <label>
                                Challan GRN No.<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtchallanNo" runat="server" autocomplete="off" onKeyPress="return alphabetKey(event);" TabIndex="1"
                                MaxLength="200" Style="margin-left: 18px;">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtName" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Name</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-4">
                            <label>
                                Date of Challan<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" autocomplete="off" onkeydown="return preventEnterSubmit(event)" ID="txtChallanDate" min='0000-01-01' max='9999-01-01' Type="Date" TabIndex="19" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtChallanDate" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Date of Renewal</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-4">
                            <label>
                                Amount Remitted<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="TxtAmount" runat="server" placeholder="(in months and years)" onkeydown="return preventEnterSubmit(event)" autocomplete="off" Style="margin-left: 18px" TabIndex="3" MaxLength="300"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="TxtAmount" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Firm Name</asp:RequiredFieldValidator>
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
                <h7 class="card-title fw-semibold mb-4">Documents</h7>
                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                    <div class="row">
                        <div class="table-responsive">
                            <table class="table table-bordered table-striped">
                                <tbody>
                                    <tr>
                                        <td style="padding-top: 45px;">Equipment tested certificate.(<span
                                            style="color: red;">★</span>)
                                        </td>
                                        <td>
                                            <input type="file" name="img[]" class="file-upload-default" style="display: none;" />
                                            <div class="form-group">
                                                <label style="font-size: 9px;">
                                                    (PLEASE UPLOAD PDF ONLY NO MORE THAN 2MB)
                                                </label>
                                                <input type="file" name="img[]" class="file-upload-default" />
                                                <div class="input-group col-xs-12">
                                                    <asp:TextBox ID="txtEquipCertificate" runat="server" CssClass="form-control file-upload-info"
                                                        Enabled="false" placeholder="Upload Equipment tested certificate" Style="width: 85%;"></asp:TextBox>
                                                    <span class="input-group-append">
                                                        <asp:Button ID="BtnEquipCertificate" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick="PhotoDialog(); return false;" />
                                                        <input type="file" id="EquipCertificate" name="EquipCertificateInput" accept=".jpg, .jpeg, .png, .pdf" style="display: none;" runat="server" onchange="PhotoDialogName()" />
                                                    </span>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" ControlToValidate="txtEquipCertificate"
                                                        ValidationGroup="Submit" ForeColor="Red">Please Upload Equipment tested certificate</asp:RequiredFieldValidator>
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
                                                        <asp:Button ID="btnIncomeTax" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick="IncomeTaxDialog(); return false;" />
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
                                                        <asp:Button ID="btnBalanceSheet" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick="BalanceSheetDialog(); return false;" />
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
                                                        <asp:Button ID="btnCalibCertificate" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick="CalibCertificateDialog(); return false;" />
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
                                                        <asp:Button ID="btnWorkDetails" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick="WorkDetailsDialog(); return false;" />
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
                                                        <asp:Button ID="btnAnnexureIII" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick="AnnexureIIIDialog(); return false;" />
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
                                                        <asp:Button ID="btnForm_E" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick="Form_EDialog(); return false;" />
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
                                                        <asp:Button ID="btnTreasuryChallan" runat="server" CssClass="file-upload-browse btn btn-primary" Text="Upload" OnClientClick="TreasuryChallanDialog(); return false;" />
                                                        <input type="file" id="File4" name="fileInput" accept=".jpg, .jpeg, .png, .pdf" style="display: none; border-top-right-radius: 10px; border-bottom-right-radius: 10px;"
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
                <div class="row" style="margin-left: 1%;">
                    <asp:CheckBox ID="Check" runat="server" />&nbsp;
                    <text>
                        I hereby declare that the information furnished in the application is correct.
                    </text>
                </div>
                <div class="row" style="margin-top: 15px; margin-bottom: 15px; margin-left: 1%;">
                    <div class="col-md-6">
                        <div class="form-group row">
                            <label class="col-sm-1 col-form-label" style="padding: 0px;">Place:</label>
                            <div class="col-sm-4">
                                <asp:TextBox class="form-control" autocomplete="off" onkeydown="return preventEnterSubmit(event)" ID="txtplace" min='0000-01-01' max='9999-01-01' Type="text" TabIndex="19" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-sm-1 col-form-label" style="padding: 0px;">Date:</label>
                            <div class="col-sm-4">
                                <asp:TextBox class="form-control" autocomplete="off" onkeydown="return preventEnterSubmit(event)" ID="txtdeclarationdate" min='0000-01-01' max='9999-01-01' Type="text" TabIndex="19" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                    </div>
                </div>
                <div class="row">
                    <div class="col-4"></div>
                    <div class="col-4" style="text-align: center;">
                        <asp:Button ID="btnSubmit" Text="Submit" runat="server" ValidationGroup="Submit" class="btn btn-primary mr-2" />
                        <asp:Button ID="BtnReset" Text="Reset" runat="server" class="btn btn-primary mr-2" Style="padding-left: 17px; padding-right: 17px;" />
                        <%--<asp:Button ID="btnPrint" Text="Print" runat="server" class="btn btn-primary mr-2"  Style="background: linear-gradient(135deg, hsla(318, 44%, 51%, 1) 0%, hsla(347, 94%, 48%, 1) 100%); border-color: #d42766;" OnClientClick="printDiv('printableDiv');"/>--%>
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
