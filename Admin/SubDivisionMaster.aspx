<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin_Master.Master" AutoEventWireup="true" CodeBehind="SubDivisionMaster.aspx.cs" Inherits="CEIHaryana.Admin.SubDivisionMaster" %>
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

        th.headercolor {
            width: 28% !important;
        }


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
         function ValidateEmail() {
             debugger;
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="card" style="box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px; border-radius: 5px !important">
            <div class="card-body">
                <div class="row">
                    <div class="col-12" style="text-align: center;">
                        <h7 class="card-title fw-semibold mb-4" id="maincard">SUB-DIVISION MASTER</h7>
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
                <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>--%>
                <div class="card-body" style="box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px; border-radius: 5px !important">

                    <div class="row">
                        <div class="col-md-6">
                            <label>
                                Power Utility
             <samp style="color: red">* </samp>
                            </label>
                            <asp:DropDownList class="form-control  select-form select2" AutoPostBack="true" Style="width: 100% !important;" ID="ddlUtility" TabIndex="2" runat="server" OnSelectedIndexChanged="ddlUtility_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator26" Text="Please Select Utility name" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlUtility" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                        </div>
                        <div class="col-md-6">
                            <label>
                                Wing
          <samp style="color: red">* </samp>
                            </label>
                            <asp:DropDownList class="form-control  select-form select2" AutoPostBack="true" Style="width: 100% !important;" ID="ddlWing" TabIndex="3" runat="server" OnSelectedIndexChanged="ddlWing_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator27" Text="Please Select Wing name" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlWing" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <label>
                                Zone 
        <samp style="color: red">* </samp>
                            </label>
                            <asp:DropDownList class="form-control  select-form select2" AutoPostBack="true" Style="width: 100% !important;" ID="ddlZone" TabIndex="2" runat="server" OnSelectedIndexChanged="ddlZone_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator28" Text="Please Select Zone name" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlZone" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                        </div>
                        <div class="col-md-6">
     <label>
         Circle
         <samp style="color: red">* </samp>
     </label>
     <asp:DropDownList class="form-control  select-form select2" AutoPostBack="true" Style="width: 100% !important;" ID="ddlCircle" TabIndex="2" runat="server" OnSelectedIndexChanged="ddlCircle_SelectedIndexChanged">
     </asp:DropDownList>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator29" Text="Please Select Applicant Type" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlCircle" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
 </div>
                                      
                    </div>
                  
                    <div class="row" style="margin-bottom:0px;">
                        <div class="col-md-6">
                            <label for="Division">
                                Division Name<samp style="color: red"> * </samp>
                            </label>
                           <asp:DropDownList class="form-control  select-form select2" AutoPostBack="true" Style="width: 100% !important;" ID="ddlDivision" TabIndex="2" runat="server" OnSelectedIndexChanged="ddlDivision_SelectedIndexChanged">
                    </asp:DropDownList>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator30" Text="Please Select Division name" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlDivision" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                        
                        </div>
                        <div class="col-md-6">
                            <label>
                                Sub Division
                                <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtSubDivision"  onkeydown="return preventEnterSubmit(event)"  onKeyPress="return alphabetKey(event);" TabIndex="8" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                           
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtSubDivision" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Division Name</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <label for="Division">

                                Email<samp style="color: red"> * </samp>
                            </label>
                             <asp:TextBox class="form-control" ID="txtEmail" TabIndex="9"  onkeydown="return preventEnterSubmit(event)" placeholder="ABC@gmail.com" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                       
                            <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ValidationExpression="^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$" ValidationGroup="Submit"
                          ErrorMessage="Enter a valid Email" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtEmail" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter valid Email</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-6">
                            <label>
                                Phone N0.
                                <samp style="color: red">* </samp>
                            </label>
                               <asp:TextBox class="form-control" ID="txtPhone" TabIndex="8" onkeydown="return preventEnterSubmit(event)" onKeyPress="return isNumberKey(event);" onkeyup="return isvalidphoneno();" MaxLength="10" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <span id="lblErrorContect" style="color: red"></span>
 <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPhone" ValidationGroup="Submit" ForeColor="Red">Please Enter Contact No.</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12" style="text-align: center;">
                            <asp:Button type="submit" ID="btnSubmit" TabIndex="22" ValidationGroup="Submit" Text="Submit" runat="server" class="btn btn-primary mr-2" OnClick="btnSubmit_Click" />
                        </div>
                    </div>
                </div>
                <%--</ContentTemplate></asp:UpdatePanel>--%>
                <asp:HiddenField ID="hdnId" runat="server" />
                <asp:HiddenField ID="hdnId2" runat="server" />
                <div>
                </div>
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
</asp:Content>