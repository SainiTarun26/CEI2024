<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintLineTestReport.aspx.cs" Inherits="CEIHaryana.UserPages.PrintLineTestReport" %>

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
        div#SubmitDate1 {
            margin-top: 1px;
        }

        SubmitBy1 {
            margin-top: 1px !important;
        }
div#Div13 {
    margin-top: 1px !important;
}
div#Div12 {
    margin-top: 1px !important;
}
div#CreatedDate {
    margin-top: 1px !important;
}
div#Div10 {
    margin-top: 1px !important;
}
div#SubmitBy1 {
    margin-top: 1px !important;
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

        input#txtInstallationType {
            font-size: 25px !important;
            font-weight: 700;
            text-align: end;
        }

        input#txtTestReportId {
            font-size: 25px !important;
            font-weight: 700;
            text-align: initial;
            border-bottom: 0px solid !important;
            text-align: center;
        }

        .col-4 {
            top: 0px;
            left: 0px;
            margin-top: 5%;
        }

        .col-3 {
            margin-top: 5%;
        }

        .col-9 {
            margin-top: 5%;
        }

        .col-8 {
            margin-top: 3%;
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

        div#SubmitDate {
            margin-top: 0px;
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

        window.onafterprint = function () {
            window.close();
        };

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
                                        <div class="row">
                                            <div class="col-3" style="margin-top: 0px;"></div>
                                            <div class="col-6" style="margin-top: 0px; padding-left: 0px; text-align: center;">
                                                <asp:TextBox class="form-control" ID="txtTestReportId" runat="server" autocomplete="off" onKeyPress="return alphabetKey(event);" TabIndex="1"
                                                    MaxLength="30" Style="margin-left: 18px;" Text="12341/tarun-2024">
                                                </asp:TextBox>
                                            </div>
                                            <div class="col-3" style="margin-top: 0px;"></div>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important;"><u>Work Intimation Details</u></h6>
                                <div id="IntimationData" runat="server" visible="true">
                                    <div class="row">
                                        <div class="col-6">

                                            <label for="Name">
                                                Electrical Installation For
                                            </label>
                                            <asp:TextBox class="form-control" ReadOnly="true" ID="txtInstallation" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>

                                        </div>
                                        <div class="col-6">

                                            <div id="agency" runat="server" visible="false">
                                                <label for="agency">Name of Organization</label>
                                                <asp:TextBox class="form-control" ID="txtagency" onkeydown="return preventEnterSubmit(event)" ReadOnly="true" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
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

                                    </div>
                                    <div class="row">



                                        <div class="col-4" id="individual10">
                                            <label for="Name">
                                                Work Start Date
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtStartDate" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4">
                                            <div id="individual6" runat="server">
                                                <label for="Name">
                                                    Tentative Work Completition Date
                                                </label>
                                                <asp:TextBox class="form-control" ID="txtCompletitionDate" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row" style="margin-top: 35px;">
                                        <div class="col-12">
                                            <div id="individual11" runat="server">
                                                <label for="Name">
                                                    Address
                                                </label>
                                                <asp:TextBox class="form-control" ID="txtAddress" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="card" id="inspection-card" style="background: #fcfcfc; margin-top: 5%;">
                                    <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important;"><u>Test Report Details</u></h6>
                                    <div class="card" id="inspection-card-child1" style="background: #fcfcfc;">
                                        <div>
                                            <div class="row">
                                                <div class="col-4">
                                                    <label>
                                                        Voltage of Line
                                                    </label>
                                                    <asp:TextBox class="form-control" ReadOnly="true" AutoPostBack="true" ID="txtLineVoltage" MaxLength="10" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                </div>
                                                <div class="col-2" id="divOtherVoltages" runat="server" visible="false" style="margin-top: 5%;">
                                                    <label for="Voltage">
                                                        Other Voltage 
                                                 
                                                    </label>
                                                    <asp:TextBox class="form-control" AutoPostBack="true" ReadOnly="true" ID="txtVotalgeType" MaxLength="10" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                </div>
                                                <div class="col-2" id="OtherVoltage" runat="server" visible="false" style="margin-top: 5%;">
                                                    <label for="Voltage">
                                                        Other Voltage 
                                                 
                                                    </label>
                                                    <asp:TextBox class="form-control" AutoPostBack="true" ReadOnly="true" ID="TxtOthervoltage" MaxLength="10" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>

                                                </div>
                                                <div class="col-4" id="Div1" runat="server">
                                                    <label for="Name">
                                                        Length of Line (in KM)
                                              
                                                    </label>
                                                    <asp:TextBox class="form-control" ID="txtLineLength" ReadOnly="true" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                </div>
                                                <div class="col-4">
                                                    <label>
                                                        Line Type
                                              
                                                    </label>
                                                    <asp:TextBox class="form-control" ID="txtLineType" ReadOnly="true" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div id="LineTypeOverhead" runat="server" visible="false">
                                            <div class="row">
                                                <div class="col-4">
                                                    <label>
                                                        No of Circuit
                                                    
                                                    </label>
                                                    <asp:TextBox class="form-control" ID="txtCircuit" ReadOnly="true" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                </div>
                                                <div class="col-4">
                                                    <label>
                                                        Conductor Type
                                                      
                                                    </label>
                                                    <asp:TextBox class="form-control" ID="txtConductorType" ReadOnly="true" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                </div>
                                                <div class="col-4">
                                                    <label>
                                                        Number of Pole/Tower
                                                    </label>
                                                    <asp:TextBox class="form-control" ReadOnly="true" ID="txtPoleTower" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="card" id="inspection-card-child2" style="background: #fcfcfc;">
                                        <div id="OverheadBare" visible="false" runat="server">
                                            <div class="row">
                                                <div class="col-4" id="Div2" runat="server">
                                                    <label for="Name">
                                                        Size of Conductor( IN SQ.MM)
                                                   
                                                    </label>
                                                    <asp:TextBox class="form-control" ReadOnly="true" ID="txtConductorSize" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                </div>
                                                <div class="col-4" id="Div3" runat="server">
                                                    <label for="Name">
                                                        Size of Ground Wire( IN SQ.MM)	
                     
                                                    </label>
                                                    <asp:TextBox class="form-control" ID="txtGroundWireSize" ReadOnly="true" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="2" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                </div>
                                                <div class="col-4" id="Div4" runat="server">
                                                    <label for="Name">
                                                        Number of Railway Crossing
                        
                                                    </label>
                                                    <asp:TextBox class="form-control" ID="txtRailwayCrossingNo" ReadOnly="true" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="2" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                </div>
                                                <div class="col-4" id="Div5" runat="server">
                                                    <label for="Name">
                                                        Number of Road Crossing
                        
                                                    </label>
                                                    <asp:TextBox class="form-control" ID="txtRoadCrossingNo" ReadOnly="true" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="2" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                </div>
                                                <div class="col-4" id="Div6" runat="server">
                                                    <label for="Name">
                                                        Number of River/Canal Crossing
                       
                                                    </label>
                                                    <asp:TextBox class="form-control" ID="txtRiverCanalCrossing" ReadOnly="true" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="2" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                </div>
                                                <div class="col-4" id="Div7" runat="server">
                                                    <label for="Name">
                                                        Number of Power Line Crossing:	
                      
                                                    </label>
                                                    <asp:TextBox class="form-control" ID="txtPowerLineCrossing" ReadOnly="true" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="2" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div id="OverheadCable" runat="server" visible="false">
                                            <div
                                                class="row">
                                                <div class="col-4">
                                                    <label>
                                                        Number of Pole/Tower
                                                    </label>
                                                    <asp:TextBox class="form-control" ID="txtPoleTowerNo" ReadOnly="true" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                </div>
                                                <div class="col-4" id="Div11" runat="server">
                                                    <label for="Name">
                                                        Size of cable: (in MM sq.)
                      
                                                    </label>
                                                    <asp:TextBox class="form-control" ID="txtCableSize1" ReadOnly="true" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                </div>
                                                <div class="col-4" id="Div19" runat="server">
                                                    <label for="Name">
                                                        Number of Railway Crossing
                       
                                                    </label>
                                                    <asp:TextBox class="form-control" ID="txtRailwayCrossingNmbr" ReadOnly="true" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                </div>
                                                <div class="col-4" id="Div20" runat="server">
                                                    <label for="Name">
                                                        Number of Road Crossing
                        
                                                    </label>
                                                    <asp:TextBox class="form-control" ID="txtRoadCrossingNmbr" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                </div>
                                                <div class="col-4" id="Div21" runat="server">
                                                    <label for="Name">
                                                        Number of River/Canal Crossing
                        
                                                    </label>
                                                    <asp:TextBox class="form-control" ID="txtRiverCanalCrossingNmber" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                </div>
                                                <div class="col-4" id="Div22" runat="server">
                                                    <label for="Name">
                                                        Number of Power Line Crossing:	
                        
                                                    </label>
                                                    <asp:TextBox class="form-control" ID="txtPowerLineCrossingNmbr" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div id="LineTypeUnderground" runat="server" visible="true">
                                            <div class="row">
                                                <div class="col-4">
                                                    <label>
                                                        Type of Cable
                        
                                                    </label>
                                                    <asp:TextBox class="form-control" ID="txtCableType" ReadOnly="true" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                </div>
                                                <div class="col-4" id="OtherCable" runat="server" visible="false">
                                                    <label>
                                                        Type of Cable(Other)
                                                    </label>
                                                    <asp:TextBox class="form-control" ID="txtOtherCable" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                </div>
                                                <div class="col-4">
                                                    <label>
                                                        Size of Cable: In(MM Sq.)
                                                    </label>
                                                    <asp:TextBox class="form-control" ID="txtCableSize" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                </div>
                                                <div class="col-4">
                                                    <label>
                                                        Cable Laid in
                        
                                                    </label>
                                                    <asp:TextBox class="form-control" ID="txtCableLaid" ReadOnly="true" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="card" id="inspection-card-child3" style="background: #fcfcfc;">
                                        <div id="Insulation440vAbove" runat="server" visible="false">
                                            <div class="row">
                                                <div class="col-4">
                                                    <label>
                                                        Red Phase – Earth Wire (in Mohm)
                                                    </label>
                                                    <asp:TextBox class="form-control" ID="txtRedEarthWire" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                </div>
                                                <div class="col-4" id="Div32" runat="server">
                                                    <label for="Name">
                                                        Yellow Phase – Earth Wire (in Mohm)	
                        
                                                    </label>
                                                    <asp:TextBox class="form-control" ID="txtYellowEarthWire" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                </div>
                                                <div class="col-4" id="Div33" runat="server">
                                                    <label for="Name">
                                                        Blue Phase – Earth Wire (in Mohm)	
                
                                                    </label>
                                                    <asp:TextBox class="form-control" ID="txtBlueEarthWire" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                </div>
                                                <div class="col-4" id="Div34" runat="server">
                                                    <label for="Name">
                                                        Red Phase – Yellow Phase(in Mohm)
               
                                                    </label>
                                                    <asp:TextBox class="form-control" ID="txtRedYellowPhase" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                </div>
                                                <div class="col-4" id="Div35" runat="server">
                                                    <label for="Name">
                                                        Blue Phase – Yellow Phase(in Mohm)
                
                                                    </label>
                                                    <asp:TextBox class="form-control" ID="txtBlueYellowPhase" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                </div>
                                                <div class="col-4" id="Div36" runat="server">
                                                    <label for="Name">
                                                        Red Phase – Blue Phase(in Mohm)
                
                                                    </label>
                                                    <asp:TextBox class="form-control" ID="txtRedBluePhase" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div id="Insulation220vAbove" runat="server" visible="false">
                                            <div class="row">
                                                <div class="col-4">
                                                    <label>
                                                        Phase wire - Neutral wire (in Mohm)
                                                    </label>
                                                    <asp:TextBox class="form-control" ID="txtNeutralWire" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                </div>
                                                <div class="col-4" id="Div37" runat="server">
                                                    <label for="Name">
                                                        Phase wire - Earth (in Mohm)
                       
                                                    </label>
                                                    <asp:TextBox class="form-control" ID="txtEarthWire" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                </div>
                                                <div class="col-4" id="Div39" runat="server">
                                                    <label for="Name">
                                                        Neutral wire - Earth (in Mohm)
             
                                                    </label>
                                                    <asp:TextBox class="form-control" ID="txtNeutralWireEarth" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div id="UndergroundInsulation440vAbove" runat="server" visible="false">
                                            <div class="row">
                                                <div class="col-4">
                                                    <label>
                                                        Red Phase – Earth Wire (in Mohm)
                                                    </label>
                                                    <asp:TextBox class="form-control" ID="txtRedWire" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                </div>
                                                <div class="col-4" id="Div38" runat="server">
                                                    <label for="Name">
                                                        Yellow Phase – Earth Wire (in Mohm)	
    
                                                    </label>
                                                    <asp:TextBox class="form-control" ID="txtYellowWire" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                </div>
                                                <div class="col-4" id="Div40" runat="server">
                                                    <label for="Name">
                                                        Blue Phase – Earth Wire (in Mohm)	
                                                    
                                                    </label>
                                                    <asp:TextBox class="form-control" ID="txtBlueWire" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                </div>
                                                <div class="col-4" id="Div41" runat="server">
                                                    <label for="Name">
                                                        Red Phase – Yellow Phase(in Mohm)
                                                   
                                                    </label>
                                                    <asp:TextBox class="form-control" ID="txtRedYellowWire" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                </div>
                                                <div class="col-4" id="Div42" runat="server">
                                                    <label for="Name">
                                                        Blue Phase – Yellow Phase(in Mohm)
                                                    
                                                    </label>
                                                    <asp:TextBox class="form-control" ID="txtBlueYellowWire" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                </div>
                                                <div class="col-4" id="Div43" runat="server">
                                                    <label for="Name">
                                                        Red Phase – Blue Phase(in Mohm)
                                                    
                                                    </label>
                                                    <asp:TextBox class="form-control" ID="txtRedBlueWire" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div id="UndergroundInsulation220vAbove" runat="server" visible="false">
                                            <div class="row">
                                                <div class="col-4">
                                                    <label>
                                                        Phase wire - Neutral wire (in Mohm)
                                                    </label>
                                                    <asp:TextBox class="form-control" ID="txtNeutralPhaseWire" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                </div>
                                                <div class="col-4" id="Div44" runat="server">
                                                    <label for="Name">
                                                        Phase wire - Earth (in Mohm)
                        
                                                    </label>
                                                    <asp:TextBox class="form-control" ID="txtPhaseWireEarth" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                </div>
                                                <div class="col-4" id="Div45" runat="server">
                                                    <label for="Name">
                                                        Neutral wire - Earth (in Mohm)
                                                   
                                                    </label>
                                                    <asp:TextBox class="form-control" ID="txtNeutralWireEarthUnderground" ReadOnly="true" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="page2" style="page-break-before: always;">
                                <div class="card" id="earthing-card" style="background: #fcfcfc; margin-top: 5%;">
                                    <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important;"><u>Earthing Details</u></h6>
                                    <div id="Earthing" runat="server" visible="true">
                                        <div class="card">
                                            <div class="col-4">
                                                <label>
                                                    Number of Earthing:
                                               
                                                </label>
                                                <asp:TextBox class="form-control" ID="txtEarthing" ReadOnly="true" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>
                                            <div class="table-responsive pt-3" id="LineEarthingdiv" runat="server" visible="true" style="margin-left: 0px;">
                                                <table class="table table-bordered table-striped" style="box-shadow: rgba(0, 0, 0, 0.16) 0px 10px 36px 0px, rgba(0, 0, 0, 0.06) 0px 0px 0px 1px;">
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
                                                        <tr id="Earthingtype1" visible="false" runat="server" style="display: table-row;">
                                                            <td>1
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ID="txtEarthingType1" ReadOnly="true" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ID="txtearthingValue1" ReadOnly="true" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr id="Earthingtype2" style="display: none" runat="server">
                                                            <td>2
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ID="txtEarthingType2" ReadOnly="true" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ID="txtEarthingValue2" ReadOnly="true" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr id="Earthingtype3" runat="server" style="display: none">
                                                            <td>3
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ID="txtEarthingType3" ReadOnly="true" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ID="txtEarthingValue3" ReadOnly="true" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr id="Earthingtype4" runat="server" style="display: none">
                                                            <td>4
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ID="txtEarthingType4" ReadOnly="true" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <div class="col-12" id="Div15" runat="server">
                                                                    <asp:TextBox class="form-control" ID="txtEarthingValue4" ReadOnly="true" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr id="Earthingtype5" runat="server" style="display: none">
                                                            <td>5
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ID="txtEarthingType5" onKeyPress="return isNumberKey(event);" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ID="txtEarthingValue5" ReadOnly="true" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr id="Earthingtype6" runat="server" style="display: none">
                                                            <td>6
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ID="txtEarthingType6" ReadOnly="true" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ID="txtEarthingValue6" ReadOnly="true" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr id="Earthingtype7" runat="server" style="display: none">
                                                            <td>7
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ID="txtEarthingType7" ReadOnly="true" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ID="txtEarthingValue7" ReadOnly="true" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr id="Earthingtype8" runat="server" style="display: none">
                                                            <td>8
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ID="txtEarthingType8" ReadOnly="true" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ID="txtEarthingValue8" ReadOnly="true" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr id="Earthingtype9" runat="server" style="display: none">
                                                            <td>9
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ID="txtEarthingType9" ReadOnly="true" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>

                                                                </div>
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ID="txtEarthingValue9" ReadOnly="true" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr id="Earthingtype10" runat="server" style="display: none">
                                                            <td>10
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ID="txtEarthingType10" ReadOnly="true" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>

                                                                </div>
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ID="txtEarthingValue10" ReadOnly="true" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr id="Earthingtype11" runat="server" style="display: none">
                                                            <td>11
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ID="txtEarthingType11" ReadOnly="true" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>

                                                                </div>
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ID="txtEarthingValue11" ReadOnly="true" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr id="Earthingtype12" runat="server" style="display: none">
                                                            <td>12
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ID="txtEarthingType12" ReadOnly="true" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>

                                                                </div>
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ID="txtEarthingValue12" ReadOnly="true" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr id="Earthingtype13" runat="server" style="display: none">
                                                            <td>13
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ID="txtEarthingType13" ReadOnly="true" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>

                                                                </div>
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ID="txtEarthingValue13" ReadOnly="true" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr id="Earthingtype14" runat="server" style="display: none">
                                                            <td>14
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ID="txtEarthingType14" ReadOnly="true" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>

                                                                </div>
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ID="txtEarthingValue14" ReadOnly="true" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr id="Earthingtype15" runat="server" style="display: none">
                                                            <td>15
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ID="txtEarthingType15" ReadOnly="true" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>

                                                                </div>
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ID="txtEarthingValue15" ReadOnly="true" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="card" style="background: #fcfcfc; margin-top: 5%;">
                                    <div class="row">

                                        <%--   <div class="col-6" id="CreatedDate" visible="false" runat="server">
                                            <label>
                                                TestReport Created Date
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtCreatedDate" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>--%>
                                        <div class="col-6" id="Div8" runat="server">
                                            <label>
                                                Installation Type
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtinstalltype" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <%--<div class="col-4" id="SubmitDate" visible="false" runat="server">
                                            <label>
                                                Work Intimation Submitted Date
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtSubmitteddate" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>--%>
                                        <%-- <div class="col-4" id="SubmitBy" visible="false" runat="server">
                                            <label>
                                                Work Intimation Submitted By
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtSubmittedBy" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>--%>
                                    </div>
                                </div>
                                <div class="card-title" style="margin-top: 3%;font-weight: 700; margin-bottom: 0px !important;">
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
                                <div class="card-title" style="margin-top: 3%;font-weight: 700; margin-bottom: 0px !important;">
                                    Test Report Prepared Details (<asp:Label ID="lblReportNo" runat="server" />)
                                </div>
                                <div id="Div9" runat="server">
                                    <div class="row" style="padding-bottom: 20px;">
                                        <div class="col-4" id="CreatedDate">
                                            <label>
                                                Test Report Created Date
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtCreatedDate" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4" id="Div10" runat="server">
                                            <label for="Name">
                                                Prepared By
                                            </label>
                                            <asp:TextBox class="form-control" ReadOnly="true" ID="txtPreparedby" onkeydown="return preventEnterSubmit(event)" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <br />

                                <div class="card-title" id="ApprovalTitle" visible="false" runat="server" style="margin-top: 3%;font-weight: 700; margin-bottom: 0px !important;">Test Report Approval Details</div>
                                <div class="row" id="DivApproval" style="padding-bottom: 20px;" visible="false" runat="server">
                                    <div class="col-4" id="Div12" runat="server">
                                        <label>
                                            Test Report Approval Date
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtApprovalDate" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-4" id="Div13" runat="server">
                                        <label for="Name">
                                            Test Report Approved By
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtApprovedBy" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
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
