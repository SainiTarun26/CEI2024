<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Print_New_Registration_Information_Contractor.aspx.cs" Inherits="CEIHaryana.Print_Forms.Print_New_Registration_Information_Contractor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="shortcut icon" type="image/png" href="/css2/style.min.css" />
    <link rel="stylesheet" href="/css2/style.css" />
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" />
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <!------ Include the above in your HEAD tag ---------->
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/css/select2.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/js/select2.min.js"></script>

    <link href="ScriptCalendar/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="ScriptCalender/jquery-1.11.0.min.js"></script>
    <script type="text/javascript" src="ScriptCalender/jquery-ui.min.js"></script>
    <style>
        ul#profile_drop {
            margin-left: -86px;
            width: 120px;
            border-radius: 8px;
        }

        span#user {
            color: white;
            font-size: 15px;
        }

        svg.bi.bi-person-circle {
            color: white;
        }

        #header .logo img {
            max-height: 62px;
            margin-left: 41px;
            margin-top: 6px;
        }


        li#logout {
            padding-left: 10px !important;
            background: #4B49AC !important;
            border-radius: 51px !important;
            padding-right: 10px !important;
            padding-top: 10px !important;
            padding-bottom: 10px !important;
        }

        img#ProfilePhoto {
            height: 100px;
            width: 100px;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0
        }

        input.form-control.file-upload-info {
            height: 1px;
        }

        input#exampleInputUsername1 {
            height: 1px;
            width: 90%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
        }

            input#exampleInputUsername1:hover {
                height: 1px;
                width: 90%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
            }

            input#exampleInputUsername1:focus {
                height: 1px;
                width: 90%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
                background: #f3f3f3;
            }

        input#exampleInputEmail1 {
            height: 1px;
            width: 90%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
        }

            input#exampleInputEmail1:hover {
                height: 1px;
                width: 90%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
            }

            input#exampleInputEmail1:focus {
                height: 1px;
                width: 90%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
                background: #f3f3f3;
            }

        select#exampleFormControlSelect3 {
            height: 1px;
            width: 90%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
        }

            select#exampleFormControlSelect3:hover {
                height: 1px;
                width: 90%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
            }

            select#exampleFormControlSelect3:focus {
                height: 1px;
                width: 90%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
                background: #f3f3f3;
            }

        input.form-control {
            height: 1px;
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
        }

            input.form-control:hover {
                height: 1px;
                width: 100%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
            }

            input.form-control:focus {
                height: 1px;
                width: 90%;
                box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
                background: #f3f3f3;
            }

        input.form-control {
            height: 1px;
            width: 90%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
        }

            input.form-control:hover {
                height: 1px;
                width: 90%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
            }

            input.form-control:focus {
                height: 1px;
                width: 90%;
                box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
                background: #f3f3f3;
            }

        input#exampleInputConfirmPassword12 {
            width: 100%;
        }

        input#exampleInputConfirmPassword13 {
            width: 100%;
            height: 31px;
        }

        select#ddlGender {
            height: 31px;
            width: 90%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
        }

            select#ddlGender:hover {
                height: 31px;
                width: 90%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
            }

            select#ddlGender:focus {
                height: 31px;
                width: 90%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
                background: #f3f3f3;
            }

        select#ddlcategory {
            height: 31px;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            color: #252525;
            border: 1px solid #ced4da;
            border-radius: 5px;
            width: 100%;
        }

            select#ddlcategory:hover {
                height: 31px;
                width: 100%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
            }

            select#ddlcategory:focus {
                height: 31px;
                width: 100%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
                background: #f3f3f3;
            }

        textarea#CommunicationAddress {
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
        }

            textarea#CommunicationAddress:hover {
                width: 100%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
            }

            textarea#CommunicationAddress:focus {
                width: 100%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
                background: #f3f3f3;
            }

        /* textarea#PermanentAddress {
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
        }
*/
        textarea#PermanentAddress:hover {
            width: 100%;
            box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
        }

        textarea#PermanentAddress:focus {
            width: 100%;
            box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
            background: #f3f3f3;
        }

        select#DropDownList1 {
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            height: 30px;
            font-size: 12px;
        }

            select#DropDownList1:hover {
                width: 100%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
                height: 30px;
                font-size: 12px;
            }

            select#DropDownList1:focus {
                width: 100%;
                box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
                height: 30px;
                font-size: 12px;
            }

        select#DropDownList2 {
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            height: 30px;
            font-size: 12px;
        }

            select#DropDownList2:hover {
                width: 100%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
                height: 30px;
                font-size: 12px;
            }

            select#DropDownList2:focus {
                width: 100%;
                box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
                height: 30px;
                font-size: 12px;
            }

        select#DropDownList3 {
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            height: 30px;
            font-size: 12px;
        }

            select#DropDownList3:hover {
                width: 100%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
                height: 30px;
                font-size: 12px;
            }

            select#DropDownList3:focus {
                width: 100%;
                box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
                height: 30px;
                font-size: 12px;
            }

        select#DropDownList4 {
            width: 100%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            height: 30px;
            font-size: 12px;
        }

            select#DropDownList4:hover {
                width: 100%;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
                height: 30px;
                font-size: 12px;
            }

            select#DropDownList4:focus {
                width: 100%;
                box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
                height: 30px;
                font-size: 12px;
            }

        select#ddlGender {
            color: #252525;
        }

        input#Button1 {
            border-top-right-radius: 10px;
            border-bottom-right-radius: 10px;
        }

        input#btnUpload {
            border-top-right-radius: 10px;
            border-bottom-right-radius: 10px;
        }

        .form-group {
            margin-bottom: 0.5rem !important;
        }

        div#CalculatedDatey {
            margin-top: 20px;
        }

        select#ddlState1:hover {
            height: 31px;
            width: 100%;
            box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px !important;
        }

        .validation_required {
            font-size: 13px;
        }

        .form-group label {
            font-size: 12px;
            line-height: 1.4rem;
            vertical-align: top;
            margin-bottom: 0px !important;
        }

        img {
            margin-top: 10px;
            margin-bottom: 9px;
        }

        .container.aos-init.aos-animate {
            max-width: 1600px;
        }

        select#ddlQualification {
            height: 31px;
            width: 90%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
        }

        select#ddlQualification1 {
            height: 31px;
            width: 90%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
        }

        select#ddlQualification2 {
            height: 31px;
            width: 90%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
        }

        select#ddlExperiene {
            height: 31px;
            width: 90%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
        }

        select#ddlTraningUnder {
            height: 31px;
            width: 90%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
        }

        select {
            height: 31px;
            width: 90%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
            font-weight: 400;
            font-size: 0.875rem;
            border-radius: 4px;
        }
        /*th.headercolor {
    width: 46% !important;
}*/
        img#Gridview1_ImgSignature_0 {
            height: 45px;
            width: 100px;
        }

        th {
            width: 45%;
        }

        .row {
            padding-left: 40px !important;
            padding-right: 40px !important;
        }

        body {
            box-sizing: border-box;
            min-height: 100vh;
            margin: 0px;
            border: solid 1px black;
            PADDING: 10PX;
            padding-right: 9px !important;
        }

        input#InstallationType {
            font-size: 25px !important;
            font-weight: 700;
            text-align: end;
        }

        input#TestReportId {
            font-size: 25px !important;
            font-weight: 700;
            text-align: initial;
            border-bottom: 0px solid !important;
        }

        .col-4 {
            top: 0px;
            left: 0px;
        }

        .form-control {
            margin-left: 0px !important;
            font-size: 16px !important;
            height: 30px;
            border: 0px solid black;
            border-radius: 0px;
            margin-top: 5px;
        }

        label {
            font-size: 18px;
            margin-top: 5px;
            font-weight: 600;
        }

        .card .card-title {
            color: #010101;
            margin-bottom: 1.2rem;
            text-transform: capitalize;
            font-size: 18PX;
            font-weight: 600;
        }

        u {
            font-size: 22px;
        }

        input#InstallationType {
            border-bottom: 0px solid !important;
        }

        p {
            font-size: 20px;
            text-align: justify;
        }

        li {
            font-size: 18PX;
            font-weight: 600;
            line-height: 2;
        }

        .col-2 {
            font-weight: bold;
        }

        textarea {
            font-weight: bold;
            font-size: 22px;
            border: none !important;
        }

        input {
            border: none;
            font-size: 18PX;
        }

        hr {
            border: 1px solid black !important;
            margin-top: -10px;
            margin-bottom: 5px;
        }

        img {
            vertical-align: middle;
            border-style: none;
        }

        td.textbold {
            font-weight: bold;
        }

        span {
            font-size: 18px !important;
            padding-bottom: 35px;
        }

        table.table {
            font-size: 17px;
        }

        span#SD {
            font-size: 45px !important;
            padding-right: 150px;
        }

        .p1 {
            font-family: 'Cedarville Cursive', cursive;
        }

        th {
            width: 1% !important;
            text-align: center;
            font-size: 18px;
            color: black;
            font-weight: 600;
        }

        td {
            font-size: 18px;
            /*  text-align: center;*/
        }

        td {
            padding-top: 4px !important;
            padding-bottom: 3px !important;
        }

        .vl {
            border-left: 2px solid black;
            height: 245px;
        }

        ol {
            padding-left: 20px;
        }

        .full-underline {
            padding: 0;
            margin: 0;
            list-style-type: decimal; /* Ensures numbering */
            list-style-position: outside; /* Numbers outside the border */
        }

            .full-underline li {
                position: relative;
                padding: 8px 0 8px 20px; /* Add space for numbers */
                border-bottom: 1px dotted black;
            }

        .uppercase-label {
            text-transform: uppercase;
        }
        th.headercolor.tdwidth {
    width: 90% !important;
}
    </style>
    <script type="text/javascript">
        function printDiv(printableDiv) {
            var printContents = document.getElementById(printableDiv).innerHTML;
            var originalContents = document.body.innerHTML;

            document.body.innerHTML = printContents;
            window.print();

        }
        window.onload = function () {
            printDiv('printableDiv');
        };
    </script>
    <script type="text/javascript">
        function countLines(textbox) {
            // Split the text into lines
            var lines = textbox.value.split('\n');

            // Initialize counter
            var counter = 1;

            // Loop through each line and add the counter if the line is not empty
            for (var i = 0; i < lines.length; i++) {
                if (lines[i].trim() !== '') {
                    lines[i] = counter + ". " + lines[i];
                    counter += 2; // Increase counter by 2 for the next line
                }
            }

            // Set the textbox value with the updated lines
            textbox.value = lines.join('\n');
        }
    </script>
    <%-- <script>
     
      window.onafterprint = function () {
          // Delay execution to ensure the print dialog is fully closed
          setTimeout(function () {
              // Check if the print dialog is still open
              if (!document.hidden) {
                  // User canceled printing, navigate back to the previous page
                  window.history.back();
              }
          }, 100);
      };
  </script>--%>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="content-wrapper">
                <div class="card" style="box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px; border-radius: 5px !important">
                    <div class="col-12" style="text-align: end; margin-top: auto; margin-bottom: auto;">
                        <asp:Button ID="btnPrint" Text="Print" runat="server" class="btn btn-primary mr-2"
                            Style="margin-top: 5px; margin-bottom: -40px; font-size: 18PX; padding-left: 25px; padding-right: 25px; position: fixed; margin-left: -100px; z-index: 50;" OnClientClick="printDiv('printableDiv');" />
                    </div>
                    <div class="col-12" style="text-align: initial; margin-top: auto; margin-bottom: auto;">
                        <asp:Button ID="btnBack" Text="Back" runat="server" class="btn btn-primary mr-2"
                            Style="margin-top: 5px; margin-bottom: -40px; font-size: 18PX; padding-left: 25px; padding-right: 25px; position: fixed; z-index: 50;" />
                    </div>
                    <div class="card-body">
                        <div id="printableDiv">
                            <div class="row" style="margin-bottom: 15PX;">
                                <%-- <div class="col-1" style="margin-top: auto; margin-bottom: auto;">
                                    <img src="../Assets/haryana.png" height="110" width="auto" />
                                </div>--%>
                                <div class="col-sm-12" style="text-align: center; padding-top: 8px; padding-bottom: 8px; border-radius: 10px;">
                                    <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important; font-size: 20PX;">APPLICATION FOR GRANT OF CERTIFICATE OF COMPETENCY/WIREMAN PERMIT                                      
                                    </h6>
                                </div>
                            </div>
                            <hr />

                            <asp:HiddenField ID="hdnApplicationId" runat="server" />

                            <br />
                            <br />


                            <div class="row">
                                <div class="col-9">
                                    <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important; font-size: 18PX; font-weight: 600; line-height: 2.7;">
                                        <text>Applying for:    </text>
                                        <asp:Label ID="ApplyingFor" CssClass="uppercase-label" runat="server" Style="font-weight: 700; width: 83%; display: inline-block; border-bottom: 1px solid black; height: 30px; padding-left: 10px;">
                                        </asp:Label>
                                        <br />

                                        <text>Name of Applicant:    </text>
                                        <asp:Label ID="Name" runat="server" CssClass="uppercase-label" Style="font-weight: 700; width: 75%; display: inline-block; border-bottom: 1px solid black; height: 30px; padding-left: 10px;">
                                        </asp:Label>
                                        <br />
                                        <text>Father's Name:    </text>
                                        <asp:Label ID="FatherName" CssClass="uppercase-label" runat="server" Style="font-weight: 700; width: 81%; display: inline-block; border-bottom: 1px solid black; height: 30px; padding-left: 10px;">
                                        </asp:Label>
                                        <br />
                                        <text>Gender:    </text>
                                        <asp:Label ID="gender" CssClass="uppercase-label" runat="server" Style="font-weight: 700; width: 40%; display: inline-block; border-bottom: 1px solid black; height: 30px; padding-left: 10px;">
                                        </asp:Label>
                                        <text>Nationality:</text>
                                        <asp:Label ID="Nationailty" CssClass="uppercase-label" runat="server" Style="font-weight: 700; width: 33%; display: inline-block; border-bottom: 1px solid black; height: 30px; padding-left: 10px;">
                                        </asp:Label>
                                        <br />
                                        <text>Date of Birth:</text>
                                        <asp:Label ID="dob" runat="server" Style="font-weight: 700; width: 22%; display: inline-block; border-bottom: 1px solid black; height: 30px; padding-left: 10px;">
                                        </asp:Label>

                                        <text>Years:</text>
                                        <asp:Label ID="Age" runat="server" Style="font-weight: 700; width: 52%; display: inline-block; border-bottom: 1px solid black; height: 30px; padding-left: 10px;">
                                        </asp:Label>
                                    </h6>

                                </div>
                                <div class="col-3">
                                    <!-- Placeholder for image -->
                                    <asp:Image ID="myimg" runat="server" Width="250" Height="225" Style="bottom: 140px;" />

                                </div>



                            </div>
                            <div class="row">
                                <div class="col-12">
                                    <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important; font-size: 18PX; font-weight: 600; line-height: 2.7;">
                                        <text>Permanent Address:</text>
                                        <asp:Label ID="lblPermanant" CssClass="uppercase-label" runat="server" Style="font-weight: 700; width: 80%; display: inline-block; border-bottom: 1px solid black; height: 30px; padding-left: 10px;">
                                        </asp:Label>
                                    </h6>
                                </div>
                                <div class="col-12">
                                    <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important; font-size: 18PX; font-weight: 600; line-height: 2.7;">
                                        <text>Communication Address:</text>
                                        <asp:Label ID="lblCommunicationAddress" CssClass="uppercase-label" runat="server" Style="font-weight: 700; width: 75%; display: inline-block; border-bottom: 1px solid black; height: 30px; padding-left: 10px;">
                                        </asp:Label>
                                    </h6>
                                </div>
                                <div class="col-5" style="padding-right: 0px !important;">
                                    <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important; font-size: 18PX; font-weight: 600; line-height: 2.7;">
                                        <text>Mobile No.:</text>
                                        <asp:Label ID="phone" runat="server" CssClass="uppercase-label" Style="font-weight: 700; width: 70%; display: inline-block; border-bottom: 1px solid black; height: 30px; padding-left: 10px;">
                                        </asp:Label>
                                    </h6>
                                </div>
                                <div class="col-7">
                                    <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important; font-size: 18PX; font-weight: 600; line-height: 2.7;">
                                        <text>E-mail Id:</text>
                                        <asp:Label ID="Email" runat="server" Style="font-weight: 700; width: 81%; display: inline-block; border-bottom: 1px solid black; height: 30px; padding-left: 10px;">
                                        </asp:Label>
                                    </h6>
                                </div>
                                <div class="col-12" style="padding-right: 0px !important;">
                                    <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important; font-size: 18PX; font-weight: 600; line-height: 2.7;">
                                        <text>Aadhaar No.:</text>
                                        <asp:Label ID="PanNo" runat="server" Style="font-weight: 700; width: 30%; display: inline-block; border-bottom: 1px solid black; height: 30px; padding-left: 10px;">
                                        </asp:Label>
                                    </h6>
                                </div>
                            </div>






                            <div class="row">
                                <div class="col-12">
                                    <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important; font-size: 20PX; font-weight: 600; line-height: 2.7; text-decoration: underline;">Organisation Details:

                                    </h6>

                                </div>
                                <div class="col-6" style="padding-right: 0px !important;">
                                    <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important; font-size: 18PX; font-weight: 600; line-height: 2.7;">
                                        <text>GST No.:</text>
                                        <asp:Label ID="lblGst" runat="server" Style="font-weight: 700; width: 70%; display: inline-block; border-bottom: 1px solid black; height: 30px; padding-left: 10px;">
                                        </asp:Label>
                                    </h6>
                                </div>
                                <div class="col-6" style="padding-right: 0px !important;">
    <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important; font-size: 18PX; font-weight: 600; line-height: 2.7;">
        <text>Style of Company:</text>
        <asp:Label ID="lblStylecompany" CssClass="uppercase-label" runat="server" Style="font-weight: 700; width: 65%; display: inline-block; border-bottom: 1px solid black; height: 30px; padding-left: 10px;">
        </asp:Label>
    </h6>
