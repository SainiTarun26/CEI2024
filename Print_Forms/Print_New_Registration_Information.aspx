<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Print_New_Registration_Information.aspx.cs" Inherits="CEIHaryana.Print_Forms.Print__New_Registration_Information" %>

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
        .form-control:disabled, .form-control[readonly] {
            background-color: #e9ecef;
            opacity: 1;
            min-height: 30px;
            height: auto;
            width: 100% !important;
        }

        ul#profile_drop {
            margin-left: -86px;
            width: 120px;
            border-radius: 8px;
        }

        span#user, svg.bi.bi-person-circle {
            color: white;
        }

        #header .logo img {
            max-height: 62px;
            margin-left: 41px;
            margin-top: 6px;
        }

        li#logout {
            background: #4B49AC !important;
            border-radius: 51px !important;
            padding: 10px !important;
        }

        img#ProfilePhoto {
            height: 100px;
            width: 100px;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0;
        }

        input#exampleInputUsername1,
        input#exampleInputEmail1,
        input.form-control,
        select#exampleFormControlSelect3 {
            width: 90%;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            min-height: 30px;
            height: auto;
        }

            input#exampleInputUsername1:hover,
            input#exampleInputUsername1:focus,
            input#exampleInputEmail1:hover,
            input#exampleInputEmail1:focus,
            select#exampleFormControlSelect3:hover,
            select#exampleFormControlSelect3:focus,
            input.form-control:hover,
            input.form-control:focus {
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
                background: #f3f3f3;
            }

        input#exampleInputConfirmPassword12,
        input#exampleInputConfirmPassword13 {
            width: 100%;
            height: 31px;
        }

        select, textarea {
            width: 90%;
            font-size: 0.875rem;
            font-weight: 400;
            border-radius: 4px;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
            border: 1px solid #CED4DA;
        }

        textarea {
            font-weight: bold;
            font-size: 22px;
            border: none !important;
            white-space: normal;
        }

        input#Button1,
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

        .validation_required {
            font-size: 13px;
        }

        .form-group label {
            font-size: 12px;
            line-height: 1.4rem;
            margin-bottom: 0px !important;
        }

        img {
            margin-top: 10px;
            margin-bottom: 9px;
            vertical-align: middle;
            border-style: none;
        }

        .container.aos-init.aos-animate {
            max-width: 1600px;
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
            padding: 5px !important;
            vertical-align: top !important;
            white-space: normal !important;
            word-wrap: break-word !important;
            overflow: visible !important;
            line-height: 1.5 !important;
            height: auto !important;
        }

        table.table {
            font-size: 17px;
        }

        .vl {
            border-left: 2px solid black;
            height: 245px;
        }

        ol {
            padding-left: 20px;
        }

        .uppercase-label {
            text-transform: uppercase;
        }

        .full-underline {
            padding: 0;
            margin: 0;
            list-style-type: decimal;
            list-style-position: outside;
        }

            .full-underline li {
                position: relative;
                padding: 8px 0 8px 20px;
                border-bottom: 1px dotted black;
            }

        .form-control {
            margin-left: 0 !important;
            font-size: 16px !important;
            border: none;
            border-radius: 0;
            margin-top: 5px;
            padding: 0;
            background: none;
            min-height: 30px;
            height: auto;
            white-space: normal !important;
            overflow-wrap: break-word !important;
            word-break: break-word !important;
            line-height: 1.5 !important;
        }

        label {
            font-size: 18px;
            margin-top: 5px;
            font-weight: 600;
        }

        u {
            font-size: 22px;
        }

        p {
            font-size: 20px;
            text-align: justify;
        }

        li {
            font-size: 18px;
            font-weight: 600;
            line-height: 2;
        }

        .col-2 {
            font-weight: bold;
        }

        input {
            border: none;
            font-size: 18px;
        }

        hr {
            border: 1px solid black !important;
            margin-top: -10px;
            margin-bottom: 5px;
        }

        span {
            font-size: 18px !important;
            padding-bottom: 35px;
        }

            span#SD {
                font-size: 45px !important;
                padding-right: 150px;
            }

        .p1 {
            font-family: 'Cedarville Cursive', cursive;
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
        }

        input#InstallationType,
        input#TestReportId {
            font-size: 25px !important;
            font-weight: 700;
            border-bottom: 0 !important;
        }

        input#InstallationType {
            text-align: end;
        }

        input#TestReportId {
            text-align: initial;
        }

        th.headercolor {
            width: 46% !important;
        }

        img#Gridview1_ImgSignature_0 {
            height: 45px;
            width: 100px;
        }

        td.textbold {
            font-weight: bold;
        }

        @media print {
            .form-control {
                border: none !important;
                box-shadow: none !important;
                padding: 0 !important;
                background: none !important;
                min-height: 30px !important;
                height: auto !important;
                line-height: 1.5 !important;
                white-space: normal !important;
                overflow-wrap: break-word !important;
                word-break: break-word !important;
            }

            .table-responsive {
                overflow: visible !important;
            }

            table {
                width: 100% !important;
                table-layout: auto !important;
                border-collapse: collapse !important;
                word-wrap: break-word !important;
            }

            th, td {
                white-space: normal !important;
                word-wrap: break-word !important;
                overflow: visible !important;
                height: auto !important;
                line-height: 1.5 !important;
                vertical-align: top !important;
                padding: 5px !important;
            }

            tr {
                page-break-inside: avoid !important;
                height: auto !important;
            }

            .no-print, .btn, .navbar {
                display: none !important;
            }
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
                                <div class="col-sm-12" style="text-align: justify; padding-top: 8px; padding-bottom: 8px; border-radius: 10px;">
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
                                        <asp:Label ID="FatherName" runat="server" CssClass="uppercase-label" Style="font-weight: 700; width: 80%; display: inline-block; border-bottom: 1px solid black; height: 30px; padding-left: 10px;">
                                        </asp:Label>
                                        <br />
                                        <text>Gender:    </text>
                                        <asp:Label ID="gender" runat="server" CssClass="uppercase-label" Style="font-weight: 700; width: 40%; display: inline-block; border-bottom: 1px solid black; height: 30px; padding-left: 10px;">
                                        </asp:Label>
                                        <text>Nationality:</text>
                                        <asp:Label ID="Nationailty" runat="server" CssClass="uppercase-label" Style="font-weight: 700; width: 33%; display: inline-block; border-bottom: 1px solid black; height: 30px; padding-left: 10px;">
                                        </asp:Label>
                                        <br />
                                        <text>Date of Birth:</text>
                                        <asp:Label ID="dob" runat="server" CssClass="uppercase-label" Style="font-weight: 700; width: 22%; display: inline-block; border-bottom: 1px solid black; height: 30px; padding-left: 10px;">
                                        </asp:Label>

                                        <text>Years:</text>
                                        <asp:Label ID="Age" runat="server" Style="font-weight: 700; width: 52%; display: inline-block; border-bottom: 1px solid black; height: 30px; padding-left: 10px;">
                                        </asp:Label>

                                    </h6>

                                </div>
                                <div class="col-3">
                                    <div class="mx-auto" style="width: 175px; height: 195px; border: 1px solid #ccc; background-color: #f8f9fa;">
                                        <asp:Image ID="imgPhoto" runat="server" Width="100px" Height="100px" Style="object-fit: cover;" />

                                    </div>
                                </div>



                            </div>
                            <div class="row">
                                <div class="col-12">
                                    <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important; font-size: 18PX; font-weight: 600; line-height: 2.7;">
                                        <text>Permanent Address:</text>
                                        <asp:Label ID="PermanentAddress" CssClass="uppercase-label" runat="server" Style="font-weight: 700; width: 82%; display: inline-block; border-bottom: 1px solid black; height: 30px; padding-left: 10px;">
                                        </asp:Label>
                                    </h6>
                                </div>
                                <div class="col-12">
                                    <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important; font-size: 18PX; font-weight: 600; line-height: 2.7;">
                                        <text>Communication Address:</text>
                                        <asp:Label ID="CommunicationAddress" CssClass="uppercase-label" runat="server" Style="font-weight: 700; width: 77%; display: inline-block; border-bottom: 1px solid black; height: 30px; padding-left: 10px;">
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
                                        <asp:Label ID="Email" runat="server" Style="font-weight: 700; width: 84%; display: inline-block; border-bottom: 1px solid black; height: 30px; padding-left: 10px;">
                                        </asp:Label>
                                    </h6>
                                </div>
                                <div class="col-12" style="padding-right: 0px !important;">
                                    <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important; font-size: 18PX; font-weight: 600; line-height: 2.7;">
                                        <text>Aadhaar No.:</text>
                                        <asp:Label ID="Aadhar" runat="server" Style="font-weight: 700; width: 29%; display: inline-block; border-bottom: 1px solid black; height: 30px; padding-left: 10px;">
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
                                                <tr style="text-align: justify;">

                                                    <th scope="col" style="width: 15% !important; text-align: justify;">Exam Name</th>
                                                    <th scope="col" style="width: 20% !important; text-align: justify;">Board/University Name</th>
                                                    <th scope="col" style="width: 10% !important;">Passing Year</th>
                                                    <th scope="col" style="width: 15% !important;">Obtained Marks&nbsp;/&nbsp;Max Marks                                                      
                                                    </th>
                                                    <th scope="col" style="width: 7% !important;">% </th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <tr>
                                                    <td>
                                                        <asp:Label ReadOnly="true" class="form-control" ID="Label1" runat="server" Text="10th"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ReadOnly="true" class="form-control uppercase-label" ID="University" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="text-align: center !important;">

                                                        <asp:Label ReadOnly="true" class="form-control uppercase-label" ID="Passingyear" runat="server" min='0000-01-01' max='9999-01-01'></asp:Label>
                                                        <div>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div class="row">
                                                            <div class="col-6">
                                                                <asp:Label ReadOnly="true" class="form-control uppercase-label" ID="marksObtained" MaxLength="3" onKeyPress="return isNumberKey(event);" autocomplete="off" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-6">
                                                                <asp:Label ReadOnly="true" class="form-control uppercase-label" ID="marksmax" MaxLength="3" onKeyPress="return isNumberKey(event);" autocomplete="off" runat="server" AutoPostBack="true"></asp:Label>
                                                            </div>
                                                        </div>

                                                    </td>
                                                    <td style="text-align: center;">
                                                        <asp:Label ReadOnly="true" class="form-control uppercase-label" ID="prcntg" MaxLength="3" onKeyPress="return isNumberKey(event);" autocomplete="off" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr id="Tr_Qualification2" runat="server" visible="false">
                                                    <td>
                                                        <asp:Label ReadOnly="true" class="form-control" ID="Exam1" MaxLength="50" autocomplete="off" TabIndex="2" onKeyPress="return alphabetKey(event);" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ReadOnly="true" class="form-control uppercase-label" autocomplete="off" ID="University1" runat="server"></asp:Label>

                                                    </td>
                                                    <td style="text-align: center !important;">
                                                        <asp:Label ReadOnly="true" class="form-control uppercase-label" autocomplete="off" min='0000-01-01' max='9999-01-01' ID="Passingyear1" runat="server"></asp:Label>

                                                    </td>
                                                    <td>
                                                        <div class="row">

                                                            <div class="col-6">
                                                                <asp:Label ReadOnly="true" class="form-control uppercase-label" autocomplete="off" MaxLength="3" onKeyPress="return isNumberKey(event);" ID="marksObtained1" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-6">
                                                                <asp:Label ReadOnly="true" class="form-control uppercase-label" autocomplete="off" MaxLength="3" onKeyPress="return isNumberKey(event);" ID="marksmax1" runat="server" AutoPostBack="true"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </td>
                                                    <td style="text-align: center;">
                                                        <asp:Label class="form-control uppercase-label" autocomplete="off" MaxLength="3" onKeyPress="return isNumberKey(event);" ID="prcntg1" ReadOnly="true" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr id="Tr_Qualification3" runat="server" visible="false">

                                                    <td style="text-align: justify;">
                                                        <asp:Label ReadOnly="true" class="form-control" ID="Exam2" MaxLength="50" autocomplete="off" TabIndex="2" onKeyPress="return alphabetKey(event);" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ReadOnly="true" class="form-control uppercase-label" ID="University2" autocomplete="off" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="text-align: center !important;">
                                                        <asp:Label ReadOnly="true" class="form-control uppercase-label" autocomplete="off" min='0000-01-01' max='9999-01-01' ID="Passingyear2" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <div class="row">
                                                            <div class="col-6">
                                                                <asp:Label ReadOnly="true" class="form-control uppercase-label" autocomplete="off" MaxLength="3" onKeyPress="return isNumberKey(event);" ID="marksObtained2" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-6">
                                                                <asp:Label ReadOnly="true" class="form-control uppercase-label" autocomplete="off" MaxLength="3" onKeyPress="return isNumberKey(event);" ID="marksmax2" runat="server" AutoPostBack="true"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </td>
                                                    <td style="text-align: center;">
                                                        <asp:Label class="form-control uppercase-label" autocomplete="off" MaxLength="3" onKeyPress="return isNumberKey(event);" ID="prcntg2" ReadOnly="true" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr id="DdlDegree" runat="server" visible="false">

                                                    <td style="text-align: justify;">
                                                        <asp:Label ReadOnly="true" class="form-control" ID="Exam3" MaxLength="50" autocomplete="off" TabIndex="2" onKeyPress="return alphabetKey(event);" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ReadOnly="true" class="form-control uppercase-label" autocomplete="off" ID="University3" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="text-align: center !important;">
                                                        <asp:Label ReadOnly="true" class="form-control uppercase-label" autocomplete="off" min='0000-01-01' max='9999-01-01' ID="Passingyear3" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <div class="row">
                                                            <div class="col-6">
                                                                <asp:Label ReadOnly="true" class="form-control uppercase-label" autocomplete="off" MaxLength="3" onKeyPress="return isNumberKey(event);" ID="marksObtained3" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-6">
                                                                <asp:Label ReadOnly="true" class="form-control uppercase-label" autocomplete="off" MaxLength="3" onKeyPress="return isNumberKey(event);" ID="marksmax3" runat="server" AutoPostBack="true"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </td>
                                                    <td style="text-align: center;">
                                                        <asp:Label class="form-control uppercase-label" autocomplete="off" ID="prcntg3" MaxLength="3" onKeyPress="return isNumberKey(event);" ReadOnly="true" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr id="DdlMasters" visible="false" runat="server">

                                                    <td style="text-align: justify;">
                                                        <asp:Label ReadOnly="true" class="form-control" ID="Exam4" MaxLength="50" autocomplete="off" TabIndex="2" onKeyPress="return alphabetKey(event);" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label class="form-control uppercase-label" autocomplete="off" ID="University4" runat="server"></asp:Label>
                                                    </td>
                                                    <td style="text-align: center !important;">
                                                        <asp:Label class="form-control uppercase-label" autocomplete="off" min='0000-01-01' max='9999-01-01' ID="Passingyear4" runat="server"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <div class="row">
                                                            <div class="col-6">
                                                                <asp:Label ReadOnly="true" class="form-control uppercase-label" autocomplete="off" MaxLength="3" onKeyPress="return isNumberKey(event);" ID="marksObtained4" runat="server"></asp:Label>
                                                            </div>
                                                            <div class="col-6">
                                                                <asp:Label ReadOnly="true" class="form-control uppercase-label" autocomplete="off" MaxLength="3" onKeyPress="return isNumberKey(event);" ID="marksmax4" runat="server" AutoPostBack="true"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </td>
                                                    <td style="text-align: center;">
                                                        <asp:Label class="form-control uppercase-label" autocomplete="off" ID="prcntg4" MaxLength="3" onKeyPress="return isNumberKey(event);" ReadOnly="true" runat="server"></asp:Label>
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
                                                    <tr style="text-align: justify;">
                                                        <th scope="col" style="text-align: justify;">Sno.</th>
                                                        <th scope="col" style="text-align: justify;">Category  
                                                        </th>
                                                        <th scope="col" style="text-align: justify;">Permit No.</th>
                                                        <th scope="col" style="text-align: justify;">Issuing Authority</th>
                                                        <th scope="col">Issue Date</th>
                                                        <th scope="col">Expiry Date</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <tr>
                                                        <td style="text-align: justify; font-size: 13px;">1
                                                        </td>
                                                        <td>
                                                            <asp:Label ReadOnly="true" class="form-control uppercase-label" autocomplete="off" ID="Category" TabIndex="26" MaxLength="30" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ReadOnly="true" class="form-control uppercase-label" autocomplete="off" ID="PermitNo" TabIndex="27" MaxLength="20" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ReadOnly="true" class="form-control uppercase-label" autocomplete="off" ID="IssuingAuthority" TabIndex="28" MaxLength="50" runat="server"></asp:Label>
                                                        </td>
                                                        <td style="text-align: center;">
                                                            <asp:Label ReadOnly="true" class="form-control uppercase-label" autocomplete="off" TabIndex="29" ID="IssuingDate" runat="server" onchange="validateDates()"></asp:Label>
                                                        </td>
                                                        <td style="text-align: center;">
                                                            <asp:Label ReadOnly="true" class="form-control uppercase-label" autocomplete="off" ID="ExpiryDate" runat="server" TabIndex="30" onchange="validateDates()"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </div>


                                <div class="row">
                                    <div class="col-12">

                                        <h4 class="card-title" style="font-size: 15px;">Are you Employed on Permanent
Basis.</h4>


                                    </div>

                                    <div class="col-12">
                                        <asp:RadioButtonList ID="RadioButtonList3" Enabled="false" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" TabIndex="31">
                                            <asp:ListItem Text="Yes" Value="0" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="No" Value="1"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                    <div class="col-12" id="PermanentEmployee" visible="false" runat="server">
                                        <div class="table-responsive">
                                            <table class="table table-bordered">
                                                <thead>
                                                    <tr style="text-align: justify;">
                                                        <th scope="col" style="text-align: justify;">Sno.</th>
                                                        <th scope="col" style="text-align: justify;">Name of Employer
                                                        </th>
                                                        <th scope="col" style="text-align: justify;">Post Description</th>
                                                        <th scope="col" style="text-align: center;">From</th>
                                                        <th scope="col" style="text-align: center;">To</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <tr>
                                                        <td style="text-align: justify; font-size: 13px;">1
                                                        </td>
                                                        <td>
                                                            <asp:Label ReadOnly="true" class="form-control uppercase-label" autocomplete="off" ID="PermanentEmployerName" TabIndex="32" MaxLength="30" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ReadOnly="true" class="form-control uppercase-label" autocomplete="off" ID="PermanentDescription" TabIndex="33" MaxLength="50" runat="server"></asp:Label>
                                                        </td>
                                                        <td style="text-align: center;">
                                                            <asp:Label ReadOnly="true" class="form-control uppercase-label" autocomplete="off" ID="PermanentFrom" TabIndex="34" runat="server" onchange="validateDates1()"></asp:Label>
                                                        </td>
                                                        <td style="text-align: center;">
                                                            <asp:Label ReadOnly="true" class="form-control uppercase-label" autocomplete="off" ID="PermanentTo" TabIndex="35" runat="server" onchange="validateDates1()"></asp:Label>
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
                                                    <tr style="text-align: justify;">
                                                        <%--  <th scope="col">Sno.</th>--%>
                                                        <th scope="col" style="text-align: justify;">Experienced in  
                                                        </th>
                                                        <th scope="col" style="text-align: justify;">Training Under  
                                                        </th>
                                                        <th scope="col" style="width: 20%; text-align: justify">Name of Employer  
                                                        </th>
                                                        <th scope="col" style="text-align: justify;">Post Description</th>
                                                        <th scope="col" style="text-align: center;">From</th>
                                                        <th scope="col" style="text-align: center;">To</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <%--<tr>
                                                        <td>
                                                            <asp:Label ReadOnly="true" class="form-control uppercase-label" ID="Experience" MaxLength="50" autocomplete="off" TabIndex="2" onKeyPress="return alphabetKey(event);" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ReadOnly="true" class="form-control uppercase-label" ID="Trainingunder" MaxLength="50" autocomplete="off" TabIndex="2" onKeyPress="return alphabetKey(event);" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ReadOnly="true" class="form-control uppercase-label" autocomplete="off" ID="ExperienceEmployer" MaxLength="30" TabIndex="38" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ReadOnly="true" class="form-control uppercase-label" autocomplete="off" ID="PostDescription" MaxLength="50" TabIndex="39" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ReadOnly="true" class="form-control uppercase-label" autocomplete="off" min='0000-01-01' max='9999-01-01' ID="ExperienceFrom" TabIndex="40" onchange="validateDates2()" runat="server"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ReadOnly="true" class="form-control uppercase-label" autocomplete="off" AutoPostBack="true" min='0000-01-01' max='9999-01-01' ID="ExperienceTo" TabIndex="41" onchange="validateDates2()" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>--%>
                                                    <tr id="TrApprenticeship" runat="server" visible="true" autopostback="true">
                                                        <td>
                                                            <asp:Label ReadOnly="true" class="form-control" autocomplete="off" ID="txtApprenticeship" TabIndex="32" MaxLength="30" runat="server"></asp:Label>

                                                        </td>
                                                        <td>
                                                            <asp:Label ReadOnly="true" class="form-control" autocomplete="off" ID="txtAppretinceExperience" TabIndex="32" MaxLength="30" runat="server"></asp:Label>

                                                        </td>
                                                        <td>
                                                            <asp:Label ReadOnly="true" class="form-control uppercase-label" autocomplete="off" ID="txtApprenticeshipEmployer" TabIndex="32" MaxLength="30" runat="server"></asp:Label>

                                                        </td>
                                                        <td>
                                                            <asp:Label ReadOnly="true" class="form-control uppercase-label" autocomplete="off" ID="txtApprenticesPost" TabIndex="32" MaxLength="30" runat="server"></asp:Label>

                                                        </td>
                                                        <td>
                                                            <asp:Label ReadOnly="true" class="form-control uppercase-label" autocomplete="off" ID="Apprenticesdatefrom" TabIndex="32" MaxLength="30" runat="server"></asp:Label>

                                                        </td>
                                                        <td>
                                                            <asp:Label ReadOnly="true" class="form-control uppercase-label" autocomplete="off" ID="Apprenticesdateto" TabIndex="32" MaxLength="30" runat="server"></asp:Label>

                                                        </td>
                                                    </tr>
                                                    <tr id="Experience" runat="server" visible="false" autopostback="true">
                                                        <td>
                                                            <asp:Label ReadOnly="true" class="form-control" autocomplete="off" ID="ddlExperience" TabIndex="32" MaxLength="30" runat="server"></asp:Label>

                                                        </td>
                                                        <td>
                                                            <asp:Label ReadOnly="true" class="form-control" autocomplete="off" ID="ddlTrainingUnder" TabIndex="32" MaxLength="30" runat="server"></asp:Label>

                                                        </td>
                                                        <td>

                                                            <asp:Label ReadOnly="true" class="form-control uppercase-label" autocomplete="off" ID="txtExperienceEmployer" TabIndex="32" MaxLength="30" runat="server"></asp:Label>

                                                        </td>
                                                        <td>
                                                            <asp:Label ReadOnly="true" class="form-control uppercase-label" autocomplete="off" ID="txtPostDescription" TabIndex="32" MaxLength="30" runat="server"></asp:Label>

                                                        </td>
                                                        <td>

                                                            <asp:Label ReadOnly="true" class="form-control uppercase-label" autocomplete="off" ID="txtExperienceFrom" TabIndex="32" MaxLength="30" runat="server"></asp:Label>

                                                        </td>
                                                        <td>
                                                            <asp:Label ReadOnly="true" class="form-control uppercase-label" autocomplete="off" ID="txtExperienceTo" TabIndex="32" MaxLength="30" runat="server"></asp:Label>

                                                        </td>
                                                    </tr>
                                                    <tr id="Experience1" runat="server" visible="false">
                                                        <td>
                                                            <asp:Label ReadOnly="true" class="form-control" autocomplete="off" ID="ddlExperience1" TabIndex="32" MaxLength="30" runat="server"></asp:Label>

                                                        </td>
                                                        <td>
                                                            <asp:Label ReadOnly="true" class="form-control" autocomplete="off" ID="ddlTrainingUnder1" TabIndex="32" MaxLength="30" runat="server"></asp:Label>

                                                        </td>
                                                        <td>
                                                            <asp:Label ReadOnly="true" class="form-control uppercase-label" autocomplete="off" ID="txtExperienceEmployer1" TabIndex="32" MaxLength="30" runat="server"></asp:Label>

                                                        </td>
                                                        <td>

                                                            <asp:Label ReadOnly="true" class="form-control uppercase-label" autocomplete="off" ID="txtPostDescription1" TabIndex="32" MaxLength="30" runat="server"></asp:Label>

                                                        </td>
                                                        <td>
                                                            <asp:Label ReadOnly="true" class="form-control uppercase-label" autocomplete="off" ID="txtExperienceFrom1" TabIndex="32" MaxLength="30" runat="server"></asp:Label>

                                                        </td>
                                                        <td>

                                                            <asp:Label ReadOnly="true" class="form-control uppercase-label" autocomplete="off" ID="txtExperienceTo1" TabIndex="32" MaxLength="30" runat="server"></asp:Label>

                                                        </td>

                                                    </tr>
                                                    <tr id="Experience2" runat="server" visible="false">
                                                        <td>
                                                            <asp:Label ReadOnly="true" class="form-control" autocomplete="off" ID="ddlExperience2" TabIndex="32" MaxLength="30" runat="server"></asp:Label>

                                                        </td>
                                                        <td>
                                                            <asp:Label ReadOnly="true" class="form-control" autocomplete="off" ID="ddlTrainingUnder2" TabIndex="32" MaxLength="30" runat="server"></asp:Label>

                                                        </td>
                                                        <td>
                                                            <asp:Label ReadOnly="true" class="form-control uppercase-label" autocomplete="off" ID="txtExperienceEmployer2" TabIndex="32" MaxLength="30" runat="server"></asp:Label>

                                                        </td>
                                                        <td>

                                                            <asp:Label ReadOnly="true" class="form-control uppercase-label" autocomplete="off" ID="txtPostDescription2" TabIndex="32" MaxLength="30" runat="server"></asp:Label>

                                                        </td>
                                                        <td>
                                                            <asp:Label ReadOnly="true" class="form-control uppercase-label" autocomplete="off" ID="txtExperienceFrom2" TabIndex="32" MaxLength="30" runat="server"></asp:Label>

                                                        </td>
                                                        <td>

                                                            <asp:Label ReadOnly="true" class="form-control uppercase-label" autocomplete="off" ID="txtExperienceTo2" TabIndex="32" MaxLength="30" runat="server"></asp:Label>

                                                        </td>
                                                    </tr>
                                                    <tr id="Experience3" runat="server" visible="false">
                                                        <td>
                                                            <asp:Label ReadOnly="true" class="form-control" autocomplete="off" ID="ddlExperience3" TabIndex="32" MaxLength="30" runat="server"></asp:Label>

                                                        </td>
                                                        <td>
                                                            <asp:Label ReadOnly="true" class="form-control" autocomplete="off" ID="ddlTrainingUnder3" TabIndex="32" MaxLength="30" runat="server"></asp:Label>

                                                        </td>
                                                        <td>
                                                            <asp:Label ReadOnly="true" class="form-control uppercase-label" autocomplete="off" ID="txtExperienceEmployer3" TabIndex="32" MaxLength="30" runat="server"></asp:Label>

                                                        </td>
                                                        <td>

                                                            <asp:Label ReadOnly="true" class="form-control uppercase-label" autocomplete="off" ID="txtPostDescription3" TabIndex="32" MaxLength="30" runat="server"></asp:Label>

                                                        </td>
                                                        <td>
                                                            <asp:Label ReadOnly="true" class="form-control uppercase-label" autocomplete="off" ID="txtExperienceFrom3" TabIndex="32" MaxLength="30" runat="server"></asp:Label>

                                                        </td>
                                                        <td>

                                                            <asp:Label ReadOnly="true" class="form-control uppercase-label" autocomplete="off" ID="txtExperienceTo3" TabIndex="32" MaxLength="30" runat="server"></asp:Label>

                                                        </td>
                                                    </tr>
                                                    <tr id="Experience4" runat="server" visible="false">

                                                        <td>
                                                            <asp:Label ReadOnly="true" class="form-control" autocomplete="off" ID="ddlExperience4" TabIndex="32" MaxLength="30" runat="server"></asp:Label>

                                                        </td>
                                                        <td>
                                                            <asp:Label ReadOnly="true" class="form-control" autocomplete="off" ID="ddlTrainingUnder4" TabIndex="32" MaxLength="30" runat="server"></asp:Label>

                                                        </td>
                                                        <td>
                                                            <asp:Label ReadOnly="true" class="form-control uppercase-label" autocomplete="off" ID="txtExperienceEmployer4" TabIndex="32" MaxLength="30" runat="server"></asp:Label>

                                                        </td>
                                                        <td>

                                                            <asp:Label ReadOnly="true" class="form-control uppercase-label" autocomplete="off" ID="txtPostDescription4" TabIndex="32" MaxLength="30" runat="server"></asp:Label>

                                                        </td>
                                                        <td>
                                                            <asp:Label ReadOnly="true" class="form-control uppercase-label" autocomplete="off" ID="txtExperienceFrom4" TabIndex="32" MaxLength="30" runat="server"></asp:Label>

                                                        </td>
                                                        <td>

                                                            <asp:Label ReadOnly="true" class="form-control uppercase-label" autocomplete="off" ID="txtExperienceTo4" TabIndex="32" MaxLength="30" runat="server"></asp:Label>

                                                        </td>
                                                    </tr>
                                                    <tr id="Experience5" runat="server" visible="false">
                                                        <td>
                                                            <asp:Label ReadOnly="true" class="form-control" autocomplete="off" ID="ddlExperience5" TabIndex="32" MaxLength="30" runat="server"></asp:Label>

                                                        </td>
                                                        <td>
                                                            <asp:Label ReadOnly="true" class="form-control" autocomplete="off" ID="ddlTrainingUnder5" TabIndex="32" MaxLength="30" runat="server"></asp:Label>

                                                        </td>
                                                        <td>
                                                            <asp:Label ReadOnly="true" class="form-control uppercase-label" autocomplete="off" ID="txtExperienceEmployer5" TabIndex="32" MaxLength="30" runat="server"></asp:Label>

                                                        </td>
                                                        <td>

                                                            <asp:Label ReadOnly="true" class="form-control uppercase-label" autocomplete="off" ID="txtPostDescription5" TabIndex="32" MaxLength="30" runat="server"></asp:Label>

                                                        </td>
                                                        <td>
                                                            <asp:Label ReadOnly="true" class="form-control uppercase-label" autocomplete="off" ID="txtExperienceFrom5" TabIndex="32" MaxLength="30" runat="server"></asp:Label>

                                                        </td>
                                                        <td>

                                                            <asp:Label ReadOnly="true" class="form-control uppercase-label" autocomplete="off" ID="txtExperienceTo5" TabIndex="32" MaxLength="30" runat="server"></asp:Label>

                                                        </td>
                                                    </tr>
                                                    <tr id="Experience6" runat="server" visible="false">

                                                        <td>
                                                            <asp:Label ReadOnly="true" class="form-control" autocomplete="off" ID="ddlExperience6" TabIndex="32" MaxLength="30" runat="server"></asp:Label>

                                                        </td>
                                                        <td>
                                                            <asp:Label ReadOnly="true" class="form-control" autocomplete="off" ID="ddlTrainingUnder6" TabIndex="32" MaxLength="30" runat="server"></asp:Label>

                                                        </td>
                                                        <td>
                                                            <asp:Label ReadOnly="true" class="form-control uppercase-label" autocomplete="off" ID="txtExperienceEmployer6" TabIndex="32" MaxLength="30" runat="server"></asp:Label>

                                                        </td>
                                                        <td>

                                                            <asp:Label ReadOnly="true" class="form-control uppercase-label" autocomplete="off" ID="txtPostDescription6" TabIndex="32" MaxLength="30" runat="server"></asp:Label>

                                                        </td>
                                                        <td>
                                                            <asp:Label ReadOnly="true" class="form-control uppercase-label" autocomplete="off" ID="txtExperienceFrom6" TabIndex="32" MaxLength="30" runat="server"></asp:Label>

                                                        </td>
                                                        <td>

                                                            <asp:Label ReadOnly="true" class="form-control uppercase-label" autocomplete="off" ID="txtExperienceTo6" TabIndex="32" MaxLength="30" runat="server"></asp:Label>

                                                        </td>
                                                    </tr>
                                                    <tr id="Experience7" runat="server" visible="false">

                                                        <td>
                                                            <asp:Label ReadOnly="true" class="form-control" autocomplete="off" ID="ddlExperience7" TabIndex="32" MaxLength="30" runat="server"></asp:Label>

                                                        </td>
                                                        <td>
                                                            <asp:Label ReadOnly="true" class="form-control" autocomplete="off" ID="ddlTrainingUnder7" TabIndex="32" MaxLength="30" runat="server"></asp:Label>

                                                        </td>
                                                        <td>
                                                            <asp:Label ReadOnly="true" class="form-control uppercase-label" autocomplete="off" ID="txtExperienceEmployer7" TabIndex="32" MaxLength="30" runat="server"></asp:Label>

                                                        </td>
                                                        <td>

                                                            <asp:Label ReadOnly="true" class="form-control uppercase-label" autocomplete="off" ID="txtPostDescription7" TabIndex="32" MaxLength="30" runat="server"></asp:Label>

                                                        </td>
                                                        <td>
                                                            <asp:Label ReadOnly="true" class="form-control uppercase-label" autocomplete="off" ID="txtExperienceFrom7" TabIndex="32" MaxLength="30" runat="server"></asp:Label>

                                                        </td>
                                                        <td>

                                                            <asp:Label ReadOnly="true" class="form-control uppercase-label" autocomplete="off" ID="txtExperienceTo7" TabIndex="32" MaxLength="30" runat="server"></asp:Label>

                                                        </td>
                                                    </tr>
                                                    <tr id="Experience8" runat="server" visible="false">

                                                        <td>
                                                            <asp:Label ReadOnly="true" class="form-control" autocomplete="off" ID="ddlExperience8" TabIndex="32" MaxLength="30" runat="server"></asp:Label>

                                                        </td>
                                                        <td>
                                                            <asp:Label ReadOnly="true" class="form-control" autocomplete="off" ID="ddlTrainingUnder8" TabIndex="32" MaxLength="30" runat="server"></asp:Label>

                                                        </td>
                                                        <td>
                                                            <asp:Label ReadOnly="true" class="form-control uppercase-label" autocomplete="off" ID="txtExperienceEmployer8" TabIndex="32" MaxLength="30" runat="server"></asp:Label>

                                                        </td>
                                                        <td>

                                                            <asp:Label ReadOnly="true" class="form-control uppercase-label" autocomplete="off" ID="txtPostDescription8" TabIndex="32" MaxLength="30" runat="server"></asp:Label>

                                                        </td>
                                                        <td>
                                                            <asp:Label ReadOnly="true" class="form-control uppercase-label" autocomplete="off" ID="txtExperienceFrom8" TabIndex="32" MaxLength="30" runat="server"></asp:Label>

                                                        </td>
                                                        <td>

                                                            <asp:Label ReadOnly="true" class="form-control uppercase-label" autocomplete="off" ID="txtExperienceTo8" TabIndex="32" MaxLength="30" runat="server"></asp:Label>

                                                        </td>
                                                    </tr>
                                                    <tr id="Experience9" runat="server" visible="false">

                                                        <td>
                                                            <asp:Label ReadOnly="true" class="form-control" autocomplete="off" ID="ddlExperience9" TabIndex="32" MaxLength="30" runat="server"></asp:Label>

                                                        </td>
                                                        <td>
                                                            <asp:Label ReadOnly="true" class="form-control" autocomplete="off" ID="ddlTrainingUnder9" TabIndex="32" MaxLength="30" runat="server"></asp:Label>

                                                        </td>
                                                        <td>
                                                            <asp:Label ReadOnly="true" class="form-control uppercase-label" autocomplete="off" ID="txtExperienceEmployer9" TabIndex="32" MaxLength="30" runat="server"></asp:Label>

                                                        </td>
                                                        <td>

                                                            <asp:Label ReadOnly="true" class="form-control uppercase-label" autocomplete="off" ID="txtPostDescription9" TabIndex="32" MaxLength="30" runat="server"></asp:Label>

                                                        </td>
                                                        <td>
                                                            <asp:Label ReadOnly="true" class="form-control uppercase-label" autocomplete="off" ID="txtExperienceFrom9" TabIndex="32" MaxLength="30" runat="server"></asp:Label>

                                                        </td>
                                                        <td>

                                                            <asp:Label ReadOnly="true" class="form-control uppercase-label" autocomplete="off" ID="txtExperienceTo9" TabIndex="32" MaxLength="30" runat="server"></asp:Label>

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4" style="font-size: 12px;"></td>
                                                        <td colspan="2" style="font-size: 12px;">
                                                            <p style="font-size: 12px;">Total Experience:</p>
                                                            <asp:Label class="form-control uppercase-label" ReadOnly="true" autocomplete="off" ID="TotalExperience" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                                <div class="page-break"></div>
                                <!-- This causes the next content to shift to new printed page -->

                                <div class="row">
                                    <div class="col-12">
                                        <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important; font-size: 18PX; font-weight: 600; line-height: 2.7;">Details of Retired Engineer:
                                        </h6>

                                    </div>
                                    <div class="col-12">
                                        <asp:RadioButtonList ID="RadioButtonList1" Enabled="false" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" TabIndex="31">
                                            <asp:ListItem Text="Yes" Value="0" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="No" Value="1"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                    <div class="col-12">
                                        <div class="table-responsive" id="RetiredEmployee" visible="true" runat="server">
                                            <table class="table table-bordered">
                                                <thead>
                                                    <tr style="text-align: justify;">
                                                        <th scope="col" style="width: 0%; text-align: justify;">Sno.</th>
                                                        <th scope="col" style="width: 30%; text-align: justify;">Name of Employer  
                                                        </th>
                                                        <th scope="col" style="width: 30%; text-align: justify">Post Description</th>
                                                        <th scope="col">From</th>
                                                        <th scope="col">To</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <tr>
                                                        <td style="text-align: justify; font-size: 13px;">1
                                                        </td>
                                                        <td>
                                                            <%--<asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" ID="EmployerName2" runat="server"> </asp:TextBox>--%>
                                                            <asp:Label ReadOnly="true" class="form-control" autocomplete="off" ID="EmployerName2" runat="server"></asp:Label>
                                                        </td>
                                                        <td>

                                                            <%--<asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" ID="Description2" runat="server"> </asp:TextBox>--%>
                                                            <asp:Label ReadOnly="true" class="form-control" autocomplete="off" ID="Description2" runat="server"></asp:Label>
                                                        </td>
                                                        <td style="text-align: center;">
                                                            <%--<asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" min='0000-01-01' max='9999-01-01' ID="From2" runat="server"> </asp:TextBox>--%>
                                                            <asp:Label ReadOnly="true" class="form-control" autocomplete="off" ID="From2" runat="server"></asp:Label>
                                                        </td>
                                                        <td style="text-align: center;">
                                                            <%--<asp:TextBox ReadOnly="true" class="form-control" autocomplete="off" min='0000-01-01' max='9999-01-01' ID="To2" runat="server"> </asp:TextBox>--%>
                                                            <asp:Label ReadOnly="true" class="form-control" ID="To2" autocomplete="off" runat="server"></asp:Label>
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


                                <div class="row" style="width: 100%; margin-bottom: 50px;">
                                    <div class="col-3" style="margin-top: auto !important;">
                                    </div>
                                    <div class="col-9" style="text-align: end !important;">

                                        <asp:Image ID="mySignature" runat="server" Width="300" Height="90" Style="bottom: 140px; margin-left: -300px;" />
                                        <h6 class="card-title fw-semibold mb-4" style="margin-bottom: 0px !important; font-size: 18PX; font-weight: 700; margin-right: 55px;">Signature of Applicant</h6>

                                    </div>
                                </div>

                                <br />
                                <br />
                                <%--<div class="row">
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
        </div>
    </form>
</body>
</html>
