<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin_Master.Master" AutoEventWireup="true" CodeBehind="CESE_Registration.aspx.cs" Inherits="CEIHaryana.Admin.CESE_Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="shortcut icon" type="image/png" href="/css2/style.min.css" />
    <link rel="stylesheet" href="/css2/style.css" />
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css" />
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/css/select2.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/js/select2.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.5.2/css/bootstrap.css" rel="stylesheet" />
    <link href="https://cdn.datatables.net/1.13.5/css/dataTables.bootstrap4.min.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.7.0.js"></script>
    <script src="https://cdn.datatables.net/1.13.5/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.13.5/js/dataTables.bootstrap4.min.js"></script>
    <script src="https://kit.fontawesome.com/57676f1d80.js" crossorigin="anonymous"></script>
    <!-- Font Awesome CDN -->
<link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.0/css/all.min.css" rel="stylesheet" />

    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <style>
        .headercolor1 {
            text-align: initial !important;
        }

        td {
            padding: 10px !important;
        }

        .submit {
            border: 1px solid #563d7c;
            border-radius: 5px;
            color: white;
            padding: 5px 10px 5px 10px;
            background: left 3px top 5px no-repeat #563d7c;
        }

            .submit:hover {
                border: 1px solid #563d7c;
                border-radius: 5px;
                color: white;
                padding: 5px 10px 5px 10px;
                background: left 3px top 5px no-repeat #26005f;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
            }

        .table-dark {
            text-align: center !important;
            background-color: #9292cc !important;
        }

        .col-4 {
            margin-bottom: 15px;
        }

        .form-control {
            box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
            margin-left: 0px !important;
            height: 30px;
            font-size: 13px;
        }

        select.form-control {
            box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
            margin-left: 0px !important;
            height: 30px;
        }

        label {
            font-size: 14px;
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
            font-size: 12.5px !important;
        }


        input#ContentPlaceHolder1_txtagency {
            font-size: 12.5px;
        }

        .headercolor {
            background-color: #9292cc;
        }


        th {
            background: #9292cc;
        }

        .card .card-title {
            font-size: 20px !important;
            color: #010101;
            text-transform: capitalize;
            font-weight: 700;
        }

        div#row3 {
            margin-top: -20px;
        }

        svg#svgcross {
            height: 35px;
            width: 67px;
        }

        svg#svgcross1 {
            height: 35px;
            width: 67px;
        }

        svg#svgcross2 {
            height: 35px;
            width: 67px;
        }

        svg#search1:hover {
            height: 22px;
            width: 22px;
            fill: #4b49ac;
            transition: ease-out;
            margin-left: -2px;
            cursor: pointer;
        }

        th.textalignleft {
            text-align: justify !important;
            padding: 9px !important;
        }

        /*th.headercolor {
            width: 28% !important;
        }*/


        th {
            width: 1%;
        }


            th.headersizeSignature {
                width: 40% !important;
            }


        .input-box {
            display: flex;
            align-items: center;
            max-width: 300px;
            background: #fff;
            border: 1px solid #a0a0a0;
            border-radius: 4px;
            padding-left: 0.5rem;
            overflow: hidden;
            font-family: sans-serif;
        }

            .input-box .prefix {
                font-weight: 300;
                font-size: 14px;
                color: black;
            }

            .input-box input {
                flex-grow: 1;
                font-size: 14px;
                background: #fff;
                border: none;
                outline: none;
                padding: 0.5rem;
            }

            .input-box:focus-within {
                border-color: #777;
            }

        .row {
            margin-bottom: 15px;
        }

        input#ContentPlaceHolder1_txtSearch {
            font-size: 13px !important;
        }
        input#ContentPlaceHolder1_btnUploadNew {
    padding-top: 0px;
    padding-bottom: 1px;
}
        input#ContentPlaceHolder1_customFile {
    padding-top: 2px;
    padding-left: 2px;
}
    </style>
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
        function preventEnterSubmit(e) {

            if (e.keyCode === 13) {
                e.preventDefault();
                return false;
            }
            return true;
        }
    </script>



    <script type="text/javascript">
        function ValidateEmail() {

            var email1 = document.getElementById("<%=txtEmail.ClientID %>");
            email = email1.value;
            var lblError = document.getElementById("lblError");
            lblError.innerHTML = "";
            var expr = /\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/;
            if (email == "") {
                // lblError.innerHTML = "Please Enter Email" + "\n";
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div class="card" style="box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px; border-radius: 5px !important">
            <div class="card-body">
                <div class="row">
                    <div class="col-12" style="text-align: center;">
                        <h7 class="card-title fw-semibold mb-4" id="maincard" style="text-transform: uppercase;">Registration of Charted Electrical Safety Engineers</h7>
                    </div>
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

                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; border-radius: 5px !important">
                                <asp:HiddenField ID="hnOwnerId" runat="server" />
                    <div class="row" style="margin-bottom: 0px !important;">
                        <div class="col-md-4">
                            <label>
                                Name
                                <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtName" TabIndex="8" onkeydown="return preventEnterSubmit(event)" onKeyPress="return alphabetKey(event)" MaxLength="50" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" ValidationGroup="Submit" ForeColor="Red">Please Enter Name</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-4">
                            <label>
                                Pan No.
                              <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtPanNo" TabIndex="8" onkeydown="return preventEnterSubmit(event)" onkeyup="convertToUpperCase(event)" MaxLength="10" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPanNo" ValidationGroup="Submit" ForeColor="Red">Please Enter Pan No.</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-4">
                            <label for="Division">
                                Max Voltage Level(Kv)<samp style="color: red"> * </samp>
                            </label>
                           <asp:DropDownList Style="width: 100% !important;" class="form-control  select-form select2" ID="ddlVoltage" runat="server" TabIndex="16">
</asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Text="Please Select Voltage level" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlVoltage" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                        </div>

                    </div>
                    <div class="row" style="margin-bottom: 0px !important;">
                        <div class="col-md-8">
                            <label>
                                Address
                                        <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtAddress" TabIndex="8" onkeydown="return preventEnterSubmit(event)" MaxLength="50" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtAddress" ValidationGroup="Submit" ForeColor="Red">Please Enter Address</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-4">
                            <label>
                                District
                                <samp style="color: red">* </samp>
                            </label>
                            <asp:DropDownList class="form-control  select-form select2" AutoPostBack="true" Style="width: 100% !important;" ID="ddldistrict" TabIndex="2" runat="server">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator30" Text="Please Select any district" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddldistrict" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                        </div>

                    </div>

                    <div class="row" style="margin-bottom: 0px;">

                        <div class="col-md-4">
                            <label for="Division">
                                Mobile No.<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtContactNo" TabIndex="8" onkeydown="return preventEnterSubmit(event)" onKeyPress="return isNumberKey(event);" onkeyup="return isvalidphoneno();" MaxLength="10" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <span id="lblErrorContect" style="color: red"></span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtContactNo" ValidationGroup="Submit" ForeColor="Red">Please Enter Contact No.</asp:RequiredFieldValidator>

                        </div>
                        <div class="col-md-4">
                            <label>
                                Email Id.
                                        <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtEmail" TabIndex="9" onkeydown="return preventEnterSubmit(event)" onkeyup="return ValidateEmail();" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <span id="lblError" style="color: red"></span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="txtEmail" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Email Id</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-4" id="CeseCert" runat="server" visible="false">
                            <label class="form-label" for="customFile">
                                CESE Certificate(1MB PDF ONLY)<samp style="color: red"> * </samp>
                            </label>
                            <br />
                            <asp:FileUpload ID="customFile" runat="server" CssClass="form-control"
                                Style="margin-left: 18px; padding: 0px; font-size: 15px;" accept=".pdf" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                ControlToValidate="customFile" ErrorMessage="Required" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <asp:HiddenField ID="hnFile" runat="server" />
                        <div class="col-md-4" id="hiddenfield" runat="server" visible="false">
                            <label class="form-label" for="customFile">CESE Certificate</label><br />
                            <asp:LinkButton ID="lnkFile" runat="server" AutoPostBack="true" OnClick="lnkFile_Click" Text="Open Document" />
                            <asp:Button type="submit" ID="btnUploadNew" TabIndex="22" Text="Upload New" runat="server" class="btn btn-primary mr-2" OnClick="btnUploadNew_Click"/>

                        </div>
                    </div>
                  
                    <div class="row" style="margin-bottom: 30px !important;">
                        <div class="col-md-6" id="ForSubmit" runat="server" visible="false" style="text-align: end;">
                            <asp:Button type="submit" ID="btnSubmit" TabIndex="22" ValidationGroup="Submit" Text="Submit" runat="server" class="btn btn-primary mr-2" OnClick="btnSubmit_Click" />
                        </div>
                        <div class="col-md-6" id="ForUpdate" runat="server" visible="false" style="text-align: end;">
                            <asp:Button type="submit" ID="btnUpdate" TabIndex="22" Text="Update" runat="server" class="btn btn-primary mr-2" OnClick="btnUpdate_Click" />
                        </div>
                        <div class="col-md-6" style="text-align: justify;">
                            <asp:Button type="submit" ID="btnReset" TabIndex="22" Text="Reset" runat="server" class="btn btn-primary mr-2" OnClick="btnReset_Click" />
                        </div>


                    </div>
                    
                    
                    <%--  <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
       <ContentTemplate>--%>
                    <asp:HiddenField ID="hnRegistrationId" runat="server" />
                    <div class="card-body" id="SubDivision" runat="server" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">

                        <asp:GridView class="table-responsive table table-striped table-hover" ID="GridView1" runat="server" Width="100%"
                            AutoGenerateColumns="false" BorderWidth="1px" BorderColor="#dbddff" OnRowCommand="GridView1_RowCommand">
                            <Columns>

                                <asp:TemplateField HeaderText="SNo">
                                    <HeaderStyle Width="1%" CssClass="headercolor" />
                                    <ItemStyle Width="1%" HorizontalAlign="center"/>
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:BoundField DataField="Name" HeaderText="Name">
                                    <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                    <ItemStyle HorizontalAlign="center" Width="15%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PanNo" HeaderText="PanNo">
                                    <HeaderStyle HorizontalAlign="center" Width="10%" CssClass="headercolor" />
                                    <ItemStyle HorizontalAlign="center"  Width="10%"/>
                                </asp:BoundField>

                                <asp:BoundField DataField="Email" HeaderText="Email">
                                    <HeaderStyle HorizontalAlign="center" Width="10%" CssClass="headercolor" />
                                    <ItemStyle HorizontalAlign="center" Width="10%" />
                                </asp:BoundField>

                                <asp:BoundField DataField="ContactNo" HeaderText="Contact No">
                                    <HeaderStyle HorizontalAlign="center" CssClass="headercolor" />
                                    <ItemStyle HorizontalAlign="center" />
                                </asp:BoundField>

                                <asp:BoundField DataField="District" HeaderText="District">
                                    <HeaderStyle HorizontalAlign="center" Width="10%" CssClass="headercolor" />
                                    <ItemStyle HorizontalAlign="center" Width="10%" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Id" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRegistrationId" runat="server" Text='<%#Eval("RegistrationId") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete">
                                    <HeaderStyle Width="5%" CssClass="headercolor" />
                                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" ID="LinkButton" Style="padding: 0px 5px 0px 5px; font-size: 18px; border-radius: 3px;"
                                            Text="<i class='fa fa-trash' style='color:white !important;'></i>"
                                            CssClass="redButton btn-danger" CommandName="Print" CommandArgument="<%# Container.DataItemIndex %>" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Edit">
                                    <HeaderStyle Width="5%" CssClass="headercolor" />
                                    <ItemStyle Width="5%" HorizontalAlign="Center"  />
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" ID="LinkButton4" Style="padding: 0px 5px 0px 5px; font-size: 18px; border-radius: 3px;"
                                            Text="<i class='fa fa-edit' style='color:white !important;'></i>" CssClass='greenButton btn-primary' CommandName="Select" CommandArgument="<%# Container.DataItemIndex %>" />
                                    </ItemTemplate>
                                </asp:TemplateField>
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
                    <%--</ContentTemplate>
                </asp:UpdatePanel>--%>
                </div>

                <asp:HiddenField ID="hdnId" runat="server" />
                <asp:HiddenField ID="hdnId2" runat="server" />
                <div>
                </div>
            </div>
        </div>

        <footer class="footer">
        </footer>



        <script src="/Assets/js/chart.js/Chart.min.js"></script>
        <script src="/Assets/js/datatables.net/jquery.dataTables.js"></script>
        <script src="/Assets/js/datatables.net-bs4/dataTables.bootstrap4.js"></script>
        <script src="/Assets/js/dataTables.select.min.js"></script>
        <script src="/Assets/js/off-canvas.js"></script>
        <script src="/Assets/js/hoverable-collapse.js"></script>
        <script src="/Assets/js/template.js"></script>
        <script src="/Assets/js/settings.js"></script>
        <script src="/Assets/js/todolist.js"></script>
        <script src="/Assets/js/dashboard.js"></script>
        <script src="/Assets/js/Chart.roundedBarCharts.js"></script>
        
          <script type="text/javascript">
              function validatePAN() {
                  var panTextBox = document.getElementById('<%= txtPanNo.ClientID %>');
        
                  var panValue = panTextBox.value.toUpperCase(); // Convert to uppercase here

                  if (panValue.length > 0 && !panValidator.isvalid) {
                      alert("Please enter a valid PAN number.");
                      return false;
                  }
                  return true;
              }

              function convertToUpperCase(event) {
                  var textBox = event.target;
                  textBox.value = textBox.value.toUpperCase();
              }

              function preventEnterSubmit(e) {
                  // Prevent form submission on Enter key press
                  if (e.keyCode === 13) {
                      e.preventDefault();
                      return false;
                  }
                  return true;
              }
          </script>
</asp:Content>
