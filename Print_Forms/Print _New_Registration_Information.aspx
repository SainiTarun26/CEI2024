<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Print _New_Registration_Information.aspx.cs" Inherits="CEIHaryana.Print_Forms.Print__New_Registration_Information" %>

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
                                        <asp:Label ID="ApplyingFor" runat="server" Style="font-weight: 700; width: 83%; display: inline-block; border-bottom: 1px solid black; height: 30px; padding-left: 10px;">
                                        </asp:Label>
                                        <br />

                                        <text>Name of Applicant:    </text>
                                        <asp:Label ID="Name" runat="server" Style="font-weight: 700; width: 75%; display: inline-block; border-bottom: 1px solid black; height: 30px; padding-left: 10px;">
                                        </asp:Label>
                                        <br />
                                        <text>Father's Name:    </text>
                                        <asp:Label ID="FatherName" runat="server" Style="font-weight: 700; width: 80%; display: inline-block; border-bottom: 1px solid black; height: 30px; padding-left: 10px;">
                                        </asp:Label>
                                        <br />
                                        <text>Gender:    </text>
                                        <asp:Label ID="gender" runat="server" Style="font-weight: 700; width: 40%; display: inline-block; border-bottom: 1px solid black; height: 30px; padding-left: 10px;">
                                        </asp:Label>
                                        <text>Nationality:</text>
                                        <asp:Label ID="Nationailty" runat="server" Style="font-weight: 700; width: 33%; display: inline-block; border-bottom: 1px solid black; height: 30px; padding-left: 10px;">
                                        </asp:Label>
                                        <br />
                                        <text>Date of Birth:</text>
                                        <asp:Label ID="dob" runat="server" Style="font-weight: 700; width: 22%; display: inline-block; border-bottom: 1px solid black; height: 30px; padding-left: 10px;">
                                        </asp:Label>

                                        <text>Years:</text>
                                        <asp:Label ID="Age" runat="server" Style="font-weight: 700; width: 11%; display: inline-block; border-bottom: 1px solid black; height: 30px; padding-left: 10px;">
                                        </asp:Label>
                                        <text>Months:</text>
                                        <asp:Label ID="Label7" runat="server" Style="font-weight: 700; width: 11%; display: inline-block; border-bottom: 1px solid black; height: 30px; padding-left: 10px;">
                                        </asp:Label>
                                        <text>Days:</text>
                                        <asp:Label ID="Label8" runat="server" Style="font-weight: 700; width: 11%; display: inline-block; border-bottom: 1px solid black; height: 30px; padding-left: 10px;">
                                        </asp:Label>
                                    </h6>

                                </div>
                                <div class="col-3">
                                    <div class="mx-auto" style="width: 175px; height: 195px; border: 1px solid #ccc; background-color: #f8f9fa;">
                                        <!-- Placeholder for image -->
                                    </div>
                                </div>



                            </div>
                            <div class="row">
                                <div class="col-12">
                                    <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important; font-size: 18PX; font-weight: 600; line-height: 2.7;">
                                        <text>Permanent Address:</text>
                                        <asp:Label ID="Label5" runat="server" Style="font-weight: 700; width: 82%; display: inline-block; border-bottom: 1px solid black; height: 30px; padding-left: 10px;">
                                        </asp:Label>
                                    </h6>
                                </div>
                                <div class="col-12">
                                    <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important; font-size: 18PX; font-weight: 600; line-height: 2.7;">
                                        <text>Communication Address:</text>
                                        <asp:Label ID="CommunicationAddress" runat="server" Style="font-weight: 700; width: 77%; display: inline-block; border-bottom: 1px solid black; height: 30px; padding-left: 10px;">
                                        </asp:Label>
                                    </h6>
                                </div>
                                <div class="col-5" style="padding-right: 0px !important;">
                                    <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important; font-size: 18PX; font-weight: 600; line-height: 2.7;">
                                        <text>Mobile No.:</text>
                                        <asp:Label ID="phone" runat="server" Style="font-weight: 700; width: 74%; display: inline-block; border-bottom: 1px solid black; height: 30px; padding-left: 10px;">
                                        </asp:Label>
                                    </h6>
                                </div>
                                <div class="col-7">
                                    <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important; font-size: 18PX; font-weight: 600; line-height: 2.7;">
                                        <text>E-mail Id:</text>
                                        <asp:Label ID="Email" runat="server" Style="font-weight: 700; width: 77%; display: inline-block; border-bottom: 1px solid black; height: 30px; padding-left: 10px;">
                                        </asp:Label>
                                    </h6>
                                </div>
                                <div class="col-12" style="padding-right: 0px !important;">
                                    <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important; font-size: 18PX; font-weight: 600; line-height: 2.7;">
                                        <text>Aadhaar No.:</text>
                                        <asp:Label ID="Aadhar" runat="server" Style="font-weight: 700; width: 30%; display: inline-block; border-bottom: 1px solid black; height: 30px; padding-left: 10px;">
                                        </asp:Label>
                                    </h6>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-12">
                                    <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important; font-size: 18PX; font-weight: 600; line-height: 2.7;">Education/Technical Qualification:
                                    </h6>

                                </div>
                                <div class="col-12">
                                    <div class="table-responsive">
    <table class="table table-bordered">
        <thead>
            <tr style="text-align: center;">

                <th scope="col" style="width: 20% !important;">Exam Name</th>
                <th scope="col">Board/University Name</th>
                <th scope="col" style="width: 0% !important;">Passing Year</th>
                <th scope="col" style="width: 0% !important;">Obtained Marks&nbsp;/&nbsp;Max Marks                                                      
                </th>
                <th scope="col" style="width: 10% !important;">% </th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td style="text-align: center; font-size: 15px !important;">10th
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" class="form-control" ID="University" runat="server" autocomplete="off"> </asp:TextBox>

                </td>
                <td>

                    <asp:TextBox ReadOnly="true" class="form-control" ID="Passingyear" runat="server" min='0000-01-01' max='9999-01-01' autocomplete="off"> </asp:TextBox>
                    <div>
                    </div>
                </td>
                <td>
                    <div class="row">
                        <div class="col-6">
                            <asp:TextBox ReadOnly="true" class="form-control" ID="marksObtained" MaxLength="3" onKeyPress="return isNumberKey(event);" autocomplete="off" runat="server"> </asp:TextBox>

                        </div>
                        <div class="col-6">
                            <asp:TextBox ReadOnly="true" class="form-control" ID="marksmax" MaxLength="3" onKeyPress="return isNumberKey(event);" autocomplete="off" runat="server" AutoPostBack="true"> </asp:TextBox>

                        </div>
                    </div>

                </td>
                <td>
                    <asp:TextBox ReadOnly="true" class="form-control" ID="prcntg" MaxLength="3" onKeyPress="return isNumberKey(event);" autocomplete="off" runat="server"> </asp:TextBox>
            </tr>
            <tr id="Tr_Qualification2" runat="server" visible="false">
                <td>
                    <asp:TextBox ReadOnly="true" class="form-control" ID="Exam1" MaxLength="50" autocomplete="off" TabIndex="2" onKeyPress="return alphabetKey(event);" runat="server"> </asp:TextBox>

                </td>
                <td>
                    <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" ID="University1" runat="server"> </asp:TextBox>

                </td>
                <td>
                    <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" min='0000-01-01' max='9999-01-01' ID="Passingyear1" runat="server"> </asp:TextBox>

                </td>
                <td>
                    <div class="row">

                        <div class="col-6">
                            <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" MaxLength="3" onKeyPress="return isNumberKey(event);" ID="marksObtained1" runat="server"> </asp:TextBox>

                        </div>
                        <div class="col-6">
                            <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" MaxLength="3" onKeyPress="return isNumberKey(event);" ID="marksmax1" runat="server" AutoPostBack="true"> </asp:TextBox>

                        </div>
                    </div>
                </td>
                <td>
                    <asp:TextBox class="form-control" autocomplete="off" MaxLength="3" onKeyPress="return isNumberKey(event);" ID="prcntg1" ReadOnly="true" runat="server"> </asp:TextBox>

                </td>
            </tr>
            <tr id="Tr_Qualification3" runat="server" visible="false">

                <td style="text-align: center;">
                    <asp:TextBox ReadOnly="true" class="form-control" ID="Exam2" MaxLength="50" autocomplete="off" TabIndex="2" onKeyPress="return alphabetKey(event);" runat="server"> </asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" class="form-control" ID="University2" autocomplete="off" runat="server"> </asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" min='0000-01-01' max='9999-01-01' ID="Passingyear2" runat="server"> </asp:TextBox>
                </td>
                <td>
                    <div class="row">
                        <div class="col-6">
                            <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" MaxLength="3" onKeyPress="return isNumberKey(event);" ID="marksObtained2" runat="server"> </asp:TextBox>
                        </div>
                        <div class="col-6">
                            <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" MaxLength="3" onKeyPress="return isNumberKey(event);" ID="marksmax2" runat="server" AutoPostBack="true"> </asp:TextBox>
                        </div>
                    </div>
                </td>
                <td>
                    <asp:TextBox class="form-control" autocomplete="off" MaxLength="3" onKeyPress="return isNumberKey(event);" ID="prcntg2" ReadOnly="true" runat="server"> </asp:TextBox>
                </td>
            </tr>
            <tr id="DdlDegree" runat="server" visible="false">

                <td style="text-align: center;">
                    <asp:TextBox ReadOnly="true" class="form-control" ID="Exam3" MaxLength="50" autocomplete="off" TabIndex="2" onKeyPress="return alphabetKey(event);" runat="server"> </asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" ID="University3" runat="server"> </asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" min='0000-01-01' max='9999-01-01' ID="Passingyear3" runat="server"> </asp:TextBox>
                </td>
                <td>
                    <div class="row">
                        <div class="col-6">
                            <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" MaxLength="3" onKeyPress="return isNumberKey(event);" ID="marksObtained3" runat="server"> </asp:TextBox>
                        </div>
                        <div class="col-6">
                            <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" MaxLength="3" onKeyPress="return isNumberKey(event);" ID="marksmax3" runat="server" AutoPostBack="true"> </asp:TextBox>
                        </div>
                    </div>
                </td>
                <td>
                    <asp:TextBox class="form-control" autocomplete="off" ID="prcntg3" MaxLength="3" onKeyPress="return isNumberKey(event);" ReadOnly="true" runat="server"> </asp:TextBox>

                </td>
            </tr>
            <tr id="DdlMasters" visible="false" runat="server">

                <td style="text-align: center;">
                    <asp:TextBox ReadOnly="true" class="form-control" ID="Exam4" MaxLength="50" autocomplete="off" TabIndex="2" onKeyPress="return alphabetKey(event);" runat="server"> </asp:TextBox>
                </td>
                <td>
                    <asp:TextBox class="form-control" autocomplete="off" ID="University4" runat="server"> </asp:TextBox>
                </td>
                <td>
                    <asp:TextBox class="form-control" autocomplete="off" min='0000-01-01' max='9999-01-01' ID="Passingyear4" runat="server"> </asp:TextBox>
                </td>
                <td>
                    <div class="row">
                        <div class="col-6">
                            <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" MaxLength="3" onKeyPress="return isNumberKey(event);" ID="marksObtained4" runat="server"> </asp:TextBox>
                        </div>
                        <div class="col-6">
                            <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" MaxLength="3" onKeyPress="return isNumberKey(event);" ID="marksmax4" runat="server" AutoPostBack="true"> </asp:TextBox>
                        </div>
                    </div>
                </td>
                <td>
                    <asp:TextBox class="form-control" autocomplete="off" ID="prcntg4" MaxLength="3" onKeyPress="return isNumberKey(event);" ReadOnly="true" runat="server"> </asp:TextBox>
                </td>
            </tr>

        </tbody>
    </table>

