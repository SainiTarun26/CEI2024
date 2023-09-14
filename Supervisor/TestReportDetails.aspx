<%@ Page Title="" Language="C#" MasterPageFile="~/Supervisor/Supervisor.Master" AutoEventWireup="true" CodeBehind="TestReportDetails.aspx.cs" Inherits="CEIHaryana.Supervisor.TestReportDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="shortcut icon" type="image/png" href="/css2/style.min.css" />
    <link rel="stylesheet" href="/css2/style.css" />
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
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
        div#ContentPlaceHolder1_individual {
            top: 15px;
        }

        .col-4 {
            top: 15px;
            left: 0px;
        }

        .col-2 {
            top: 15px;
            left: 0px;
        }

        .form-control {
            box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
            margin-left: 0px !important;
            height: 30px;
            font-size: 12px !important;
            padding:0px 5px !important;
        }

        select.form-control {
            box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
            margin-left: 0px !important;
            height: 30px !important;
            font-size: 12px !important;
            padding:0px 5px !important;
        }

        label {
            font-size: 13px;
            margin-top: 15px;
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
            margin-top: 30px !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <%--        <div class="card-header" style="background: linear-gradient(341deg, rgba(0,255,103,1) 0%, rgba(70,85,252,1) 100%); color: white; margin-bottom: 15px; border-radius: 5px;">
         <h4 style="font-weight: 600; text-align: center;">CONTRACTOR DETAILS</h4>
     </div>--%>
        <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel" runat="server">
            <ContentTemplate>
                <div class="card" style="box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px; border-radius: 5px !important">
                    <div class="card-body">
                        <div class="row">
                            <div class="col-md-4"></div>
                            <div class="col-sm-4" style="text-align: center; box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding-top: 8px; padding-bottom: 8px; border-radius: 10px;">
                                <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important;">TEST REPORT</h6>
                            </div>
                            <br />
                            <div class="col-md-4"></div>
                        </div>
                        <div class="row">
                            <div class="col-md-4"></div>
                            <div class="col-sm-4" style="text-align: center;">
                                <label id="DataUpdated" runat="server" visible="false" style="color: red; font-size: 1.125rem">
                                    Data Updated Successfully !!!.
                                </label>
                                <label id="DataSaved" runat="server" visible="false" style="color: greenyellow; font-size: 1.125rem">
                                    Data Saved Successfully !!!.
                                </label>
                            </div>
                        </div>
                        <br />
                        <div id="IfInstallationIsLine" runat="server">
                        <div class="row" style="margin-bottom: 20px;">
                            <div class="col-4">
                                <label>
                                    Sanction load/ Contract demand(in KVA) 
                            <samp style="color: red">* </samp>
                                </label>
                                <asp:TextBox class="form-control" ID="txtSanctionLoad" onkeypress="return isNumberKey(event);" MaxLength="5" autocomplete="off" placeholder="as per demand notice of utility OR electricity bill." runat="server" Style="margin-left: 18px"></asp:TextBox>
                            </div>
                        </div>
                        <h7 class="card-title fw-semibold mb-4">Personal Details</h7>
                        <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                            <div>
                                <div class="row">
                                    <div class="col-4">
                                        <label>
                                            Voltage of Line<samp style="color: red"> * </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlLineVoltage" selectionmode="Multiple" Style="width: 100% !important" OnSelectedIndexChanged="ddlLineVoltage_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-4" id="OtherVoltage" runat="server" visible="false">
                                        <label for="Voltage">
                                            Other Voltage 
                                <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" AutoPostBack="true" ID="TxtOthervoltage" MaxLength="10" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>

                                    </div>
                                    <div class="col-4" id="Div1" runat="server">
                                        <label for="Name">
                                            Length of Line (in KM)
                                <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtLineLength" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>

                                    </div>
                                    <div class="col-4">
                                        <label>
                                            Line Type
                                <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlLineType" selectionmode="Multiple" Style="width: 100% !important" OnSelectedIndexChanged="ddlLineType_SelectedIndexChanged">
                                            <asp:ListItem Text="Select" Value=""></asp:ListItem>
                                            <asp:ListItem Text="Overhead" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Underground" Value="2"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div id="LineTypeOverhead" runat="server" visible="false">
                                <div class="row">
                                    <div class="col-4">
                                        <label>
                                            No of Circuit
             <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlNmbrOfCircuit" selectionmode="Multiple" Style="width: 100% !important">
                                            <asp:ListItem Text="Select" Value=""></asp:ListItem>
                                            <asp:ListItem Text="Single" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Double" Value="2"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-4">
                                        <label>
                                            Conductor Type
             <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlConductorType" Style="width: 100% !important" OnSelectedIndexChanged="ddlConductorType_SelectedIndexChanged">

                                            <asp:ListItem Text="Select" Value=""></asp:ListItem>
                                            <asp:ListItem Text="Bare" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Cable" Value="2"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div id="OverheadBare" visible="false" runat="server">
                                <div class="row">
                                    <div class="col-4">
                                        <label>
                                            Number of Pole/Tower<samp style="color: red"> * </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtPoleTower" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" onkeypress="return isNumberKey(event);" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-4" id="Div2" runat="server">
                                        <label for="Name">
                                            Size of Conductor( IN SQ.MM)
        <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtConductorSize" onkeydown="return preventEnterSubmit(event)" MaxLength="3" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-4" id="Div3" runat="server">
                                        <label for="Name">
                                            Size of Ground Wire( IN SQ.MM)	

                                    <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtGroundWireSize" onkeydown="return preventEnterSubmit(event)" MaxLength="2" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-4" id="Div4" runat="server">
                                        <label for="Name">
                                            Number of Railway Crossing
                                    <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtRailwayCrossingNo" onkeydown="return preventEnterSubmit(event)" MaxLength="2" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-4" id="Div5" runat="server">
                                        <label for="Name">
                                            Number of Road Crossing
                                    <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtRoadCrossingNo" onkeydown="return preventEnterSubmit(event)" MaxLength="2" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-4" id="Div6" runat="server">
                                        <label for="Name">
                                            Number of River/Canal Crossing
                                    <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtRiverCanalCrossing" onkeydown="return preventEnterSubmit(event)" MaxLength="2" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-4" id="Div7" runat="server">
                                        <label for="Name">
                                            Number of Power Line Crossing:	
                                    <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtPowerLineCrossing" onkeydown="return preventEnterSubmit(event)" MaxLength="2" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>

                                </div>
                            </div>
                            <div id="OverheadCable" runat="server" visible="false">
                                <div class="row">
                                    <div class="col-4">
                                        <label>
                                            Number of Pole/Tower<samp style="color: red"> * </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtPoleTowerNo" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-4" id="Div10" runat="server">
                                        <label for="Name">
                                            Size of Conductor( IN SQ.MM)	
        <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtConductorSize1" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-4" id="Div11" runat="server">
                                        <label for="Name">
                                           Size of cable: (in MM sq.)
                                    <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtCableSize1" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-4" id="Div19" runat="server">
                                        <label for="Name">
                                            Number of Railway Crossing
                                    <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtRailwayCrossingNmbr" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-4" id="Div20" runat="server">
                                        <label for="Name">
                                            Number of Road Crossing
                                    <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtRoadCrossingNmbr" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-4" id="Div21" runat="server">
                                        <label for="Name">
                                            Number of River/Canal Crossing
                                    <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtRiverCanalCrossingNmber" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-4" id="Div22" runat="server">
                                        <label for="Name">
                                            Number of Power Line Crossing:	
                                    <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtPowerLineCrossingNmbr" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>

                                </div>
                            </div>
                            <div id="Earthing" runat="server" visible="false">
                                  <div class="row">
                                <div class="col-4">
                                    <label>
                                        Number of Earthing:
                                    <samp style="color: red">* </samp>
                                    </label>
                                    <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlNoOfEarthing" selectionmode="Multiple" Style="width: 100% !important">
                                    <asp:ListItem Value="1" Text="1"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div id="Earthingtype1" runat="server">
                                <div class="col-2" >
                                    <label>
                                        Earthing Type
                                    <samp style="color: red">* </samp>
                                    </label>
                                    <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlEarthingtype1" selectionmode="Multiple" Style="width: 100% !important">
                                    <asp:ListItem Value="0" Text="Select"></asp:ListItem> <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                         <asp:ListItem Value="1" Text="Pipe"></asp:ListItem>
                                         <asp:ListItem Value="1" Text="Plate"></asp:ListItem>
                                        </asp:DropDownList>
                                </div>

                                <div class="col-2">
                                    <label>
                                        Value in(ohms)
                                    <samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtearthingValue1" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                </div>
                                    </div>
                                <div  id="Earthingtype2" runat="server">
                                <div class="col-2">
                                    <label>
                                        Earthing Type
        <samp style="color: red">* </samp>
                                    </label>
                                    <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlEarthingtype2" selectionmode="Multiple" Style="width: 100% !important">
                                     <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                         <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                         <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                        </asp:DropDownList>
                                </div>
                                <div class="col-2" >
                                    <label for="Name">
                                        Value in(ohms)
        <samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtEarthingValue2" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                </div>
                                    </div>
                                    
                                <div id="Earthingtype3" runat="server">
                                <div class="col-2">
                                    <label for="Name">
                                        Earthing Type
        <samp style="color: red">* </samp>
                                    </label>
                                    <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlEarthingtype3" selectionmode="Multiple" Style="width: 100% !important">
                                      <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                         <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                         <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                        </asp:DropDownList>
                                </div>
                                <div class="col-2" >
                                    <label for="Name">
                                        Value in(ohms)
        <samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtEarthingValue3" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                </div>
                                    </div>
                                        
                                <div id="Earthingtype4" runat="server">
                                <div class="col-2">
                                    <label for="Name">
                                        Earthing Type
        <samp style="color: red">* </samp>
                                    </label>
                                    <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlEarthingtype4" selectionmode="Multiple" Style="width: 100% !important">
                                     <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                         <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                         <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                        </asp:DropDownList>
                                </div>
                                <div class="col-2">
                                    <label for="Name">
                                        Value in(ohms)
        <samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtEarthingValue4" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                </div>
                                    </div>
                                    
                                <div id="Earthingtype5" runat="server">
                                <div class="col-2">
                                    <label for="Name">
                                        Earthing Type
        <samp style="color: red">* </samp>
                                    </label>
                                    <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlEarthingtype5" selectionmode="Multiple" Style="width: 100% !important">
                                     <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                         <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                         <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                        </asp:DropDownList>
                                </div>
                                <div class="col-2">
                                    <label for="Name">
                                        Value in(ohms)
        <samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtEarthingValue5" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                </div>
                                 </div>
                                    
                                <div id="Earthingtype6" runat="server">
                                <div class="col-2">
                                    <label for="Name">
                                        Earthing Type
        <samp style="color: red">* </samp>
                                    </label>
                                    <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlEarthingtype6" selectionmode="Multiple" Style="width: 100% !important">
                                     <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                         <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                         <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                        </asp:DropDownList>
                                </div>
                                <div class="col-2>
                                    <label>
                                        Value in(ohms)
        <samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtEarthingValue6" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                </div>
                                    </div>
                                <div id="Earthingtype7" runat="server">
                                <div class="col-2">
                                    <label>
                                        Earthing Type
        <samp style="color: red">* </samp>
                                    </label>
                                    <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlEarthingtype7" selectionmode="Multiple" Style="width: 100% !important">
                                     <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                         <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                         <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                        </asp:DropDownList>
                                </div>
                                <div class="col-2" >
                                    <label for="Name">
                                        Value in(ohms)
        <samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtEarthingValue7" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                </div>
                                    </div>
                                <div id="Earthingtype8" runat="server">
                                <div class="col-2">
                                    <label>
                                        Earthing Type
        <samp style="color: red">* </samp>
                                    </label>
                                    <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlEarthingtype8" selectionmode="Multiple" Style="width: 100% !important">
                                      <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                         <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                         <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                        </asp:DropDownList>
                                </div>
                                <div class="col-2">
                                    <label>
                                        Value in(ohms)
        <samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtEarthingValue8" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                </div>
                                    </div>
                                    
                                <div id="Earthingtype9" runat="server">
                                <div class="col-2">
                                    <label for="Name">
                                        Earthing Type
        <samp style="color: red">* </samp>
                                    </label>
                                    <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlEarthingtype9" selectionmode="Multiple" Style="width: 100% !important">
                                      <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                         <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                         <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                        </asp:DropDownList>
                                </div>
                                <div class="col-2">
                                    <label for="Name">
                                        Value in(ohms)
        <samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtEarthingValue9" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                </div>
                                    </div>
                                <div id="Earthingtype10" runat="server">
                                <div class="col-2">
                                    <label>
                                        Earthing Type
        <samp style="color: red">* </samp>
                                    </label>
                                    <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlEarthingtype10" selectionmode="Multiple" Style="width: 100% !important">
                                    <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                         <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                         <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                        </asp:DropDownList>
                                </div>
                                <div class="col-2">
                                    <label>
                                        Value in(ohms)
        <samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtEarthingValue10" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                </div>
                                    </div>
                                <div id="Earthingtype11" runat="server">
                                <div class="col-2">
                                    <label>
                                        Earthing Type
        <samp style="color: red">* </samp>
                                    </label>
                                    <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlEarthingtype11" selectionmode="Multiple" Style="width: 100% !important">
                                    <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                         <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                         <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                        </asp:DropDownList>
                                </div>
                                <div class="col-2">
                                    <label>
                                        Value in(ohms)
        <samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtEarthingValue11" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                </div>
                                    </div>
                                    
                                <div id="Earthingtype12" runat="server">
                                <div class="col-2">
                                    <label>
                                        Earthing Type
        <samp style="color: red">* </samp>
                                    </label>
                                    <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlEarthingtype12" selectionmode="Multiple" Style="width: 100% !important">
                                   <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                         <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                         <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                        </asp:DropDownList>
                                </div>
                                <div class="col-2">
                                    <label>
                                        Value in(ohms)
        <samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtEarthingValue12" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                </div>
                                    </div>
                                <div id="Earthingtype13" runat="server">
                                <div class="col-2">
                                    <label>
                                        Earthing Type
        <samp style="color: red">* </samp>
                                    </label>
                                    <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlEarthingtype13" selectionmode="Multiple" Style="width: 100% !important">
                                    <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                         <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                         <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                        </asp:DropDownList>
                                </div>
                                <div class="col-2">
                                    <label>
                                        Value in(ohms)
        <samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtEarthingValue13" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                </div>
                                    </div>
                                <div id="Earthingtype14" runat="server">
                                <div class="col-2">
                                    <label>
                                        Earthing Type
        <samp style="color: red">* </samp>
                                    </label>
                                    <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlEarthingtype14" selectionmode="Multiple" Style="width: 100% !important">
                                     <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                         <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                         <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                        </asp:DropDownList>
                                </div>
                                <div class="col-2">
                                    <label>
                                        Value in(ohms)
        <samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtEarthingValue14" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                </div>
                                    </div>
                                <div id="Earthingtype15" runat="server">
                                <div class="col-2">
                                    <label>
                                        Earthing Type
        <samp style="color: red">* </samp>
                                    </label>
                                    <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlEarthingtype15" selectionmode="Multiple" Style="width: 100% !important">
                                        <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                         <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                         <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                        </asp:DropDownList>
                                </div>
                                <div class="col-2">
                                    <label>
                                        Value in(ohms)
        <samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtEarthingValue15" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                </div>
                                    </div>
                                    </div>
                            </div>
                            <div id="Insulation440vAbove" runat="server" visible="false">
                                <div class="row">
                                    <div class="col-4">
                                        <label>
                                            Red Phase – Earth Wire (in Mohm)<samp style="color: red"> * </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtRedEarthWire" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-4" id="Div32" runat="server">
                                        <label for="Name">
                                            Yellow Phase – Earth Wire (in Mohm)	

                                    <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtYellowEarthWire" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-4" id="Div33" runat="server">
                                        <label for="Name">
                                            Blue Phase – Earth Wire (in Mohm)	

                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtBlueEarthWire" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-4" id="Div34" runat="server">
                                        <label for="Name">
                                            Red Phase – Yellow Phase(in Mohm)
                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtRedYellowPhase" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-4" id="Div35" runat="server">
                                        <label for="Name">
                                            Blue Phase – Yellow Phase(in Mohm)
                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtBlueYellowPhase" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-4" id="Div36" runat="server">
                                        <label for="Name">
                                            Red Phase – Blue Phase(in Mohm)
                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtRedBluePhase" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div id="Insulation220vAbove" runat="server" visible="false">
                                <div class="row">
                                    <div class="col-4">
                                        <label>
                                            Phase wire - Neutral wire (in Mohm)<samp style="color: red"> * </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtNeutralWire" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-4" id="Div37" runat="server">
                                        <label for="Name">
                                            Phase wire - Earth (in Mohm)
                                    <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtEarthWire" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-4" id="Div39" runat="server">
                                        <label for="Name">
                                            Neutral wire - Earth (in Mohm)
                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtNeutralWireEarth" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div id="LineTypeUnderground" runat="server" visible="false">
                                <div class="row">
                                    <div class="col-4">
                                        <label>
                                            Type of Cable
                                    <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlCableType" selectionmode="Multiple" Style="width: 100% !important">
                                     <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="XPLE"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Other"></asp:ListItem>
                                            </asp:DropDownList>
                                    </div>
                                    <div class="col-4">
                                        <label>
                                            Size of Cable: In(MM Sq.)<samp style="color: red"> * </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtCableSize" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-4">
                                        <label>
                                            Cable Laid in
                                    <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlCableLaid" selectionmode="Multiple" Style="width: 100% !important">
                                       <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="Trench"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="circuit"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="cable tray"></asp:ListItem>
                                            </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div id="UndergroundInsulation440vAbove" runat="server" visible="false">
                                <div class="row">
                                    <div class="col-4">
                                        <label>
                                            Red Phase – Earth Wire (in Mohm)<samp style="color: red"> * </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtRedWire" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-4" id="Div38" runat="server">
                                        <label for="Name">
                                            Yellow Phase – Earth Wire (in Mohm)	
                <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtYellowWire" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-4" id="Div40" runat="server">
                                        <label for="Name">
                                            Blue Phase – Earth Wire (in Mohm)	
        <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtBlueWire" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-4" id="Div41" runat="server">
                                        <label for="Name">
                                            Red Phase – Yellow Phase(in Mohm)
        <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtRedYellowWire" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-4" id="Div42" runat="server">
                                        <label for="Name">
                                            Blue Phase – Yellow Phase(in Mohm)
        <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtBlueYellowWire" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-4" id="Div43" runat="server">
                                        <label for="Name">
                                            Red Phase – Blue Phase(in Mohm)
        <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtRedBlueWire" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div id="UndergroundInsulation220vAbove" runat="server" visible="false">
                                <div class="row">
                                    <div class="col-4">
                                        <label>
                                            Phase wire - Neutral wire (in Mohm)<samp style="color: red"> * </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtNeutralPhaseWire" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-4" id="Div44" runat="server">
                                        <label for="Name">
                                            Phase wire - Earth (in Mohm)
                                    <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtPhaseWireEarth" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-4" id="Div45" runat="server">
                                        <label for="Name">
                                            Neutral wire - Earth (in Mohm)
        <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtNeutralWireEarthUnderground" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-4" id="Div46" runat="server">
                                        <label for="Name">
                                            Number of Earthing:
                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList22" selectionmode="Multiple" Style="width: 100% !important">
                                     <asp:ListItem Value="1" Text="1"></asp:ListItem>
                                            </asp:DropDownList>
                                    </div>
                                    <div class="col-2" id="Div47" runat="server">
                                        <label for="Name">
                                            Earthing Type
                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList16" selectionmode="Multiple" Style="width: 100% !important">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-2" id="Div48" runat="server">
                                        <label for="Name">
                                            Value in(ohms)
                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="TextBox49" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-2" id="Div49" runat="server">
                                        <label for="Name">
                                            Earthing Type
                                    <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList17" selectionmode="Multiple" Style="width: 100% !important">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-2" id="Div50" runat="server">
                                        <label for="Name">
                                            Value in(ohms)
                                    <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="TextBox50" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-2" id="Div51" runat="server">
                                        <label for="Name">
                                            Earthing Type
                                    <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList18" selectionmode="Multiple" Style="width: 100% !important">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-2" id="Div52" runat="server">
                                        <label for="Name">
                                            Value in(ohms)
                                    <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="TextBox51" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-2" id="Div53" runat="server">
                                        <label for="Name">
                                            Earthing Type
                                    <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList19" selectionmode="Multiple" Style="width: 100% !important">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-2" id="Div54" runat="server">
                                        <label for="Name">
                                            Value in(ohms)
                                    <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="TextBox52" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                         <div class="row">
                            <div class="col-4"></div>
                            <div class="col-4" style="text-align: center;">
                                <asp:Button ID="btnSubmit" Text="Generate Test Report" runat="server" ValidationGroup="Submit" class="btn btn-primary mr-2"
                                    Style="background: linear-gradient(135deg, hsla(318, 44%, 51%, 1) 0%, hsla(347, 94%, 48%, 1) 100%); border-color: #d42766;" OnClick="btnSubmit_Click" />
                            </div>
                            <div class="col-4">
                                <asp:HiddenField ID="HiddenField1" runat="server" />
                            </div>
                        </div>
                            <div class="row">
                            </div>
                        </div>
                        
                            </div>
                        </div>
                        <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                            <div class="InstallationSubstation">
                                <div class="row">
                                    <div class="col-4" id="Div121" runat="server">
                                        <label for="Voltage">
                                            Serial number of transformer  
                                                <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" AutoPostBack="true" ID="TextBox41" MaxLength="10" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-4">
                                        <label>
                                            Capacity of transformer (IN KVA) 
                                                <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList48" selectionmode="Multiple" Style="width: 100% !important" OnSelectedIndexChanged="ddlLineVoltage_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-4">
                                        <label>
                                            Type of transformer
                                                <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList49" selectionmode="Multiple" Style="width: 100% !important" OnSelectedIndexChanged="ddlLineVoltage_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="InCaseOfOil">
                                <div class="row">
                                    <div class="col-4" id="Div122" runat="server">
                                        <label for="Voltage">
                                            Primary voltage(in kva)  
                                                <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" AutoPostBack="true" ID="TextBox42" MaxLength="10" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-4" id="Div123" runat="server">
                                        <label for="Voltage">
                                            Secondary Voltage(in volte)  
                                                <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" AutoPostBack="true" ID="TextBox43" MaxLength="10" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-4" id="Div125" runat="server">
                                        <label for="Voltage">
                                            Capacity of oil(in liters)  
                                                <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" AutoPostBack="true" ID="TextBox44" MaxLength="10" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-4" id="Div126" runat="server">
                                        <label for="Voltage">
                                            BDV level of oil (in kv) Break down voltage  
                                                <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" AutoPostBack="true" ID="TextBox45" MaxLength="10" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                </div>
                                <label for="Voltage" style="margin-top: 30px; margin-bottom: 0px; font-size: 1rem !important; font-weight: 600;">HT side Insulation Resistance</label>
                                <div class="HTInsulationResistance">
                                    <div class="row" style="margin-top: -15px;">
                                        <div class="col-4" id="Div124" runat="server">
                                            <label for="Voltage" style="margin-top: 10px;">
                                                Red Phase – Earth Wire (in Mohm)  
        <samp style="color: red">* </samp>
                                            </label>
                                            <asp:TextBox class="form-control" AutoPostBack="true" ID="TextBox46" MaxLength="10" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4" id="Div127" runat="server">
                                            <label for="Voltage" style="margin-top: 10px;">
                                                Yellow Phase – Earth Wire (in Mohm)   
        <samp style="color: red">* </samp>
                                            </label>
                                            <asp:TextBox class="form-control" AutoPostBack="true" ID="TextBox47" MaxLength="10" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4" id="Div128" runat="server">
                                            <label for="Voltage" style="margin-top: 10px;">
                                                Blue Phase – Earth Wire (in Mohm)  
        <samp style="color: red">* </samp>
                                            </label>
                                            <asp:TextBox class="form-control" AutoPostBack="true" ID="TextBox48" MaxLength="10" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <label for="Voltage" style="margin-top: 30px; margin-bottom: 0px; font-size: 1rem !important; font-weight: 600;">LT side Insulation Resistance</label>
                                <div class="LTInsulationResistance">
                                    <div class="row" style="margin-top: -15px;">
                                        <div class="col-4" id="Div129" runat="server">
                                            <label for="Voltage" style="margin-top: 10px;">
                                                Red Phase – Earth Wire (in Mohm)  
                                                    <samp style="color: red">* </samp>
                                            </label>
                                            <asp:TextBox class="form-control" AutoPostBack="true" ID="TextBox53" MaxLength="10" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4" id="Div130" runat="server">
                                            <label for="Voltage" style="margin-top: 10px;">
                                                Yellow Phase – Earth Wire (in Mohm)   
                                                    <samp style="color: red">* </samp>
                                            </label>
                                            <asp:TextBox class="form-control" AutoPostBack="true" ID="TextBox54" MaxLength="10" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                        <div class="col-4" id="Div131" runat="server">
                                            <label for="Voltage" style="margin-top: 10px;">
                                                Blue Phase – Earth Wire (in Mohm)  
                                                    <samp style="color: red">* </samp>
                                            </label>
                                            <asp:TextBox class="form-control" AutoPostBack="true" ID="TextBox55" MaxLength="10" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <label for="Voltage" style="margin-top: 30px; margin-bottom: 0px; font-size: 1rem !important; font-weight: 600;">Lowest value between HT LT Side</label>
                                <div class="LTInsulationResistance">
                                    <div class="row" style="margin-top: -15px;">
                                        <div class="col-4" id="Div132" runat="server">
                                            <label for="Voltage" style="margin-top: 10px;">
                                                Red Phase – Earth Wire (in Mohm)  
                    <samp style="color: red">* </samp>
                                            </label>
                                            <asp:TextBox class="form-control" AutoPostBack="true" ID="TextBox56" MaxLength="10" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-4" id="Div133" runat="server">
                                        <label for="Voltage">
                                            Lightning Arrestor (LA) Location  
         <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" AutoPostBack="true" ID="TextBox57" MaxLength="10" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-4" id="Div134" runat="server">
                                        <label for="Name">
                                            Number of Earthing:
                                                <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList50" selectionmode="Multiple" Style="width: 100% !important">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-2" id="Div135" runat="server">
                                        <label for="Name">
                                            Earthing Type
                                                <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList51" selectionmode="Multiple" Style="width: 100% !important">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-2" id="Div136" runat="server">
                                        <label for="Name">
                                            Value in(ohms)
                                                <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="TextBox58" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-2" id="Div137" runat="server">
                                        <label for="Name">
                                            Earthing Type
        <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList52" selectionmode="Multiple" Style="width: 100% !important">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-2" id="Div138" runat="server">
                                        <label for="Name">
                                            Value in(ohms)
        <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="TextBox59" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-2" id="Div139" runat="server">
                                        <label for="Name">
                                            Earthing Type
        <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList53" selectionmode="Multiple" Style="width: 100% !important">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-2" id="Div140" runat="server">
                                        <label for="Name">
                                            Value in(ohms)
        <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="TextBox60" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-2" id="Div141" runat="server">
                                        <label for="Name">
                                            Earthing Type
        <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList54" selectionmode="Multiple" Style="width: 100% !important">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-2" id="Div142" runat="server">
                                        <label for="Name">
                                            Value in(ohms)
        <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="TextBox61" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-2" id="Div143" runat="server">
                                        <label for="Name">
                                            Earthing Type
        <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList55" selectionmode="Multiple" Style="width: 100% !important">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-2" id="Div144" runat="server">
                                        <label for="Name">
                                            Value in(ohms)
        <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="TextBox62" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-2" id="Div145" runat="server">
                                        <label for="Name">
                                            Earthing Type
        <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList56" selectionmode="Multiple" Style="width: 100% !important">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-2" id="Div146" runat="server">
                                        <label for="Name">
                                            Value in(ohms)
        <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="TextBox63" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-2" id="Div147" runat="server">
                                        <label for="Name">
                                            Earthing Type
        <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList57" selectionmode="Multiple" Style="width: 100% !important">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-2" id="Div148" runat="server">
                                        <label for="Name">
                                            Value in(ohms)
        <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="TextBox64" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-2" id="Div149" runat="server">
                                        <label for="Name">
                                            Earthing Type
        <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList58" selectionmode="Multiple" Style="width: 100% !important">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-2" id="Div150" runat="server">
                                        <label for="Name">
                                            Value in(ohms)
        <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="TextBox65" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-2" id="Div151" runat="server">
                                        <label for="Name">
                                            Earthing Type
        <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList59" selectionmode="Multiple" Style="width: 100% !important">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-2" id="Div152" runat="server">
                                        <label for="Name">
                                            Value in(ohms)
        <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="TextBox66" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-2" id="Div153" runat="server">
                                        <label for="Name">
                                            Earthing Type
        <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList60" selectionmode="Multiple" Style="width: 100% !important">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-2" id="Div154" runat="server">
                                        <label for="Name">
                                            Value in(ohms)
        <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="TextBox67" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-2" id="Div155" runat="server">
                                        <label for="Name">
                                            Earthing Type
        <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList61" selectionmode="Multiple" Style="width: 100% !important">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-2" id="Div156" runat="server">
                                        <label for="Name">
                                            Value in(ohms)
        <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="TextBox68" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-2" id="Div157" runat="server">
                                        <label for="Name">
                                            Earthing Type
        <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList62" selectionmode="Multiple" Style="width: 100% !important">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-2" id="Div158" runat="server">
                                        <label for="Name">
                                            Value in(ohms)
        <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="TextBox69" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-2" id="Div159" runat="server">
                                        <label for="Name">
                                            Earthing Type
        <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList63" selectionmode="Multiple" Style="width: 100% !important">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-2" id="Div160" runat="server">
                                        <label for="Name">
                                            Value in(ohms)
        <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="TextBox70" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-2" id="Div161" runat="server">
                                        <label for="Name">
                                            Earthing Type
        <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList64" selectionmode="Multiple" Style="width: 100% !important">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-2" id="Div162" runat="server">
                                        <label for="Name">
                                            Value in(ohms)
        <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="TextBox71" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-2" id="Div163" runat="server">
                                        <label for="Name">
                                            Earthing Type
        <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList65" selectionmode="Multiple" Style="width: 100% !important">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-2" id="Div164" runat="server">
                                        <label for="Name">
                                            Value in(ohms)
        <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="TextBox72" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-4">
                                        <label>
                                            Type of HT (Primary Side/ Switch)<samp style="color: red"> * </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList66" selectionmode="Multiple" Style="width: 100% !important" OnSelectedIndexChanged="ddlLineVoltage_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="TypeOfHTBreaker">
                                <div class="row">
                                    <div class="col-4" id="Div165" runat="server">
                                        <label for="Voltage">
                                            Load breaking capacity of breaker (IN KA)  
        <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" AutoPostBack="true" ID="TextBox73" MaxLength="10" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-4">
                                        <label>
                                            Type of LT protection
        <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList67" selectionmode="Multiple" Style="width: 100% !important" OnSelectedIndexChanged="ddlLineVoltage_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-4" id="Div166" runat="server">
                                        <label for="Voltage">
                                            Capacity of individual fuse(IN AMPS)  
        <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" AutoPostBack="true" ID="TextBox74" MaxLength="10" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="TypeOfLTProtectionBREAKER">
                                <div class="row">
                                    <div class="col-4" id="Div167" runat="server">
                                        <label for="Voltage">
                                            Capacity of LT Breaker(IN AMPS)  
        <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" AutoPostBack="true" ID="TextBox75" MaxLength="10" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-4" id="Div168" runat="server">
                                        <label for="Voltage">
                                            Load Breaking Capacity of Breaker (IN AMPS)  
        <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" AutoPostBack="true" ID="TextBox76" MaxLength="10" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-4" id="Div169" runat="server">
                                        <label for="Voltage">
                                            Mean Sea Level of transformer plinth (IN METRES)  
        <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" AutoPostBack="true" ID="TextBox77" MaxLength="10" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                            <div class="row">
                                <div class="col-2" id="Div170" runat="server">
                                    <label for="Name">
                                        Generating Set Capacity
                                        <samp style="color: red">* </samp>
                                    </label>
                                    <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList68" selectionmode="Multiple" Style="width: 100% !important">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-2" id="Div171" runat="server">
                                    <label for="Name">
                                        Value
                                        <samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="TextBox78" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                </div>
                                <div class="col-4" id="Div172" runat="server">
                                    <label for="Name">
                                        Type of Generating Set
        <samp style="color: red">* </samp>
                                    </label>
                                    <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList69" selectionmode="Multiple" Style="width: 100% !important">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-4" id="Div173" runat="server">
                                    <label for="Name">
                                        Generator voltage level(IN VOLTS)
        <samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="TextBox79" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                </div>
                            </div>
                            <div class="InsulationResistance">
                                <div class="row">
                                    <div class="col-4" id="Div174" runat="server">
                                        <label for="Name">
                                            Red Phase – Earth Wire (in Mohm)
                                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="TextBox80" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-4" id="Div175" runat="server">
                                        <label for="Name">
                                            Yellow Phase – Earth Wire (in Mohm)
                                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="TextBox81" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-4" id="Div176" runat="server">
                                        <label for="Name">
                                            Blue Phase – Earth Wire (in Mohm)
                                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="TextBox82" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-4" id="Div177" runat="server">
                                        <label for="Name">
                                            Red Phase – Yellow Phase(in Mohm)
                                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="TextBox83" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-4" id="Div178" runat="server">
                                        <label for="Name">
                                            Red Phase – Blue Phase(in Mohm)
                                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="TextBox84" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-4" id="Div179" runat="server">
                                        <label for="Name">
                                            Blue Phase – Yellow Phase(in Mohm)
                                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="TextBox85" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-4" id="Div180" runat="server">
                                        <label for="Name">
                                            Current capacity of breaker( IN AMPS)
                                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="TextBox86" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-4" id="Div181" runat="server">
                                        <label for="Name">
                                            Breaking capacity of breaker (IN KA)
                                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="TextBox87" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="GeneratingSetIfSolar">
                                <div class="row">
                                    <div class="col-4" id="Div182" runat="server">
                                        <label for="Name">
                                            Type of plant
        <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList70" selectionmode="Multiple" Style="width: 100% !important">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-2" id="Div183" runat="server">
                                        <label for="Name">
                                            capacity of plant
        <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList71" selectionmode="Multiple" Style="width: 100% !important">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-2" id="Div184" runat="server">
                                        <label for="Name">
                                            DC string Highest Voltage        
                                        </label>
                                        <asp:TextBox class="form-control" ID="TextBox88" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-4" id="Div185" runat="server">
                                        <label for="Name">
                                            Lowest Insulation Resistance B/w DC phase wire to earth wire        
                                        </label>
                                        <asp:TextBox class="form-control" ID="TextBox89" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-4" id="Div186" runat="server">
                                        <label for="Name">
                                            No of PCV or Solar Inverter        
                                        </label>
                                        <asp:TextBox class="form-control" ID="TextBox90" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-4" id="Div187" runat="server">
                                        <label for="Name">
                                            capacity of main LTAC Breaker        
                                        </label>
                                        <asp:TextBox class="form-control" ID="TextBox91" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-4" id="Div188" runat="server">
                                        <label for="Name">
                                            Lowest Insulation resistance of AC cables       
                                        </label>
                                        <asp:TextBox class="form-control" ID="TextBox92" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-4" id="Div189" runat="server">
                                        <label for="Name">
                                            Number of Earthing:
                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList72" selectionmode="Multiple" Style="width: 100% !important">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-2" id="Div190" runat="server">
                                        <label for="Name">
                                            Earthing Type
                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList73" selectionmode="Multiple" Style="width: 100% !important">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-2" id="Div191" runat="server">
                                        <label for="Name">
                                            Value in(ohms)
                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="TextBox93" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-2" id="Div192" runat="server">
                                        <label for="Name">
                                            Earthing Type
                                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList74" selectionmode="Multiple" Style="width: 100% !important">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-2" id="Div193" runat="server">
                                        <label for="Name">
                                            Value in(ohms)
                                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="TextBox94" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-2" id="Div194" runat="server">
                                        <label for="Name">
                                            Earthing Type
                                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList75" selectionmode="Multiple" Style="width: 100% !important">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-2" id="Div195" runat="server">
                                        <label for="Name">
                                            Value in(ohms)
                                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="TextBox95" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-2" id="Div196" runat="server">
                                        <label for="Name">
                                            Earthing Type
                                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList76" selectionmode="Multiple" Style="width: 100% !important">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-2" id="Div197" runat="server">
                                        <label for="Name">
                                            Value in(ohms)
                                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="TextBox96" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-2" id="Div198" runat="server">
                                        <label for="Name">
                                            Earthing Type
                                    <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList77" selectionmode="Multiple" Style="width: 100% !important">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-2" id="Div199" runat="server">
                                        <label for="Name">
                                            Value in(ohms)
                                    <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="TextBox97" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-2" id="Div200" runat="server">
                                        <label for="Name">
                                            Earthing Type
                                    <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList78" selectionmode="Multiple" Style="width: 100% !important">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-2" id="Div201" runat="server">
                                        <label for="Name">
                                            Value in(ohms)
                                    <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="TextBox98" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-2" id="Div202" runat="server">
                                        <label for="Name">
                                            Earthing Type
                                    <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList79" selectionmode="Multiple" Style="width: 100% !important">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-2" id="Div203" runat="server">
                                        <label for="Name">
                                            Value in(ohms)
                                    <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="TextBox99" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-2" id="Div204" runat="server">
                                        <label for="Name">
                                            Earthing Type
                                    <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList80" selectionmode="Multiple" Style="width: 100% !important">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-2" id="Div205" runat="server">
                                        <label for="Name">
                                            Value in(ohms)
                                    <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="TextBox100" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-2" id="Div206" runat="server">
                                        <label for="Name">
                                            Earthing Type
                                    <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList81" selectionmode="Multiple" Style="width: 100% !important">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-2" id="Div207" runat="server">
                                        <label for="Name">
                                            Value in(ohms)
                                    <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="TextBox101" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-2" id="Div208" runat="server">
                                        <label for="Name">
                                            Earthing Type
                                    <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList82" selectionmode="Multiple" Style="width: 100% !important">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-2" id="Div209" runat="server">
                                        <label for="Name">
                                            Value in(ohms)
                                    <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="TextBox102" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-2" id="Div210" runat="server">
                                        <label for="Name">
                                            Earthing Type
                                    <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList83" selectionmode="Multiple" Style="width: 100% !important">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-2" id="Div211" runat="server">
                                        <label for="Name">
                                            Value in(ohms)
                                    <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="TextBox103" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-2" id="Div212" runat="server">
                                        <label for="Name">
                                            Earthing Type
                                    <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList84" selectionmode="Multiple" Style="width: 100% !important">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-2" id="Div213" runat="server">
                                        <label for="Name">
                                            Value in(ohms)
                                    <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="TextBox104" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-2" id="Div214" runat="server">
                                        <label for="Name">
                                            Earthing Type
                                    <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList85" selectionmode="Multiple" Style="width: 100% !important">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-2" id="Div215" runat="server">
                                        <label for="Name">
                                            Value in(ohms)
                                    <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="TextBox105" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-2" id="Div216" runat="server">
                                        <label for="Name">
                                            Earthing Type
                                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList86" selectionmode="Multiple" Style="width: 100% !important">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-2" id="Div217" runat="server">
                                        <label for="Name">
                                            Value in(ohms)
                                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="TextBox106" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-2" id="Div218" runat="server">
                                        <label for="Name">
                                            Earthing Type
                                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList87" selectionmode="Multiple" Style="width: 100% !important">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-2" id="Div219" runat="server">
                                        <label for="Name">
                                            Value in(ohms)
                                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="TextBox107" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                            <div class="row">
                                <div class="col-4" id="Div221" runat="server">
                                    <label for="Name">
                                        Voltage Level
                                        <samp style="color: red">* </samp>
                                    </label>
                                    <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList88" selectionmode="Multiple" Style="width: 100% !important">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-4" id="Div220" runat="server">
                                    <label for="Name">
                                        Main switch capacity/ Breaker
        <samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="TextBox108" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                </div>
                                <div class="col-4" id="Div222" runat="server">
                                    <label for="Name">
                                        Number of Earthing
        <samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="TextBox109" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                </div>
                                <div class="row">
                                    <div class="col-2" id="Div223" runat="server">
                                        <label for="Name">
                                            Earthing Type
                                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList89" selectionmode="Multiple" Style="width: 100% !important">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-2" id="Div224" runat="server">
                                        <label for="Name">
                                            Value in(ohms)
                                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="TextBox110" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-2" id="Div225" runat="server">
                                        <label for="Name">
                                            Earthing Type
                                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList90" selectionmode="Multiple" Style="width: 100% !important">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-2" id="Div226" runat="server">
                                        <label for="Name">
                                            Value in(ohms)
                                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="TextBox111" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-2" id="Div227" runat="server">
                                        <label for="Name">
                                            Earthing Type
                                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList91" selectionmode="Multiple" Style="width: 100% !important">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-2" id="Div228" runat="server">
                                        <label for="Name">
                                            Value in(ohms)
                                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="TextBox112" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-2" id="Div229" runat="server">
                                        <label for="Name">
                                            Earthing Type
                                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList92" selectionmode="Multiple" Style="width: 100% !important">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-2" id="Div230" runat="server">
                                        <label for="Name">
                                            Value in(ohms)
                                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="TextBox113" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-2" id="Div231" runat="server">
                                        <label for="Name">
                                            Earthing Type
                                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList93" selectionmode="Multiple" Style="width: 100% !important">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-2" id="Div232" runat="server">
                                        <label for="Name">
                                            Value in(ohms)
                                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="TextBox114" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-2" id="Div233" runat="server">
                                        <label for="Name">
                                            Earthing Type
                                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList94" selectionmode="Multiple" Style="width: 100% !important">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-2" id="Div234" runat="server">
                                        <label for="Name">
                                            Value in(ohms)
                                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="TextBox115" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-2" id="Div235" runat="server">
                                        <label for="Name">
                                            Earthing Type
                                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList95" selectionmode="Multiple" Style="width: 100% !important">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-2" id="Div236" runat="server">
                                        <label for="Name">
                                            Value in(ohms)
                                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="TextBox116" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-2" id="Div237" runat="server">
                                        <label for="Name">
                                            Earthing Type
                                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList96" selectionmode="Multiple" Style="width: 100% !important">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-2" id="Div238" runat="server">
                                        <label for="Name">
                                            Value in(ohms)
                                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="TextBox117" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-2" id="Div239" runat="server">
                                        <label for="Name">
                                            Earthing Type
                                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList97" selectionmode="Multiple" Style="width: 100% !important">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-2" id="Div240" runat="server">
                                        <label for="Name">
                                            Value in(ohms)
                                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="TextBox118" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-2" id="Div241" runat="server">
                                        <label for="Name">
                                            Earthing Type
                                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList98" selectionmode="Multiple" Style="width: 100% !important">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-2" id="Div242" runat="server">
                                        <label for="Name">
                                            Value in(ohms)
                                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="TextBox119" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-2" id="Div243" runat="server">
                                        <label for="Name">
                                            Earthing Type
                                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList99" selectionmode="Multiple" Style="width: 100% !important">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-2" id="Div244" runat="server">
                                        <label for="Name">
                                            Value in(ohms)
                                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="TextBox120" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-2" id="Div245" runat="server">
                                        <label for="Name">
                                            Earthing Type
                                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList100" selectionmode="Multiple" Style="width: 100% !important">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-2" id="Div246" runat="server">
                                        <label for="Name">
                                            Value in(ohms)
                                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="TextBox121" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-2" id="Div247" runat="server">
                                        <label for="Name">
                                            Earthing Type
                                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList101" selectionmode="Multiple" Style="width: 100% !important">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-2" id="Div248" runat="server">
                                        <label for="Name">
                                            Value in(ohms)
                                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="TextBox122" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-2" id="Div249" runat="server">
                                        <label for="Name">
                                            Earthing Type
                                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList102" selectionmode="Multiple" Style="width: 100% !important">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-2" id="Div250" runat="server">
                                        <label for="Name">
                                            Value in(ohms)
                                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="TextBox123" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-2" id="Div251" runat="server">
                                        <label for="Name">
                                            Earthing Type
                                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList103" selectionmode="Multiple" Style="width: 100% !important">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-2" id="Div252" runat="server">
                                        <label for="Name">
                                            Value in(ohms)
                                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="TextBox124" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                    <div class="col-4" id="Div253" runat="server">
                                        <label for="Name">
                                            Minimum IR value between wires
        <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="TextBox125" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-4"></div>
                            <div class="col-4" style="text-align: center;">
                                <asp:Button ID="btnSubmit2" Text="Generate Test Report" runat="server" ValidationGroup="Submit" class="btn btn-primary mr-2" />
                            </div>
                            <div class="col-4">
                                <asp:HiddenField ID="hdnId" runat="server" />
                            </div>
                        </div>
                    </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>