<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintGeneratingSetTestReport.aspx.cs" Inherits="CEIHaryana.UserPages.PrintGeneratingSetTestReport" %>

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
                            Style="margin-top: 5px; margin-bottom: -40px; font-size: 20px; padding-left: 25px; padding-right: 25px; position: fixed; margin-left: -100px; z-index: 50;" OnClientClick="printDiv('printableDiv');" />
                    </div>
                    <div class="card-body">
                        <div id="printableDiv">
                            <div class="page1">
                                <div class="row" style="margin-bottom: 15PX;">
                                    <div class="col-sm-12" style="text-align: center; padding-top: 8px; padding-bottom: 8px; border-radius: 10px;">
                                        <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important; font-size: 32PX;">Work Completion and Test Report Details</h6>
                                        <div class="col-12" style="margin-top: 0px; padding-left: 0px; text-align: center;">
                                            <asp:TextBox class="form-control" ID="txtTestReportId" runat="server" autocomplete="off" onKeyPress="return alphabetKey(event);" TabIndex="1"
                                                MaxLength="30" Style="margin-left: 18px;">
                                            </asp:TextBox>
                                        </div>
                                        <div class="col-3" style="margin-top: 0px;"></div>
                                    </div>
                                </div>
                                <br />
                                <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important;"><u>Work Intimation Details</u></h6>
                                <div id="IntimationData" runat="server" visible="true">
                                    <div class="row">
                                        <div class="col-4">
                                            <label for="Name">
                                                Electrical Installation For
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtInstallation" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>

                                        </div>
                                        <div class="col-4">

                                            <div id="agency" runat="server" visible="false">
                                                <label for="agency">Name of Firm/ Org./ Company/ Department</label>
                                                <asp:TextBox class="form-control" ID="txtagency" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>
                                            <div id="individual" runat="server">
                                                <label for="Name">
                                                    Name of Owner/ Consumer
                                                </label>
                                                <asp:TextBox class="form-control" ID="txtName" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>

                                        </div>
                                        <div class="col-4" id="individual5">
                                            <label for="Name">
                                                Contact Details 
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtPhone" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>

                                    </div>
                                    <div class="row" style="margin-top: 30px;">

                                        <div class="col-4">
                                            <div id="individual2" runat="server">
                                                <label for="Name">Type of Premises</label>
                                                <asp:TextBox class="form-control" ID="TxtPremises" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-4">
                                            <div id="individual3" runat="server">
                                                <label for="Name">
                                                    Highest Voltage Level of Work
                                                </label>
                                                <asp:TextBox class="form-control" ID="txtVoltagelevel" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>

                                        </div>
                                        <div class="col-4">
                                            <div id="individual6" runat="server">
                                                <label for="Name">
                                                    Work Start Date
                                                </label>
                                                <asp:TextBox class="form-control" ID="txtStartDate" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">

                                        <div class="col-4">
                                            <div id="individual11" runat="server">
                                                <label for="Name">
                                                    Tentative Work Completition Date
                                                </label>
                                                <asp:TextBox class="form-control" ID="txtCompletitionDate" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-8" id="individual10">
                                            <label for="Name">
                                                Address 
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtAddress" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                    </div>
                                </div>
                                <div class="card" id="inspection-card" style="background: #fcfcfc; margin-top: 5%;">
                                    <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important;"><u>Test Report Details</u></h6>
                                    <div class="card" id="inspection-card-child1" style="background: #fcfcfc;">

                                        <div class="row">
                                            <div class="col-4" id="Div170" runat="server">
                                                <label>
                                                    Capacity
                                                </label>
                                                <asp:TextBox class="form-control" ReadOnly="true" ID="txtCapacityType" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>
                                            <div class="col-4" id="Div171" runat="server">
                                                <label>
                                                    Value
                                                </label>
                                                <asp:TextBox class="form-control" ReadOnly="true" ID="txtCapacity" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>
                                            <div class="col-4">
                                                <label>
                                                    Serial no. 
                                                </label>
                                                <asp:TextBox class="form-control" ReadOnly="true" ID="txtSerialNoOfGenerator" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="of Ac generator/ Alternator" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>

                                            </div>
                                            <div class="col-4" id="Div172" runat="server">
                                                <label>
                                                    Type of Generating Set
                                                </label>
                                                <asp:TextBox class="form-control" ReadOnly="true" ID="txtGeneratingSetType" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>

                                            <div class="col-4">
                                                <label>
                                                    Generator voltage level(IN VOLTS)
                                                </label>
                                                <asp:TextBox class="form-control" ReadOnly="true" ID="txtGeneratorVoltage" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>


                                            <div class="col-4">
                                                <label>
                                                    Current capacity of breaker( IN AMPS)
                    
                                                </label>
                                                <asp:TextBox class="form-control" ReadOnly="true" ID="txtCurrentCapacity" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>
                                            <div class="col-4">
                                                <label>
                                                    Breaking capacity of breaker (IN KA)
                    
                                                </label>
                                                <asp:TextBox class="form-control" ReadOnly="true" ID="txtBreakingCapacity" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>

                                            <div class="col-4">
                                                <label>
                                                    Type of plant
                                                </label>
                                                <asp:TextBox class="form-control" ReadOnly="true" ID="txtPlantType" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>

                                            </div>

                                        </div>


                                        <%--aa--%>

                                        <div id="SolarPanelGeneratingSet" runat="server" visible="false">
                                            <div class="row">
                                                <%--  <div class="col-4">
                                                    <label>
                                                        Type of plant
                                                    </label>
                                                    <asp:TextBox class="form-control" ReadOnly="true" ID="txtPlantType" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>

                                                </div>--%>
                                                <div class="col-4">
                                                    <label>
                                                        capacity of plant
                                                    </label>
                                                    <asp:TextBox class="form-control" ReadOnly="true" ID="txtPlantCapacityType" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>

                                                </div>
                                                <div class="col-4">
                                                    <label>
                                                        capacity of plant      
                                                    </label>
                                                    <asp:TextBox class="form-control" ReadOnly="true" ID="txtPlantCapacity" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder=" between DC phase wire to earth wire" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                </div>
                                                <div class="col-4" id="Div184" runat="server">
                                                    <label>
                                                        DC string       
                                                    </label>
                                                    <asp:TextBox class="form-control" ReadOnly="true" ID="txtDCString" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder=" Highest Voltage" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                </div>

                                                <div class="col-4" id="Div185" runat="server">
                                                    <label>
                                                        Lowest Insulation Resistance        
                                                    </label>
                                                    <asp:TextBox class="form-control" ReadOnly="true" ID="txtLowestInsulation" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder=" between DC phase wire to earth wire" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                </div>
                                                <div class="col-4" id="Div186" runat="server">
                                                    <label>
                                                        No of PCV or Solar Inverter        
                                                    </label>
                                                    <asp:TextBox class="form-control" ReadOnly="true" ID="txtPCVOrSolar" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                </div>
                                                <div class="col-4" id="Div187" runat="server">
                                                    <label>
                                                        capacity of main LTAC Breaker        
                                                    </label>
                                                    <asp:TextBox class="form-control" ReadOnly="true" ID="txtLTACCapacity" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                </div>
                                                <div class="col-4" id="Div188" runat="server">
                                                    <label>
                                                        Lowest Insulation resistance of AC cables       
                                                    </label>
                                                    <asp:TextBox class="form-control" ReadOnly="true" ID="txtLowestInsulationAC" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                </div>
                                                <%--<div class="col-4" id="Div189" runat="server">
                                                <label>
                                                    Number of Earthing:
                                                </label>
                                                <asp:TextBox class="form-control" ReadOnly="true" ID="TextBox1" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>

                                                <label id="Limit" runat="server" visible="false">
                                                    Minimum Limit is 4     
                                                </label>
                                            </div>--%>
                                            </div>
                                        </div>

                                        <%--aa--%>
                                    </div>

                                </div>
                            </div>
                            <div class="page2">
                                <div class="card" id="earthing-card" style="background: #fcfcfc; margin-top: 5%;">
                                    <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important;"><u>Earthing Details</u></h6>
                                    <div id="Earthing" runat="server" visible="true">
                                        <div class="card">
                                            <div class="col-4">
                                                <label>
                                                    Number of Earthing:
                                                <%--<samp style="color: red">* </samp>--%>
                                                </label>
                                                <asp:TextBox class="form-control" AutoPostBack="true" ID="txtEarthing" ReadOnly="true" MaxLength="10" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>
                                            <div class="table-responsive pt-3" id="GeneratingEarthing" runat="server" visible="false" style="margin-left: 0px;">
                                                <table class="table table-bordered table-striped" style="box-shadow: rgba(0, 0, 0, 0.16) 0px 10px 36px 0px, rgba(0, 0, 0, 0.06) 0px 0px 0px 1px;">
                                                    <thead class="table-dark">
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
                                                        <div id="GeneratingEarthing4" runat="server" visible="false">
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
                                                                        <asp:TextBox class="form-control" ReadOnly="true" ID="txtOther1" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
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
                                                                        <asp:TextBox class="form-control" ReadOnly="true" ID="txtOther2" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
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
                                                                        <asp:TextBox class="form-control" ReadOnly="true" ID="textOther3" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
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
                                                                        <asp:TextBox class="form-control" ReadOnly="true" ID="txtOther4" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </div>

                                                        <tr id="GeneratingEarthing5" runat="server" visible="false">
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
                                                                    <asp:TextBox class="form-control" ReadOnly="true" ID="txtOther5" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr id="GeneratingEarthing6" runat="server" visible="false">
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
                                                                    <asp:TextBox class="form-control" ReadOnly="true" ID="txtOther6" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr id="GeneratingEarthing7" runat="server" visible="false">
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
                                                                    <asp:TextBox class="form-control" ReadOnly="true" ID="txtOther7" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr id="GeneratingEarthing8" runat="server" visible="false">
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
                                                                    <asp:TextBox class="form-control" ReadOnly="true" ID="txtOther8" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr id="GeneratingEarthing9" runat="server" visible="false">
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
                                                                    <asp:TextBox class="form-control" ReadOnly="true" ID="txtOther9" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr id="GeneratingEarthing10" runat="server" visible="false">
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
                                                                    <asp:TextBox class="form-control" ReadOnly="true" ID="txtOther10" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr id="GeneratingEarthing11" runat="server" visible="false">
                                                            <td>11
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ReadOnly="true" ID="txtEarthingType11" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>

                                                                </div>
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ReadOnly="true" ID="txtGeneratingEarthing11" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ReadOnly="true" ID="txtEarthingUsed11" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>

                                                                </div>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ReadOnly="true" ID="txtOther11" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr id="GeneratingEarthing12" runat="server" visible="false">
                                                            <td>12
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ReadOnly="true" ID="txtEarthingType12" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>

                                                                </div>
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ReadOnly="true" ID="txtGeneratingEarthing12" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ReadOnly="true" ID="txtEarthingUsed12" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>

                                                                </div>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ReadOnly="true" ID="txtOther12" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr id="GeneratingEarthing13" runat="server" visible="false">
                                                            <td>13
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ReadOnly="true" ID="txtEarthingType13" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>

                                                                </div>
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ReadOnly="true" ID="txtGeneratingEarthing13" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ReadOnly="true" ID="txtEarthingUsed13" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>

                                                                </div>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ReadOnly="true" ID="txtOther13" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr id="GeneratingEarthing14" runat="server" visible="false">
                                                            <td>14
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ReadOnly="true" ID="txtEarthingType14" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>

                                                                </div>
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ReadOnly="true" ID="txtGeneratingEarthing14" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ReadOnly="true" ID="txtEarthingUsed14" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>

                                                                </div>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ReadOnly="true" ID="txtOther14" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr id="GeneratingEarthing15" runat="server" visible="false">
                                                            <td>15
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ReadOnly="true" ID="txtEarthingType15" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>

                                                                </div>
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ReadOnly="true" ID="txtGeneratingEarthing15" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ReadOnly="true" ID="txtEarthingUsed15" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>

                                                                </div>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ReadOnly="true" ID="txtOther15" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>

                                                            </td>
                                                        </tr>

                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="card" style="background: #fcfcfc;">
                                    <div class="row">

                                        <%--<div class="col-6" id="CreatedDate" visible="false" runat="server">
                                            <label>
                                                TestReport Created Date
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtCreatedDate" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>--%>

                                        <div class="col-6" id="Div1" runat="server">

                                            <label>
                                                Installation Type

                                            </label>

                                            <asp:TextBox class="form-control" ID="txtinstalltype" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>

                                        </div>

                                       <%-- <div class="col-6" id="SubmitDate" visible="false" runat="server">
                                            <label>
                                                WorkIntimation Submitted Date
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtSubmitteddate" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>--%>
                                        <%--<div class="col-6" id="SubmitBy" visible="false" runat="server">
                                            <label>
                                                WorkIntimation Submitted By
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtSubmittedBy" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>--%>
                                    </div>
                                </div>
                                <div class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important;">
                                    Work Intimation Created Details (<asp:Label ID="lblIntimationId" runat="server" />)
                                </div>
                                <div class="row">
                                    <div class="col-4" id="SubmitDate1">
                                        <label>
                                            Work Intimation Submitted Date
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtSubmitteddate" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-4" id="SubmitBy1">
                                        <label>
                                            Work Intimation Submitted By
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtSubmittedBy" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important;">
                                    Test Report Prepared Details (<asp:Label ID="lblReportNo" runat="server" />)
                                </div>
                                <div id="Div2" runat="server">
                                    <div class="row" style="padding-bottom: 20px;">
                                       
                                        <div class="col-4" id="CreatedDate">
                                            <label>
                                                Test Report Created Date
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtCreatedDate" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4" id="Div3" runat="server">
                                            <label for="Name">
                                                Prepared By
                                            </label>
                                            <asp:TextBox class="form-control" ReadOnly="true" ID="txtPreparedby" onkeydown="return preventEnterSubmit(event)" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                                                          </div>
                                </div>
                                
                                <div class="card-title fw-semibold mb-4" id="ApprovalTitle" visible="false" runat="server"  style="font-weight: 700; margin-bottom: 0px !important;">
                                    Test Report Approval Details</div>
                                <div class="row" style="padding-bottom: 20px;"  id="DivApproval" visible="false" runat="server">
                                    <div class="col-4" id="Div4" runat="server">
                                        <label>
                                            Test Report Approval Date
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtApprovalDate" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-4" id="Div5" runat="server">
                                        <label for="Name">
                                            Test Report Approved By
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtApprovedBy" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                </div>
                              <%--  <div class="card" style="background: #fcfcfc;">
                                    <div id="Contractor" runat="server" visible="false">
                                        <div class="row">
                                            <div class="col-6" runat="server">
                                                <label for="Name">
                                                    TestReport No
                                                </label>
                                                <asp:TextBox class="form-control" ReadOnly="true" ID="txtReportNo" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>
                                            <div class="col-6" id="Rejection" runat="server">
                                                <label for="Name">
                                                    Prepared By                                               
                                                </label>
                                                <asp:TextBox class="form-control" ReadOnly="true" ID="txtPreparedby" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>--%>
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
