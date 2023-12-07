<%@ Page Title="" Language="C#" MasterPageFile="~/TestReportsNew/TestReport.Master" AutoEventWireup="true" CodeBehind="LineTestReport.aspx.cs" Inherits="CEIHaryana.TestReportsNew.LineTestReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style type="text/css">
        .nav-link.active {
  color: blue;
}
        ul.nav.nav-pills {
    padding-bottom: 0px;
    margin-left:3% !important;
}
        div#ContentPlaceHolder1_divLine {
    margin-top: 0px !important;
    
}
        .nav-pills .nav-link.active, .nav-pills .show > .nav-link {
    color: #252525;
    background-color: #f9f9f9;
}
        a.nav-link.dropdown-toggle{
            border-radius:0px !important;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card" style="box-shadow: rgba(0, 0, 0, 0.2) 0px 20px 15px -3px, rgba(0, 0, 0, 0.05) 0px 4px 6px -2px;border-radius:0px !important;background:#f9f9f9;margin-left: 24px;margin-top:-1px;
   margin-right: 2%;">
        <div class="card-body" id="divLine" asp-validation-summary="ModelOnly" runat="server" style="margin-top: -30px;">
    <div id="IfInstallationIsLine" runat="server">
    <div class="card-body" style="padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px; margin-top: -20px;">
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
        
            <ContentTemplate>
                <div>
                    <div class="row">
                        <div class="col-4">
                            <label>
                                Voltage of Line<samp style="color: red"> * </samp>
                            </label>
                            <asp:DropDownList class="form-control  select-form select2" TabIndex="1" runat="server" AutoPostBack="true" ID="ddlLineVoltage" selectionmode="Multiple" Style="width: 100% !important;" OnSelectedIndexChanged="ddlLineVoltage_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="Req_state" Text="Please Select Voltage of Line" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlLineVoltage" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                        </div>
                        <div class="col-2" id="divOtherVoltages" runat="server" visible="false" style="top: 0px !important;">
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
                        <div class="col-2" id="OtherVoltage" runat="server" visible="false" style="top: 0px !important;">
                            <label for="Voltage">
                                Other Voltage 
                                     <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" AutoPostBack="true" ID="TxtOthervoltage" MaxLength="3" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtOthervoltage" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Other Voltage</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-4" id="Div1" runat="server">
                            <label for="Name">
                                Length of Line (in KM)
                                    <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtLineLength" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtLineLength" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Length of Line</asp:RequiredFieldValidator>

                        </div>
                        <div class="col-4">
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
                        <div class="col-4">
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
                        <div class="col-4">
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
                    <div class="row">
                        <div class="col-4">
                            <label>
                                Number of Pole/Tower<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtPoleTower" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="6" runat="server" Style="margin-left: 18px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtPoleTower" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Number of Pole/Tower</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-4" id="Div2" runat="server">
                            <label for="Name">
                                Size of Conductor( IN SQ.MM)
                                        <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtConductorSize" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtConductorSize" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Size of Conductor</asp:RequiredFieldValidator>
                            </div>
                        <div class="col-4" id="Div3" runat="server">
                            <label for="Name">
                                Size of Ground Wire( IN SQ.MM)	
            <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtGroundWireSize" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtGroundWireSize" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Size of Ground Wire</asp:RequiredFieldValidator>
                            </div>
                        <div class="col-4" id="Div4" runat="server">
                            <label for="Name">
                                Number of Railway Crossing
            <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtRailwayCrossingNo" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="2" placeholder="" autocomplete="off" TabIndex="8" runat="server" Style="margin-left: 18px"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtRailwayCrossingNo" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter No. of Railway Crossings</asp:RequiredFieldValidator>
                            </div>
                        <div class="col-4" id="Div5" runat="server">
                            <label for="Name">
                                Number of Road Crossing
            <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtRoadCrossingNo" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="2" placeholder="" autocomplete="off" TabIndex="9" runat="server" Style="margin-left: 18px"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtRoadCrossingNo" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Size of Ground Wire</asp:RequiredFieldValidator>
                            </div>
                        <div class="col-4" id="Div6" runat="server">
                            <label for="Name">
                                Number of River/Canal Crossing
            <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtRiverCanalCrossing" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="2" placeholder="" autocomplete="off" TabIndex="10" runat="server" Style="margin-left: 18px"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtRiverCanalCrossing" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Number of River/Canal Crossing</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-4" id="Div7" runat="server">
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
                        class="row">
                        <div class="col-4">
                            <label>
                                Number of Pole/Tower<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtPoleTowerNo" MaxLength="3" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtPoleTowerNo" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter No. of Pole/Tower</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-4" id="Div11" runat="server">
                            <label for="Name">
                                Size of cable: (in MM sq.)
            <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtCableSize1" MaxLength="3" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="7" runat="server" Style="margin-left: 18px"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtCableSize1" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Size of Cable</asp:RequiredFieldValidator>
                            </div>
                        <div class="col-4" id="Div19" runat="server">
                            <label for="Name">
                                Number of Railway Crossing
            <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtRailwayCrossingNmbr" MaxLength="2" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="7" runat="server" Style="margin-left: 18px"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtRailwayCrossingNmbr" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter No. of Railway Crossings</asp:RequiredFieldValidator>
                            </div>
                        <div class="col-4" id="Div20" runat="server">
                            <label for="Name">
                                Number of Road Crossing
            <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtRoadCrossingNmbr" MaxLength="2" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtRoadCrossingNmbr" ErrorMessage="txtRoadCrossingNmbr" ValidationGroup="Submit" ForeColor="Red">Please Enter NO. of Road Crossing</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-4" id="Div21" runat="server">
                            <label for="Name">
                                Number of River/Canal Crossing
            <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtRiverCanalCrossingNmber" MaxLength="2" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtRiverCanalCrossingNmber" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter No. of River/Canal Crossing</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-4" id="Div22" runat="server">
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
                        <div class="col-4">
                            <label>
                                Red Phase – Earth Wire (in Mohm)<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtRedEarthWire" MaxLength="4" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="14" runat="server" Style="margin-left: 18px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtRedEarthWire" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Red Phase – Earth Wire</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-4" id="Div32" runat="server">
                            <label for="Name">
                                Yellow Phase – Earth Wire (in Mohm)	
                            <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtYellowEarthWire" MaxLength="4" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="15" runat="server" Style="margin-left: 18px"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="txtYellowEarthWire" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Yellow Phase – Earth Wire</asp:RequiredFieldValidator>
                            </div>
                        <div class="col-4" id="Div33" runat="server">
                            <label for="Name">
                                Blue Phase – Earth Wire (in Mohm)	
                            <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtBlueEarthWire" MaxLength="4" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="16" runat="server" Style="margin-left: 18px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtBlueEarthWire" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Blue Phase – Earth Wire</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-4" id="Div34" runat="server">
                            <label for="Name">
                                Red Phase – Yellow Phase(in Mohm)
                            <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtRedYellowPhase" MaxLength="4" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="17" runat="server" Style="margin-left: 18px"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="txtRedYellowPhase" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Red Phase – Yellow Phase</asp:RequiredFieldValidator>
                            </div>
                        <div class="col-4" id="Div35" runat="server">
                            <label for="Name">
                                Blue Phase – Yellow Phase(in Mohm)
                            <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtBlueYellowPhase" MaxLength="4" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="18" runat="server" Style="margin-left: 18px"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="txtBlueYellowPhase" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Blue Phase – Yellow Phase</asp:RequiredFieldValidator>
                            </div>
                        <div class="col-4" id="Div36" runat="server">
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
                    <div class="row">
                        <div class="col-4">
                            <label>
                                Phase wire - Neutral wire (in Mohm)<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtNeutralWire" MaxLength="4" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ControlToValidate="txtNeutralWire" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Red Phase – Earth Wire</asp:RequiredFieldValidator>
                            </div>
                        <div class="col-4" id="Div37" runat="server">
                            <label for="Name">
                                Phase wire - Earth (in Mohm)
                            <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtEarthWire" MaxLength="4" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" ControlToValidate="txtEarthWire" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Red Phase – Earth Wire</asp:RequiredFieldValidator>
                            </div>
                        <div class="col-4" id="Div39" runat="server">
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
                        <div class="col-4">
                            <label>
                                Type of Cable
                            <samp style="color: red">* </samp>
                            </label>
                            <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlCableType" selectionmode="Multiple" Style="width: 100% !important" OnSelectedIndexChanged="ddlCableType_SelectedIndexChanged1">
                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                <asp:ListItem Value="1" Text="XPLE"></asp:ListItem>
                                <asp:ListItem Value="2" Text="Other"></asp:ListItem>
                            </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator33" Text="Please Select Type of Cable" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlCableType" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                        </div>
                        <div class="col-4" id="OtherCable" runat="server" visible="false">
                            <label>
                                Type of Cable(Other)<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtOtherCable" MaxLength="50" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ControlToValidate="txtOtherCable" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Type of Cable</asp:RequiredFieldValidator>
                            </div>
                        <div class="col-4">
                            <label>
                                Size of Cable: In(MM Sq.)<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtCableSize" MaxLength="3" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ControlToValidate="txtCableSize" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Name</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-4">
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
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator30" Text="Please Select Cable Laid in" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlCableLaid" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                        </div>
                    </div>
                </div>
                <div id="UndergroundInsulation440vAbove" runat="server" visible="false">
                    <div class="row">
                        <div class="col-4">
                            <label>
                                Red Phase – Earth Wire (in Mohm)<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtRedWire" MaxLength="4" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator35" ControlToValidate="txtRedWire" runat="server" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Enter Red Wire"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-4" id="Div38" runat="server">
                            <label for="Name">
                                Yellow Phase – Earth Wire (in Mohm)	
                            <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtYellowWire" MaxLength="4" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator36" ControlToValidate="txtYellowWire" ForeColor="Red" runat="server" ValidationGroup="Submit" ErrorMessage="Please Enter Yellow Wire"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-4" id="Div40" runat="server">
                            <label for="Name">
                                Blue Phase – Earth Wire (in Mohm)	
                            <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtBlueWire" MaxLength="4" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator37" ControlToValidate="txtBlueWire" ForeColor="Red" runat="server" ValidationGroup="Submit" ErrorMessage="Please Ente Blue Wire"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-4" id="Div41" runat="server">
                            <label for="Name">
                                Red Phase – Yellow Phase(in Mohm)
                            <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtRedYellowWire" MaxLength="4" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator38" ControlToValidate="txtRedYellowWire" ForeColor="Red" runat="server" ValidationGroup="Submit" ErrorMessage="Please Enter Red Yellow Wire"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-4" id="Div42" runat="server">
                            <label for="Name">
                                Blue Phase – Yellow Phase(in Mohm)
                            <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtBlueYellowWire" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator39" ControlToValidate="txtBlueYellowWire" ForeColor="Red" runat="server" ErrorMessage="Please Enter Blue Yellow Wire"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-4" id="Div43" runat="server">
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
                        <div class="col-4">
                            <label>
                                Phase wire - Neutral wire (in Mohm)<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtNeutralPhaseWire" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator41" ControlToValidate="txtNeutralPhaseWire" ForeColor="Red" runat="server" ValidationGroup="Submit" ErrorMessage="Please Enter Neutral Phase wire"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-4" id="Div44" runat="server">
                            <label for="Name">
                                Phase wire - Earth (in Mohm)
                            <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtPhaseWireEarth" MaxLength="4" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator42" ControlToValidate="txtPhaseWireEarth" ForeColor="Red" runat="server" ValidationGroup="Submit" ErrorMessage="Please Enter Phase Wire Earth"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-4" id="Div45" runat="server">
                            <label for="Name">
                                Neutral wire - Earth (in Mohm)
                                        <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="txtNeutralWireEarthUnderground" MaxLength="4" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator43" ControlToValidate="txtNeutralWireEarthUnderground" ForeColor="Red" runat="server" ValidationGroup="Submit" ErrorMessage="Please Enter NeutralWireEarthUnderground"></asp:RequiredFieldValidator>
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
                 <div class="row"  id="OTP" runat="server" visible="false">
                     <div class="col-4"></div>
                      <div class="col-4">
                          <label>
                              Enter the OTP you received to Your Phone Number
                                        <samp style="color: red">* </samp>
                            </label>
                        <asp:TextBox class="form-control" ID="txtOTP" MaxLength="6" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator74" ControlToValidate="txtOTP" runat="server" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Enter OTP"></asp:RequiredFieldValidator>
                                           
                    </div>
                 </div>
                <div class="row">
                    <div class="col-4" >
                    </div>
                    <div class="col-4" style="text-align: center;">
                        <asp:Button ID="BtnBack" runat="server" Text="Back" Visible="false" class="btn btn-primary mr-2" OnClick="BtnBack_Click"/>
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
        
    </div>
</div><div id="Div8" runat="server">
    <div class="card-body" style="padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px; margin-top: -46px;">
        <div class="row">
            <div class="col-md-4"></div>
            <div class="col-sm-4" style="text-align: center;">
                <label id="Label1" runat="server" visible="false" style="color: red; font-size: 1.125rem">
                    Data Updated Successfully !!!.
                </label>
                <label id="Label2" runat="server" visible="false" style="color: red; font-size: 1.125rem">
                    Data Saved Successfully !!!.
                </label>
            </div>
        </div>
      <%--  <asp:UpdatePanel ID="UpdatePanel2" runat="server">--%>
            <ContentTemplate>
                <div>
                    <div class="row">
                        <div class="col-4">
                            <label>
                                Voltage of Line<samp style="color: red"> * </samp>
                            </label>
                            <asp:DropDownList class="form-control  select-form select2" TabIndex="1" runat="server" AutoPostBack="true" ID="DropDownList1" selectionmode="Multiple" Style="width: 100% !important;" OnSelectedIndexChanged="ddlLineVoltage_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator34" Text="Please Select Voltage of Line" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlLineVoltage" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                        </div>
                        <div class="col-2" id="div9" runat="server" visible="false" style="top: 0px !important;">
                            <label for="Voltage">
                                Other Voltage 
                                     <samp style="color: red">* </samp>
                            </label>
                            <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList2" selectionmode="Multiple" Style="width: 100% !important;">
                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                <asp:ListItem Text="V" Value="1"></asp:ListItem>
                                <asp:ListItem Text="KV" Value="2"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator75" Text="Please Select Other Voltage" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlOtherVoltage" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />

                        </div>
                        <div class="col-2" id="Div10" runat="server" visible="false" style="top: 0px !important;">
                            <label for="Voltage">
                                Other Voltage 
                                     <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" AutoPostBack="true" ID="TextBox1" MaxLength="3" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator76" runat="server" ControlToValidate="TxtOthervoltage" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Other Voltage</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-4" id="Div12" runat="server">
                            <label for="Name">
                                Length of Line (in KM)
                                    <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="TextBox2" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator77" runat="server" ControlToValidate="txtLineLength" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Length of Line</asp:RequiredFieldValidator>

                        </div>
                        <div class="col-4">
                            <label>
                                Line Type
                                  <samp style="color: red">* </samp>
                            </label>
                            <asp:DropDownList class="form-control  select-form select2" TabIndex="3" runat="server" OnSelectedIndexChanged="ddlLineType_SelectedIndexChanged" AutoPostBack="true" ID="DropDownList3" selectionmode="Multiple" Style="width: 100% !important">
                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Overhead" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Underground" Value="2"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator78" Text="Please Select Line Type" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlLineType" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                        </div>
                    </div>
                </div>
                <div id="Div13" runat="server" visible="false">
                    <div class="row">
                        <div class="col-4">
                            <label>
                                No of Circuit
                            <samp style="color: red">* </samp>
                            </label>
                            <asp:DropDownList class="form-control  select-form select2" TabIndex="4" runat="server" AutoPostBack="true" ID="DropDownList4" selectionmode="Multiple" Style="width: 100% !important">
                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Single" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Double" Value="2"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator79" Text="Please Select No of Circuit" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlNmbrOfCircuit" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />

                        </div>
                        <div class="col-4">
                            <label>
                                Conductor Type
                            <samp style="color: red">* </samp>
                            </label>
                            <asp:DropDownList class="form-control  select-form select2" TabIndex="5" runat="server" AutoPostBack="true" ID="DropDownList5" Style="width: 100% !important" OnSelectedIndexChanged="ddlConductorType_SelectedIndexChanged">
                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Bare" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Cable" Value="2"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator80" Text="Please Select Conductor Type " ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlConductorType" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />

                        </div>
                    </div>
                </div>
                <div id="Div14" visible="false" runat="server">
                    <div class="row">
                        <div class="col-4">
                            <label>
                                Number of Pole/Tower<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="TextBox3" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="6" runat="server" Style="margin-left: 18px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator81" runat="server" ControlToValidate="txtPoleTower" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Number of Pole/Tower</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-4" id="Div16" runat="server">
                            <label for="Name">
                                Size of Conductor( IN SQ.MM)
                                        <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="TextBox4" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator82" runat="server" ControlToValidate="txtConductorSize" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Size of Conductor</asp:RequiredFieldValidator>
                            </div>
                        <div class="col-4" id="Div17" runat="server">
                            <label for="Name">
                                Size of Ground Wire( IN SQ.MM)	
            <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="TextBox5" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator83" runat="server" ControlToValidate="txtGroundWireSize" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Size of Ground Wire</asp:RequiredFieldValidator>
                            </div>
                        <div class="col-4" id="Div18" runat="server">
                            <label for="Name">
                                Number of Railway Crossing
            <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="TextBox6" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="2" placeholder="" autocomplete="off" TabIndex="8" runat="server" Style="margin-left: 18px"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator84" runat="server" ControlToValidate="txtRailwayCrossingNo" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter No. of Railway Crossings</asp:RequiredFieldValidator>
                            </div>
                        <div class="col-4" id="Div23" runat="server">
                            <label for="Name">
                                Number of Road Crossing
            <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="TextBox7" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="2" placeholder="" autocomplete="off" TabIndex="9" runat="server" Style="margin-left: 18px"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator85" runat="server" ControlToValidate="txtRoadCrossingNo" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Size of Ground Wire</asp:RequiredFieldValidator>
                            </div>
                        <div class="col-4" id="Div24" runat="server">
                            <label for="Name">
                                Number of River/Canal Crossing
            <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="TextBox8" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="2" placeholder="" autocomplete="off" TabIndex="10" runat="server" Style="margin-left: 18px"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator86" runat="server" ControlToValidate="txtRiverCanalCrossing" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Number of River/Canal Crossing</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-4" id="Div25" runat="server">
                            <label for="Name">
                                Number of Power Line Crossing:	
            <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="TextBox9" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="2" placeholder="" autocomplete="off" TabIndex="11" runat="server" Style="margin-left: 18px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator87" runat="server" ControlToValidate="txtPowerLineCrossing" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Number of Power Line Crossing</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div id="Div26" runat="server" visible="false">
                    <div
                        class="row">
                        <div class="col-4">
                            <label>
                                Number of Pole/Tower<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="TextBox10" MaxLength="3" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator88" runat="server" ControlToValidate="txtPoleTowerNo" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter No. of Pole/Tower</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-4" id="Div27" runat="server">
                            <label for="Name">
                                Size of cable: (in MM sq.)
            <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="TextBox11" MaxLength="3" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="7" runat="server" Style="margin-left: 18px"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator89" runat="server" ControlToValidate="txtCableSize1" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Size of Cable</asp:RequiredFieldValidator>
                            </div>
                        <div class="col-4" id="Div28" runat="server">
                            <label for="Name">
                                Number of Railway Crossing
            <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="TextBox12" MaxLength="2" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="7" runat="server" Style="margin-left: 18px"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator90" runat="server" ControlToValidate="txtRailwayCrossingNmbr" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter No. of Railway Crossings</asp:RequiredFieldValidator>
                            </div>
                        <div class="col-4" id="Div29" runat="server">
                            <label for="Name">
                                Number of Road Crossing
            <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="TextBox13" MaxLength="2" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator91" runat="server" ControlToValidate="txtRoadCrossingNmbr" ErrorMessage="txtRoadCrossingNmbr" ValidationGroup="Submit" ForeColor="Red">Please Enter NO. of Road Crossing</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-4" id="Div30" runat="server">
                            <label for="Name">
                                Number of River/Canal Crossing
            <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="TextBox14" MaxLength="2" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator92" runat="server" ControlToValidate="txtRiverCanalCrossingNmber" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter No. of River/Canal Crossing</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-4" id="Div31" runat="server">
                            <label for="Name">
                                Number of Power Line Crossing:	
            <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="TextBox15" MaxLength="2" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator93" runat="server" ControlToValidate="txtPowerLineCrossingNmbr" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter No. of Power Line Crossing</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>

                <div id="Div46" runat="server" visible="true">
                    <div class="row">
                        <div class="col-4">
                            <label>
                                Red Phase – Earth Wire (in Mohm)<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="TextBox16" MaxLength="4" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="14" runat="server" Style="margin-left: 18px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator94" runat="server" ControlToValidate="txtRedEarthWire" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Red Phase – Earth Wire</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-4" id="Div47" runat="server">
                            <label for="Name">
                                Yellow Phase – Earth Wire (in Mohm)	
                            <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="TextBox17" MaxLength="4" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="15" runat="server" Style="margin-left: 18px"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator95" runat="server" ControlToValidate="txtYellowEarthWire" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Yellow Phase – Earth Wire</asp:RequiredFieldValidator>
                            </div>
                        <div class="col-4" id="Div48" runat="server">
                            <label for="Name">
                                Blue Phase – Earth Wire (in Mohm)	
                            <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="TextBox18" MaxLength="4" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="16" runat="server" Style="margin-left: 18px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator96" runat="server" ControlToValidate="txtBlueEarthWire" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Blue Phase – Earth Wire</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-4" id="Div49" runat="server">
                            <label for="Name">
                                Red Phase – Yellow Phase(in Mohm)
                            <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="TextBox19" MaxLength="4" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="17" runat="server" Style="margin-left: 18px"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator97" runat="server" ControlToValidate="txtRedYellowPhase" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Red Phase – Yellow Phase</asp:RequiredFieldValidator>
                            </div>
                        <div class="col-4" id="Div50" runat="server">
                            <label for="Name">
                                Blue Phase – Yellow Phase(in Mohm)
                            <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="TextBox20" MaxLength="4" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="18" runat="server" Style="margin-left: 18px"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator98" runat="server" ControlToValidate="txtBlueYellowPhase" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Blue Phase – Yellow Phase</asp:RequiredFieldValidator>
                            </div>
                        <div class="col-4" id="Div51" runat="server">
                            <label for="Name">
                                Red Phase – Blue Phase(in Mohm)
                            <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="TextBox21" MaxLength="4" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="19" runat="server" Style="margin-left: 18px"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator99" runat="server" ControlToValidate="txtRedBluePhase" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Red Phase – Blue Phase</asp:RequiredFieldValidator>
                            </div>
                    </div>
                </div>
                <div id="Div52" runat="server" visible="false">
                    <div class="row">
                        <div class="col-4">
                            <label>
                                Phase wire - Neutral wire (in Mohm)<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="TextBox22" MaxLength="4" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator100" runat="server" ControlToValidate="txtNeutralWire" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Red Phase – Earth Wire</asp:RequiredFieldValidator>
                            </div>
                        <div class="col-4" id="Div53" runat="server">
                            <label for="Name">
                                Phase wire - Earth (in Mohm)
                            <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="TextBox23" MaxLength="4" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator101" runat="server" ControlToValidate="txtEarthWire" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Red Phase – Earth Wire</asp:RequiredFieldValidator>
                            </div>
                        <div class="col-4" id="Div54" runat="server">
                            <label for="Name">
                                Neutral wire - Earth (in Mohm)
                            <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="TextBox24" MaxLength="4" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator102" runat="server" ControlToValidate="txtNeutralWireEarth" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Red Phase – Earth Wire</asp:RequiredFieldValidator>
                            </div>
                    </div>
                </div>
                <div id="Div55" runat="server" visible="false">
                    <div class="row">
                        <div class="col-4">
                            <label>
                                Type of Cable
                            <samp style="color: red">* </samp>
                            </label>
                            <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList6" selectionmode="Multiple" Style="width: 100% !important" OnSelectedIndexChanged="ddlCableType_SelectedIndexChanged1">
                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                <asp:ListItem Value="1" Text="XPLE"></asp:ListItem>
                                <asp:ListItem Value="2" Text="Other"></asp:ListItem>
                            </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator103" Text="Please Select Type of Cable" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlCableType" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                        </div>
                        <div class="col-4" id="Div56" runat="server" visible="false">
                            <label>
                                Type of Cable(Other)<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="TextBox25" MaxLength="50" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator104" runat="server" ControlToValidate="txtOtherCable" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Type of Cable</asp:RequiredFieldValidator>
                            </div>
                        <div class="col-4">
                            <label>
                                Size of Cable: In(MM Sq.)<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="TextBox26" MaxLength="3" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator105" runat="server" ControlToValidate="txtCableSize" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Name</asp:RequiredFieldValidator>
                        </div>
                        <div class="col-4">
                            <label>
                                Cable Laid in
                            <samp style="color: red">* </samp>
                            </label>
                            <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList7" selectionmode="Multiple" Style="width: 100% !important">
                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                <asp:ListItem Value="1" Text="Trench"></asp:ListItem>
                                <asp:ListItem Value="2" Text="circuit"></asp:ListItem>
                                <asp:ListItem Value="3" Text="cable tray"></asp:ListItem>
                            </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator106" Text="Please Select Cable Laid in" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlCableLaid" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                        </div>
                    </div>
                </div>
                <div id="Div57" runat="server" visible="false">
                    <div class="row">
                        <div class="col-4">
                            <label>
                                Red Phase – Earth Wire (in Mohm)<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="TextBox27" MaxLength="4" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator107" ControlToValidate="txtRedWire" runat="server" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Enter Red Wire"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-4" id="Div58" runat="server">
                            <label for="Name">
                                Yellow Phase – Earth Wire (in Mohm)	
                            <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="TextBox28" MaxLength="4" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator108" ControlToValidate="txtYellowWire" ForeColor="Red" runat="server" ValidationGroup="Submit" ErrorMessage="Please Enter Yellow Wire"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-4" id="Div59" runat="server">
                            <label for="Name">
                                Blue Phase – Earth Wire (in Mohm)	
                            <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="TextBox29" MaxLength="4" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator109" ControlToValidate="txtBlueWire" ForeColor="Red" runat="server" ValidationGroup="Submit" ErrorMessage="Please Ente Blue Wire"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-4" id="Div60" runat="server">
                            <label for="Name">
                                Red Phase – Yellow Phase(in Mohm)
                            <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="TextBox30" MaxLength="4" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator110" ControlToValidate="txtRedYellowWire" ForeColor="Red" runat="server" ValidationGroup="Submit" ErrorMessage="Please Enter Red Yellow Wire"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-4" id="Div61" runat="server">
                            <label for="Name">
                                Blue Phase – Yellow Phase(in Mohm)
                            <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="TextBox31" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator111" ControlToValidate="txtBlueYellowWire" ForeColor="Red" runat="server" ErrorMessage="Please Enter Blue Yellow Wire"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-4" id="Div62" runat="server">
                            <label for="Name">
                                Red Phase – Blue Phase(in Mohm)
                                        <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="TextBox32" MaxLength="4" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator112" ControlToValidate="txtRedBlueWire" ForeColor="Red" runat="server" ValidationGroup="Submit" ErrorMessage="Please Enter Red Blue Wire"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div id="Div63" runat="server" visible="false">
                    <div class="row">
                        <div class="col-4">
                            <label>
                                Phase wire - Neutral wire (in Mohm)<samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="TextBox33" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator113" ControlToValidate="txtNeutralPhaseWire" ForeColor="Red" runat="server" ValidationGroup="Submit" ErrorMessage="Please Enter Neutral Phase wire"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-4" id="Div64" runat="server">
                            <label for="Name">
                                Phase wire - Earth (in Mohm)
                            <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="TextBox34" MaxLength="4" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator114" ControlToValidate="txtPhaseWireEarth" ForeColor="Red" runat="server" ValidationGroup="Submit" ErrorMessage="Please Enter Phase Wire Earth"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-4" id="Div65" runat="server">
                            <label for="Name">
                                Neutral wire - Earth (in Mohm)
                                        <samp style="color: red">* </samp>
                            </label>
                            <asp:TextBox class="form-control" ID="TextBox35" MaxLength="4" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator115" ControlToValidate="txtNeutralWireEarthUnderground" ForeColor="Red" runat="server" ValidationGroup="Submit" ErrorMessage="Please Enter NeutralWireEarthUnderground"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div id="Div66" runat="server" visible="false">
                    <div class="row">
                        <div class="col-4">
                            <label>
                                Number of Earthing:
                            <samp style="color: red">* </samp>
                            </label>
                            <asp:DropDownList class="form-control  select-form select2" TabIndex="12" runat="server" AutoPostBack="true" ID="DropDownList8" selectionmode="Multiple" Style="width: 100% !important" OnSelectedIndexChanged="ddlNoOfEarthing_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator116" ControlToValidate="ddlNoOfEarthing" runat="server" ForeColor="Red" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Enter No of Earthing"></asp:RequiredFieldValidator>
                        </div>
                        <div class="table-responsive pt-3" id="Div67" runat="server" visible="false">
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
                                    <tr id="Tr1" visible="false" runat="server" style="display: table-row;">
                                        <td>1</td>
                                        <td>
                                            <div class="col-12">
                                                <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList9" selectionmode="Multiple" Style="width: 100% !important">
                                                    <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                                    <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator117" ControlToValidate="ddlEarthingtype1" runat="server" ForeColor="Red" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Earth Type"></asp:RequiredFieldValidator>
                                            </div>
                                        </td>
                                        <td>
                                            <div class="col-12">
                                                <asp:TextBox class="form-control" ID="TextBox36" MaxLength="2" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator118" ControlToValidate="txtearthingValue1" runat="server" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Enter Value"></asp:RequiredFieldValidator>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr id="Tr2" visible="false" runat="server">
                                        <td>2</td>
                                        <td>
                                            <div class="col-12">
                                                <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList10" selectionmode="Multiple" Style="width: 100% !important">
                                                    <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                                    <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator119" ControlToValidate="ddlEarthingtype2" runat="server" ForeColor="Red" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Earth Type"></asp:RequiredFieldValidator>
                                            </div>
                                        </td>
                                        <td>
                                            <div class="col-12">
                                                <asp:TextBox class="form-control" ID="TextBox37" MaxLength="2" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator120" ControlToValidate="txtEarthingValue2" runat="server" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Enter Value"></asp:RequiredFieldValidator>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr id="Tr3" runat="server" visible="false">
                                        <td>3</td>
                                        <td>
                                            <div class="col-12">
                                                <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList11" selectionmode="Multiple" Style="width: 100% !important">
                                                    <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                                    <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator121" ControlToValidate="ddlEarthingtype3" runat="server" ForeColor="Red" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Earth Type"></asp:RequiredFieldValidator>
                                            </div>
                                        </td>
                                        <td>
                                            <div class="col-12">
                                                <asp:TextBox class="form-control" ID="TextBox38" MaxLength="2" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator122" ControlToValidate="txtEarthingValue3" runat="server" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Enter Value"></asp:RequiredFieldValidator>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr id="Tr4" runat="server" visible="false">
                                        <td>4</td>
                                        <td>
                                            <div class="col-12">
                                                <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList12" selectionmode="Multiple" Style="width: 100% !important">
                                                    <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                                    <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator123" ControlToValidate="ddlEarthingtype4" runat="server" ForeColor="Red" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Earth Type"></asp:RequiredFieldValidator>
                                            </div>
                                        </td>
                                        <td>
                                            <div class="col-12" id="Div68" runat="server">
                                                <asp:TextBox class="form-control" ID="TextBox39" MaxLength="2" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator124" ControlToValidate="txtEarthingValue4" runat="server" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Enter Value"></asp:RequiredFieldValidator>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr id="Tr5" runat="server" visible="false">
                                        <td>5</td>
                                        <td>
                                            <div class="col-12">
                                                <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList13" selectionmode="Multiple" Style="width: 100% !important">
                                                    <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                                    <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator125" ControlToValidate="ddlEarthingtype5" runat="server" ForeColor="Red" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Earth Type"></asp:RequiredFieldValidator>
                                            </div>
                                        </td>
                                        <td>
                                            <div class="col-12">
                                                <asp:TextBox class="form-control" ID="TextBox40" MaxLength="2" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator126" ControlToValidate="txtEarthingValue5" runat="server" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Enter Value"></asp:RequiredFieldValidator>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr id="Tr6" runat="server" visible="false">
                                        <td>6</td>
                                        <td>
                                            <div class="col-12">
                                                <asp:DropDownList class="form-control  select-form select2" onKeyPress="return isNumberKey(event);" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList14" selectionmode="Multiple" Style="width: 100% !important">
                                                    <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                                    <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator127" ControlToValidate="ddlEarthingtype6" runat="server" ForeColor="Red" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Earth Type"></asp:RequiredFieldValidator>
                                            </div>
                                        </td>
                                        <td>
                                            <div class="col-12">
                                                <asp:TextBox class="form-control" ID="TextBox41" MaxLength="2" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator128" ControlToValidate="txtEarthingValue6" runat="server" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Enter Value"></asp:RequiredFieldValidator>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr id="Tr7" runat="server" visible="false">
                                        <td>7</td>
                                        <td>
                                            <div class="col-12">
                                                <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList15" selectionmode="Multiple" Style="width: 100% !important">
                                                    <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                                    <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator129" ControlToValidate="ddlEarthingtype7" runat="server" ForeColor="Red" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Earth Type"></asp:RequiredFieldValidator>
                                            </div>
                                        </td>
                                        <td>
                                            <div class="col-12">
                                                <asp:TextBox class="form-control" ID="TextBox42" MaxLength="2" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator130" ControlToValidate="txtEarthingValue7" runat="server" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Enter Value"></asp:RequiredFieldValidator>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr id="Tr8" runat="server" visible="false">
                                        <td>8</td>
                                        <td>
                                            <div class="col-12">
                                                <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList16" selectionmode="Multiple" Style="width: 100% !important">
                                                    <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                                    <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator131" ControlToValidate="ddlEarthingtype8" runat="server" ForeColor="Red" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Earth Type"></asp:RequiredFieldValidator>
                                            </div>
                                        </td>
                                        <td>
                                            <div class="col-12">
                                                <asp:TextBox class="form-control" ID="TextBox43" MaxLength="2" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator132" ControlToValidate="txtEarthingValue8" runat="server" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Enter Value"></asp:RequiredFieldValidator>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr id="Tr9" runat="server" visible="false">
                                        <td>9</td>
                                        <td>
                                            <div class="col-12">
                                                <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList17" selectionmode="Multiple" Style="width: 100% !important">
                                                    <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                                    <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator133" ControlToValidate="ddlEarthingtype9" runat="server" ForeColor="Red" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Earth Type"></asp:RequiredFieldValidator>
                                            </div>
                                        </td>
                                        <td>
                                            <div class="col-12">
                                                <asp:TextBox class="form-control" ID="TextBox44" MaxLength="2" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator134" ControlToValidate="txtEarthingValue9" runat="server" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Enter Value"></asp:RequiredFieldValidator>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr id="Tr10" runat="server" visible="false">
                                        <td>10</td>
                                        <td>
                                            <div class="col-12">
                                                <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList18" selectionmode="Multiple" Style="width: 100% !important">
                                                    <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                                    <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator135" ControlToValidate="ddlEarthingtype10" runat="server" ForeColor="Red" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Earth Type"></asp:RequiredFieldValidator>
                                            </div>
                                        </td>
                                        <td>
                                            <div class="col-12">
                                                <asp:TextBox class="form-control" ID="TextBox45" MaxLength="2" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator136" ControlToValidate="txtEarthingValue10" runat="server" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Enter Value"></asp:RequiredFieldValidator>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr id="Tr11" runat="server" visible="false">
                                        <td>11</td>
                                        <td>
                                            <div class="col-12">
                                                <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList19" selectionmode="Multiple" Style="width: 100% !important">
                                                    <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                                    <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator137" ControlToValidate="ddlEarthingtype11" runat="server" ForeColor="Red" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Earth Type"></asp:RequiredFieldValidator>
                                            </div>
                                        </td>
                                        <td>
                                            <div class="col-12">
                                                <asp:TextBox class="form-control" ID="TextBox46" MaxLength="2" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator138" ControlToValidate="txtEarthingValue11" runat="server" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Enter Value"></asp:RequiredFieldValidator>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr id="Tr12" runat="server" visible="false">
                                        <td>12</td>
                                        <td>
                                            <div class="col-12">
                                                <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList20" selectionmode="Multiple" Style="width: 100% !important">
                                                    <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                                    <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator139" ControlToValidate="ddlEarthingtype12" runat="server" ForeColor="Red" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Earth Type"></asp:RequiredFieldValidator>
                                            </div>
                                        </td>
                                        <td>
                                            <div class="col-12">
                                                <asp:TextBox class="form-control" ID="TextBox47" MaxLength="2" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator140" ControlToValidate="txtEarthingValue12" runat="server" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Enter Value"></asp:RequiredFieldValidator>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr id="Tr13" runat="server" visible="false">
                                        <td>13</td>
                                        <td>
                                            <div class="col-12">
                                                <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList21" selectionmode="Multiple" Style="width: 100% !important">
                                                    <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                                    <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator141" ControlToValidate="ddlEarthingtype13" runat="server" ForeColor="Red" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Earth Type"></asp:RequiredFieldValidator>
                                            </div>
                                        </td>
                                        <td>
                                            <div class="col-12">
                                                <asp:TextBox class="form-control" ID="TextBox48" MaxLength="2" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator142" ControlToValidate="txtEarthingValue13" runat="server" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Enter Value"></asp:RequiredFieldValidator>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr id="Tr14" runat="server" visible="false">
                                        <td>14</td>
                                        <td>
                                            <div class="col-12">
                                                <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList22" selectionmode="Multiple" Style="width: 100% !important">
                                                    <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                                    <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator143" ControlToValidate="ddlEarthingtype14" runat="server" ForeColor="Red" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Earth Type"></asp:RequiredFieldValidator>
                                            </div>
                                        </td>
                                        <td>
                                            <div class="col-12">
                                                <asp:TextBox class="form-control" ID="TextBox49" MaxLength="2" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator144" ControlToValidate="txtEarthingValue14" runat="server" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Enter Value"></asp:RequiredFieldValidator>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr id="Tr15" runat="server" visible="false">
                                        <td>15</td>
                                        <td>
                                            <div class="col-12">
                                                <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="DropDownList23" selectionmode="Multiple" Style="width: 100% !important">
                                                    <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                                    <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator145" ControlToValidate="ddlEarthingtype15" runat="server" ForeColor="Red" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Earth Type"></asp:RequiredFieldValidator>
                                            </div>
                                        </td>
                                        <td>
                                            <div class="col-12">
                                                <asp:TextBox class="form-control" ID="TextBox50" MaxLength="2" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator146" ControlToValidate="txtEarthingValue15" runat="server" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Enter Value"></asp:RequiredFieldValidator>
                                            </div>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
                <div class="row" style="margin-top: 50px;" id="Div69" visible="false" runat="server">
                    <%--  <div class="col-2"></div>--%>
                    <div class="col-12" style="text-align: center;">
                        <asp:CheckBox ID="CheckBox2" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged" AutoPostBack="true" Text="&nbsp;I hereby declare that all information submitted as part of the form is true to my knowledge." Font-Size="Medium" Font-Bold="True" />
                        <br />
                        <label id="label3" runat="server" visible="false" style="color: red; font-size: 1.125rem">
                            Please Verify this.
                        </label>
                    </div>
                </div>
                 <div class="row"  id="Div70" runat="server" visible="false">
                     <div class="col-4"></div>
                      <div class="col-4">
                          <label>
                              Enter the OTP you received to Your Phone Number
                                        <samp style="color: red">* </samp>
                            </label>
                        <asp:TextBox class="form-control" ID="TextBox51" MaxLength="6" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator147" ControlToValidate="txtOTP" runat="server" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Enter OTP"></asp:RequiredFieldValidator>
                                           
                    </div>
                 </div>
                <div class="row">
                    <div class="col-4" >
                    </div>
                    <div class="col-4" style="text-align: center;">
                        <asp:Button ID="Button1" runat="server" Text="Back" Visible="false" class="btn btn-primary mr-2" OnClick="BtnBack_Click"/>
                        <asp:Button ID="Button2" Text="Verify Details" Visible="false" runat="server" class="btn btn-primary mr-2" ValidationGroup="Submit" OnClick="btnVerify_Click" />
                  <asp:Button ID="Button3" OnClick="btnSubmit_Click" Text="Submit" runat="server" class="btn btn-primary mr-2" ValidationGroup="Submit" />
                    </div>
                    <div class="col-4">
                        <asp:HiddenField ID="HiddenField1" Value="0" runat="server" />
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnSubmit" EventName="Click" />
            </Triggers>
      <%--  </asp:UpdatePanel>--%>
    </div>
</div>
</div>
        </div>
    <%--<div class="card">
        <ul class="nav nav-pills">
  <li class="nav-item">
    <a class="nav-link " href="#">Active</a>
  </li>
  <li class="nav-item dropdown">
    <a class="nav-link dropdown-toggle" data-toggle="dropdown" href="#" role="button" aria-haspopup="true" aria-expanded="false">Dropdown</a>
    <div class="dropdown-menu">
      <a class="dropdown-item" href="#">Action</a>
      <a class="dropdown-item" href="#">Another action</a>
    </div>
  </li>
  <li class="nav-item dropdown">
   <a class="nav-link dropdown-toggle" data-toggle="dropdown" href="#" role="button" aria-haspopup="true" aria-expanded="false">Dropdown</a>
   <div class="dropdown-menu">
     <a class="dropdown-item" href="#">Action</a>
     <a class="dropdown-item" href="#">Another action</a>
   </div>
 </li> <li class="nav-item dropdown">
   <a class="nav-link dropdown-toggle" data-toggle="dropdown" href="#" role="button" aria-haspopup="true" aria-expanded="false">Dropdown</a>
   <div class="dropdown-menu">
     <a class="dropdown-item" href="#">Action</a>
     <a class="dropdown-item" href="#">Another action</a>
   </div>
 </li>
</ul>
        </div>--%>
    <script>
        const links = document.querySelectorAll('.nav-link');

        if (links.length) {
            links.forEach((link) => {
                link.addEventListener('click', (e) => {
                    links.forEach((link) => {
                        link.classList.remove('active');
                    });
                    e.preventDefault();
                    link.classList.add('active');
                });
            });
        }
    </script>
</asp:Content>
