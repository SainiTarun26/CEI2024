<%@ Page Title="" Language="C#" MasterPageFile="~/Supervisor/Supervisor.Master" AutoEventWireup="true" CodeBehind="DeAttachedRequestView.aspx.cs" Inherits="CEIHaryana.Supervisor.DeAttachedRequestView" %>
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
              <%--  <asp:UpdatePanel runat="server" ID="updatePanel">
                    <ContentTemplate>--%>
                        <div class="row">
                            <div class="col-md-4"></div>
                            <div class="col-md-4" style="text-align: center; box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding-top: 8px; padding-bottom: 8px; border-radius: 10px; top: 0px; left: 0px;">
                                <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important;">DE-ATTACH REQUEST</h6>
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
                                                <h7 class="card-title fw-semibold mb-4">Contractor Details</h7>
                        <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                            <div class="row" style="margin-bottom: 15px;">
                                <asp:HiddenField ID="hdnSupervisiorId" runat="server" />
                                    <asp:HiddenField ID="hdnId" runat="server" />
                                 <asp:HiddenField ID="hdnFile" runat="server" />
                               
                                 <div class="col-md-4">
                                     <label>
                                        Contractor Name
            <samp style="color: red">* </samp>
                                     </label>
                                    
     <asp:TextBox class="form-control" ID="txtContractorName" runat="server" autocomplete="off" ReadOnly="true" onKeyPress="return alphabetKey(event);" TabIndex="1"
         MaxLength="200" Style="margin-left: 18px;">
     </asp:TextBox>
 </div>
                                <div class="col-md-4">
                                    <label>
                                        Contractor Licence No.
                                        <samp style="color: red">* </samp>
                                    </label>

                                    <asp:TextBox class="form-control" ID="txtLicenceNo" runat="server" ReadOnly="true" autocomplete="off" TabIndex="1"
                                        MaxLength="200" Style="margin-left: 18px;">
                                    </asp:TextBox>
                                </div>
                                                          <div class="col-md-4">
                              <label>
                                  Firm Name
<samp style="color: red">* </samp>
                              </label>

                              <asp:TextBox class="form-control" ID="txtFirmName" runat="server" ReadOnly="true" autocomplete="off" TabIndex="1"
                                  MaxLength="200" Style="margin-left: 18px;">
                              </asp:TextBox>
                          </div>
                            </div>
                            <div class="row">

                               
                                <div class="col-md-4">
                                 <label>
                                Email Id
<samp style="color: red">* </samp>
                              </label>
                                   
                                    <asp:TextBox class="form-control" ID="TxtEmailId" runat="server" ReadOnly="true" autocomplete="off" TabIndex="1"
                                        MaxLength="200" Style="margin-left: 18px;">
                                    </asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                   <label>
                              Contact No.
<samp style="color: red">* </samp>
                              </label>
                             
                                    <asp:TextBox class="form-control" ID="TxtContactNo" runat="server" ReadOnly="true" autocomplete="off" TabIndex="1"
                                        MaxLength="200" Style="margin-left: 18px;">
                                    </asp:TextBox>
                                </div>
                               

                                </div>
                                                           

                                </div>
                                        <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">

                            <div class="row" style="margin-top:15px;">
                                                               <div class="col-md-4">
                     <label class="form-label" for="customFile">Attachment</label><br />
                   <asp:LinkButton ID="lnkFile" runat="server" AutoPostBack="true" OnClick="lnkFile_Click" Text="Open Document" style="margin-left:-65px;"/>
</div>
                                                                                           <div class="col-md-4">
                                                       <label>
                            Application Status
<samp style="color: red">* </samp>
                              </label>
                             
                                    <asp:TextBox class="form-control" ID="txtStatus" runat="server" ReadOnly="true" autocomplete="off" TabIndex="1"
                                        MaxLength="200" Style="margin-left: 18px;">
                                    </asp:TextBox>
</div>

                                <div class="col-md-12">
                                    <label>
                                        Remarks
                                        <samp style="color: red">* </samp>
                                    </label>
                               
<asp:TextBox class="form-control" ID="txtRemarks" runat="server" ReadOnly="true" autocomplete="off" onKeyPress="return alphabetKey(event);" TabIndex="1"
    MaxLength="200" Style="margin-left: 18px;" >
</asp:TextBox>
                                  
                                                                     </div>
                            </div>
                                            </div>
                        </div>
                <%--    </ContentTemplate>
                </asp:UpdatePanel>--%>
                <div class="row">
                    <div class="col-md-4"></div>
                    <div class="col-md-4" style="text-align: center;">
                        <asp:Button ID="btnToDeattach" Text="Back" runat="server"  class="btn btn-primary mr-2" OnClick="btnToDeattach_Click"/>
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
    
</asp:Content>