</div>
                                                                <div class="col-12" style="padding-right: 0px !important;">
    <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important; font-size: 18PX; font-weight: 600; line-height: 2.7;">
        <text>Name of <asp:Label ID="lblCompanyName" runat="server"></asp:Label>:</text>
        <asp:Label ID="lblInputCompanyName" runat="server" Style="font-weight: 700; width: 72%; display: inline-block; border-bottom: 1px solid black; height: 30px; padding-left: 10px;">
        </asp:Label>
    </h6>
</div>
                                <div class="col-8" style="padding-right: 0px !important;">
                                    <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important; font-size: 18PX; font-weight: 600; line-height: 2.7;">
                                        <text>Registered office in (Haryana/UT Chandigarh/ NCT Delhi):</text>
                                        <asp:Label ID="lblRegisteroffice" CssClass="uppercase-label" runat="server" Style="font-weight: 700; width: 20%; display: inline-block; border-bottom: 1px solid black; height: 30px; padding-left: 10px;">
                                        </asp:Label>
                                    </h6>
                                </div>
                                <div class="col-12" style="padding-right: 0px !important;">
    <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important; font-size: 18PX; font-weight: 600; line-height: 2.7;">
        <text>Business Address:</text>
        <asp:Label ID="lblBusinessAdd" CssClass="uppercase-label" runat="server" Style="font-weight: 700; width: 82%; display: inline-block; border-bottom: 1px solid black; height: 30px; padding-left: 10px;">
        </asp:Label>
    </h6>
