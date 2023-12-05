<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin_Master.Master" AutoEventWireup="true" CodeBehind="ChallanReport.aspx.cs" Inherits="CEIHaryana.Admin.ChallanReport" %>
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


   <%--<script type="text/javascript">
    $(document).ready(function () {
        $("#<%=txtDateofIntialissue.ClientID%>").datepicker({
            dateFormat: "dd/mm/yy",
            changeMonth: true,
            changeYear: true,
            minDate: -7,
            maxDate: +7
        });
        $("#<%=txtDateofIntialissue.ClientID%>").keydown(function () {
            //code to not allow any changes to be made to input field
            return false;
        });

        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
        function EndRequestHandler(sender, args) {
            $("#<%=txtDateofIntialissue.ClientID%>").datepicker({
                dateFormat: "dd/mm/yy",
                changeMonth: true,
                changeYear: true,
                minDate: -7,
                maxDate: +7
            });
            $("#<%=txtDateofIntialissue.ClientID%>").keydown(function () {
                //code to not allow any changes to be made to input field
                return false;
            });
        }
    });
    }
</script>--%>
   <%--<script type="text/javascript">
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
</script>--%>
   <%--<script type="text/javascript">
     function alertWithRedirectdata() {
         if (confirm('Data Added Successfully')) {
             window.location.href = "/Admin/AddContractorDetails.aspx";
         } else {
         }
     }
 </script>--%>
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
       input#ContentPlaceHolder1_FileUpload1{
           padding:3px;
       }
   </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="content-wrapper">
        <div class="card" style="box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px; border-radius: 5px !important">
            <div class="card-body">
                <div class="row">
                    <div class="col-md-4"></div>
                    <div class="col-sm-4" style="text-align: center; box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding-top: 8px; padding-bottom: 8px; border-radius: 10px; top: 0px; left: 0px;">
                        <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important;">CHALLLAN DETAILS</h6>
                    </div>
                    <br />
                    <div class="col-md-4"></div>
                </div>
               <%-- <h7 class="card-title fw-semibold mb-4">Personal Details</h7>--%>
                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 35px;">
                    <div class="row" style="margin-top:15px;">
                        <div class="col-4">
                            <label>
                                Inspection Request details   
                            </label>
                            <asp:DropDownList Style="width: 100% !important;" class="form-control select-form select2" ID="ddlState" TabIndex="8" runat="server" AutoPostBack="true">
                            </asp:DropDownList>
                        </div>
                        <div class="col-4">
                            <label>
                                Upload Challan
                            </label>
                            
                            <asp:FileUpload ID="FileUpload1" runat="server" class="form-control" />
                        </div>
                        
                    </div>
                </div>
                <div class="row" style="margin-top:15px;">
                    <div class="col-4"></div>
                    <div class="col-4" style="text-align: center;">
                        <asp:Button ID="BtnReset" Text="Submits" runat="server" class="btn btn-primary mr-2"
                            Style="padding-left: 17px; padding-right: 17px;" />
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
</asp:Content>
