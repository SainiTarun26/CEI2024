<%@ Page Title="" Language="C#" MasterPageFile="~/Supervisor/Supervisor.Master" AutoEventWireup="true"  EnableEventValidation="false" CodeBehind="LineTestReport.aspx.cs" Inherits="CEIHaryana.Supervisor.LineTestReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="shortcut icon" type="image/png" href="/css2/style.min.css" />
    <link rel="stylesheet" href="/css2/style.css" />
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css" />
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css" />
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/css/select2.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/js/select2.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
    <script src="https://cdn.rawgit.com/harvesthq/chosen/gh-pages/chosen.jquery.min.js"></script>
    <link href="https://cdn.rawgit.com/harvesthq/chosen/gh-pages/chosen.min.css" rel="stylesheet" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/css/select2.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.2/css/solid.min.css" integrity="sha512-P9pgMgcSNlLb4Z2WAB2sH5KBKGnBfyJnq+bhcfLCFusrRc4XdXrhfDluBl/usq75NF5gTDIMcwI1GaG5gju+Mw==" crossorigin="anonymous" referrerpolicy="no-referrer" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/js/select2.min.js"></script>
    <script defer src="https://use.fontawesome.com/releases/v5.15.4/js/all.js" integrity="sha384-rOA1PnstxnOBLzCLMcre8ybwbTmemjzdNlILg8O7z1lUkLXozs4DHonlDtnE7fpc" crossorigin="anonymous"></script>
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
    <script type="text/javascript">
        function alertWithRedirectdata() {
            if (confirm('Intimation Created Successfully')) {
                window.location.href = "/Contractor/Work_Intimation.aspx";
            } else {
            }
        }
    </script>
    <style>
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

        .col-4 {
            margin-bottom: 15px;
        }

        .form-control {
            box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
            margin-left: 0px !important;
            height: 30px;
            font-size: 13px;
        }

        select.form-control {
            box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
            margin-left: 0px !important;
            height: 30px;
        }

        label {
            font-size: 14px;
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

        .headercolor {
            background-color: #9292cc;
        }

        th {
            background: #9292cc;
        }

        .card .card-title {
            font-size: 23px !important;
            color: #010101;
            text-transform: capitalize;
            font-weight: 700;
        }

        div#row2 {
            margin-top: -20px;
        }

        div#row3 {
            margin-top: -20px;
        }

        svg#svgcross {
            height: 35px;
            width: 67px;
        }

        svg#svgcross1 {
            height: 35px;
            width: 67px;
        }

        svg#svgcross2 {
            height: 35px;
            width: 67px;
        }

        td {
            padding-top: 12px !important;
            padding-bottom: 0px !important;
        }

        svg#search1:hover {
            height: 22px;
            width: 22px;
            fill: #4b49ac;
            transition: ease-out;
            margin-left: -2px;
            cursor: pointer;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="card" style="box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px; border-radius: 5px !important">
            <div class="card-body">
                <div class="row">
                    <div class="col-12" style="text-align: center;">
                        <h7 class="card-title fw-semibold mb-4" id="maincard">LINE TEST REPORT</h7>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4"></div>
                    <div class="col-sm-4" style="text-align: center;">
                        <label id="DataUpdated" runat="server" visible="false" style="color: red; font-size: 1.125rem">
                            Data Updated Successfully !!!.
                        </label>
                        <label id="DataSaved" runat="server" visible="false" style="color: red; font-size: 1.125rem">
                            Data Saved Successfully !!!.
                        </label>
                    </div>
                </div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="row" style="margin-top: 10px;">
                            <div class="col-12" style="text-align: left;">
                                <h7 class="card-title fw-semibold mb-4" style="font-size: 20px !important;">Intimation/Installation Details</h7>
                            </div>
                        </div>
                        <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; background:#d4d7ec; margin-bottom: 25px; border-radius: 10px; margin-top: 10px; padding-top: 10px; padding-bottom: 0px;">
                            <div class="row">
                                <div class="col-3" id="Div8" runat="server">
                                    <label for="Name">
                                        Application
            <samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtapplication" Enabled="false" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px;width:100%"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator34" runat="server" ControlToValidate="txtapplication" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Length of Line</asp:RequiredFieldValidator>

                                </div>
                                <div class="col-3" id="Div9" runat="server">
                                    <label for="Name">
                                        Intimation ID
            <samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtid" Enabled="false" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator75" runat="server" ControlToValidate="txtid" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Length of Line</asp:RequiredFieldValidator>

                                </div>
                                <div class="col-3" id="Div10" runat="server">
                                    <label for="Name">
                                        Type of Installation
            <samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtInstallation" Enabled="false" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator76" runat="server" ControlToValidate="txtInstallation" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Length of Line</asp:RequiredFieldValidator>

                                </div>
                                <div class="col-3" id="Div12" runat="server">
                                    <label for="Name">
                                        No of Installations
            <samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtNOOfInstallation" Enabled="false" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator77" runat="server" ControlToValidate="txtNOOfInstallation" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Length of Line</asp:RequiredFieldValidator>

                                </div>
                            </div>
                        </div>
                        <div class="row" style="margin-top: 10px;">
                            <div class="col-12" style="text-align: left;">
                                <h7 class="card-title fw-semibold mb-4" style="font-size: 20px !important;">Installation Details</h7>
                            </div>
                        </div>
                        <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                            <div>
                                <div class="row">
                                    <div class="col-3">
                                        <label>
                                            Voltage of Line<samp style="color: red"> * </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="1" runat="server" AutoPostBack="true" ID="ddlLineVoltage" selectionmode="Multiple" Style="width: 100% !important;" OnSelectedIndexChanged="ddlLineVoltage_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="Req_state" Text="Please Select Voltage of Line" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlLineVoltage" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                    </div>
                                    <div class="col-3" id="divOtherVoltages" runat="server" visible="false" style="top: 0px !important;">
                                        <label for="Voltage">
                                            Other Voltage 
                                                     <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlOtherVoltage" selectionmode="Multiple" Style="width: 100% !important;">
                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="V" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="KV" Value="2"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Text="Please Select Other Voltage" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlOtherVoltage" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />

                                    </div>
                                    <div class="col-3" id="OtherVoltage" runat="server" visible="false" style="top: 0px !important;">
                                        <label for="Voltage">
                                            Other Voltage 
                                                     <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" AutoPostBack="true" ID="TxtOthervoltage" MaxLength="3" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtOthervoltage" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Other Voltage</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-3" id="Div1" runat="server">
                                        <label for="Name">
                                            Length of Line (in KM)
                                                    <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtLineLength" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtLineLength" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Length of Line</asp:RequiredFieldValidator>

                                    </div>
                                    <div class="col-3">
                                        <label>
                                            Line Type
                                                  <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="3" runat="server" OnSelectedIndexChanged="ddlLineType_SelectedIndexChanged" AutoPostBack="true" ID="ddlLineType" selectionmode="Multiple" Style="width: 100% !important">
                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="Overhead" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Underground" Value="2"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Text="Please Select Line Type" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlLineType" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                    </div>
                                </div>
                            </div>

                            <div id="LineTypeOverhead" runat="server" visible="false">
                                <div class="row">
                                    <div class="col-3">
                                        <label>
                                            No of Circuit
                                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="4" runat="server" AutoPostBack="true" ID="ddlNmbrOfCircuit" selectionmode="Multiple" Style="width: 100% !important">
                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="Single" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Double" Value="2"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Text="Please Select No of Circuit" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlNmbrOfCircuit" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />

                                    </div>
                                    <div class="col-3">
                                        <label>
                                            Conductor Type
                                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="5" runat="server" AutoPostBack="true" ID="ddlConductorType" Style="width: 100% !important" OnSelectedIndexChanged="ddlConductorType_SelectedIndexChanged">
                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="Bare" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Cable" Value="2"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" Text="Please Select Conductor Type " ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlConductorType" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />

                                    </div>
                                </div>
                            </div>
                            <div id="OverheadBare" visible="false" runat="server">
                                <div class="row" style="margin-top: 20px;">
                                    <div class="col-3">
                                        <label>
                                            Number of Pole/Tower<samp style="color: red"> * </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtPoleTower" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="6" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtPoleTower" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Number of Pole/Tower</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-3" id="Div2" runat="server">
                                        <label for="Name">
                                            Size of Conductor( IN SQ.MM)
                                                        <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtConductorSize" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtConductorSize" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Size of Conductor</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-3" id="Div3" runat="server">
                                        <label for="Name">
                                            Size of Ground Wire( IN SQ.MM)	
                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtGroundWireSize" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtGroundWireSize" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Size of Ground Wire</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-3" id="Div4" runat="server">
                                        <label for="Name">
                                            Number of Railway Crossing
                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtRailwayCrossingNo" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="2" placeholder="" autocomplete="off" TabIndex="8" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtRailwayCrossingNo" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter No. of Railway Crossings</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-3" id="Div5" runat="server" style="margin-top: -25px;">
                                        <label for="Name">
                                            Number of Road Crossing
                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtRoadCrossingNo" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="2" placeholder="" autocomplete="off" TabIndex="9" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtRoadCrossingNo" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Size of Ground Wire</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-3" id="Div6" runat="server" style="margin-top: -25px;">
                                        <label for="Name">
                                            Number of River/Canal Crossing
                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtRiverCanalCrossing" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="2" placeholder="" autocomplete="off" TabIndex="10" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtRiverCanalCrossing" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Number of River/Canal Crossing
                                        </asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-3" id="Div7" runat="server" style="margin-top: -25px;">
                                        <label for="Name">
                                            Number of Power Line Crossing:	
                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtPowerLineCrossing" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="2" placeholder="" autocomplete="off" TabIndex="11" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtPowerLineCrossing" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Number of Power Line Crossing</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div id="OverheadCable" runat="server" visible="false">
                                <div
                                    class="row" style="margin-top: 20px !important;">
                                    <div class="col-3">
                                        <label>
                                            Number of Pole/Tower<samp style="color: red"> * </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtPoleTowerNo" MaxLength="3" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtPoleTowerNo" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter No. of Pole/Tower</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-3" id="Div11" runat="server">
                                        <label for="Name">
                                            Size of cable: (in MM sq.)
                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtCableSize1" MaxLength="3" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="7" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtCableSize1" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Size of Cable</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-3" id="Div19" runat="server">
                                        <label for="Name">
                                            Number of Railway Crossing
                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtRailwayCrossingNmbr" MaxLength="2" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="7" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtRailwayCrossingNmbr" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter No. of Railway Crossings</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-3" id="Div20" runat="server">
                                        <label for="Name">
                                            Number of Road Crossing
                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtRoadCrossingNmbr" MaxLength="2" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtRoadCrossingNmbr" ErrorMessage="txtRoadCrossingNmbr" ValidationGroup="Submit" ForeColor="Red">Please Enter NO. of Road Crossing</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-3" id="Div21" runat="server" style="margin-top: -25px;">
                                        <label for="Name">
                                            Number of River/Canal Crossing
                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtRiverCanalCrossingNmber" MaxLength="2" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtRiverCanalCrossingNmber" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter No. of River/Canal Crossing</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-3" id="Div22" runat="server" style="margin-top: -25px;">
                                        <label for="Name">
                                            Number of Power Line Crossing:	
                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtPowerLineCrossingNmbr" MaxLength="2" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtPowerLineCrossingNmbr" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter No. of Power Line Crossing</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div id="Insulation440vAbove" runat="server" visible="true">
                                <div class="row">
                                    <div class="col-3">
                                        <label>
                                            Red Phase – Earth Wire (in Mohm)<samp style="color: red"> * </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtRedEarthWire" MaxLength="4" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="14" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtRedEarthWire" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Red Phase – Earth Wire</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-3" id="Div32" runat="server">
                                        <label for="Name">
                                            Yellow Phase – Earth Wire (in Mohm)	
                                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtYellowEarthWire" MaxLength="4" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="15" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="txtYellowEarthWire" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Yellow Phase – Earth Wire</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-3" id="Div33" runat="server">
                                        <label for="Name">
                                            Blue Phase – Earth Wire (in Mohm)	
                                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtBlueEarthWire" MaxLength="4" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="16" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtBlueEarthWire" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Blue Phase – Earth Wire</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-3" id="Div34" runat="server">
                                        <label for="Name">
                                            Red Phase – Yellow Phase(in Mohm)
                                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtRedYellowPhase" MaxLength="4" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="17" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="txtRedYellowPhase" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Red Phase – Yellow Phase</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-3" id="Div35" runat="server">
                                        <label for="Name">
                                            Blue Phase – Yellow Phase(in Mohm)
                                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtBlueYellowPhase" MaxLength="4" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="18" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="txtBlueYellowPhase" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Blue Phase – Yellow Phase</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-3" id="Div36" runat="server">
                                        <label for="Name">
                                            Red Phase – Blue Phase(in Mohm)
                                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtRedBluePhase" MaxLength="4" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="19" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="txtRedBluePhase" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Red Phase – Blue Phase</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div id="Insulation220vAbove" runat="server" visible="false">
                                <div class="row" style="margin-top: 10px !important;">
                                    <div class="col-3">
                                        <label>
                                            Phase wire - Neutral wire (in Mohm)<samp style="color: red"> * </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtNeutralWire" MaxLength="4" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ControlToValidate="txtNeutralWire" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Red Phase – Earth Wire</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-3" id="Div37" runat="server">
                                        <label for="Name">
                                            Phase wire - Earth (in Mohm)
                                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtEarthWire" MaxLength="4" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" ControlToValidate="txtEarthWire" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Red Phase – Earth Wire</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-3" id="Div39" runat="server">
                                        <label for="Name">
                                            Neutral wire - Earth (in Mohm)
                                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtNeutralWireEarth" MaxLength="4" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="txtNeutralWireEarth" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Red Phase – Earth Wire</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div id="LineTypeUnderground" runat="server" visible="false">
                                <div class="row">
                                    <div class="col-3">
                                        <label>
                                            Type of Cable
                                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlCableType" selectionmode="Multiple" Style="width: 100% !important" OnSelectedIndexChanged="ddlCableType_SelectedIndexChanged1">
                                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="XPLE"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Other"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator33" Text="Please Select Type of Cable" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlCableType" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                    </div>
                                    <div class="col-3" id="OtherCable" runat="server" visible="false">
                                        <label>
                                            Type of Cable(Other)<samp style="color: red"> * </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtOtherCable" MaxLength="50" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ControlToValidate="txtOtherCable" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Type of Cable</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-3">
                                        <label>
                                            Size of Cable: In(MM Sq.)<samp style="color: red"> * </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtCableSize" MaxLength="3" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ControlToValidate="txtCableSize" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Name</asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-3">
                                        <label>
                                            Cable Laid in
                                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlCableLaid" selectionmode="Multiple" Style="width: 100% !important">
                                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="Trench"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="circuit"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="cable tray"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator30" Text="Please Select Cable Laid in" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlCableLaid" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                    </div>
                                </div>
                            </div>
                            <div id="UndergroundInsulation440vAbove" runat="server" visible="false">
                                <div class="row">
                                    <div class="col-3">
                                        <label>
                                            Red Phase – Earth Wire (in Mohm)<samp style="color: red"> * </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtRedWire" MaxLength="4" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator35" ControlToValidate="txtRedWire" runat="server" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Enter Red Wire"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-3" id="Div38" runat="server">
                                        <label for="Name">
                                            Yellow Phase – Earth Wire (in Mohm)	
                                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtYellowWire" MaxLength="4" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator36" ControlToValidate="txtYellowWire" ForeColor="Red" runat="server" ValidationGroup="Submit" ErrorMessage="Please Enter Yellow Wire"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-3" id="Div40" runat="server">
                                        <label for="Name">
                                            Blue Phase – Earth Wire (in Mohm)	
                                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtBlueWire" MaxLength="4" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator37" ControlToValidate="txtBlueWire" ForeColor="Red" runat="server" ValidationGroup="Submit" ErrorMessage="Please Ente Blue Wire"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-3" id="Div41" runat="server">
                                        <label for="Name">
                                            Red Phase – Yellow Phase(in Mohm)
                                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtRedYellowWire" MaxLength="4" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator38" ControlToValidate="txtRedYellowWire" ForeColor="Red" runat="server" ValidationGroup="Submit" ErrorMessage="Please Enter Red Yellow Wire"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-3" id="Div42" runat="server">
                                        <label for="Name">
                                            Blue Phase – Yellow Phase(in Mohm)
                                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtBlueYellowWire" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator39" ControlToValidate="txtBlueYellowWire" ForeColor="Red" runat="server" ErrorMessage="Please Enter Blue Yellow Wire"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-3" id="Div43" runat="server">
                                        <label for="Name">
                                            Red Phase – Blue Phase(in Mohm)
                                                        <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtRedBlueWire" MaxLength="4" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator40" ControlToValidate="txtRedBlueWire" ForeColor="Red" runat="server" ValidationGroup="Submit" ErrorMessage="Please Enter Red Blue Wire"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div id="UndergroundInsulation220vAbove" runat="server" visible="false">
                                <div class="row">
                                    <div class="col-3">
                                        <label>
                                            Phase wire - Neutral wire (in Mohm)<samp style="color: red"> * </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtNeutralPhaseWire" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator41" ControlToValidate="txtNeutralPhaseWire" ForeColor="Red" runat="server" ValidationGroup="Submit" ErrorMessage="Please Enter Neutral Phase wire"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-3" id="Div44" runat="server">
                                        <label for="Name">
                                            Phase wire - Earth (in Mohm)
                                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtPhaseWireEarth" MaxLength="4" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator42" ControlToValidate="txtPhaseWireEarth" ForeColor="Red" runat="server" ValidationGroup="Submit" ErrorMessage="Please Enter Phase Wire Earth"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-3" id="Div45" runat="server">
                                        <label for="Name">
                                            Neutral wire - Earth (in Mohm)
                                                        <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtNeutralWireEarthUnderground" MaxLength="4" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator43" ControlToValidate="txtNeutralWireEarthUnderground" ForeColor="Red" runat="server" ValidationGroup="Submit" ErrorMessage="Please Enter NeutralWireEarthUnderground"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="Earthing" runat="server" visible="false" class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                        <div class="row" style="margin-top: 10px;">
                            <div class="col-12" style="text-align: left;">
                                <h7 class="card-title fw-semibold mb-4" style="font-size: 20px !important;">Earthing Details</h7>
                            </div>
                        </div>
                        
                            <div>
                                <div class="row">
                                    <div class="col-3">
                                        <label>
                                            Number of Earthing:
                                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="12" runat="server" AutoPostBack="true" ID="ddlNoOfEarthing" selectionmode="Multiple" Style="width: 100% !important" OnSelectedIndexChanged="ddlNoOfEarthing_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator21" ControlToValidate="ddlNoOfEarthing" runat="server" ForeColor="Red" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Enter No of Earthing"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="table-responsive pt-3" id="LineEarthingdiv" runat="server" visible="false">
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
                                                <tr id="Earthingtype1" visible="false" runat="server" style="display: table-row;">
                                                    <td>1</td>
                                                    <td>
                                                        <div class="col-12">
                                                            <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlEarthingtype1" selectionmode="Multiple" Style="width: 100% !important">
                                                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator44" ControlToValidate="ddlEarthingtype1" runat="server" ForeColor="Red" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Earth Type"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div class="col-12">
                                                            <asp:TextBox class="form-control" ID="txtearthingValue1" MaxLength="2" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator73" ControlToValidate="txtearthingValue1" runat="server" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Enter Value"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr id="Earthingtype2" visible="false" runat="server">
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
                                                <tr id="Earthingtype3" runat="server" visible="false">
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
                       
                        <div class="row" style="margin-top: 50px;" id="Declaration" visible="false" runat="server">
                            <%--  <div class="col-2"></div>--%>
                            <div class="col-12" style="text-align: center;">
                                <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged" AutoPostBack="true" Text="&nbsp;I hereby declare that all information submitted as part of the form is true to my knowledge." Font-Size="Medium" Font-Bold="True" />
                                <br />
                                <label id="labelVerification" runat="server" visible="false" style="color: red; font-size: 1.125rem">
                                    Please Verify this.
                                </label>
                            </div>
                        </div>
                        <div class="row" id="OTP" runat="server" visible="false">
                            <div class="col-4"></div>
                            <div class="col-4">
                                <label>
                                    Enter the OTP you received to Your Phone Number <samp style="color: red">* </samp>
                                </label>
                                <asp:TextBox class="form-control" ID="txtOTP" MaxLength="6" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator74" ControlToValidate="txtOTP" runat="server" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Enter OTP"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-4">
                            </div>
                            <div class="col-4" style="text-align: center;">
                            <%--    <asp:Button ID="BtnBack" runat="server" Text="Back" Visible="true" class="btn btn-primary mr-2" OnClick="BtnBack_Click" />--%>
                                <asp:Button ID="BtnBack" runat="server" Text="Back" Visible="false" class="btn btn-primary mr-2" OnClick="BtnBack_Click" />
                                <asp:Button ID="btnVerify" Text="Verify Details" Visible="false" runat="server" class="btn btn-primary mr-2" ValidationGroup="Submit" OnClick="btnVerify_Click" />
                                <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" Text="Submit" runat="server" class="btn btn-primary mr-2" ValidationGroup="Submit" />
                            </div>
                            <div class="col-4">
                                <asp:HiddenField ID="hdn" Value="0" runat="server" />
                            </div>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnSubmit" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <footer class="footer">
    </footer>
    <script src="/Assets/js/js/vendor.bundle.base.js"></script>
    <script src="/Assets/js/chart.js/Chart.min.js"></script>
    <script src="/Assets/js/datatables.net/jquery.dataTables.js"></script>
    <script src="/Assets/js/datatables.net-bs4/dataTables.bootstrap4.js"></script>
    <script src="/Assets/js/dataTables.select.min.js"></script>
    <script src="/Assets/js/off-canvas.js"></script>
    <script src="/Assets/js/hoverable-collapse.js"></script>
    <script src="/Assets/js/template.js"></script>
    <script src="/Assets/js/settings.js"></script>
    <script src="/Assets/js/todolist.js"></script>
    <script src="/Assets/js/dashboard.js"></script>
    <script src="/Assets/js/Chart.roundedBarCharts.js"></script>
    <script type="text/javascript">
        function alertWithRedirect() {
            if (confirm('Test report has been submitted and is under review by the Contractor for final submission')) {
                window.location.href = "/Supervisor/IntimationData.aspx";
            } else {
            }
        }
    </script>
</asp:Content>