</div>
                                 <div class="col-4" style="padding-right: 0px !important;">
     <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important; font-size: 18PX; font-weight: 600; line-height: 2.7;">
         <text>State:</text>
         <asp:Label ID="lblBusinessState" CssClass="uppercase-label" runat="server" Style="font-weight: 700; width: 72%; display: inline-block; border-bottom: 1px solid black; height: 30px; padding-left: 10px;">
         </asp:Label>
     </h6>
 </div>
                                                                <div class="col-4" style="padding-right: 0px !important;">
    <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important; font-size: 18PX; font-weight: 600; line-height: 2.7;">
        <text>District:</text>
        <asp:Label ID="lblBusinessDistrict" CssClass="uppercase-label" runat="server" Style="font-weight: 700; width: 72%; display: inline-block; border-bottom: 1px solid black; height: 30px; padding-left: 10px;">
        </asp:Label>
    </h6>
</div>
                                                                <div class="col-4" style="padding-right: 0px !important;">
    <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important; font-size: 18PX; font-weight: 600; line-height: 2.7;">
        <text>Pincode:</text>
        <asp:Label ID="lblBusinessPin" CssClass="uppercase-label" runat="server" Style="font-weight: 700; width: 72%; display: inline-block; border-bottom: 1px solid black; height: 30px; padding-left: 10px;">
        </asp:Label>
    </h6>