</div>
                                </div>

                            <div class="row">
                                <div class="col-12">
                                    <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important; font-size: 18PX; font-weight: 600; line-height: 2.7;">Whether you are holder of Certificate of Competency/Wireman Permit issued by any State Licensing
Board/Chief Electrical Inspector. If so, give details:
                                    </h6>

                                </div>
                                <div class="col-12">

                                    <div class="table-responsive" runat="server">
                                        <table class="table table-bordered">
                                            <thead>
                                                <tr style="text-align: center;">
                                                    <th scope="col">Sno.</th>
                                                    <th scope="col">Category  
                                                    </th>
                                                    <th scope="col">Permit No.</th>
                                                    <th scope="col">Issuing Authority</th>
                                                    <th scope="col">Issue Date</th>
                                                    <th scope="col">Expiry Date</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <tr>
                                                    <td style="text-align: center; font-size: 13px;">1
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" ID="Category" TabIndex="26" MaxLength="30" runat="server"> </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" ID="PermitNo" TabIndex="27" MaxLength="20" runat="server"> </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" ID="IssuingAuthority" TabIndex="28" MaxLength="50" runat="server"> </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ReadOnly="true" class="form-control" min='0000-01-01' max='9999-01-01' autocomplete="off" TabIndex="29" ID="IssuingDate" runat="server" onchange="validateDates()"> </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ReadOnly="true" class="form-control" min='0000-01-01' max='9999-01-01' autocomplete="off" ID="ExpiryDate" runat="server" TabIndex="30" onchange="validateDates()"> </asp:TextBox>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>


                                <div class="row">
                                    <div class="col-12">
                                        <div class="col-5">
                                            <h4 class="card-title" style="font-size: 15px;">Are you Employed on Permanent
