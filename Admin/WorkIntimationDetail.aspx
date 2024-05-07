<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin_Master.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="WorkIntimationDetail.aspx.cs" Inherits="CEIHaryana.Admin.WorkIntimationDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="shortcut icon" type="image/png" href="/css2/style.min.css" />
    <link rel="stylesheet" href="/css2/style.css" />
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/css/select2.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/js/select2.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
    <script src="https://cdn.rawgit.com/harvesthq/chosen/gh-pages/chosen.jquery.min.js"></script>
    <link href="https://cdn.rawgit.com/harvesthq/chosen/gh-pages/chosen.min.css" rel="stylesheet" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/css/select2.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/js/select2.min.js"></script>
    <script type="text/javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
        }

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
            margin-bottom: 15px;
        }

        .form-control {
            box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
            margin-left: 0px !important;
            height: 30px;
        }

        select.form-control {
            box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
            margin-left: 0px !important;
            height: 30px !important;
        }

        label {
            font-size: 13px;
        }

        .form-control:focus {
            border: 2px solid #80bdff;
        }

        select.form-control:focus {
            border: 2px solid #80bdff;
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

        select.form-control.select-form.select2 {
            height: 30px !important;
            padding: 2px 0px 5px 10px;
        }

        ul.chosen-choices {
            border-radius: 5px;
        }

        input#customFile {
            padding: 0px 0px 0px 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="card" style="box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px; border-radius: 5px !important">
            <div class="card-body">
                <h7 class="card-title fw-semibold mb-4">WORK INTIMATION DETAILS</h7>
                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                    <div class="row">
                        <div class="col-4">
                            <label>Electrical Installation For</label>
                            <asp:DropDownList ID="ddlworktype" runat="server" AutoPostBack="true" disabled class="form-control  select-form select2" Style="width: 100% !important;">
                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                <asp:ListItem Value="1" Text="Individual Person"></asp:ListItem>
                                <asp:ListItem Value="2" Text="Firm/Organization/Company/Department"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-4" id="individual" runat="server">
                            <label for="Name">Name of Owner/ Responsible Person</label>
                            <asp:TextBox class="form-control" ID="txtName" autocomplete="off" readOnly="true" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtName"
                                ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">(*)</asp:RequiredFieldValidator>

                        </div>
                        <div class="col-4" id="agency" runat="server">
                            <label for="agency">Name of Firm/ Org./ Company/ Department</label>
                            <asp:TextBox class="form-control" ID="txtagency" autocomplete="off" readOnly="true" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtagency"
                                ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">*</asp:RequiredFieldValidator>

                        </div>
                        <div class="col-4">
                            <label for="Phone">Contact No.</label>
                            <asp:TextBox class="form-control" ID="txtPhone" readOnly="true" onKeyPress="return isNumberKey(event);" TabIndex="5"
                                onkeyup="return isvalidphoneno();" MaxLength="10" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <span id="lblErrorContect" style="color: red"></span>
                        </div>
                    </div>
                    <div class="row" style="margin-top: -20px">
                        <div class="col-8">
                            <label for="Address">Address</label>
                            <asp:TextBox class="form-control" ID="txtAddress"  readOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                        </div>
                         <div class="col-4">
                                    <label>
                                        District
                                <samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtDistrict" readOnly="true" MaxLength="6" onkeydown="return preventEnterSubmit(event)" onkeyup="ValidatePincode();" onKeyPress="return isNumberKey(event);" autocomplete="off" TabIndex="7" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                     </div>
                                
                        </div>
                    <div class="row">
                        <div class="col-4" runat="server">
                                    <label for="Pin">PinCode</label>
                                    <asp:TextBox class="form-control" ID="txtPin" MaxLength="6" readOnly="true" onkeydown="return preventEnterSubmit(event)" onkeyup="ValidatePincode();" onKeyPress="return isNumberKey(event);" autocomplete="off" TabIndex="7" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    <span id="lblPinError" style="color: red"></span>
                                </div>
                                <div class="col-4" runat="server">
                                    <label for="Email">Email</label>
                                    <asp:TextBox class="form-control" ID="txtEmail" readOnly="true" onkeydown="return preventEnterSubmit(event)" onkeyup="return ValidateEmail();" TabIndex="8" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    <span id="lblError" style="color: red"></span>
                                </div>
                        <div class="col-4">
                            <label>Type of Premises</label>
                            <asp:TextBox class="form-control" ID="txtPremises" readOnly="true" onkeydown="return preventEnterSubmit(event)" onkeyup="return ValidateEmail();" TabIndex="8" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                   
                    </div>
                        </div>
                    <div class="row">
                        <div class="col-4" id="OtherPremises" runat="server">
                            <label for="OtherPremises">Other Premises</label>
                            <asp:TextBox class="form-control" ID="txtOtherPremises" readOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtOtherPremises"
                                ErrorMessage="Please Enter Premises" ValidationGroup="Submit" ForeColor="Red">(*)</asp:RequiredFieldValidator>

                        </div>

                        <div class="col-4">
                            <label>Highest Voltage Level of Work</label>
                             <asp:TextBox class="form-control" ID="ddVoltageLevel" readOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                          <%--  <asp:DropDownList class="form-control  select-form select2" Style="width: 100% !important;" ID="ddlVoltageLevel" runat="server" TabIndex="14">
                            </asp:DropDownList>--%>
                        </div>
                       <div class="col-4" runat="server">
                             <label for="PanNumber">PAN Number of Site Owner
                                        <samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtPAN" MaxLength="10" readOnly="true" onkeydown="return preventEnterSubmit(event)" TabIndex="11" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                  
                        </div>
                           <div class="col-4">
                                    <label>
                                        Applicant Type
        <samp style="color: red">* </samp>
                                    </label>
                                   <asp:TextBox class="form-control" ID="txtApplicant" ReadOnly="true" MaxLength="10" onkeydown="return preventEnterSubmit(event)" TabIndex="11" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                  

                                      </div>

                   </div>
                        <div class="row">
                                <div class="col-12">
                                    <div class="table-responsive pt-3" id="Installation" runat="server" visible="false">
                                        <table class="table table-bordered table-striped" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px;">
                                <thead class="table-dark">
                                    <tr>
                                        <th style="width: 70%;">Installation Type
                                        </th>
                                        <th style="width: 20%;">No of Installations
                                        </th>
                                     
                                    </tr>
                                </thead>
                                <tbody>
                                    <div id="installationType1" runat="server" visible="False">
                                        <tr>
                                            <td>
                                                <div class="col-12">
                                                    <asp:TextBox class="form-control" ID="txtinstallationType1" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                </div>
                                            </td>
                                            <td>
                                                <div class="col-12">
                                                    <asp:TextBox class="form-control" ID="txtinstallationNo1" readonly="true" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtinstallationNo1" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Number Of Installation</asp:RequiredFieldValidator>
                                                </div>
                                            </td>
                                          
                                        </tr>
                                    </div>
                                    <div id="installationType2" runat="server" visible="False">
                                        <tr>
                                            <td>
                                                <div class="col-12">
                                                    <asp:TextBox class="form-control" ID="txtinstallationType2" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                </div>
                                            </td>
                                            <td>
                                                <div class="col-12">
                                                    <asp:TextBox class="form-control" ID="txtinstallationNo2"  readonly="true"  onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtinstallationNo2" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Number Of Installation</asp:RequiredFieldValidator>
                                                </div>
                                            </td>
                                           
                                        </tr>
                                    </div>
                                    <div id="installationType3" runat="server" visible="False">
                                        <tr>
                                            <td>
                                                <div class="col-12">
                                                    <asp:TextBox class="form-control" ID="txtinstallationType3" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px;"></asp:TextBox>
                                                </div>
                                            </td>
                                            <td>
                                                <div style="margin-left: 15px !important; margin-right: 15px !important;">
                                                    <asp:TextBox class="form-control" ID="txtinstallationNo3"   readonly="true" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtinstallationNo3" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Number Of Installation</asp:RequiredFieldValidator>
                                                </div>
                                            </td>
                                           
                                        </tr>
                                    </div>
                                    <div id="installationType4" runat="server" visible="False">
                                        <tr>
                                            <td>
                                                <div class="col-12">
                                                    <asp:TextBox class="form-control" ID="txtinstallationType4" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                </div>
                                            </td>
                                            <td>
                                                <div class="col-12">
                                                    <asp:TextBox class="form-control" ID="txtinstallationNo4" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtinstallationNo4" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Number Of Installation</asp:RequiredFieldValidator>
                                                </div>
                                            </td>
                                            
                                        </tr>
                                    </div>
                                    <div id="installationType5" runat="server" visible="False">
                                        <tr>
                                            <td>
                                                <div class="col-12">
                                                    <asp:TextBox class="form-control" ID="txtinstallationType5" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                </div>
                                            </td>
                                            <td>
                                                <div class="col-12">
                                                    <asp:TextBox class="form-control" ID="txtinstallationNo5" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtinstallationNo5" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Number Of Installation</asp:RequiredFieldValidator>
                                                </div>
                                            </td>
                                           
                                        </tr>
                                    </div>
                                    <div id="installationType6" runat="server" visible="False">
                                        <tr>
                                            <td>
                                                <div class="col-12">
                                                    <asp:TextBox class="form-control" ID="txtinstallationType6" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                </div>
                                            </td>
                                            <td>
                                                <div class="col-12">
                                                    <asp:TextBox class="form-control" ID="txtinstallationNo6" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="txtinstallationNo6" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Number Of Installation</asp:RequiredFieldValidator>
                                                </div>
                                            </td>
                                            
                                        </tr>
                                    </div>
                                    <div id="installationType7" runat="server" visible="False">
                                        <tr>
                                            <td>
                                                <div class="col-12">
                                                    <asp:TextBox class="form-control" ID="txtinstallationType7" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                </div>
                                            </td>
                                            <td>
                                                <div class="col-12">
                                                    <asp:TextBox class="form-control" ID="txtinstallationNo7" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="txtinstallationNo7" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Number Of Installation</asp:RequiredFieldValidator>
                                                </div>
                                            </td>
                                           
                                        </tr>
                                    </div>
                                    <div id="installationType8" runat="server" visible="False">
                                        <tr>
                                            <td>
                                                <div class="col-12">
                                                    <asp:TextBox class="form-control" ID="txtinstallationType8" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                </div>
                                            </td>
                                            <td>
                                                <div class="col-12">
                                                    <asp:TextBox class="form-control" ID="txtinstallationNo8" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtinstallationNo8" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Number Of Installation</asp:RequiredFieldValidator>
                                                </div>
                                            </td>
                                         
                                        </tr>
                                    </div>
                                </tbody>
                            </table>
                                    </div>
                                </div>
                            </div>
                </div>
                <h7 class="card-title fw-semibold mb-4">Work Schedule</h7>
                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">

                    <%--<asp:UpdatePanel ID="UpdatePanel6" runat="server">
                        <ContentTemplate>--%>
                            <div class="row">
                                <div class="col-4">
                                    <label for="StartDate">Work Start Date</label>
                                    <asp:TextBox class="form-control" ID="txtStartDate" readOnly="true" autocomplete="off" Type="Date" min='0000-01-01' max='9999-01-01' runat="server" Style="margin-left: 18px"></asp:TextBox>
                                </div>
                                <div class="col-4">
                                    <label for="CompletitionDate">Tentative Work Completition Date</label>
                                    <asp:TextBox class="form-control" ID="txtCompletitionDate" readOnly="true" autocomplete="off" Type="Date" min='0000-01-01' max='9999-01-01' runat="server" Style="margin-left: 18px"></asp:TextBox>
                                </div>
                                <div class="col-4">
                                    <label>If any work issued by any Agency/ Dept. / Owner</label>
                                    <asp:DropDownList class="form-control  select-form select2" ID="ddlAnyWork" disabled Style="width: 100% !important;" runat="server" TabIndex="16" AutoPostBack="true">
                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>


                            </div>

                            <div class="row">
                                <div class="col-4" id="hiddenfield" runat="server">
                                    <label class="form-label" for="customFile">Attached Copy of Work Order</label>
                                 <asp:LinkButton ID="lnkFile" runat="server" AutoPostBack="true" OnClick="lnkFile_Click" Text="Open Document" />
                                  <%--  <asp:FileUpload ID="customFile" runat="server" CssClass="form-control" Style="margin-left: 18px; padding: 0px; font-size: 15px;" />--%>

                                   
                                </div>

                                <div class="col-4" id="hiddenfield1" runat="server">
                                    <label for="CompletionDateasperWorkOrder">Completion Date as per Work Order</label>
                                    <asp:TextBox class="form-control" ID="txtCompletionDateAPWO" readOnly="true" autocomplete="off" Type="Date" min='0000-01-01' max='9999-01-01' runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtCompletionDateAPWO"
                                        ErrorMessage="Please Enter Completion Date as per Work Order" ValidationGroup="Submit" ForeColor="Red">(*)</asp:RequiredFieldValidator>

                                </div>
                            </div>
                       <%-- </ContentTemplate>
                    </asp:UpdatePanel>--%>
                </div>
                <div>
                    <h7 class="card-title fw-semibold mb-4">Attached Supervisor/Wireman Details</h7>
                    <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                        <div class="row">
                              <div class="col-12" >
                            <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="false">
                                <Columns>
                                    <%-- <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="chkSelectAll" runat="server" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckBox1" runat="server" HorizontalAlign="center" />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="REID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblREID" runat="server" Text='<%#Eval("REID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                  <%--  <asp:BoundField DataField="REID" HeaderText="ID">
                                        <HeaderStyle HorizontalAlign="center" Width="10%" />
                                        <ItemStyle HorizontalAlign="center" Width="10%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Category" HeaderText="Category">
                                        <HeaderStyle HorizontalAlign="center" Width="10%" />
                                        <ItemStyle HorizontalAlign="center" Width="10%" />
                                    </asp:BoundField>--%>
                                    <asp:BoundField DataField="Name" HeaderText="Name">
                                        <HeaderStyle HorizontalAlign="Center" CssClass="headercolor textalignCenter" />
                                        <ItemStyle HorizontalAlign="Center" CssClass="textalignCenter" />
                                          </asp:BoundField>

                                    <asp:BoundField DataField="LicenseNo" HeaderText="Competency Certificate Number">
                                        <HeaderStyle HorizontalAlign="Center" CssClass="headercolor textalignCenter" />
                                        <ItemStyle HorizontalAlign="Center" CssClass="textalignCenter" />
                                    </asp:BoundField>

                                    <%--<asp:BoundField DataField="DateOfExpiry" HeaderText="Expiry Date">
                                        <HeaderStyle HorizontalAlign="right" Width="24%" />
                                        <ItemStyle HorizontalAlign="right" Width="24%" />
                                    </asp:BoundField>--%>
                                       <asp:BoundField DataField="DateOfExpiry" HeaderText="Valid Upto">
                                        <HeaderStyle HorizontalAlign="Center" CssClass="headercolor textalignCenter"/>
                                        <ItemStyle HorizontalAlign="Center" CssClass="textalignCenter" />
                                    </asp:BoundField>
                                   <%-- <asp:BoundField DataField="LicenseNo" HeaderText="License">
                                        <HeaderStyle HorizontalAlign="right" Width="20%" />
                                        <ItemStyle HorizontalAlign="right" Width="20%" />
                                    </asp:BoundField>--%>
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
                                  </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-4"></div>
                        <div class="col-4" style="text-align: center;">
                            <asp:Button type="submit" ID="btnBack" Text="Back" runat="server" class="btn btn-primary mr-2" OnClick="btnBack_Click" />
                        </div>
                        <div class="col-4"></div>
                    </div>
                    <asp:HiddenField ID="hdnId" runat="server" />
                    <asp:HiddenField ID="hdnId2" runat="server" />
                    <div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <footer class="footer">
    </footer>
 

    <script>
        $('.select2').select2();
    </script>
    <script>
        $(".chosen-select").chosen({
            no_results_text: "Oops, nothing found!"
        })
    </script>
      
 
    <script type="text/javascript">
        function isvalidphoneno() {

            var Phone1 = document.getElementById("<%=txtPhone.ClientID %>");
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
        function showHide() {
            debugger
            let experience = document.getElementById('experience');
            if (experience.value == 1) {
                document.getElementById('hidden-field').style.display = 'block';
            } else {
                document.getElementById('hidden-field').style.display = 'none';
            }
            if (experience.value == 1) {
                document.getElementById('hidden-field1').style.display = 'block';
            } else {
                document.getElementById('hidden-field1').style.display = 'none';
            }
        }
    </script>
    <script type="text/javascript">
        function showHide1() {
            debugger
            let experience = document.getElementById('ddlworktype');
            if (experience.value == 1) {
                document.getElementById('individual').style.display = 'block';
            } else {
                document.getElementById('individual').style.display = 'none';
            }
            if (experience.value == 1) {
                document.getElementById('Agency').style.display = 'block';
            } else {
                document.getElementById('Agency').style.display = 'none';
            }
        }
    </script>
</asp:Content>