</div>


                                                                 <div class="col-6" style="padding-right: 0px !important;">
     <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important; font-size: 18PX; font-weight: 600; line-height: 2.7;">
         <text>Email Id.:</text>
         <asp:Label ID="lblBusinessEmail" CssClass="uppercase-label" runat="server" Style="font-weight: 700; width: 75%; display: inline-block; border-bottom: 1px solid black; height: 30px; padding-left: 10px;">
         </asp:Label>
     </h6>
 </div>
                                                                <div class="col-6" style="padding-right: 0px !important;">
    <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important; font-size: 18PX; font-weight: 600; line-height: 2.7;">
        <text>Phone No.:</text>
        <asp:Label ID="lblBusinessPhone" CssClass="uppercase-label" runat="server" Style="font-weight: 700; width: 75%; display: inline-block; border-bottom: 1px solid black; height: 30px; padding-left: 10px;">
        </asp:Label>
    </h6>
</div>
                                                                <div class="col-12" style="padding-right: 0px !important;">
    <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important; font-size: 18PX; font-weight: 600; line-height: 2.7;">
        <text>Name of Authorized person signing document:</text>
        <asp:Label ID="lblauthorizedperson" CssClass="uppercase-label" runat="server" Style="font-weight: 700; width: 56%; display: inline-block; border-bottom: 1px solid black; height: 30px; padding-left: 10px;">
        </asp:Label>
    </h6>
