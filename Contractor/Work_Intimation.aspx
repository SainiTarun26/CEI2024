<%@ Page Title="" Language="C#" MasterPageFile="~/Contractor/Contractor.Master" AutoEventWireup="true" CodeBehind="Work_Intimation.aspx.cs" Inherits="CEIHaryana.Contractor.Work_Intimation" %>

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
            height: 30px;
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

        input#ContentPlaceHolder1_txtName {
            font-size: 11px !important;
        }
<<<<<<< HEAD

        input#ContentPlaceHolder1_txtagency {
            font-size: 12px;
        }
=======
>>>>>>> f90ba1348131d10b95ac418fb8d75d3343734f03
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div class="card" style="box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px; border-radius: 5px !important">
            <div class="card-body">
                <h7 class="card-title fw-semibold mb-4">WORK INTIMATION DETAILS</h7>
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
                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                    <div class="row">
                        <div class="col-4">
                            <label>
                                Electrical Installation For<samp style="color: red"> * </samp>
                            </label>
                            <asp:DropDownList ID="ddlworktype" runat="server" AutoPostBack="true" class="form-control  select-form select2" TabIndex="1" OnSelectedIndexChanged="ddlworktype_SelectedIndexChanged" Style="width: 100% !important;">
                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                <asp:ListItem Value="1" Text="Individual Person"></asp:ListItem>
                                <asp:ListItem Value="2" Text="Firm/Organization/Company/Department"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" Text="Please Select Work Type" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlworktype" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />

                        </div>
                        <div class="col-4" id="individual" runat="server">
                            <label for="Name">
                                Name of Owner/ Consumer<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtName" onkeydown="return preventEnterSubmit(event)" placeholder="As Per Demand Notice of Utility or Electricity Bill" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtName" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Name</asp:RequiredFieldValidator>

                        </div>
                        <div class="col-4" id="agency" runat="server">
                            <label for="agency">
                                Name of Firm/ Org./ Company/ Department
                                <samp style="color: red">* </samp>
                            </label>
<<<<<<< HEAD
                            <asp:TextBox class="form-control" ID="txtagency" onkeydown="return preventEnterSubmit(event)" placeholder="As Per Demand Notice of Utility or Electricity Bill" autocomplete="off" TabIndex="3" runat="server" Style="margin-left: 18px;"></asp:TextBox>
=======
                            <asp:TextBox class="form-control" ID="txtagency" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="3" runat="server" Style="margin-left: 18px"></asp:TextBox>
>>>>>>> f90ba1348131d10b95ac418fb8d75d3343734f03
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtagency"
                                ErrorMessage="Please Enter Your Name" ValidationGroup="Submit" ForeColor="Red">*</asp:RequiredFieldValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtagency" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Name</asp:RequiredFieldValidator>

                        </div>
                        <div class="col-4">
<<<<<<< HEAD
                            <label for="Phone">
                                Site Contact
=======
                            <label for="Phone">Contact Number (Site Owner)
