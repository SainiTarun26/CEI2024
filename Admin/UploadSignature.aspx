﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin_Master.Master" AutoEventWireup="true" CodeBehind="UploadSignature.aspx.cs" Inherits="CEIHaryana.Admin.UploadSignature" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="shortcut icon" type="image/png" href="/css2/style.min.css" />
    <link rel="stylesheet" href="/css2/style.css" />
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css" />
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css" />
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/css/select2.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/js/select2.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
    <script src="https://cdn.rawgit.com/harvesthq/chosen/gh-pages/chosen.jquery.min.js"></script>
    <link href="https://cdn.rawgit.com/harvesthq/chosen/gh-pages/chosen.min.css" rel="stylesheet" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/css/select2.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.2/css/solid.min.css" integrity="sha512-P9pgMgcSNlLb4Z2WAB2sH5KBKGnBfyJnq+bhcfLCFusrRc4XdXrhfDluBl/usq75NF5gTDIMcwI1GaG5gju+Mw==" crossorigin="anonymous" referrerpolicy="no-referrer" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/js/select2.min.js"></script>
    <script defer src="https://use.fontawesome.com/releases/v5.15.4/js/all.js" integrity="sha384-rOA1PnstxnOBLzCLMcre8ybwbTmemjzdNlILg8O7z1lUkLXozs4DHonlDtnE7fpc" crossorigin="anonymous"></script>
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
            if (confirm('Intimation Created Successfully')) {
                window.location.href = "/Contractor/Work_Intimation.aspx";
            } else {
            }
        }
    </script>
    <script type="text/javascript">
        function alertWithRedirectUpdation() {
            if (confirm('Intimation Updated Successfully')) {
                window.location.href = "/Contractor/PreviousProjects.aspx";
            } else {
            }
        }
    </script>
    <style>
        img {
            height: 60px !important;
            width: 150px !important;
            max-width: 126% !important;
        }

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
            color: white;
            text-align: center !important;
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

        table {
            width: 100%;
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

        th.headercolor1 {
            width: 15%;
        }

        th.headercolor3 {
            width: 12%;
        }

        th.headercolor4 {
            width: 20%;
        }

        th.headersizeSignature {
            width: 17%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="card" style="box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px; border-radius: 5px !important">
            <div class="card-body">
                <div class="row">
                    <div class="col-12" style="text-align: center;">
                        <h7 class="card-title fw-semibold mb-4" id="maincard">SIGNATURE UPLOAD</h7>
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
                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                    <div>
                        <div class="row" style="margin-bottom: 8px;">
                            <div class="col-12">
                                <h7 class="card-title fw-semibold mb-4" style="margin-top: 5%; font-size: 18px !important;">Officers Signature Upload</h7>
                            </div>
                        </div>
                        <div class="card" style="padding: 15px; box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px; padding-bottom: 30px;">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="row">
                                        <div class="col-sm-6">
                                            <label>
                                                Division Name
                                                <samp style="color: red">* </samp>
                                            </label>
                                            <asp:DropDownList class="form-control  select-form select2" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDivisionName_SelectedIndexChanged" ID="ddlDivisionName" TabIndex="10" selectionmode="Multiple" Style="width: 100% !important">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" Text="Please Select any division" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlDivisionName" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                        </div>
                                        <div class="col-sm-6">
                                            <label>
                                                Staff
                                               <samp style="color: red">* </samp>
                                            </label>
                                            <asp:DropDownList class="form-control  select-form select2" runat="server" AutoPostBack="true" ID="ddlstaffname" TabIndex="10" selectionmode="Multiple" Style="width: 100% !important">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Text="Please Select StaffName" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlstaffname" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <div class="row">
                                <div class="col-md-8" style="margin-top: 15px;">
                                    <label for="formFile" class="form-label">
                                        Upload Signature<samp style="color: red">* </samp>
                                        <samp style="color: red; font-weight: 800; font-size: 12px;"><b>(Max Dimensions 300 X 110 pixel, Image size 1 MB , Image Format .jpg ,jpeg,.png only)</b></samp>
                                    </label>
                                    <asp:FileUpload class="form-control" ID="Signature" runat="server" Style="padding: 2px;" accept=".jpg, jpeg ,.png  " />
                                              <asp:TextBox class="form-control" ID="txtsignature" Visible="false" ReadOnly="true" MaxLength="6" autocomplete="off" TabIndex="7" runat="server" Style="margin-left: 18px"></asp:TextBox>
                   </div>

                                <div runat="server" id="OTPVERIFICATION" visible="false" class="col-md-4" style="margin-top: 15px;">
                                    <label for="formFile" class="form-label">
                                        Enter OTP<samp style="color: red">* </samp>

                                    </label>
                                    <asp:TextBox class="form-control" ID="txtOTP" autocomplete="off"
                                        runat="server" MaxLength="50"
                                        TabIndex="17" />
                                </div>
                            </div>
                        </div>
                        <div class="row" style="margin-top: 25px; margin-bottom: -15px;">
                            <div class="col-4" style="margin-top: auto;"></div>
                            <div class="col-4" style="margin-top: auto; text-align: center;">


                                <asp:Button type="submit" ID="BtnSentOtp" TabIndex="23" Text="Submit" runat="server" class="btn btn-primary mr-2" Style="padding-left: 18px; padding-right: 18px;" OnClick="BtnSendotp_Click" />
                                <asp:Button type="submit" ID="BtnSubmit" TabIndex="23" Visible="false" Text="Submit" runat="server" class="btn btn-primary mr-2" Style="padding-left: 18px; padding-right: 18px;" OnClick="BtnSubmit_Click" />
     <br />   <text id="Resendotp" runat="server" visible="false">(An OTP has been sent to the email. If you have not received yet, please <asp:LinkButton ID="LinkButton4" runat="server" AutoPostBack="true" OnClick="LinkButton4_Click">click here to resend</asp:LinkButton> .)</text>
                                                    
 </div>
                        </div>
                        <div class="card" style="padding: 15px; box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px; padding-bottom: 30px; margin-top: 20px;">
                            <asp:GridView ID="gvImages" runat="server" AutoGenerateColumns="false" OnRowCommand="gvImages_RowCommand" OnRowDataBound="gvImages_OnRowDataBound">
                                <Columns>

                                    <asp:BoundField DataField="DivisionName" HeaderText="DivisionName">
                                        <HeaderStyle HorizontalAlign="center" CssClass="headercolor1 headercolor" />
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Staff" HeaderText="User Id">
                                        <HeaderStyle HorizontalAlign="center" CssClass="headercolor2 headercolor" />
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Staff" HeaderText="User Name">
                                        <HeaderStyle HorizontalAlign="center" CssClass="headercolor2 headercolor" />
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="StaffUserId" HeaderText="Staff Id">
                                        <HeaderStyle HorizontalAlign="center" CssClass="headercolor3 headercolor" />
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Designation" HeaderText="Designation">
                                        <HeaderStyle HorizontalAlign="center" CssClass="headercolor4 headercolor" />
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>


                                    <asp:TemplateField HeaderText="Signature" HeaderStyle-CssClass="headersizeSignature headercolor">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSignatureStatus" runat="server" Text="Not Uploaded" Visible="false"></asp:Label>
                                            <asp:Image ID="ImageUrl" runat="server" Visible="false" />

                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="center" CssClass="headercolor headersizeSignature" />
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText=" ">
                                        <HeaderStyle ForeColor="White" HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:ImageButton
                                                ID="btnDelete"
                                                runat="server"
                                                ImageUrl="/Image/Image/ImageToDelete-removebg-preview.png"
                                                CommandArgument='<%# Eval("Id") %>'
                                                CommandName="DeleteRow"
                                                CssClass="delete-button"
                                                Style="display: block; margin: 0 auto; height: 30px; width: 30px;" />
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                </Columns>
                            </asp:GridView>
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



    <script src="/Assets/js/js/vendor.bundle.base.js"></script>
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
        function FileName() {
            var fileInput = document.getElementById('customFile');
            var selectedFileName = document.getElementById('customFileLocation');

            if (fileInput.files.length > 0) {
                // Update the TextBox value with the selected file name
                selectedFileName.value = fileInput.files[0].name;
            }
        }
    </script>
    <script type="text/javascript">
        function alertWithRedirect() {
            if (confirm('User Created Successfully User Id And password will be sent Via Text Mesaage.')) {
                window.location.href = "/Contractor/Work_Intimation.aspx";
            } else {
            }
        }

    </script>
    <script>
        window.onload = function () {
            checkLoginBeforeSubmit();
        };

        function checkLoginBeforeSubmit() {
            // Check if user is already logged in another tab
            localStorage.removeItem('activeSession');
            sessionStorage.clear();
            // window.location.href = 'Login.aspx';
        }
    </script>
</asp:Content>