</div>
                                
                               <%-- <div class="col-12" style="padding-right: 0px !important;">
    <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important; font-size: 18PX; font-weight: 600; line-height: 2.7;">
        <text>Name of Person Signing Document:</text>
        <asp:Label ID="lblSigning" CssClass="uppercase-label" runat="server" Style="font-weight: 700; width: 66%; display: inline-block; border-bottom: 1px solid black; height: 30px; padding-left: 10px;">
        </asp:Label>
    </h6>
</div>--%>
                                 <div class="col-12" style="padding-right: 0px !important;" id="DivAgentName" runat="server" visible="false">
     <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important; font-size: 18PX; font-weight: 600; line-height: 2.7;">
         <text>Full Name of Agent/Manager:</text>
         <asp:Label ID="lblAgentName" CssClass="uppercase-label" runat="server" Style="font-weight: 700; width: 71%; display: inline-block; border-bottom: 1px solid black; height: 30px; padding-left: 10px;">
         </asp:Label>
     </h6>
 </div>
                            </div>


                            <div class="row">
                                <div class="col-12">
                                    <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important; font-size: 20PX; font-weight: 600; line-height: 2.7; text-decoration: underline;">Other Organisation Details:

                                    </h6>

                                </div>
                               
                                <div class="col-12" style="padding-right: 0px !important;">
                                    <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important; font-size: 18PX; font-weight: 600; line-height: 2.7;">
                                        <text>
                                            Is Applicant a manufacturing firm or production unit:</text>
                                        <asp:Label ID="lblManufacturing" CssClass="uppercase-label" runat="server" Style="font-weight: 700; width: 50%; display: inline-block; border-bottom: 1px solid black; height: 30px; padding-left: 10px;">
                                        </asp:Label>
                                    </h6>
                                </div>
                                <div class="col-12" style="padding-right: 0px !important;" id="divLicensePreviouslyGranted" runat="server" visible="true">
                                    <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important; font-size: 18PX; font-weight: 600; line-height: 2.7;">
                                        <text>
                                            Is Contractor License Previously Granted with same name  :</text>
                                        <asp:Label ID="lblLicencePrivouslySameName" CssClass="uppercase-label" runat="server" Style="font-weight: 700; width: 46%; display: inline-block; border-bottom: 1px solid black; height: 30px; padding-left: 10px;">
                                        </asp:Label>
                                    </h6>
                                </div>
                                <div class="col-6" style="padding-right: 0px !important;"  id="divLicenceSM" runat="server" visible="false">
                                    <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important; font-size: 18PX; font-weight: 600; line-height: 2.7;">
                                        <text>
                                            Enter License No.:</text>
                                        <asp:Label ID="lblLicenceNo" CssClass="uppercase-label" runat="server" Style="font-weight: 700; width: 65%; display: inline-block; border-bottom: 1px solid black; height: 30px; padding-left: 10px;">
                                        </asp:Label>
                                    </h6>
                                </div>
                                <div class="col-6" style="padding-right: 0px !important;" id="divDateOfIssueSM" runat="server" visible="false">
                                    <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important; font-size: 18PX; font-weight: 600; line-height: 2.7;">
                                        <text>
                                            Date of Issue:</text>
                                        <asp:Label ID="lblDateOfIssue" runat="server" Style="font-weight: 700; width: 66%; display: inline-block; border-bottom: 1px solid black; height: 30px; padding-left: 10px;">
                                        </asp:Label>
                                    </h6>
                                </div>
                                <div class="col-12" style="padding-right: 0px !important;">
                                    <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important; font-size: 18PX; font-weight: 600; line-height: 2.7;">
                                        <text>
                                            Is Contractor License Previously Granted with same name from other state:</text>
                                        <asp:Label ID="lblCOntractorLicencesamename_otherstate" CssClass="uppercase-label" runat="server" Style="font-weight: 700; width: 32%; display: inline-block; border-bottom: 1px solid black; height: 30px; padding-left: 10px;">
                                        </asp:Label>
                                    </h6>
                                </div>
                                <div class="col-6" style="padding-right: 0px !important;" id="divIssusuingNameSNO" runat="server" visible="false">
                                    <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important; font-size: 18PX; font-weight: 600; line-height: 2.7;">
                                        <text>
                                            Name of Issuing Authority:</text>
                                        <asp:Label ID="lblIssusuingName" CssClass="uppercase-label" runat="server" Style="font-weight: 700; width: 50%; display: inline-block; border-bottom: 1px solid black; height: 30px; padding-left: 10px;">
                                        </asp:Label>
                                    </h6>
                                </div>
                                <div class="col-6" id="divIssueDateSNO" runat="server" visible="false" style="padding-right: 0px !important;">
                                    <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important; font-size: 18PX; font-weight: 600; line-height: 2.7;">
                                        <text>
                                            Date of Issue:</text>
                                        <asp:Label ID="lblDateOfIssueSNO" runat="server" Style="font-weight: 700; width: 66%; display: inline-block; border-bottom: 1px solid black; height: 30px; padding-left: 10px;">
                                        </asp:Label>
                                    </h6>
                                </div>

                                <div class="col-6" style="padding-right: 0px !important;" id="divLicenceExpirySNO" runat="server" visible="false">
                                    <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important; font-size: 18PX; font-weight: 600; line-height: 2.7;">
                                        <text>
                                            Date of Licence Expiry:</text>
                                        <asp:Label ID="lblDateOfExpirySNO" runat="server" Style="font-weight: 700; width: 50%; display: inline-block; border-bottom: 1px solid black; height: 30px; padding-left: 10px;">
                                        </asp:Label>
                                    </h6>
                                </div>
                                <div class="col-12" id="divDetailOfWorkPermitSNO" runat="server" visible="false" style="padding-right: 0px !important;">
                                    <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important; font-size: 18PX; font-weight: 600; line-height: 2.7;">
                                        <text>
                                            Details of work permit to be undertaken:</text>
                                        <asp:Label ID="lblWorkPermitUndertaken" CssClass="uppercase-label" runat="server" Style="font-weight: 700; width: 94%; display: inline-block; border-bottom: 1px solid black; height: 30px; padding-left: 10px;">
                                        </asp:Label>
                                    </h6>
                                </div>

                            </div>


                            <div class="row">
                                <div class="col-12">
                                    <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important; font-size: 20PX; font-weight: 600; line-height: 2.7; text-decoration: underline;">Partners/Directors Details:

                                    </h6>

                                </div>
                                <div class="col-8" style="padding-right: 0px !important;">
    <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important; font-size: 18PX; font-weight: 600; line-height: 2.7;">
        <text>Whether the company have Partner/Director:</text>
        <asp:Label ID="lblweathercompnypartner" CssClass="uppercase-label" runat="server" Style="font-weight: 700; width: 20%; display: inline-block; border-bottom: 1px solid black; height: 30px; padding-left: 10px;">
        </asp:Label>
    </h6>
