<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerificationLetter.aspx.cs" Inherits="CEIHaryana.Print_Forms.VerificationLetter" %>

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
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js">
   <link href="ScriptCalendar/jquery-ui.css" rel="stylesheet" type="text/css" />
   <script type="text/javascript" src="ScriptCalender/jquery-1.11.0.min.js"></script>
    <script type="text/javascript" src="ScriptCalender/jquery-ui.min.js"></script>


    <style>
        .card {
            padding-left: 30px !important;
            padding-right: 30px !important;
        }

        th.headercolor {
            color: white !important;
        }

        .multiselect {
            width: 100%;
        }

        .selectBox {
            position: relative;
        }

            .selectBox select {
                width: 100%;
                width: 100%;
            }

        .overSelect {
            position: absolute;
            left: 0;
            right: 0;
            top: 0;
            bottom: 0;
        }

        #mySelectOptions {
            display: none;
            border: 0.5px #7c7c7c solid;
            background-color: #ffffff;
            max-height: 150px;
            overflow-y: scroll;
        }

            #mySelectOptions label {
                display: block;
                font-weight: normal;
                display: block;
                white-space: nowrap;
                min-height: 1.2em;
                background-color: #ffffff00;
                padding: 0 2.25rem 0 .75rem;
                /* padding: .375rem 2.25rem .375rem .75rem; */
            }

                #mySelectOptions label:hover {
                    background-color: #1e90ff;
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

        .col-md-4 {
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
            font-size: 12.5px !important;
        }

        input#ContentPlaceHolder1_txtagency {
            font-size: 12.5px;
        }

        th.headercolor {
            background: #9292cc;
            color: white;
        }

        select#ContentPlaceHolder1_ddlSuggestion {
            display: block;
            width: 90%;
            padding-left: 12px;
            font-size: 1rem;
            font-weight: 400;
            line-height: 1.5;
            color: #212529;
            background-color: #fff;
            background-clip: padding-box;
            border: 1px solid #ced4da;
            -webkit-appearance: none;
            -moz-appearance: none;
            appearance: none;
            border-radius: .25rem;
            transition: border-color .15s ease-in-out, box-shadow .15s ease-in-out;
            height: 30px !important;
        }

        textarea#ContentPlaceHolder1_txtSuggestion {
            display: block;
            width: 100%;
            padding-left: 12px;
            font-size: 1rem;
            font-weight: 400;
            line-height: 1.5;
            color: #212529;
            background-color: #fff;
            background-clip: padding-box;
            border: 1px solid #ced4da;
            -webkit-appearance: none;
            -moz-appearance: none;
            appearance: none;
            border-radius: .25rem;
            transition: border-color .15s ease-in-out, box-shadow .15s ease-in-out;
            height: 100px !important;
        }

        .modal1 {
            display: none; /* Hidden by default */
            position: fixed;
            z-index: 1;
            left: 0;
            top: 0;
            width: 100%;
            height: 100%;
            overflow: auto;
            background-color: rgb(0, 0, 0);
            background-color: rgba(0, 0, 0, 0.4);
        }

        .modal-content {
            background-color: #fefefe;
            margin: 15% auto;
            padding: 20px;
            border: 1px solid #888;
            width: 80%;
        }

        input#ContentPlaceHolder1_BtnAddSuggestion {
            padding-top: 2px;
            padding-bottom: 2px;
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
                font-size: 18px;
                color: black;
            }

            .input-box input {
                flex-grow: 1;
                font-size: 18px;
                background: #fff;
                border: none;
                outline: none;
                padding: 0.5rem;
            }

            .input-box:focus-within {
                border-color: #777;
            }

        th {
            width: 1%;
        }
        /* Normal screen preview */
        #signature-section {
            position: absolute;
            bottom: 20px; /* keep some margin from bottom */
            width: 100%;
        }

        /* Ensure proper placement on A4 when printing */
        @media print {
            html, body {
                height: 300mm;
                margin: 0;
                padding: 0;
            }

            .card-body {
                min-height: 375mm; /* Full A4 height */
                position: relative; /* Needed for absolute child positioning */
            }

            #signature-section {
                position: absolute;
                bottom: 20mm; /* distance from bottom of A4 page */
                left: 0;
                right: 0;
                width: 100%;
            }
        }

        p {
            margin-bottom: 7px !important;
        }
    </style>
    <script type="text/javascript">

        $(document).ready(function () {

            window.print();
        });

    </script>


    <script>
        // Detect when the print dialog is closed (whether by printing or canceling)
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
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="card-body" style="border: 2px solid black; padding: 20px;">
            <asp:HiddenField ID="hdnApplicationId" runat="server" />
            <div class="row" style="margin-bottom: 15PX;">
                <div class="col-2" style="margin-top: auto; margin-bottom: auto; text-align: end;">
                    <img src="../Assets/haryana.png" height="110" width="auto" />
                </div>
                <div class="col-sm-10" style="text-align: center; padding-top: 8px; padding-bottom: 8px; border-radius: 10px; padding-right: 140px;">
                    <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important; font-size: 18px;">Office of the
                    </h6>
                    <asp:Label ID="lblAddress1" runat="server" Text="Chief Electrical Inspector to Govt., Haryana"
                        Style="font-weight: 700; margin-bottom: 0px !important; font-size: 18px; text-align: center;"></asp:Label><br />
                    <asp:Label ID="lblAdress2" runat="server"
                        Text="SCO 117-118, Sector-17-B, Chandigarh (E-mail: cei_goh@yahoo.com)"
                        Style="font-weight: 700; margin-bottom: 0px !important; font-size: 18px; text-align: center;"></asp:Label><br />
                    <asp:Label ID="lblAdress3" runat="server"
                        Text="Telephone No. 0172-2704090, Fax No. 0172-2710171"
                        Style="font-weight: 700; margin-bottom: 0px !important; font-size: 18px; text-align: center;"></asp:Label><br />
                    <asp:Label ID="lblAdress4" runat="server" Text="Website: www.ceiharyana.com"
                        Style="font-weight: 700; margin-bottom: 0px !important; font-size: 18px; text-align: center;"></asp:Label><br />
                </div>
            </div>
            <hr />

            <div class="letter-content"
                style="font-size: 18px; line-height: 1.5; padding-left: 15px; padding-right: 15px; text-align: justify;">

                <div style="display: flex; justify-content: space-between; margin-bottom: 20px;">
                    <div>
                        <asp:Label ID="lblName" runat="server" Text=""></asp:Label><br />
                        <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label>
                    </div>
                    <div>
                        Date:
                        <asp:Label ID="lblDate" runat="server" Text=""></asp:Label>
                    </div>
                </div>

                <p>
                    <p>
                        <strong>Subject:</strong> Document Verification and Clarification of Shortcomings for
               <asp:Label ID="lblCategary" runat="server" Text=""></asp:Label>
                        License Registration
                    </p>

                    <p><b>Dear Applicant,</b></p>

                    <p>
                        With reference to your online application bearing <b>Application No.</b>
                        <asp:Label ID="lblAppNo" runat="server" Text=""></asp:Label>
                        for the
                        <asp:Label ID="lblCategary1" runat="server" Text=""></asp:Label>
                        license registration, you are hereby requested
                to appear in person for the <b>mandatory Application Document Verification</b>.
                    </p>

                    <p>
                        During the preliminary scrutiny of your application, the following shortcomings/clarifications
                have been observed and are hereby communicated for your attention:
                    </p>

                    <p>
                        <%-- <b>Shortcomings identified:</b><br />--%>
                        <b>
                            <asp:Label ID="Shortcomings" runat="server" Text="Shortcomings identified:" Visible="true"></asp:Label></b><br />
                        <asp:Label ID="lblShortcomings" runat="server" Text="Shortcoming 1"></asp:Label>

                        <%-- <asp:Label ID="lblShortcomings1" runat="server" Text="Shortcoming 2"></asp:Label><br />
                        <br />
                        <asp:Label ID="lblShortcomings2" runat="server" Text="Shortcoming 3"></asp:Label><br />
                        <br />
                        <asp:Label ID="lblShortcomings3" runat="server" Text="Shortcoming 4"></asp:Label><br />
                        <br />
                        <asp:Label ID="lblShortcomings4" runat="server" Text="Shortcoming 5"></asp:Label><br />
                        <br />--%>
                    </p>

                    <%--<p>(In case no shortcomings are observed, “Nil” shall be displayed.)</p>--%>

                    <p>
                        You are requested to bring all relevant original documents uploaded during the online application
                process, along with the necessary supporting documents to address the above shortcomings, at the
                time of verification.
                    </p>

                    <p><b>The schedule for your document verification is as follows:</b></p>
                    <ul>
                        <li>Date:
                            <asp:Label ID="lblScheduleDate" runat="server" Text=""></asp:Label></li>
                        <li>Time:
                            <asp:Label ID="lblScheduleTime" runat="server" Text="{{Time}}"></asp:Label></li>
                        <li>Venue:
                            <asp:Label ID="lblScheduleVenue" runat="server" Text="{{Full Venue}}"></asp:Label></li>
                    </ul>

                    <p>This notice is issued with the approval of the State License Board Committee, Haryana.</p>


                    <p>With regards,</p>
                    <br />
                    <br />
                    <br />
                    <br />
                    <p>

                        <asp:Label ID="lblSuperintendent" runat="server" Text="Executive Engineer"></asp:Label><br />
                        <%--<asp:Label ID="lblChief" runat="server" Text="Chief Electrical Inspector (CEI), Haryana"></asp:Label>--%>
                    </p>
            </div>



            <br />
        </div>
    </form>

</body>
</html>
