<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintLineTestReport.aspx.cs" Inherits="CEIHaryana.UserPages.PrintLineTestReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="shortcut icon" type="image/png" href="/css2/style.min.css" />
    <link rel="stylesheet" href="/css2/style.css" />
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet">
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
    <style>
        input#txtInstallationType {
    font-size: 25px !important;
    font-weight: 700;
    text-align: end;
}
        input#txtTestReportId{
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
    </style>
    <script>

        function
            printDiv(printableDiv) {
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
                <%--        <div class="card-header" style="background: linear-gradient(341deg, rgba(0,255,103,1) 0%, rgba(70,85,252,1) 100%); color: white; margin-bottom: 15px; border-radius: 5px;">
        <h4 style="font-weight: 600; text-align: center;">CONTRACTOR DETAILS</h4>
    </div>--%>

                <div class="card" style="box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px; border-radius: 5px !important">
                    <div class="col-12" style="text-align: end; margin-top: auto; margin-bottom: auto;">
                        <asp:Button ID="btnPrint" Text="Print" runat="server" class="btn btn-primary mr-2"
                            Style="margin-top: 5px; margin-bottom: -40px; font-size: 20px; padding-left: 25px; padding-right: 25px;position: fixed; margin-left: -100px; z-index: 50;" OnClientClick="printDiv('printableDiv');" />
                        <%--    <asp:Button ID="btnPrint" runat="server" Text="Print" OnClientClick="printDiv('printableDiv');" />--%>
                    </div>
                    <div class="card-body">
                        <div id="printableDiv">
                            <div class="row" style="margin-bottom: 15PX;">
                                <div class="col-sm-12" style="text-align: center; padding-top: 8px; padding-bottom: 8px; border-radius: 10px;">
                                    <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important; font-size: 32PX;">Work Completion and Test Report Details</h6>
                                    <div class="row">
                                        <div class="col-4"></div>
                                        <div class="col-2">
                                            <asp:TextBox class="form-control" ID="txtInstallationType" runat="server" autocomplete="off" onKeyPress="return alphabetKey(event);" TabIndex="1"
                                                MaxLength="30" Style="margin-left: 18px;" Text="Line">
                                            </asp:TextBox>
                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"  ErrorMessage="RequiredFieldValidator" ForeColor="Red" >(*)</asp:RequiredFieldValidator>--%>
                                        </div>
                                        <div class="col-3">
                                            <asp:TextBox class="form-control" ID="txtTestReportId" runat="server" autocomplete="off" onKeyPress="return alphabetKey(event);" TabIndex="1"
                                                MaxLength="30" Style="margin-left: 18px;" Text="12341/tarun-2024">
                                            </asp:TextBox>

                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"  ErrorMessage="RequiredFieldValidator" ForeColor="Red" >(*)</asp:RequiredFieldValidator>--%>
                                        </div>
                                        <div class="col-3"></div>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important;"><u>Work Intimation Details</u></h6>
                            <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                                <div class="row">
                                    <div class="col-3">
                                        <label for="Name">
                                            Site Owner Name
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtName" runat="server" autocomplete="off" onKeyPress="return alphabetKey(event);" TabIndex="1"
                                            MaxLength="30" Style="margin-left: 18px;">
                                        </asp:TextBox>

                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"  ErrorMessage="RequiredFieldValidator" ForeColor="Red" >(*)</asp:RequiredFieldValidator>--%>
                                    </div>
                                    <div class="col-3">
                                        <label for="FatherName">Contractor Name</label>

                                        <asp:TextBox class="form-control" ID="txtContractorName" autocomplete="off" runat="server" onKeyPress="return alphabetKey(event);" TabIndex="2"
                                            MaxLength="30" Style="margin-left: 18px">
                                        </asp:TextBox>
                                    </div>
                                    <div class="col-3">
                                        <label for="FatherName">Installation For</label>

                                        <asp:TextBox class="form-control" ID="txtInstallationFor" autocomplete="off" runat="server" onKeyPress="return alphabetKey(event);" TabIndex="2"
                                            MaxLength="30" Style="margin-left: 18px">
                                        </asp:TextBox>
                                    </div>
                                    <div class="col-3">
    <label for="FirmName">
        Type of Premises 
    </label>
    <asp:TextBox class="form-control" ID="txtFirmName" runat="server" autocomplete="off" Style="margin-left: 18px" TabIndex="3" MaxLength="60"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFirmName" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">(*)</asp:RequiredFieldValidator>
</div>
                                </div>
                                <div class="row" style="margin-top: 30px;">
                                    <div class="col-3">
                                        <label for="GST">Highest Voltage Level</label>
                                        <asp:TextBox class="form-control" ID="txtGST" runat="server" TabIndex="4" autocomplete="off"
                                            MaxLength="30" Style="margin-left: 18px; text-transform: uppercase">
                                        </asp:TextBox>
                                        <asp:RegularExpressionValidator ID="regexValidatorGST" runat="server" ControlToValidate="txtGST"
                                            ValidationExpression="^(06)[A-Z]{5}[0-9]{4}[A-Z]{1}[1-9A-Z]{1}Z[0-9A-Z]{1}$" ValidationGroup="Submit"
                                            ErrorMessage="GST is incorrect. Only Haryana's GST is valid" ForeColor="Red" Display="Dynamic">
                                        </asp:RegularExpressionValidator>
                                    </div>
                                    <div class="col-9">
                                        <label for="GST">Address</label>
                                        <asp:TextBox class="form-control" ID="txtAddress" runat="server" TabIndex="4" autocomplete="off"
                                            MaxLength="30" Style="margin-left: 18px; text-transform: uppercase">
                                        </asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtGST"
                                            ValidationExpression="^(06)[A-Z]{5}[0-9]{4}[A-Z]{1}[1-9A-Z]{1}Z[0-9A-Z]{1}$" ValidationGroup="Submit"
                                            ErrorMessage="GST is incorrect. Only Haryana's GST is valid" ForeColor="Red" Display="Dynamic">
                                        </asp:RegularExpressionValidator>
                                    </div>
                                </div>

                            </div>
                            <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important;"><u>Test Report Details</u></h6>
                            <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                                <div class="row">
                                    <div class="col-3">
                                        <label for="LicenceOld">
                                            Voltage of Line
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtLicenceOld" autocomplete="off" TabIndex="14" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-3">
                                        <label for="LicenceNew">
                                            Length of Line(in Km) 
                                        </label>
                                        <asp:TextBox class="form-control" ID="TextBox9" autocomplete="off" TabIndex="14" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-3">
                                        <label for="LicenceNew">
                                            Line Type
                                        </label>
                                        <asp:TextBox class="form-control" ID="TextBox1" autocomplete="off" TabIndex="14" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>

                                </div>
                                <div class="DivOverhead">
                                    <div class="row" style="margin-top: 20px;">
                                        <div class="col-3">
                                            <label for="LicenceNew">
                                                No. of Circuit
                                            </label>
                                            <asp:TextBox class="form-control" ID="TextBox3" autocomplete="off" TabIndex="14" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-3">
                                            <label>
                                                Conductor Type 
                                            </label>
                                            <asp:TextBox class="form-control" ID="TextBox4" autocomplete="off" runat="server" Style="margin-left: 18px" TabIndex="15"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="OverHeadBare">
                                    <div class="row" style="margin-top: 20px;">
                                        <div class="col-3">
                                            <label for="VoltageLevelWithEffect">
                                                No. of Pole Towers
                                            </label>
                                            <asp:TextBox class="form-control" ID="TextBox5" autocomplete="off" TabIndex="14" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-3">
                                            <label for="DateofIntialissue">
                                                Size of Conductor (Sq.mm) 
                                            </label>
                                            <asp:TextBox class="form-control" ID="TextBox6" autocomplete="off" TabIndex="14" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-3">
                                            <label for="DateofRenewal">
                                                Size of Ground Wire (in Sq.mm) 
                                            </label>
                                            <asp:TextBox class="form-control" ID="TextBox7" autocomplete="off" TabIndex="14" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-3">
                                            <label for="DateofRenewal">
                                                No. of Railway Crossing
                                            </label>
                                            <asp:TextBox class="form-control" ID="TextBox10" autocomplete="off" TabIndex="14" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row" style="margin-top: 20px;">
                                        <div class="col-3">
                                            <label for="DateofExpiry">
                                                No of Road Crossing  
                                            </label>
                                            <asp:TextBox class="form-control" ID="TextBox8" autocomplete="off" TabIndex="14" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-3">
                                            <label for="DateofExpiry">
                                                No. of River/Canal Crossings
                                            </label>
                                            <asp:TextBox class="form-control" ID="TextBox2" autocomplete="off" TabIndex="14" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-3">
                                            <label for="DateofExpiry">
                                                No. of Power Line Crossing
                                            </label>
                                            <asp:TextBox class="form-control" ID="TextBox11" autocomplete="off" TabIndex="14" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="OverHeadCable">
                                    <div class="row" style="margin-top: 20px;">
                                        <div class="col-3">
                                            <label for="VoltageLevelWithEffect">
                                                No. of Pole Towers  
                                            </label>
                                            <asp:TextBox class="form-control" ID="TextBox12" autocomplete="off" TabIndex="14" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-3">
                                            <label for="DateofIntialissue">
                                                Size of Conductor (Sq.mm)  
                                            </label>
                                            <asp:TextBox class="form-control" ID="TextBox13" autocomplete="off" TabIndex="14" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-3">
                                            <label for="DateofRenewal">
                                                No. of Railway Crossing
                                            </label>
                                            <asp:TextBox class="form-control" ID="TextBox15" autocomplete="off" TabIndex="14" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-3">
                                            <label for="DateofExpiry">
                                                No of Road Crossing
                                            </label>
                                            <asp:TextBox class="form-control" ID="TextBox16" autocomplete="off" TabIndex="14" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row" style="margin-top: 20px;">
                                        <div class="col-3">
                                            <label for="DateofExpiry">
                                                No. of River/Canal Crossings
                                            </label>
                                            <asp:TextBox class="form-control" ID="TextBox17" autocomplete="off" TabIndex="14" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-3">
                                            <label for="DateofExpiry">
                                                No. of Power Line Crossing
                                            </label>
                                            <asp:TextBox class="form-control" ID="TextBox18" autocomplete="off" TabIndex="14" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="DivUnderground">
                                    <div class="row" style="margin-top: 20px;">
                                        <div class="col-3">
                                            <label for="LicenceNew">
                                                Type of Cable
                                            </label>
                                            <asp:TextBox class="form-control" ID="TextBox27" autocomplete="off" TabIndex="14" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-3">
                                            <label>
                                                Cable Size(im mm)  
                                            </label>
                                            <asp:TextBox class="form-control" ID="TextBox28" autocomplete="off" runat="server" Style="margin-left: 18px" TabIndex="15"></asp:TextBox>
                                        </div>
                                        <div class="col-3">
                                            <label>
                                                Cable Laid im
                                            </label>
                                            <asp:TextBox class="form-control" ID="TextBox29" autocomplete="off" runat="server" Style="margin-left: 18px" TabIndex="15"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="Insulation440Above">
                                    <div class="row" style="margin-top: 20px;">
                                        <div class="col-3">
                                            <label for="VoltageLevelWithEffect">
                                                Red Phase-Earth Wire 
                                            </label>
                                            <asp:TextBox class="form-control" ID="TextBox14" autocomplete="off" TabIndex="14" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-3">
                                            <label for="DateofIntialissue">
                                                Yellow Phase-Earth Wire  
                                            </label>
                                            <asp:TextBox class="form-control" ID="TextBox19" autocomplete="off" TabIndex="14" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-3">
                                            <label for="DateofRenewal">
                                                Blue Phase-Earth Wire   
                                            </label>
                                            <asp:TextBox class="form-control" ID="TextBox20" autocomplete="off" TabIndex="14" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-3">
                                            <label for="DateofExpiry">
                                                Red Phase-Yellow Phase 
                                            </label>
                                            <asp:TextBox class="form-control" ID="TextBox21" autocomplete="off" TabIndex="14" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row" style="margin-top: 20px;">
                                        <div class="col-3">
                                            <label for="DateofExpiry">
                                                Red Phase-Blue Phase 
                                            </label>
                                            <asp:TextBox class="form-control" ID="TextBox22" autocomplete="off" TabIndex="14" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-3">
                                            <label for="DateofExpiry">
                                                Blue Phase-Yellow Phase 
                                            </label>
                                            <asp:TextBox class="form-control" ID="TextBox23" autocomplete="off" TabIndex="14" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="Insulation220Above">
                                    <div class="row" style="margin-top: 20px;">
                                        <div class="col-3">
                                            <label for="VoltageLevelWithEffect">
                                                Phase Wire-Neutral Wire
                                            </label>
                                            <asp:TextBox class="form-control" ID="TextBox24" autocomplete="off" TabIndex="14" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-3">
                                            <label for="DateofIntialissue">
                                                Phase Wire-Earth  
                                            </label>
                                            <asp:TextBox class="form-control" ID="TextBox25" autocomplete="off" TabIndex="14" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-3">
                                            <label for="DateofRenewal">
                                                Neutral Wire-Earth
                                            </label>
                                            <asp:TextBox class="form-control" ID="TextBox26" autocomplete="off" TabIndex="14" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                
                            </div>
                             <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important;"><u>Earthing Details</u></h6>
                                                            <div id="Earthing" runat="server" class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
  <div>
        <div class="row">
            <div class="col-3">
                <label>
                    Number of Earthing:
                    <samp style="color: red">* </samp>
                </label>
                 <asp:TextBox class="form-control" ID="TextBox31" MaxLength="2" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
            </div>
            <div class="table-responsive pt-3" id="LineEarthingdiv" runat="server">
                <table class="table table-bordered table-striped">
                    <thead class="table-dark">
                        <tr>
                            <th>S.No.
                            </th>
                            <th style="width: 60% !important;">Earthing Type
                            </th>
                            <th>Value in(ohms)
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr id="Earthingtype1"  runat="server" style="display: table-row;">
                            <td>1</td>
                            <td>
                                <div class="col-12">
                                    <asp:TextBox class="form-control" ID="TextBox30" autocomplete="off" TabIndex="14" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                </div>
                            </td>
                            <td>
                                <div class="col-12">
                                    <asp:TextBox class="form-control" ID="txtearthingValue1" MaxLength="2" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator73" ControlToValidate="txtearthingValue1" runat="server" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Enter Value"></asp:RequiredFieldValidator>
                                </div>
                            </td>
                        </tr>
                        <tr id="Earthingtype2" runat="server">
                            <td>2</td>
                            <td>
                                <div class="col-12">
                                    <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlEarthingtype2" selectionmode="Multiple" Style="width: 100% !important">
                                        <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator45" ControlToValidate="ddlEarthingtype2" runat="server" ForeColor="Red" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Earth Type"></asp:RequiredFieldValidator>
                                </div>
                            </td>
                            <td>
                                <div class="col-12">
                                    <asp:TextBox class="form-control" ID="txtEarthingValue2" MaxLength="2" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator72" ControlToValidate="txtEarthingValue2" runat="server" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Enter Value"></asp:RequiredFieldValidator>
                                </div>
                            </td>
                        </tr>
                        <tr id="Earthingtype3" runat="server">
                            <td>3</td>
                            <td>
                                <div class="col-12">
                                    <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlEarthingtype3" selectionmode="Multiple" Style="width: 100% !important">
                                        <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator46" ControlToValidate="ddlEarthingtype3" runat="server" ForeColor="Red" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Earth Type"></asp:RequiredFieldValidator>
                                </div>
                            </td>
                            <td>
                                <div class="col-12">
                                    <asp:TextBox class="form-control" ID="txtEarthingValue3" MaxLength="2" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator71" ControlToValidate="txtEarthingValue3" runat="server" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Enter Value"></asp:RequiredFieldValidator>
                                </div>
                            </td>
                        </tr>
                        <tr id="Earthingtype4" runat="server" visible="false">
                            <td>4</td>
                            <td>
                                <div class="col-12">
                                    <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlEarthingtype4" selectionmode="Multiple" Style="width: 100% !important">
                                        <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator47" ControlToValidate="ddlEarthingtype4" runat="server" ForeColor="Red" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Earth Type"></asp:RequiredFieldValidator>
                                </div>
                            </td>
                            <td>
                                <div class="col-12" id="Div15" runat="server">
                                    <asp:TextBox class="form-control" ID="txtEarthingValue4" MaxLength="2" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator70" ControlToValidate="txtEarthingValue4" runat="server" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Enter Value"></asp:RequiredFieldValidator>
                                </div>
                            </td>
                        </tr>
                        <tr id="Earthingtype5" runat="server" visible="false">
                            <td>5</td>
                            <td>
                                <div class="col-12">
                                    <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlEarthingtype5" selectionmode="Multiple" Style="width: 100% !important">
                                        <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator48" ControlToValidate="ddlEarthingtype5" runat="server" ForeColor="Red" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Earth Type"></asp:RequiredFieldValidator>
                                </div>
                            </td>
                            <td>
                                <div class="col-12">
                                    <asp:TextBox class="form-control" ID="txtEarthingValue5" MaxLength="2" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator69" ControlToValidate="txtEarthingValue5" runat="server" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Enter Value"></asp:RequiredFieldValidator>
                                </div>
                            </td>
                        </tr>
                        <tr id="Earthingtype6" runat="server" visible="false">
                            <td>6</td>
                            <td>
                                <div class="col-12">
                                    <asp:DropDownList class="form-control  select-form select2" onKeyPress="return isNumberKey(event);" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlEarthingtype6" selectionmode="Multiple" Style="width: 100% !important">
                                        <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator49" ControlToValidate="ddlEarthingtype6" runat="server" ForeColor="Red" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Earth Type"></asp:RequiredFieldValidator>
                                </div>
                            </td>
                            <td>
                                <div class="col-12">
                                    <asp:TextBox class="form-control" ID="txtEarthingValue6" MaxLength="2" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator68" ControlToValidate="txtEarthingValue6" runat="server" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Enter Value"></asp:RequiredFieldValidator>
                                </div>
                            </td>
                        </tr>
                        <tr id="Earthingtype7" runat="server" visible="false">
                            <td>7</td>
                            <td>
                                <div class="col-12">
                                    <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlEarthingtype7" selectionmode="Multiple" Style="width: 100% !important">
                                        <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator50" ControlToValidate="ddlEarthingtype7" runat="server" ForeColor="Red" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Earth Type"></asp:RequiredFieldValidator>
                                </div>
                            </td>
                            <td>
                                <div class="col-12">
                                    <asp:TextBox class="form-control" ID="txtEarthingValue7" MaxLength="2" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator67" ControlToValidate="txtEarthingValue7" runat="server" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Enter Value"></asp:RequiredFieldValidator>
                                </div>
                            </td>
                        </tr>
                        <tr id="Earthingtype8" runat="server" visible="false">
                            <td>8</td>
                            <td>
                                <div class="col-12">
                                    <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlEarthingtype8" selectionmode="Multiple" Style="width: 100% !important">
                                        <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator51" ControlToValidate="ddlEarthingtype8" runat="server" ForeColor="Red" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Earth Type"></asp:RequiredFieldValidator>
                                </div>
                            </td>
                            <td>
                                <div class="col-12">
                                    <asp:TextBox class="form-control" ID="txtEarthingValue8" MaxLength="2" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator66" ControlToValidate="txtEarthingValue8" runat="server" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Enter Value"></asp:RequiredFieldValidator>
                                </div>
                            </td>
                        </tr>
                        <tr id="Earthingtype9" runat="server" visible="false">
                            <td>9</td>
                            <td>
                                <div class="col-12">
                                    <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlEarthingtype9" selectionmode="Multiple" Style="width: 100% !important">
                                        <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator52" ControlToValidate="ddlEarthingtype9" runat="server" ForeColor="Red" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Earth Type"></asp:RequiredFieldValidator>
                                </div>
                            </td>
                            <td>
                                <div class="col-12">
                                    <asp:TextBox class="form-control" ID="txtEarthingValue9" MaxLength="2" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator65" ControlToValidate="txtEarthingValue9" runat="server" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Enter Value"></asp:RequiredFieldValidator>
                                </div>
                            </td>
                        </tr>
                        <tr id="Earthingtype10" runat="server" visible="false">
                            <td>10</td>
                            <td>
                                <div class="col-12">
                                    <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlEarthingtype10" selectionmode="Multiple" Style="width: 100% !important">
                                        <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator53" ControlToValidate="ddlEarthingtype10" runat="server" ForeColor="Red" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Earth Type"></asp:RequiredFieldValidator>
                                </div>
                            </td>
                            <td>
                                <div class="col-12">
                                    <asp:TextBox class="form-control" ID="txtEarthingValue10" MaxLength="2" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator64" ControlToValidate="txtEarthingValue10" runat="server" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Enter Value"></asp:RequiredFieldValidator>
                                </div>
                            </td>
                        </tr>
                        <tr id="Earthingtype11" runat="server" visible="false">
                            <td>11</td>
                            <td>
                                <div class="col-12">
                                    <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlEarthingtype11" selectionmode="Multiple" Style="width: 100% !important">
                                        <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator54" ControlToValidate="ddlEarthingtype11" runat="server" ForeColor="Red" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Earth Type"></asp:RequiredFieldValidator>
                                </div>
                            </td>
                            <td>
                                <div class="col-12">
                                    <asp:TextBox class="form-control" ID="txtEarthingValue11" MaxLength="2" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator63" ControlToValidate="txtEarthingValue11" runat="server" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Enter Value"></asp:RequiredFieldValidator>
                                </div>
                            </td>
                        </tr>
                        <tr id="Earthingtype12" runat="server" visible="false">
                            <td>12</td>
                            <td>
                                <div class="col-12">
                                    <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlEarthingtype12" selectionmode="Multiple" Style="width: 100% !important">
                                        <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator55" ControlToValidate="ddlEarthingtype12" runat="server" ForeColor="Red" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Earth Type"></asp:RequiredFieldValidator>
                                </div>
                            </td>
                            <td>
                                <div class="col-12">
                                    <asp:TextBox class="form-control" ID="txtEarthingValue12" MaxLength="2" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator62" ControlToValidate="txtEarthingValue12" runat="server" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Enter Value"></asp:RequiredFieldValidator>
                                </div>
                            </td>
                        </tr>
                        <tr id="Earthingtype13" runat="server" visible="false">
                            <td>13</td>
                            <td>
                                <div class="col-12">
                                    <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlEarthingtype13" selectionmode="Multiple" Style="width: 100% !important">
                                        <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator56" ControlToValidate="ddlEarthingtype13" runat="server" ForeColor="Red" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Earth Type"></asp:RequiredFieldValidator>
                                </div>
                            </td>
                            <td>
                                <div class="col-12">
                                    <asp:TextBox class="form-control" ID="txtEarthingValue13" MaxLength="2" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator61" ControlToValidate="txtEarthingValue13" runat="server" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Enter Value"></asp:RequiredFieldValidator>
                                </div>
                            </td>
                        </tr>
                        <tr id="Earthingtype14" runat="server" visible="false">
                            <td>14</td>
                            <td>
                                <div class="col-12">
                                    <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlEarthingtype14" selectionmode="Multiple" Style="width: 100% !important">
                                        <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator57" ControlToValidate="ddlEarthingtype14" runat="server" ForeColor="Red" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Earth Type"></asp:RequiredFieldValidator>
                                </div>
                            </td>
                            <td>
                                <div class="col-12">
                                    <asp:TextBox class="form-control" ID="txtEarthingValue14" MaxLength="2" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator60" ControlToValidate="txtEarthingValue14" runat="server" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Enter Value"></asp:RequiredFieldValidator>
                                </div>
                            </td>
                        </tr>
                        <tr id="Earthingtype15" runat="server" visible="false">
                            <td>15</td>
                            <td>
                                <div class="col-12">
                                    <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlEarthingtype15" selectionmode="Multiple" Style="width: 100% !important">
                                        <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator58" ControlToValidate="ddlEarthingtype15" runat="server" ForeColor="Red" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Earth Type"></asp:RequiredFieldValidator>
                                </div>
                            </td>
                            <td>
                                <div class="col-12">
                                    <asp:TextBox class="form-control" ID="txtEarthingValue15" MaxLength="2" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator59" ControlToValidate="txtEarthingValue15" runat="server" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Enter Value"></asp:RequiredFieldValidator>
                                </div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
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
            <!-- partial:../../partials/_footer.html -->
            <footer class="footer">
            </footer>
        </div>
    </form>
</body>
</html>