<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin_Master.Master" AutoEventWireup="true" CodeBehind="Supervisor_Upgradation_Details.aspx.cs" Inherits="CEIHaryana.Admin.Supervisor_Upgradation_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="shortcut icon" type="image/png" href="/css2/style.min.css" />
    <link rel="stylesheet" href="/css2/style.css" />
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css" />
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.7.2/font/bootstrap-icons.css" rel="stylesheet" />
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <!------ Include the above in your HEAD tag ---------->
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>

    <!---------------------   Dropdown With Search Option   ---------------------->
    <%-- <link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/css/select2.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/js/select2.min.js"></script>--%>

    <link href="ScriptCalendar/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="ScriptCalender/jquery-1.11.0.min.js"></script>
    <script type="text/javascript" src="ScriptCalender/jquery-ui.min.js"></script>
    <style>
        .glyphicon {
            position: relative;
            top: 1px;
            display: inline-block;
            font-family: 'Glyphicons Halflings';
            -webkit-font-smoothing: antialiased;
            font-style: normal;
            font-weight: normal;
            line-height: 1
        }

        .glyphicon-search:before {
            content: "\e003"
        }

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
            font-size: 13px;
            padding: 14px 15px 0px 15px;
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
            padding: 13px;
            font-size: 13px;
        }

        label {
            float: left;
        }

        span {
            display: block;
            overflow: hidden;
            padding: 0px 4px 0px 6px;
        }

        td {
            padding: 10px 10px 10px 10px !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
    <div class="content-wrapper">
        <div class="card" style="box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px; border-radius: 5px !important">
            <div class="card-body">
                <asp:UpdatePanel runat="server" ID="updatePanel">
                    <ContentTemplate>
                        <div class="row">
                            <div class="col-md-4"></div>
                            <div class="col-md-4" style="text-align: center; box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding-top: 8px; padding-bottom: 8px; border-radius: 10px; top: 0px; left: 0px;">
                                <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important;">LICENCE UPGRADATION REQUEST</h6>
                            </div>
                            <br />
                            <div class="col-md-4"></div>
                        </div>
                        <div class="row">
                            <div class="col-md-4"></div>
                            <div class="col-md-4" style="text-align: center;">
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
                            <div class="row" style="margin-bottom: 15px;">
                                <asp:HiddenField ID="hdnId" runat="server" />
                                <div class="col-md-4" style="margin-top: 15px;">
    <label>
        Current scope Voltage level
        <samp style="color: red">* </samp>
    </label>
    <asp:TextBox class="form-control" ID="txtCurrentVoltage" ReadOnly="true" runat="server" autocomplete="off" TabIndex="1"
        MaxLength="200" Style="margin-left: 18px;" onchange="validateInterviewDate();">
    </asp:TextBox>
</div>
                                <div class="col-md-4" style="margin-top: 15px;">
    <label>
        Scope Voltage level applied for
        <samp style="color: red">* </samp>
    </label>
    <asp:TextBox class="form-control" ID="txtScopeVoltage"  ReadOnly="true" runat="server" autocomplete="off" TabIndex="1"
        MaxLength="200" Style="margin-left: 18px;" >
    </asp:TextBox>
</div>
                                <div class="col-md-4" style="margin-top: 15px;">
                                    <label>
                                       Name<samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtName"  ReadOnly="true" runat="server" autocomplete="off"  onKeyPress="return alphabetKey(event);" TabIndex="1"
                                        Style="margin-left: 18px;">
                                    </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ErrorMessage="Required" ControlToValidate="txtName" runat="server" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />

                                </div>

                                <div class="col-md-4" style="margin-top: 15px;">
                                    <label>
                                        Date Of Birth<samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtDob" runat="server"  ReadOnly="true" autocomplete="off"  
                                          Style="margin-left: 18px;" AutoPostBack="true">
                                    </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator20" ErrorMessage="Required" ControlToValidate="txtDob" runat="server" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                </div>
                                <div class="col-md-4" style="margin-top: 15px;">
                                    <label>
                                        Current Age<samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtCurrentAge" runat="server" autocomplete="off"  ReadOnly="true" 
                                         Style="margin-left: 18px;">
                                    </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator21" ErrorMessage="Required" ControlToValidate="txtCurrentAge" runat="server" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                </div>

                                <div class="col-md-4" style="margin-top: 15px;" runat="server" id="OldCertificate">
                                    <label>
                                        Old Certificate No.<samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtOldCertificateNo"  ReadOnly="true" runat="server" autocomplete="off"  
                                         Style="margin-left: 18px;">
                                    </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ErrorMessage="Required" ControlToValidate="txtOldCertificateNo" runat="server" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                </div>
                                <div class="col-md-4" style="margin-top: 15px;">
                                    <label>
                                        New Certificate No.<samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtNewCertificateNo" runat="server" autocomplete="off"  
                                        ReadOnly="true" Style="margin-left: 18px;">
                                    </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ErrorMessage="Required" ControlToValidate="txtNewCertificateNo" runat="server" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                </div>
                                <div class="col-md-4" style="margin-top: 15px;">
                                    <label>
                                        Date of Issue<samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtIssueDate" runat="server" autocomplete="off"  
                                       ReadOnly="true"  Style="margin-left: 18px;">
                                    </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ErrorMessage="Required" ControlToValidate="txtIssueDate" runat="server" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                </div>
                                <div class="col-md-4" style="margin-top: 15px;">
    <label>
       Higher Qualification
        <samp style="color: red">* </samp>
    </label>
    <asp:TextBox class="form-control" ID="txtQualification"  ReadOnly="true" runat="server" autocomplete="off" TabIndex="1"
         Style="margin-left: 18px;">
    </asp:TextBox>
</div>
                                 <div class="col-md-4" id="otherQualification" visible="false" runat="server">
     <label>
         Other Qualification<samp style="color: red">* </samp>
     </label>
     <asp:TextBox class="form-control" ID="txtOtherQualification" runat="server" autocomplete="off" TabIndex="1"
         Style="margin-left: 18px;">
     </asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ErrorMessage="Required" ControlToValidate="txtQualification" runat="server" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
 </div>
                            </div>
                            <div class="row">                           
                                <div class="col-md-4">
    <label>
        Experience (in years & months)<samp style="color: red">* </samp>
    </label>
    <asp:TextBox class="form-control" ID="txtExperience" readonly="true" runat="server" autocomplete="off" TabIndex="1"
        MaxLength="200" Style="margin-left: 18px;">
    </asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ErrorMessage="Required" ControlToValidate="txtExperience" runat="server" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
</div>
                                  <div class="col-md-8">
      <label>
          Address<samp style="color: red">* </samp>
      </label>
      <asp:TextBox class="form-control" ID="txtAddress" readonly="true"  runat="server" autocomplete="off" TabIndex="1"
           Style="margin-left: 18px;">
      </asp:TextBox>
      <asp:RequiredFieldValidator ID="RequiredFieldValidator14" ErrorMessage="Required" ControlToValidate="txtAddress" runat="server" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
  </div>
                                                               <div class="col-md-4" style="margin-top:15px;">
                                   <label>
                                       State<samp style="color: red">* </samp>
                                   </label>
                                  <asp:TextBox class="form-control" ID="txtState" runat="server" autocomplete="off" TabIndex="1"
                                      readonly="true"  Style="margin-left: 18px;">
                                   </asp:TextBox>
                               </div>
                               <div class="col-md-4" style="margin-top:15px;">
                                   <label>
                                       District<samp style="color: red">* </samp>
                                   </label>

                                   <asp:TextBox class="form-control" ID="txtDistrict" runat="server" autocomplete="off" TabIndex="1"
                                       readonly="true"  Style="margin-left: 18px;">
                                   </asp:TextBox>
                               </div>
                               <div class="col-md-4" style="margin-top:15px;">
                                   <label>
                                       Pincode<samp style="color: red">* </samp>
                                   </label>
                                   <asp:TextBox class="form-control" autocomplete="off" readonly="true"  MaxLength="6" ID="txtPin" onkeypress="return isNumberKey(event)" Style="padding: 0px 0px 0px 5px; height: 30px;" TabIndex="10" runat="server"> </asp:TextBox>
                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator7" CssClass="validation_required" runat="server" ControlToValidate="txtPin"
                                       ErrorMessage="Please Enter Your Pincode" ValidationGroup="Submit" ForeColor="Red">Required</asp:RequiredFieldValidator>
                                   <asp:RegularExpressionValidator
                                       ID="RegexValidatorPin"
                                       runat="server"
                                       ControlToValidate="txtPin"
                                       ValidationExpression="^\d{6}$"
                                       ErrorMessage="Pincode must be exactly 6 digits"
                                       ForeColor="Red"
                                       ValidationGroup="Submit">
                                   </asp:RegularExpressionValidator>
                               </div>
                                </div>
                            <div class="row">
                                  <div class="col-md-4" style="margin-top:-30px;">
      <label>
          Applied for upgradation earlier? If yes, mention interview date.<samp style="color: red">* </samp>
      </label>
  
      <asp:TextBox class="form-control" ID="txtrblbelated"  ReadOnly="true" AutoPostBack="true" runat="server" autocomplete="off" TabIndex="1"
          MaxLength="200" Style="margin-left: 18px;">
      </asp:TextBox>
  </div>
  <div class="col-md-4" runat="server" id="InterviewDate" visible="false" style="margin-top:-30px;">
      <label>
          Date of Interview
          <samp style="color: red">* </samp>
      </label>
      <asp:TextBox class="form-control" ID="txtInterviewDate"  ReadOnly="true" runat="server"  autocomplete="off" TabIndex="1"
          MaxLength="200" Style="margin-left: 18px;">
      </asp:TextBox>
      <asp:RequiredFieldValidator ID="RequiredFieldValidator19" ErrorMessage="Required" ControlToValidate="txtInterviewDate" runat="server" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
  </div>
                                
                            </div>
                          
                           
                        </div>
                        <h7 class="card-title fw-semibold mb-4">Upload Documents</h7>
                        <text style="color: red; font-size: 12px;" id="text3" runat="server" visible="true">(Upload Only PDF File not more than 1mb.)</text>

                        <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                            <div class="row" style="padding: 0px 15px 0px 15px;">

                                <table class="table table-bordered table-striped">
                                    <tbody>
                                       <tr>
                                           <th>Document Name</th>
                                           <th style="text-align:center;">View Document</th>
                                       </tr>
                                        <tr>
                                            <td style="margin-top: auto; margin-bottom: auto;">Copy of the Certificate of Competency. 
                                            </td>
                                            <td style="text-align: center;">
                                                <asp:LinkButton ID="lnkcompetencyCertificate" runat="server" OnClick="lnkcompetencyCertificate_Click">View Document</asp:LinkButton>
                                              <%--  <asp:FileUpload ID="FileUpload2" runat="server" CssClass="form-control" Style="margin-left: 18px; padding: 0px; font-size: 15px; height: 28px !important;" accept=".pdf" />--%>
                                                 </td>

                                        </tr>
                                        <tr>
                                            <td style="margin-top: auto; margin-bottom: auto;">Copy of Certificate of Experience.
                                            </td>
                                            <td style="text-align: center;">
                                                 <asp:LinkButton ID="lnkexperienceCertificate" runat="server" OnClick="lnkexperienceCertificate_Click">LinkButton</asp:LinkButton>
                                                <%--<asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control" Style="margin-left: 18px; padding: 0px; font-size: 15px; height: 28px !important;" accept=".pdf" />--%>
                                                  </td>

                                        </tr>
                                        <tr id="MedicalCertificate" runat="server" visible="false">
                                            <td style="margin-top: auto; margin-bottom: auto;">Copy of Medical Certificate. 
                                            </td>
                                            <td style="text-align: center;">
                                                 <asp:LinkButton ID="lnkMedicalCertificate" runat="server" OnClick="lnkMedicalCertificate_Click">LinkButton</asp:LinkButton>
                                               <%-- <asp:FileUpload ID="FileUpload3" runat="server" CssClass="form-control" Style="margin-left: 18px; padding: 0px; font-size: 15px; height: 28px !important;" accept=".pdf" />--%>
                                               </td>

                                        </tr>
                                    </tbody>
                                </table>
                            </div>

                        </div>

                        <div class="card-title" style="margin-bottom: 20px; margin-top: 15px; font-size: 17px; font-weight: 600; margin-left: 5px;">
                            Action Required
                        </div>
                        <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">



                            <div class="row" id="Action" runat="server" visible="True" style="padding-left: 0px;">
                                <asp:RadioButtonList ID="RdbtnAccptReturn" AutoPostBack="true" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="RdbtnAccptReturn_SelectedIndexChanged" TabIndex="25">
                                    <asp:ListItem Text="Approve &nbsp;" Value="0" style="margin-top: auto; margin-bottom: auto; padding-left: 10px;"></asp:ListItem>
                                    <asp:ListItem Text="Reject &nbsp;" Value="1" style="margin-top: auto; margin-bottom: auto; padding-left: 10px;"></asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ErrorMessage="Choose one" ControlToValidate="RdbtnAccptReturn" runat="server" ValidationGroup="Submit" SetFocusOnError="true" ForeColor="Red" />
                            </div>
                            <div class="row" id="DivReason" runat="server" visible="false" style="padding-left: 20px;margin-top:20px;">
                                <label>
                                    Reject Reason<samp style="color: red">* </samp>
                                </label>
                                <asp:TextBox class="form-control" ID="txtRejectReason" runat="server" autocomplete="off" TabIndex="1"
                                    MaxLength="200" Style="margin-left: 18px;">
                                </asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="Required" ControlToValidate="txtInterviewDate" runat="server" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />

                            </div>

                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="row">
                    <div class="col-md-4"></div>
                    <div class="col-md-4" style="text-align: center;">
                        <asp:Button ID="btnSubmit" Text="Submit" runat="server" OnClick="btnSubmit_Click" ValidationGroup="Submit" class="btn btn-primary mr-2" />
                    </div>
                </div>
                <asp:HiddenField ID="HFVoltage" runat="server" />
                <asp:HiddenField ID="HFUserID" runat="server" />
                 <asp:HiddenField ID="HFApplicationId" runat="server" />
              
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
    <script type="text/javascript">
        function validateInterviewDate() {
            var input = document.getElementById('<%= txtInterviewDate.ClientID %>');
            var selectedDate = new Date(input.value);
            var today = new Date();

            today.setHours(0, 0, 0, 0);
            selectedDate.setHours(0, 0, 0, 0);

            if (selectedDate >= today) {
                alert("Today and future dates are not allowed.");
                input.value = "";
                return false;
            }
            return true;
        }
    </script>


    <script type="text/javascript">
        function validateDOB() {
            var dobInput = document.getElementById('<%= txtDob.ClientID %>');
            var ageInput = document.getElementById('<%= txtCurrentAge.ClientID %>');
            var selectedDate = new Date(dobInput.value);
            var today = new Date();

            // Normalize both dates (remove time)
            today.setHours(0, 0, 0, 0);
            selectedDate.setHours(0, 0, 0, 0);

            // Check if DOB is today or future
            if (selectedDate >= today) {
                alert("Date of Birth cannot be today or a future date.");
                dobInput.value = "";
                if (ageInput) {
                    ageInput.value = "";
                }
                return false;
            }

            // Calculate age in years
            var years = today.getFullYear() - selectedDate.getFullYear();
            var months = today.getMonth() - selectedDate.getMonth();
            var days = today.getDate() - selectedDate.getDate();

            if (months < 0 || (months === 0 && days < 0)) {
                years--;
            }

            // Check if age is 18 or below
            if (years < 18) {
                alert("You must be at least 18 years old to apply.");
                dobInput.value = "";
                if (ageInput) {
                    ageInput.value = "";
                }
                return false;
            }

            // If txtCurrentAge input exists, populate it
            if (ageInput) {
                ageInput.value = years + " years";
            }

            return true;
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


</asp:Content>