</div>
                                <div class="col-md-12">
                                    <%-- Add gridview here --%>
                                    <div class="row" id="Partner_Div" runat="server" visible="false" style="margin-top: 40px;">

                                        <div class="col-12">
                                            <asp:GridView class="table-responsive table table-hover table-striped table-bordered" ID="grdview_Partners" runat="server" Width="100%"
                                                AutoGenerateColumns="false" BorderWidth="1px" BorderColor="#dbddff">
                                                <PagerStyle CssClass="pagination-ys" />
                                                <Columns>
                                                    <asp:BoundField DataField="TypeOfAuthority" HeaderText="Type Of Authority">
                                                        <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                                        <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="tdpadding" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Name" HeaderText="Name">
                                                        <HeaderStyle HorizontalAlign="center" Width="12%" CssClass="headercolor" />
                                                        <ItemStyle HorizontalAlign="center" Width="12%" CssClass="tdpadding" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="State" HeaderText="State">
                                                        <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                                        <ItemStyle HorizontalAlign="center" Width="15%" CssClass="tdpadding" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="District" HeaderText="District">
                                                        <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                                        <ItemStyle HorizontalAlign="center" Width="15%" CssClass="tdpadding" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="PinCode" HeaderText="PinCode">
                                                        <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                                        <ItemStyle HorizontalAlign="center" Width="15%" CssClass="tdpadding" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Address" HeaderText="Address">
                                                        <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                                        <ItemStyle HorizontalAlign="center" Width="15%" CssClass="tdpadding" />
                                                    </asp:BoundField>
                                                </Columns>
                                                <FooterStyle BackColor="White" ForeColor="#000066" />
                                                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                                                <RowStyle ForeColor="#000066" CssClass="gridViewRow" />
                                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                <SortedDescendingHeaderStyle BackColor="#00547E" />
                                            </asp:GridView>
                                        </div>


                                    </div>
                                </div>
                            </div>


                            <div class="row">
                                <div class="col-12">
                                    <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important; font-size: 20PX; font-weight: 600; line-height: 2.7; text-decoration: underline;">Other Details:

                                    </h6>

                                </div>
                                <div class="col-12" style="padding-right: 0px !important;">
                                    <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important; font-size: 18PX; font-weight: 600; line-height: 2.7;">
                                        <text>Whether E library/library as per ANNEXURE-2 Available:</text>
                                        <asp:Label ID="lblLibraryAnnexure" CssClass="uppercase-label" runat="server" Style="font-weight: 700; width: 46%; display: inline-block; border-bottom: 1px solid black; height: 30px; padding-left: 10px;">
                                        </asp:Label>
                                    </h6>
                                </div>
                                <div class="col-12" style="padding-right: 0px !important;">
                                    <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important; font-size: 18PX; font-weight: 600; line-height: 2.7;">
                                        <text>Do company/firm have any penalties or punishments? :</text>
                                        <asp:Label ID="lblAnyPenality" CssClass="uppercase-label" runat="server" Style="font-weight: 700; width: 46%; display: inline-block; border-bottom: 1px solid black; height: 30px; padding-left: 10px;">
                                        </asp:Label>
                                    </h6>
                                </div>
                                <div class="col-12" style="padding-right: 0px !important;" id="ShowPenelity" runat="server" visible="false">
                                    <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important; font-size: 18PX; font-weight: 600; line-height: 2.7;">
                                        <text>penalties or punishments:</text>
                                        <asp:Label ID="lblPenality" runat="server" Style="font-weight: 700; width: 71%; display: inline-block; border-bottom: 1px solid black; height: 30px; padding-left: 10px;">
                                        </asp:Label>
                                    </h6>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-12">
                                    <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important; font-size: 20PX; font-weight: 600; line-height: 2.7; text-decoration: underline;">Employees Details:</h6>
                                    <asp:GridView class="table-responsive table table-hover table-striped table-bordered" ID="grdView_ContractorTeam" runat="server" Width="100%"
                                        AutoGenerateColumns="false" BorderWidth="1px" BorderColor="#dbddff">
                                        <PagerStyle CssClass="pagination-ys" />
                                        <Columns>
                                            <asp:BoundField DataField="Name" HeaderText="Name">
                                                <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="tdpadding" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="TypeOfEmployee" HeaderText="TypeOfEmployee">
                                                <HeaderStyle HorizontalAlign="center" Width="12%" CssClass="headercolor" />
                                                <ItemStyle HorizontalAlign="center" Width="12%" CssClass="tdpadding" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="LicenseNo" HeaderText="LicenseNo">
                                                <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                                <ItemStyle HorizontalAlign="center" Width="15%" CssClass="tdpadding" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="IssueDate" HeaderText="LicenseIssueDate">
                                                <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                                <ItemStyle HorizontalAlign="center" Width="15%" CssClass="tdpadding" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ValidityDate" HeaderText="LicenseValidity">
                                                <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                                <ItemStyle HorizontalAlign="center" Width="15%" CssClass="tdpadding" />
                                            </asp:BoundField>
                                        </Columns>
                                        <FooterStyle BackColor="White" ForeColor="#000066" />
                                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                                        <RowStyle ForeColor="#000066" CssClass="gridViewRow" />
                                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                                    </asp:GridView>


                                </div>

                                  <div class="col-12" style="padding-right: 0px !important;">
      <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important; font-size: 18PX; font-weight: 600; line-height: 2.7;">
          <text>  Whether the staff indicated under column 13 are exclusively earmark for the work under the conditions for licencing and Regulation 29 of "Central Electricity Authority (Measures relating to Safety and Electric Supply)"? :</text>
          <asp:Label ID="lblWorkUnderConditionsandgulation29" CssClass="uppercase-label" runat="server" Style="font-weight: 700; width: 46%; display: inline-block; border-bottom: 1px solid black; height: 30px; padding-left: 10px;">
          </asp:Label>
      </h6>
  </div>
                                <div class="col-md-12">
                                    <asp:GridView ID="grd_Documemnts" OnRowDataBound="grd_Documemnts_RowDataBound" autopostback="true" CssClass="table table-bordered table-striped table-responsive" runat="server" AutoGenerateColumns="false">
                                        <HeaderStyle BackColor="#B7E2F0" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="SNo">
                                                <HeaderStyle Width="5%" CssClass="headercolor" />
                                                <ItemStyle Width="5%" />
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex+1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="DocumentName" HeaderText="Documents Name">
                                                <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor tdwidth" />
                                                <ItemStyle HorizontalAlign="Left" Width="15%" />
                                            </asp:BoundField>

                                        </Columns>
                                        <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
                                    </asp:GridView>

                                </div>
                            </div>

                            <br />

                            <div class="row">
                                <div class="col-12">
                                    <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important; font-size: 18PX; font-weight: 600; text-align: justify;">I hereby declare that the particulars stated above are correct to the best of my knowledge. I am not a holder of
