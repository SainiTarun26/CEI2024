<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintPeriodicLiftTestReport.aspx.cs" Inherits="CEIHaryana.SiteOwnerPages.PrintPeriodicLiftTestReport" %>

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

    <script type="text/javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return true;
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

    <style>
        input {
            background: white !important;
        }

        div#Div4 {
            margin-top: 1px;
        }

        div#Div5 {
            margin-top: 1px;
        }

        div#CreatedDate {
            margin-top: 1px;
        }

        div#Div3 {
            margin-top: 1px;
        }

        div#SubmitDate1 {
            margin-top: 1px;
        }

        div#SubmitBy1 {
            margin-top: 1px;
        }

        .page1 {
            box-sizing: border-box;
            min-height: 100vh;
            border-radius: 10px;
            border: solid 1px black;
            padding: 25px;
        }

        .page2 {
            box-sizing: border-box;
            min-height: 100vh;
            border-radius: 10px;
            border: solid 1px black;
            padding: 25px;
        }
        .page3 {
    box-sizing: border-box;
    min-height: 100vh;
    border-radius: 10px;
    border: solid 1px black;
    padding: 25px;
}
                .page4 {
    box-sizing: border-box;
    min-height: 100vh;
    border-radius: 10px;
    border: solid 1px black;
    padding: 25px;
}

        input#txtInstallationType {
            font-size: 25px !important;
            font-weight: 700;
            text-align: end;
        }

        input#txtTestReportId {
            font-size: 25px !important;
            font-weight: 700;
            text-align: center;
            border-bottom: 0px solid !important;
        }

        .col-4 {
            top: 0px;
            left: 0px;
            margin-top: 5%;
        }

        .col-3 {
            margin-top: 3%;
        }

        .col-9 {
            margin-top: 3%;
        }

        .col-6 {
            margin-top: 3%;
        }

        .col-8 {
            margin-top: 5%;
        }

        .col-12 {
            margin-top: 5%;
        }

        .form-control {
            margin-left: 0px !important;
            font-size: 18px !important;
            height: 30px;
            border-bottom: 1px solid !important;
            border: 0px solid black;
            border-radius: 0px;
            margin-top: 5px;
        }

        label {
            font-size: 18px;
            margin-top: 5px;
            font-weight: 600;
        }

        .card {
            border: none !important;
        }

            .card .card-title {
                color: #010101;
                margin-bottom: 1.2rem;
                text-transform: capitalize;
                font-size: 20px;
                font-weight: 600;
            }

        u {
            font-size: 22px;
        }

        input#txtInstallationType {
            border-bottom: 0px solid !important;
        }

        @media print {
            #Header, #Footer {
                display: none !important;
            }
        }
    </style>
    <script>

        function
            printDiv(printableDiv) {
            debugger;
            var printContents = document.getElementById(printableDiv).innerHTML;
            var originalContents = document.body.innerHTML;

            document.body.innerHTML = printContents;

            window.print();

            document.body.innerHTML = originalContents;

        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="content-wrapper">
                <div class="card" style="box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px; border-radius: 5px !important">
                    <div class="col-12" style="text-align: end; margin-top: auto; margin-bottom: auto;">
                        <asp:Button ID="btnPrint" Text="Print" runat="server" class="btn btn-primary mr-2"
                            Style="margin-top: 5px; margin-bottom: -40px; font-size: 20px; padding-left: 25px; padding-right: 25px; position: fixed; margin-left: -100px; z-index: 50; background: blue !important;" OnClientClick="printDiv('printableDiv');" />
                    </div>
                    <div class="card-body">
                        <div id="printableDiv">
                            <div class="page1">
                                <div class="row" style="margin-bottom: 15PX;">
                                    <div class="col-sm-12" style="text-align: center; padding-top: 8px; padding-bottom: 8px; border-radius: 10px;">
                                        <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important; font-size: 32PX;">Work Completion and Test Report</h6>
                                        <div class="col-12" style="margin-top: 0px; padding-left: 0px; text-align: center;">
                                            <asp:TextBox class="form-control" ID="txtTestReportId" ReadOnly="true" runat="server" autocomplete="off" onKeyPress="return alphabetKey(event);" TabIndex="1"
                                                MaxLength="30" Style="margin-left: 18px;">
                                            </asp:TextBox>
                                        </div>
                                        <div class="col-3" style="margin-top: 0px;"></div>
                                    </div>
                                </div>
                                <br />
                                <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important;"><u>Site Owner Information</u></h6>
                                <div id="IntimationData" runat="server" visible="true">
                                    <div class="row">
                                        <div class="col-4">
                                            <label for="Name">
                                               Applicant Type
                                            </label>
                                            <asp:TextBox class="form-control" ID="ddlApplicantType" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>

                                        </div>
                                        <div class="col-4">

                                            <div id="agency" runat="server" visible="true">
                                                <label for="agency">Electrical Installation For</label>
                                                <asp:TextBox class="form-control" ID="txtagency1" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>

                                        </div>
                                        <div class="col-4" id="individual5">
                                            <label for="Name">
                                                Name of Owner/Consumer
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtName" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4">
                                            <div id="individual2" runat="server">
                                                <label for="Name">Name of Firm/Company</label>
                                                <asp:TextBox class="form-control" ID="txtagency" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-12">
                                            <div id="individual3" runat="server">
                                                <label for="Name">
                                                    Address of Site(Preferred as per demand notice of Utility or Electricty Bill)
                                                </label>
                                                <asp:TextBox class="form-control" ID="txtAddress" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>

                                        </div>
                                        <div class="col-4">
                                            <div id="individual6" runat="server">
                                                <label for="Name">
                                                    State
                                                </label>
                                                <asp:TextBox class="form-control" ID="txtState" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-4">
                                            <div id="individual11" runat="server">
                                                <label for="Name">
                                                    District
                                                </label>
                                                <asp:TextBox class="form-control" ID="txtDistrict" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-4" id="individual10">
                                            <label for="Name">
                                                Pincode
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtPincode" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4" id="Div170" runat="server">
                                            <label>
                                                Contact Number(Site Owner)
                                            </label>
                                            <asp:TextBox class="form-control" ReadOnly="true" ID="txtPhone" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4" id="Div171" runat="server">
                                            <label>
                                                Email
                                            </label>
                                            <asp:TextBox class="form-control" ReadOnly="true" ID="txtEmail" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                    </div>
                                </div>
                                <div class="card" id="inspection-card" style="margin-top: 5%;">
                                    <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important;"><u>Application Details</u></h6>
                                    <div class="card" id="inspection-card-child1">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="table-responsive pt-3" id="Installation" runat="server">
                                                    <table class="table table-bordered table-striped">
                                                        <thead class="table-dark">
                                                            <tr>
                                                                <th style="width: 70%;">Installation Type
                                                                </th>
                                                                <th style="width: 20%;">No of Installations
                                                                </th>

                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <div id="installationType1" runat="server">
                                                                <tr>
                                                                    <td>
                                                                        <div class="col-md-12">
                                                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtinstallationType1" Text="Lift" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        <div class="col-md-12">

                                                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtinstallationNo1" TabIndex="13" onkeydown="return preventEnterSubmit(event)" onKeyPress="return restrictInput(event)" placeholder="Max no. of Installations is 25." MaxLength="2" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                            <%--  <p style="color:red; margin-bottom: 0px; margin-top: -12px; font-weight: 600;
                        font-size: 12px;">Max no. of Installations is only 25.</p>--%>
                                                                        </div>
                                                                    </td>
                                                                    <%--   <td style="text-align: center !important;">
                                            <asp:ImageButton ID="imgDelete1" ImageUrl="/Image/Image/ImageToDelete-removebg-preview.png" Height="30" Width="30"
                                                runat="server" />
                                        </td>--%>
                                                                </tr>
                                                            </div>
                                                            <div id="installationType2" runat="server">
                                                                <tr>
                                                                    <td>
                                                                        <div class="col-md-12">
                                                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtinstallationType2" Text="Escalator" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                        </div>
                                                                    </td>
                                                                    <td>
                                                                        <div class="col-md-12">
                                                                            <asp:TextBox ReadOnly="true" class="form-control" ID="txtinstallationNo2" TabIndex="14" onkeydown="return preventEnterSubmit(event)" onKeyPress="return restrictInput(event)" placeholder="Max no. of Installations is 25." MaxLength="2" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                        </div>
                                                                    </td>
                                                                    <%--<td style="text-align: center !important;">
                                            <asp:ImageButton ID="imgDelete2" ImageUrl="/Image/Image/ImageToDelete-removebg-preview.png" Height="30" Width="30" runat="server" />
                                        </td>--%>
                                                                </tr>
                                                            </div>
                                                        </tbody>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>


                                        <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important; margin-top: 6%;"><u>Installation Details</u></h6>
                                        <div id="Div6" runat="server" visible="true">
                                            <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important; margin-top: 25px; margin-bottom: -50px !important; margin-left: 15px;">Local Agent Details</h6>

                                            <div class="row" style="margin-left: 0px;">
                                                <div class="col-4">
                                                    <label for="Name">
                                                       Name of Local Agent
                                                    </label>
                                                    <asp:TextBox class="form-control" ID="TextBox1" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>

                                                </div>
                                                <div class="col-4">

                                                    <div id="Div7" runat="server" visible="true">
                                                        <label for="agency">Address of Local Agent</label>
                                                        <asp:TextBox class="form-control" ID="TextBox2" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                    </div>

                                                </div>
                                                <div class="col-4" id="individual5">
                                                    <label for="Name">
                                                       Contact No. of Local Agent
                                                    </label>
                                                    <asp:TextBox class="form-control" ID="TextBox3" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>



                                        <%--aa--%>
                                    </div>
                                </div>
                            </div>
                            <div class="page2">
                                <div id="Div8" runat="server" visible="true">
                                    <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important; margin-top: 25px; margin-bottom: -50px !important; margin-left: 15px;">Lift Details</h6>
                                    <div class="row" style="margin-left: 0px;">
                                        <div class="col-4">
                                            <label for="Name">
                                             Date of Erection
                                            </label>
                                            <asp:TextBox class="form-control" ID="TextBox4" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>

                                        </div>
                                        <div class="col-4">

                                            <div id="Div11" runat="server" visible="true">
                                                <label for="agency">Type of Lift Erected</label>
                                                <asp:TextBox class="form-control" ID="TextBox5" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>

                                        </div>
                                        <div class="col-4" id="individual5">
                                            <label for="Name">
                                                Contract Speed of Lift (Mtr./sec.)
                                            </label>
                                            <asp:TextBox class="form-control" ID="TextBox6" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4" id="individual5">
                                            <label for="Name">
                                                Contract Load of Lift (in Kgs.)
                                            </label>
                                            <asp:TextBox class="form-control" ID="TextBox7" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4" id="individual5">
                                            <label for="Name">
                                                Max Person Capacity (with Lift Operator)
                                            </label>
                                            <asp:TextBox class="form-control" ID="TextBox8" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4" id="individual5">
                                            <label for="Name">
                                                Weight of Lift Car With Contact Load (in Kg.)
                                            </label>
                                            <asp:TextBox class="form-control" ID="TextBox9" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4" id="individual5">
                                            <label for="Name">
                                                Weight of Counter Weight (in Kg)
                                            </label>
                                            <asp:TextBox class="form-control" ID="TextBox10" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4" id="individual5">
                                            <label for="Name">
                                                Depth of Pit (in mm)
                                            </label>
                                            <asp:TextBox class="form-control" ID="TextBox11" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4" id="individual5">
                                            <label for="Name">
                                                Travel Distance of Lift (in mtr)
                                            </label>
                                            <asp:TextBox class="form-control" ID="TextBox12" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4" id="individual5">
                                            <label for="Name">
                                                No. of Floors Served (in mtr)
                                            </label>
                                            <asp:TextBox class="form-control" ID="TextBox13" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4" id="individual5">
                                            <label for="Name">
                                                Total Head Room (in mm)
                                            </label>
                                            <asp:TextBox class="form-control" ID="TextBox14" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                 <div id="Div22" runat="server" visible="true">
     <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important; margin-top: 25px; margin-bottom: -50px !important; margin-left: 15px;">Suspension Ropes Details</h6>
     <div class="row" style="margin-left: 0px;">
         <div class="col-4">
             <label for="Name">
             No of Suspension Ropes
             </label>
             <asp:TextBox class="form-control" ID="TextBox47" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>

         </div>
         <div class="col-4">

             <div id="Div23" runat="server" visible="true">
                 <label for="agency">Descrption of Suspension Ropes</label>
                 <asp:TextBox class="form-control" ID="TextBox48" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
             </div>

         </div>
         <div class="col-4" id="individual5">
             <label for="Name">
                Size of Susspension Ropes (in mm)
             </label>
             <asp:TextBox class="form-control" ID="TextBox49" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
         </div>
     
     </div>
 </div>
                                <div id="Div14" runat="server" visible="true">
                                    <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important; margin-top: 25px; margin-bottom: -50px !important; margin-left: 15px;">Overhead Construction Details</h6>
                                    <div class="row" style="margin-left: 0px;">
                                        <div class="col-4">
                                            <label for="Name">
                                                Weight of Beam (in Kg)
                                            </label>
                                            <asp:TextBox class="form-control" ID="TextBox15" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>

                                        </div>
                                        <div class="col-4">

                                            <div id="Div15" runat="server" visible="true">
                                                <label for="agency">size of Beam (in mm)</label>
                                                <asp:TextBox class="form-control" ID="TextBox16" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                                <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important; margin-top: 6%;"><u>Machine Main Breaker Details</u></h6>
                                <div id="Div16" runat="server" visible="true">
                                    <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important; margin-top: 25px; margin-bottom: -50px !important; margin-left: 15px;">Main Breaker</h6>

                                    <div class="row" style="margin-left: 0px;">
                                        <div class="col-4">
                                            <label for="Name">
                                                Make
                                            </label>
                                            <asp:TextBox class="form-control" ID="TextBox17" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>

                                        </div>
                                        <div class="col-4">

                                            <div id="Div17" runat="server" visible="true">
                                                <label for="agency">Type</label>
                                                <asp:TextBox class="form-control" ID="TextBox18" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>

                                        </div>
                                        <div class="col-4" id="individual5">
                                            <label for="Name">
                                                Poles
                                            </label>
                                            <asp:TextBox class="form-control" ID="TextBox19" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4" id="individual5">
                                            <label for="Name">
                                                Current Rating (in Amps.)
                                            </label>
                                            <asp:TextBox class="form-control" ID="TextBox20" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4" id="individual5">
                                            <label for="Name">
                                                Breaking Capacity (in KA.)
                                            </label>
                                            <asp:TextBox class="form-control" ID="TextBox21" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                    </div>
                                    <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important; margin-top: 25px; margin-bottom: -50px !important; margin-left: 15px;">RCCB</h6>

                                    <div class="row" style="margin-left: 0px;">
                                        <div class="col-4">
                                            <label for="Name">
                                                Make
                                            </label>
                                            <asp:TextBox class="form-control" ID="TextBox22" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>

                                        </div>
                                        <div class="col-4" id="individual5">
                                            <label for="Name">
                                                Poles
                                            </label>
                                            <asp:TextBox class="form-control" ID="TextBox24" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4" id="individual5">
                                            <label for="Name">
                                                Current Rating (in Amps.)
                                            </label>
                                            <asp:TextBox class="form-control" ID="TextBox25" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4" id="individual5">
                                            <label for="Name">
                                                Fault Current Rating (in MA.)
                                            </label>
                                            <asp:TextBox class="form-control" ID="TextBox26" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>




                                </div>
                              <div class="page3">
                                <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important; margin-top: 6%;"><u>Lignting Load Breaker Details</u></h6>
                                <div id="Div18" runat="server" visible="true">
                                    <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important; margin-top: 25px; margin-bottom: -50px !important; margin-left: 15px;">Main Breaker</h6>

                                    <div class="row" style="margin-left: 0px;">
                                        <div class="col-4">
                                            <label for="Name">
                                                Make
                                            </label>
                                            <asp:TextBox class="form-control" ID="TextBox23" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>

                                        </div>
                                        <div class="col-4">

                                            <div id="Div19" runat="server" visible="true">
                                                <label for="agency">Type</label>
                                                <asp:TextBox class="form-control" ID="TextBox27" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>

                                        </div>
                                        <div class="col-4" id="individual5">
                                            <label for="Name">
                                                Poles
                                            </label>
                                            <asp:TextBox class="form-control" ID="TextBox28" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4" id="individual5">
                                            <label for="Name">
                                                Current Rating (in Amps.)
                                            </label>
                                            <asp:TextBox class="form-control" ID="TextBox29" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4" id="individual5">
                                            <label for="Name">
                                                Breaking Capacity (in KA.)
                                            </label>
                                            <asp:TextBox class="form-control" ID="TextBox30" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                    </div>
                                    <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important; margin-top: 25px; margin-bottom: -50px !important; margin-left: 15px;">RCCB</h6>

                                    <div class="row" style="margin-left: 0px;">
                                        <div class="col-4">
                                            <label for="Name">
                                                Make
                                            </label>
                                            <asp:TextBox class="form-control" ID="TextBox31" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>

                                        </div>
                                        <div class="col-4" id="individual5">
                                            <label for="Name">
                                                Poles
                                            </label>
                                            <asp:TextBox class="form-control" ID="TextBox32" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4" id="individual5">
                                            <label for="Name">
                                                Current Rating (in Amps.)
                                            </label>
                                            <asp:TextBox class="form-control" ID="TextBox33" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4" id="individual5">
                                            <label for="Name">
                                                Fault CUrrent Rating (in MA.)
                                            </label>
                                            <asp:TextBox class="form-control" ID="TextBox34" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important; margin-top: 6%;"><u>Insulation Resistance</u></h6>
                                <div id="Div20" runat="server" visible="true">
                                    <div class="row" style="margin-left: 0px;">
                                        <div class="col-4">
                                            <label for="Name">
                                                For Whole Installation
                                            </label>
                                            <asp:TextBox class="form-control" ID="TextBox44" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                    </div>
                                    <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important; margin-top: 25px; margin-bottom: -50px !important; margin-left: 15px;">Between Phases</h6>
                                    <div class="row" style="margin-left: 0px;">
                                        <div class="col-4">
                                            <label for="Name">
                                                Red Phase - Yellow Phase (in Mohms.)
                                            </label>
                                            <asp:TextBox class="form-control" ID="TextBox35" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4">
                                            <label for="Name">
                                                Red Phase - Blue Phase (in Mohms.)
                                            </label>
                                            <asp:TextBox class="form-control" ID="TextBox36" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4">
                                            <label for="Name">
                                                Yellow Phase - Blue Phase (in Mohms.)
                                            </label>
                                            <asp:TextBox class="form-control" ID="TextBox37" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                    </div>
                                    <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important; margin-top: 25px; margin-bottom: -50px !important; margin-left: 15px;">Between Each Phase and Earth</h6>

                                    <div class="row" style="margin-left: 0px;">
                                        <div class="col-4">
                                            <label for="Name">
                                                Red Phase - Earth Wire (in Mohms.)
                                            </label>
                                            <asp:TextBox class="form-control" ID="TextBox38" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4">
                                            <label for="Name">
                                                Yellow Phase - Earth Wire (in Mohms.)
                                            </label>
                                            <asp:TextBox class="form-control" ID="TextBox39" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4">
                                            <label for="Name">
                                                 Blue Phase - Earth Wire (in Mohms.)
                                            </label>
                                            <asp:TextBox class="form-control" ID="TextBox40" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                  </div>
                             <div class="page4">
                                <div class="card" id="earthing-card" style="margin-top: 5%;">
                                    <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important;"><u>Earthing Details</u></h6>
                                    <div id="Earthing" runat="server" visible="true">
                                        <div class="card">
                                            <div class="col-4">
                                                <label>
                                                    Number of Earthing
                                                <%--<samp style="color: red">* </samp>--%>
                                                </label>
                                                <asp:TextBox class="form-control" AutoPostBack="true" ID="txtEarthing" ReadOnly="true" MaxLength="10" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>
                                            <div class="table-responsive pt-3" id="GeneratingEarthing" runat="server" visible="true" style="margin-left: 0px;">
                                                <table class="table table-bordered table-striped" style="box-shadow: rgba(0, 0, 0, 0.16) 0px 10px 36px 0px, rgba(0, 0, 0, 0.06) 0px 0px 0px 1px;">
                                                    <thead class="table" style="background-color: #9292cc;">
                                                        <tr>
                                                            <th>S.No.
                                                            </th>
                                                            <th>Earthing Type
                                                            </th>
                                                            <th>Value in(ohms)
                                                            </th>
                                                            <th>Used For
                                                            </th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <div id="GeneratingEarthing4" runat="server" visible="true">
                                                            <tr>
                                                                <td>1
                                                                </td>
                                                                <td>
                                                                    <div class="col-12">
                                                                        <asp:TextBox class="form-control" ReadOnly="true" ID="txtEarthingType1" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <div class="col-12">
                                                                        <asp:TextBox class="form-control" ReadOnly="true" ID="txtGeneratingEarthing1" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <div class="col-12">
                                                                        <asp:TextBox class="form-control" ReadOnly="true" ID="txtEarthingUsed1" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                    </div>
                                                                    <div class="col-12">
                                                                        <asp:TextBox class="form-control" ReadOnly="true" ID="txtOther1" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="true" Style="margin-left: 18px"></asp:TextBox>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>2
                                                                </td>
                                                                <td>
                                                                    <div class="col-12">
                                                                        <asp:TextBox class="form-control" ReadOnly="true" ID="txtEarthingType2" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <div class="col-12">
                                                                        <asp:TextBox class="form-control" ReadOnly="true" ID="txtGeneratingEarthing2" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <div class="col-12">
                                                                        <asp:TextBox class="form-control" ReadOnly="true" ID="txtEarthingUsed2" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                    </div>
                                                                    <div class="col-12">
                                                                        <asp:TextBox class="form-control" ReadOnly="true" ID="txtOther2" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="true" Style="margin-left: 18px"></asp:TextBox>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>3
                                                                </td>
                                                                <td>
                                                                    <div class="col-12">
                                                                        <asp:TextBox class="form-control" ReadOnly="true" ID="txtEarthingType3" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <div class="col-12">
                                                                        <asp:TextBox class="form-control" ReadOnly="true" ID="txtGeneratingEarthing3" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <div class="col-12">
                                                                        <asp:TextBox class="form-control" ReadOnly="true" ID="txtEarthingUsed3" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                    </div>
                                                                    <div class="col-12">
                                                                        <asp:TextBox class="form-control" ReadOnly="true" ID="textOther3" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="true" Style="margin-left: 18px"></asp:TextBox>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>4
                                                                </td>
                                                                <td>
                                                                    <div class="col-12" id="Div9" runat="server">
                                                                        <asp:TextBox class="form-control" ReadOnly="true" ID="txtEarthingType4" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <div class="col-12" id="Div10" runat="server">
                                                                        <asp:TextBox class="form-control" ReadOnly="true" ID="txtGeneratingEarthing4" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                    <div class="col-12">
                                                                        <asp:TextBox class="form-control" ReadOnly="true" ID="txtEarthingUsed4" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                    </div>
                                                                    <div class="col-12">
                                                                        <asp:TextBox class="form-control" ReadOnly="true" ID="txtOther4" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="true" Style="margin-left: 18px"></asp:TextBox>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </div>
                                                        <tr id="GeneratingEarthing5" runat="server" visible="true">
                                                            <td>5
                                                            </td>
                                                            <td>
                                                                <div class="col-12" id="Div12" runat="server">
                                                                    <asp:TextBox class="form-control" ReadOnly="true" ID="txtEarthingType5" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ReadOnly="true" ID="txtGeneratingEarthing5" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ReadOnly="true" ID="txtEarthingUsed5" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ReadOnly="true" ID="txtOther5" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="true" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr id="GeneratingEarthing6" runat="server" visible="true">
                                                            <td>6
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ReadOnly="true" ID="txtEarthingType6" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ReadOnly="true" ID="txtGeneratingEarthing6" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ReadOnly="true" ID="txtEarthingUsed6" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ReadOnly="true" ID="txtOther6" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="true" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr id="GeneratingEarthing7" runat="server" visible="true">
                                                            <td>7
                                                            </td>
                                                            <td>
                                                                <div class="col-12" id="Div13" runat="server">
                                                                    <asp:TextBox class="form-control" ReadOnly="true" ID="txtEarthingType7" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ReadOnly="true" ID="txtGeneratingEarthing7" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ReadOnly="true" ID="txtEarthingUsed7" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ReadOnly="true" ID="txtOther7" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="true" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr id="GeneratingEarthing8" runat="server" visible="true">
                                                            <td>8
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ReadOnly="true" ID="txtEarthingType8" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ReadOnly="true" ID="txtGeneratingEarthing8" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ReadOnly="true" ID="txtEarthingUsed8" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ReadOnly="true" ID="txtOther8" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="true" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr id="GeneratingEarthing9" runat="server" visible="true">
                                                            <td>9
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ReadOnly="true" ID="txtEarthingType9" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ReadOnly="true" ID="txtGeneratingEarthing9" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ReadOnly="true" ID="txtEarthingUsed9" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ReadOnly="true" ID="txtOther9" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="true" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr id="GeneratingEarthing10" runat="server" visible="true">
                                                            <td>10
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ReadOnly="true" ID="txtEarthingType10" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ReadOnly="true" ID="txtGeneratingEarthing10" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ReadOnly="true" ID="txtEarthingUsed10" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ReadOnly="true" ID="txtOther10" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="true" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                              
                                <div class="card-title fw-semibold mb-4" id="ApprovalTitle" visible="true" runat="server" style="font-weight: 700; margin-bottom: 0px !important; margin-top: 2%;">
                                    Supervisor/Contractor Details
                                </div>
                                <div class="row" style="padding-bottom: 20px;" id="DivApproval" visible="true" runat="server">
                                    <div class="col-4" id="Div4" runat="server"  style="margin-top:3% !important;">
                                        <label>
                                           Contractor Name
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtApprovalDate" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                     <div class="col-4" id="Div1" runat="server" style="margin-top:3% !important;">
     <label>
        Contractor Licence No.
     </label>
     <asp:TextBox class="form-control" ID="TextBox41" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
 </div>
                                     <div class="col-4" id="Div2" runat="server" style="margin-top:3% !important;">
     <label>
      Licence expiry Date
     </label>
     <asp:TextBox class="form-control" ID="TextBox42" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
 </div>
                                     <div class="col-4" id="Div3" runat="server" style="margin-top:3% !important;">
     <label>
        Supervisor Name
     </label>
     <asp:TextBox class="form-control" ID="TextBox43" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
 </div>
                                     <div class="col-4" id="Div5" runat="server" style="margin-top:3% !important;">
     <label>
        Supervisor Licence No.
     </label>
     <asp:TextBox class="form-control" ID="TextBox45" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
 </div>
                                     <div class="col-4" id="Div21" runat="server" style="margin-top:3% !important;">
     <label>
       Licence Expiry Date
     </label>
     <asp:TextBox class="form-control" ID="TextBox46" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
 </div>
                                </div>
                                
                            </div>
        <div class="row">
                                <div class="col-4"></div>
                                <div class="col-4">
                                    <asp:HiddenField ID="hdnId" runat="server" />
                                </div>
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