Basis.</h4>
                                        </div>
                                        </h6>
                                        <div class="col-2">
                                            <asp:RadioButtonList ID="RadioButtonList3" Enabled="false" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" TabIndex="31">
                                                <asp:ListItem Text="Yes" Value="0" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="No" Value="1"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                    </div>
                                    <div class="col-12" id="PermanentEmployee" visible="false" runat="server">
                                        <div class="table-responsive">
                                            <table class="table table-bordered">
                                                <thead>
                                                    <tr style="text-align: center;">
                                                        <th scope="col">Sno.</th>
                                                        <th scope="col">Name of Employer
                                                        </th>
                                                        <th scope="col">Post Description</th>
                                                        <th scope="col">From</th>
                                                        <th scope="col">To</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                <tr>
                                                    <td style="text-align: center; font-size: 13px;">1
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" ID="PermanentEmployerName" TabIndex="32" MaxLength="30" runat="server"> </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" ID="PermanentDescription" TabIndex="33" MaxLength="50" runat="server"> </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" min='0000-01-01' max='9999-01-01' ID="PermanentFrom" TabIndex="34" runat="server" onchange="validateDates1()"> </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" min='0000-01-01' max='9999-01-01' ID="PermanentTo" TabIndex="35" runat="server" onchange="validateDates1()"> </asp:TextBox>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>


                            <div class="row">
                                <div class="col-12">
                                    <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important; font-size: 18PX; font-weight: 600; line-height: 2.7;">Detail of experience:
                                    </h6>

                                </div>
                                <div class="col-12">
                                    <div class="table-responsive">
                                        <table class="table table-bordered">
                                            <thead>
                                                <tr style="text-align: center;">
                                                    <%--  <th scope="col">Sno.</th>--%>
                                                    <th scope="col">Experienced in  
                                                    </th>
                                                    <th scope="col">Training Under  
                                                    </th>
                                                    <th scope="col" style="width: 20%;">Name of Employer  
                                                    </th>
                                                    <th scope="col">Post Description</th>
                                                    <th scope="col">From</th>
                                                    <th scope="col">To</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <tr>
                                                    <%--  <td style="text-align: center; font-size: 13px;">1
                                                            </td>--%>
                                                    <td>
                                                        <asp:TextBox ReadOnly="true" class="form-control" ID="Experience" MaxLength="50" autocomplete="off" TabIndex="2" onKeyPress="return alphabetKey(event);" runat="server"> </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ReadOnly="true" class="form-control" ID="Trainingunder" MaxLength="50" autocomplete="off" TabIndex="2" onKeyPress="return alphabetKey(event);" runat="server"> </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" ID="ExperienceEmployer" MaxLength="30" TabIndex="38" runat="server"> </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" ID="PostDescription" MaxLength="50" TabIndex="39" runat="server"> </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" min='0000-01-01' max='9999-01-01' ID="ExperienceFrom" TabIndex="40" onchange="validateDates2()" runat="server"> </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" AutoPostBack="true" min='0000-01-01' max='9999-01-01' ID="ExperienceTo" TabIndex="41" onchange="validateDates2()" runat="server"> </asp:TextBox>

                                                    </td>
                                                </tr>
                                                <tr id="Experience1" runat="server" visible="false">
                                                    <%--  <td style="text-align: center; font-size: 13px;">1
    </td>--%>
                                                    <td>
                                                        <asp:TextBox ReadOnly="true" class="form-control" ID="txtExperience1" MaxLength="50" autocomplete="off" TabIndex="2" onKeyPress="return alphabetKey(event);" runat="server"> </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ReadOnly="true" class="form-control" ID="Trainingunder1" MaxLength="50" autocomplete="off" TabIndex="2" onKeyPress="return alphabetKey(event);" runat="server"> </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" ID="ExperienceEmployer1" MaxLength="30" TabIndex="44" runat="server"> </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" ID="PostDescription1" MaxLength="50" TabIndex="45" runat="server"> </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" min='0000-01-01' max='9999-01-01' ID="ExperienceFrom1" TabIndex="46" onchange="validateDates3()" runat="server"> </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ReadOnly="true" class="form-control" AutoPostBack="true" autocomplete="off" min='0000-01-01' max='9999-01-01' ID="ExperienceTo1" TabIndex="47" onchange="validateDates3()" runat="server"> </asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr id="Experience2" runat="server" visible="false">
                                                    <td>
                                                        <asp:TextBox ReadOnly="true" class="form-control" ID="txtExperience2" MaxLength="50" autocomplete="off" TabIndex="2" onKeyPress="return alphabetKey(event);" runat="server"> </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ReadOnly="true" class="form-control" ID="Trainingunder2" MaxLength="50" autocomplete="off" TabIndex="2" onKeyPress="return alphabetKey(event);" runat="server"> </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" ID="ExperienceEmployer2" MaxLength="30" TabIndex="49" runat="server"> </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" ID="PostDescription2" MaxLength="50" TabIndex="50" runat="server"> </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" min='0000-01-01' max='9999-01-01' ID="ExperienceFrom2" TabIndex="51" onchange="validateDates4()" runat="server"> </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" AutoPostBack="true" min='0000-01-01' max='9999-01-01' ID="ExperienceTo2" TabIndex="52" onchange="validateDates4()" runat="server"> </asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr id="Experience3" runat="server" visible="false">
                                                    <%--  <td style="text-align: center; font-size: 13px;">1
    </td>--%>
                                                    <td>
                                                        <asp:TextBox ReadOnly="true" class="form-control" ID="txtExperience3" MaxLength="50" autocomplete="off" TabIndex="2" onKeyPress="return alphabetKey(event);" runat="server"> </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ReadOnly="true" class="form-control" ID="Trainingunder3" MaxLength="50" autocomplete="off" TabIndex="2" onKeyPress="return alphabetKey(event);" runat="server"> </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" ID="ExperienceEmployer3" MaxLength="30" TabIndex="55" runat="server"> </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" ID="PostDescription3" MaxLength="50" TabIndex="56" runat="server"> </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" min='0000-01-01' max='9999-01-01' ID="ExperienceFrom3" TabIndex="57" onchange="validateDates5()" runat="server"> </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ReadOnly="true" class="form-control" AutoPostBack="true" autocomplete="off" min='0000-01-01' max='9999-01-01' ID="ExperienceTo3" TabIndex="58" onchange="validateDates5()" runat="server"> </asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr id="Experience4" runat="server" visible="false">
                                                    <td>
                                                        <asp:TextBox ReadOnly="true" class="form-control" ID="txtExperience4" MaxLength="50" autocomplete="off" TabIndex="2" onKeyPress="return alphabetKey(event);" runat="server"> </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ReadOnly="true" class="form-control" ID="Trainingunder4" MaxLength="50" autocomplete="off" TabIndex="2" onKeyPress="return alphabetKey(event);" runat="server"> </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" ID="ExperienceEmployer4" MaxLength="30" TabIndex="61" runat="server"> </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" ID="PostDescription4" MaxLength="50" TabIndex="62" runat="server"> </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" min='0000-01-01' max='9999-01-01' ID="ExperienceFrom4" TabIndex="63" onchange="validateDates6()" runat="server"> </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" AutoPostBack="true" min='0000-01-01' max='9999-01-01' ID="ExperienceTo4" TabIndex="64" onchange="validateDates6()" runat="server"> </asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" style="font-size: 12px;"></td>
                                                    <td colspan="2" style="font-size: 12px;">
                                                        <p style="font-size: 12px;">Total Experience:</p>
                                                        <asp:TextBox class="form-control" ReadOnly="true" autocomplete="off" ID="TotalExperience" runat="server"> </asp:TextBox>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>


                            <div class="row">
                                <div class="col-12">
                                    <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important; font-size: 18PX; font-weight: 600; line-height: 2.7;">Details of Retired Engineer:
                                    </h6>

                                </div>
                                <div class="col-12">
                                    <div class="table-responsive" id="RetiredEmployee" visible="true" runat="server">
                                        <table class="table table-bordered">
                                            <thead>
                                                <tr style="text-align: center;">
                                                    <th scope="col">Sno.</th>
                                                    <th scope="col">Name of Employer  
                                                    </th>
                                                    <th scope="col">Post Description</th>
                                                    <th scope="col">From</th>
                                                    <th scope="col">To</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <tr>
                                                    <td style="text-align: center; font-size: 13px;">1
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" ID="EmployerName2" runat="server"> </asp:TextBox>
                                                    </td>
                                                    <td>

                                                        <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" ID="Description2" runat="server"> </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" min='0000-01-01' max='9999-01-01' ID="From2" runat="server"> </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" min='0000-01-01' max='9999-01-01' ID="To2" runat="server"> </asp:TextBox>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>


                            <div class="row">
                                <div class="col-12">
                                    <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important; font-size: 18PX; font-weight: 600; line-height: 2.7;">Document Checklist:
                                    </h6>

                                </div>
                                <div class="col-12">
                                    <%-- Add GridView Here --%>
                                    <asp:GridView ID="grd_Documemnts" CssClass="table table-bordered table-striped table-responsive" runat="server" autopostback="true" AutoGenerateColumns="false">
                                        <HeaderStyle BackColor="#B7E2F0" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="SNo">
                                                <HeaderStyle Width="5%" CssClass="headercolor tdwidth" />
                                                <ItemStyle Width="5%" />
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex+1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="DocumentName" HeaderText="Documents Name">
                                                <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                                <ItemStyle HorizontalAlign="Left" Width="15%" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Documents" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="4%">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="LnkDocumemtPath" runat="server" CommandArgument='<%# Bind("DocumentPath") %>' CommandName="Select">Click here to view document </asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="2%"></ItemStyle>
                                                <HeaderStyle HorizontalAlign="Left" CssClass="headercolor" />
                                            </asp:TemplateField>
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

                                    <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important; font-size: 18PX; font-weight: 700;">Place:
                                        <asp:Label ID="lblApprovedDate" runat="server" Text="29-Aug-2025" Style="font-weight: 500; font-size: 16px !important;"></asp:Label></h6>
                                    <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important; font-size: 18PX; font-weight: 700;">Dated:
     <asp:Label ID="Label12" runat="server" Text="29-Aug-2025" Style="font-weight: 500; font-size: 16px !important;"></asp:Label></h6>
                                </div>
                                <div class="col-9" style="text-align: end">

                                    <asp:Image ID="myImage" runat="server" Width="300" Height="90" Style="bottom: 140px; margin-left: -300px;" />
                                    <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important; font-size: 18PX; font-weight: 700; margin-right: 55px;">Signature of Applicant</h6>

                                </div>
                            </div>

                            <br />
                            <br />
                            <div class="row">
                                <div class="col-12">
                                    <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important; font-size: 18PX; text-align: Justify;">Photocopies of documents to be forwarded alongwith the application:-</h6>

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
                            </div>




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