Supervisor Competency Certificate issued by the State Licensing Board/Chief Electrical Inspector other than those
indicated in the<bold>Column 10</bold>. I also agree to the cancellation of my Certificate of Competency to be issued in
pursuance of this application, in case the particulars furnished in the application are found incorrect or false at any
stage
                                    </h6>
                                </div>
                            </div>
                            <br />


                            <div class="row">
                                <div class="col-3" style="margin-top: auto !important;">
                                </div>
                                <div class="col-9" style="text-align: end">

                                    <asp:Image ID="imgsignature" runat="server" Width="300" Height="90" Style="bottom: 140px; margin-left: -300px;" />
                                    <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important; font-size: 18PX; font-weight: 700; margin-right: 55px;">Signature of Applicant</h6>

                                </div>
                            </div>

                            <br />
                            <br />
                          <%--  <div class="row">
                                <div class="col-12">
                                    <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important; font-size: 18PX; text-align: Justify;">Photocopies of documents to be forwarded alongwith the application:-
                                    </h6>

                                </div>
                                <div class="col-12" style="padding-left: 30px;">
                                    <ol>
                                        <li>Matriculation certificate indicating date of birth.</li>
                                        <li>Residence Proof.</li>
                                        <li>Identity Proof.</li>
                                        <li>Photographs 2 Nos</li>
                                        <li>Photographs 2 Nos</li>
                                        <li>Degree/Diploma in Electrical Engineering./Electrical and Electronics Engineering. or its equivalent.</li>
                                        <li>Experience Certificate.</li>
                                        <li>Number of three Specimen signatures of the applicant. </li>
                                        <li>Copy of retirement orders in case of retired engineers.</li>
                                        <li>Medical fitness certificate from Government/Government approved Hospital, in case he is above 55 years
                                     of age on the date of submission of application.</li>
                                        <li>Copy of retirement orders in case of retired engineers.</li>
                                        <li>Treasury challan of fees for the purpose, deposited in any treasury of Haryana under
                                            <bold>
                                                Head of account: -
‗0043-Taxes and Duties on Electricity –Other Receipts i.e. 0043-51-800-99-51—Other Receipts‘.</bold></li>
                                    </ol>
                                </div>
                            </div>--%>




                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- partial:../../partials/_footer.html -->
        <footer class="footer">
        </footer>
    </form>
</body>
</html>