>>>>>>> f90ba1348131d10b95ac418fb8d75d3343734f03
                                <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtPhone" onkeydown="return preventEnterSubmit(event)" onKeyPress="return isNumberKey(event);" TabIndex="4"
                                onkeyup="return isvalidphoneno();" MaxLength="10" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <span id="lblErrorContect" style="color: red"></span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtPhone" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Contact No.</asp:RequiredFieldValidator>

                        </div>
                    </div>
                    <div class="row">
                        <div class="col-8">
                            <label for="Address">
                                Address of Site(As Per Demand Notice of Utility or Electricity Bill)
                                <samp style="color: red">* </samp>
                            </label>
                            <%-- <asp:TextBox class="form-control" ID="txtAddress" onkeydown="return preventEnterSubmit(event)" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>--%>
                            <asp:TextBox class="form-control" ID="txtAddress" onkeydown="return preventEnterSubmit(event)" autocomplete="off" runat="server" TabIndex="5" Style="margin-left: 18px"></asp:TextBox>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtAddress" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Address</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-4" runat="server">
                            <label for="Pin">PinCode</label>
                            <asp:TextBox class="form-control" ID="txtPin" MaxLength="6" onkeydown="return preventEnterSubmit(event)" onkeyup="ValidatePincode();" onKeyPress="return isNumberKey(event);" autocomplete="off" TabIndex="7" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <span id="lblPinError" style="color: red"></span>

                        </div>


                    </div>
                    <div class="row">
                        <div class="col-4">
                            <label>
                                Type of Premises
                                <samp style="color: red">* </samp>
                            </label>
                            <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlPremises" selectionmode="Multiple" OnSelectedIndexChanged="ddlPremises_SelectedIndexChanged" Style="width: 100% !important">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" Text="Please Select Premises Type" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlPremises" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />

                        </div>
                        <div class="col-4" id="OtherPremises" runat="server">
                            <label for="OtherPremises">
                                Other Premises<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtOtherPremises" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="7" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtOtherPremises" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Other Premises</asp:RequiredFieldValidator>
                        </div>

                        <div class="col-4">
                            <label>
                                Highest Voltage Level of Work
                                <samp style="color: red">* </samp>
                            </label>
                            <asp:DropDownList class="form-control  select-form select2" Style="width: 100% !important;" TabIndex="8" ID="ddlVoltageLevel" runat="server">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" Text="Please Select Voltage Level" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlVoltageLevel" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />

                        </div>

                        <div class="col-4">

                            <label>
                                Work Details
        <samp style="color: red">* </samp>
                            </label>
                            <asp:ListBox ID="ddlWorkDetail" Style="width: 100% !important;" class="chosen-select form-control  select-form" value="select multiple" TabIndex="9" AutoPostBack="true" placeholder="your hint" runat="server" SelectionMode="Multiple"></asp:ListBox>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="ddlWorkDetail" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Work Details</asp:RequiredFieldValidator>

                            <asp:TextBox class="form-control" ID="WorkDetail" autocomplete="off" onkeydown="return preventEnterSubmit(event)" Visible="false" runat="server" Style="margin-left: 18px"></asp:TextBox>
                        </div>



                    </div>
                    <div class="row">

                        <%-- <div class="col-4" runat="server">
                            <label for="SiteContact">Contact Details of Site Owner</label>
                            <asp:TextBox class="form-control" ID="txtSiteContact" MaxLength="10" onkeydown="return preventEnterSubmit(event)" onkeyup="return isvalidphoneno2();" onKeyPress="return isNumberKey(event);" TabIndex="10" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <span id="lblErrorContect2" style="color: red"></span>

                        </div>--%>
                        <div class="col-4" runat="server">
                            <label for="Email">Email</label>
                            <asp:TextBox class="form-control" ID="txtEmail" onkeydown="return preventEnterSubmit(event)" onkeyup="return ValidateEmail();" TabIndex="10" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <span id="lblError" style="color: red"></span>

                        </div>
                    </div>

                </div>
                <h7 class="card-title fw-semibold mb-4">Work Schedule</h7>
                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">

                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                        <ContentTemplate>
                            <div class="row">
                                <div class="col-4">
                                    <label for="StartDate">
                                        Work Start Date<samp style="color: red"> * </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtStartDate" onkeydown="return preventEnterSubmit(event)" autocomplete="off" Type="Date" TabIndex="11" min='0000-01-01' max='9999-01-01' runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtStartDate" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Work Start Date</asp:RequiredFieldValidator>

                                </div>
                                <div class="col-4">
                                    <label for="CompletitionDate">
                                        Tentative Work Completition Date<samp style="color: red"> * </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtCompletitionDate" onkeydown="return preventEnterSubmit(event)" autocomplete="off" Type="Date" TabIndex="12" min='0000-01-01' max='9999-01-01' runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtCompletitionDate" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Work Completition Date</asp:RequiredFieldValidator>

                                </div>
                                <div class="col-4">
                                    <label>
                                        If any work issued by any Agency/ Dept. / Owner<samp style="color: red"> * </samp>
                                    </label>
                                    <asp:DropDownList class="form-control  select-form select2" ID="ddlAnyWork" Style="width: 100% !important;" OnSelectedIndexChanged="ddlAnyWork_SelectedIndexChanged" runat="server" TabIndex="13" AutoPostBack="true">
                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" Text="Please Select any work issued" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlAnyWork" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />

                                </div>


                            </div>

                            <div class="row">

                                <div class="col-4" id="hiddenfield" runat="server">
                                    <label class="form-label" for="customFile">
                                        Attached Copy of Work Order<samp style="color: red"> * </samp>

                                        <%--                            <asp:TextBox class="form-control" ID="txtcustomFile" Type="file" runat="server" Style="margin-left: 18px"></asp:TextBox>--%>
                                        <%-- <input type="file" id="customFile" runat="server" name="imageInput" CssClass="form-control" AutoPostBack="true" TabIndex="14" accept="image/*">--%>

                                        <asp:FileUpload ID="customFile" EnableViewState="true" runat="server" CssClass="form-control" TabIndex="14" Style="margin-left: 18px; padding: 0px; font-size: 15px;" />
                                        <asp:TextBox class="form-control" ID="customFileLocation" autocomplete="off" runat="server" Style="margin-left: 18px" Visible="false"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="customFile" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Select File</asp:RequiredFieldValidator>
                                </div>

                                <div class="col-4" id="hiddenfield1" runat="server">
                                    <label for="CompletionDateasperWorkOrder">
                                        Completion Date as per Work Order<samp style="color: red"> * </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtCompletionDateAPWO" onkeydown="return preventEnterSubmit(event)" TabIndex="15" autocomplete="off" Type="Date" min='0000-01-01' max='9999-01-01' runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtCompletionDateAPWO" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Completion Date as per Work Order</asp:RequiredFieldValidator>

                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div>
                    <h7 class="card-title fw-semibold mb-4">Assign Supervisor/Wireman Details For Above Work</h7>
                    <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                        <div class="row">
                            <div class="col-12">
                                <asp:UpdatePanel ID="UpdatePanel" runat="server">
                                    <ContentTemplate>

                                        <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="false" OnRowDataBound="GridView1_RowDataBound">
                                            <Columns>
                                                <asp:TemplateField Visible="False">
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="chkSelectAll" runat="server" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="CheckBox1" runat="server" HorizontalAlign="center" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="REID" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblREID" runat="server" Text='<%#Eval("REID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="REID" HeaderText="ID">
                                                    <HeaderStyle HorizontalAlign="center" Width="10%" />
                                                    <ItemStyle HorizontalAlign="center" Width="10%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Category" HeaderText="Category">
                                                    <HeaderStyle HorizontalAlign="center" Width="10%" />
                                                    <ItemStyle HorizontalAlign="center" Width="10%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Name" HeaderText="Name">
                                                    <HeaderStyle HorizontalAlign="Left" Width="16%" />
                                                    <ItemStyle HorizontalAlign="Left" Width="16%" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="DateOfExpiry" HeaderText="Expiry Date">
                                                    <HeaderStyle HorizontalAlign="right" Width="24%" />
                                                    <ItemStyle HorizontalAlign="right" Width="24%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="DateofRenewal" HeaderText="Valid Upto">
                                                    <HeaderStyle HorizontalAlign="right" Width="22%" />
                                                    <ItemStyle HorizontalAlign="right" Width="22%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="LicenseNo" HeaderText="License">
                                                    <HeaderStyle HorizontalAlign="right" Width="20%" />
                                                    <ItemStyle HorizontalAlign="right" Width="20%" />
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
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="row">
                                <div class="col-4"></div>
                                <div class="col-4" style="text-align: center;">
                                    <asp:Button type="submit" ID="btnSubmit" ValidationGroup="Submit" Text="Submit" runat="server" class="btn btn-primary mr-2" OnClick="Submit_Click" />
                                    <asp:Button type="submit" ID="btnReset" Text="Reset" runat="server" class="btn btn-primary mr-2" OnClick="Unnamed2_Click" />
                                    <asp:Button type="Back" ID="btnBack" Text="Back" runat="server" Visible="false" class="btn btn-primary mr-2" OnClick="btnBack_Click" />


                                </div>
                                <div class="col-4"></div>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btnSubmit" />
                            <asp:PostBackTrigger ControlID="btnReset" />
                            <asp:PostBackTrigger ControlID="btnBack" />
                        </Triggers>
                    </asp:UpdatePanel>
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
    <script type="text/javascript">
        function ValidatePincode() {
            var Pin1 = document.getElementById("<%=txtPin.ClientID %>");
            Pincode = Pin1.value;
            var lblPinError = document.getElementById("lblPinError");
            lblPinError.innerHTML = "";
            var expr = /\d{6}/;;
            if (Pincode == "") {
                lblPinError.innerHTML = "Please Enter Pincode" + "\n";
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
    <script>
        function preventEnterSubmit(event) {
            if (event.keyCode === 13) {
                event.preventDefault(); // Prevent form submission
                return false;
            }
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
        function SelectAllCheckboxes(headerCheckbox) {
            var checkboxes = document.querySelectorAll('[id*=CheckBox1]');
            for (var i = 0; i < checkboxes.length; i++) {
                checkboxes[i].checked = headerCheckbox.checked;
            }
        }
    </script>

    <script>
        $('.select2').select2();
    </script>
    <script>
        $(".chosen-select").chosen({
            no_results_text: "Oops, nothing found!"
        })
    </script>

    <script type="text/javascript">
        function validateForm() {
            var emptyFields = [];
            var worktype = document.getElementById('<%= ddlworktype.ClientID %>');
            var txtPhone = document.getElementById('<%= txtPhone.ClientID %>').value;
            var Address = document.getElementById('<%= txtAddress.ClientID %>').value;
            var Premises = document.getElementById('<%= ddlPremises.ClientID %>');
            var VoltageLevel = document.getElementById('<%= ddlVoltageLevel.ClientID %>');
            var WorkDetail = document.getElementById('<%= ddlWorkDetail.ClientID %>').value;
            var StartDate = document.getElementById('<%= txtStartDate.ClientID %>').value
            var CompletitionDate = document.getElementById('<%= txtCompletitionDate.ClientID %>').value;
            var AnyWork = document.getElementById('<%= ddlAnyWork.ClientID %>').value;


            if (worktype.selectedIndex === 0) {
                emptyFields.push('work type');

            }
            if (txtPhone.trim() === '') {
                emptyFields.push('Contact No.');

            }
            if (Address.trim() === '') {
                emptyFields.push('Address.');

            }

            if (Premises.selectedIndex === 0) {
                emptyFields.push('Select Premises');

            }
            if (VoltageLevel.selectedIndex === 0) {
                emptyFields.push('VoltageLevel.');

            }
            if (WorkDetail.selectedIndex === 0) {
                emptyFields.push('Work Details.');

            }

            if (StartDate.trim() === '') {
                emptyFields.push('PleaStartDate.');

            }
            if (CompletitionDate.trim() === '') {
                emptyFields.push('CompletitionDate.');

            }
            if (AnyWork.selectedIndex === 0) {
                emptyFields.push('Any work issued ?');

            }


            if (emptyFields.length > 0) {
                var message = 'Please enter values for the following fields:\n\n';
                message += emptyFields.join('\n');
                alert(message);
                return false;
            }
            else {

                return true;
            }

        }
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
