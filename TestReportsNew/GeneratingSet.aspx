<%@ Page Title="" Language="C#" MasterPageFile="~/TestReportsNew/TestReport.Master" AutoEventWireup="true" CodeBehind="GeneratingSet.aspx.cs" Inherits="CEIHaryana.TestReportsNew.GeneratingSet" %>
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
       <div class="card" style="box-shadow: rgba(0, 0, 0, 0.2) 0px 20px 15px -3px, rgba(0, 0, 0, 0.05) 0px 4px 6px -2px;border-radius:0px !important;background:#f9f9f9;margin-left: 24px;margin-top:-2px;
    margin-right: 2%;">
        <div class="card-body" id="divGeneratingSet" runat="server" style="margin-top: -30px;">
    <div class="card-body" style="margin-top: -30px;">
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
                <div class="row">
                    <div class="col-2" id="Div170" runat="server" style="margin-top: -15px;">
                        <label for="Name">
                            Capacity
                    <samp style="color: red">* </samp>
                        </label>
                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlCapacity" selectionmode="Multiple" Style="width: 100% !important">
                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                            <asp:ListItem Text="KVA" Value="1"></asp:ListItem>
                            <asp:ListItem Text="MVA" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ForeColor="Red" ControlToValidate="ddlCapacity" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Capacity "></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-2" id="Div171" runat="server" style="margin-top: -15px;">
                        <label for="Name">
                            Value
                    <samp style="color: red">* </samp>
                        </label>
                        <asp:TextBox class="form-control" ID="txtCapacity" AutoPostBack="true" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" autocomplete="off"
                            placeholder="" TabIndex="2" MaxLength="4" runat="server" Style="margin-left: 18px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rvfCapacity" runat="server" ForeColor="Red" ControlToValidate="txtCapacity" ValidationGroup="Submit" ErrorMessage="Please Enter Capacity"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-2" runat="server" style="margin-top: -15px;">
                        <label for="Name">
                            Serial no. 
                        <samp style="color: red">* </samp>
                        </label>
                        <asp:TextBox class="form-control" ID="txtSerialNoOfGenerator" placeholder="of Ac generator/ Alternator" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ControlToValidate="txtSerialNoOfGenerator" ValidationGroup="Submit" ErrorMessage="Please Enter Serial No Of Generator"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-2" id="Div172" runat="server" style="margin-top: -15px;">
                        <label for="Name">
                            Type of Generating Set
                                    <samp style="color: red">* </samp>
                        </label>
                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlGeneratingSetType_SelectedIndexChanged" ID="ddlGeneratingSetType" selectionmode="Multiple" Style="width: 100% !important">
                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Diesel Engine" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Gas Engine" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Solar Panel" Value="3"></asp:ListItem>
                            <asp:ListItem Text="Bio Fuel" Value="4"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ForeColor="Red" ControlToValidate="ddlGeneratingSetType" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Generator Set Type"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-4">
                        <label for="Name">
                            Generator voltage level(IN VOLTS)
                                    <samp style="color: red">* </samp>
                        </label>
                        <asp:TextBox class="form-control" ID="txtGeneratorVoltage" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" MaxLength="5" placeholder="" AutoPostBack="true" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ControlToValidate="txtGeneratorVoltage" ValidationGroup="Submit" ErrorMessage="Please Enter Generator Voltage"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-4">
                        <label for="Name">
                            Current capacity of breaker( IN AMPS)
                                    <samp style="color: red">* </samp>
                        </label>
                        <asp:TextBox class="form-control" ID="txtCurrentCapacity" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" MaxLength="4" runat="server" Style="margin-left: 18px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red" ControlToValidate="txtCurrentCapacity" ValidationGroup="Submit" ErrorMessage="Please Enter Current Capacity Of Breaker"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-4">
                        <label for="Name">
                            Breaking capacity of breaker (IN KA)
                                    <samp style="color: red">* </samp>
                        </label>
                        <asp:TextBox class="form-control" ID="txtBreakingCapacity" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" MaxLength="4" runat="server" Style="margin-left: 18px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ForeColor="Red" ControlToValidate="txtBreakingCapacity" ValidationGroup="Submit" ErrorMessage="Please Enter Breaking Capacity"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-4">
                        <label for="Name">
                            Number of Earthing:
                            <samp style="color: red">* </samp>
                        </label>
                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlGeneratingEarthing_SelectedIndexChanged" ID="ddlGeneratingEarthing" selectionmode="Multiple" Style="width: 100% !important">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ForeColor="Red" ControlToValidate="ddlGeneratingEarthing" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select No Of Earthing"></asp:RequiredFieldValidator>
                        <label id="Limit" runat="server" visible="false" style="color: red; font-size: 1.125rem">
                            Minimum Limit is 4     
                        </label>
                    </div>
                </div>
                <div class="table-responsive pt-3" id="GeneratingEarthing" runat="server" visible="false">
                    <table class="table table-bordered table-striped">
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
                                    <td>1</td>
                                    <td>
                                        <div class="col-12">
                                            <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlGeneratingEarthing1" selectionmode="Multiple" Style="width: 100% !important">
                                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                                <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ForeColor="Red" ControlToValidate="ddlGeneratingEarthing1" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Select Earth Type"></asp:RequiredFieldValidator>
                                        </div>
                                    </td>
                                    <td>
                                        <div class="col-12">
                                            <asp:TextBox class="form-control" ID="txtGeneratingEarthing1" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" MaxLength="5" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator45" runat="server" ForeColor="Red" ControlToValidate="txtGeneratingEarthing1" ValidationGroup="Submit" ErrorMessage="Please Enter Value"></asp:RequiredFieldValidator>
                                        </div>
                                    </td>
                                    <td>
                                        <div class="col-12">
                                            <asp:DropDownList class="form-control  select-form select2" TabIndex="6" OnSelectedIndexChanged="ddlGeneratingEarthingUsed1_SelectedIndexChanged" runat="server" AutoPostBack="true" ID="ddlGeneratingEarthingUsed1" selectionmode="Multiple" Style="width: 100% !important">
                                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="Neutral Transformer"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="Body Of Transformer"></asp:ListItem>
                                                <asp:ListItem Value="3" Text="LA's"></asp:ListItem>
                                                <asp:ListItem Value="4" Text="HT Panels"></asp:ListItem>
                                                <asp:ListItem Value="5" Text="LT Panels"></asp:ListItem>
                                                <asp:ListItem Value="6" Text="Fencing"></asp:ListItem>
                                                <asp:ListItem Value="7" Text="Other"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator44" runat="server" ForeColor="Red" ControlToValidate="ddlGeneratingEarthingUsed1" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Used For"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-12">
                                            <asp:TextBox class="form-control" ID="txtOtherEarthing1" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator61" runat="server" ForeColor="Red" ControlToValidate="txtOtherEarthing1" ValidationGroup="Submit" ErrorMessage="Please Enter Other earthing"></asp:RequiredFieldValidator>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>2</td>
                                    <td>
                                        <div class="col-12">
                                            <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlGeneratingEarthing2" selectionmode="Multiple" Style="width: 100% !important">
                                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                                <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ForeColor="Red" ControlToValidate="ddlGeneratingEarthing2" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Select Earth Type"></asp:RequiredFieldValidator>
                                        </div>
                                    </td>
                                    <td>
                                        <div class="col-12">
                                            <asp:TextBox class="form-control" ID="txtGeneratingEarthing2" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" MaxLength="5" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator46" runat="server" ForeColor="Red" ControlToValidate="txtGeneratingEarthing2" ValidationGroup="Submit" ErrorMessage="Please Enter Value"></asp:RequiredFieldValidator>
                                        </div>
                                    </td>
                                    <td>
                                        <div class="col-12">
                                            <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" OnSelectedIndexChanged="ddlGeneratingEarthingUsed2_SelectedIndexChanged" AutoPostBack="true" ID="ddlGeneratingEarthingUsed2" selectionmode="Multiple" Style="width: 100% !important">
                                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="Neutral Transformer"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="Body Of Transformer"></asp:ListItem>
                                                <asp:ListItem Value="3" Text="LA's"></asp:ListItem>
                                                <asp:ListItem Value="4" Text="HT Panels"></asp:ListItem>
                                                <asp:ListItem Value="5" Text="LT Panels"></asp:ListItem>
                                                <asp:ListItem Value="6" Text="Fencing"></asp:ListItem>
                                                <asp:ListItem Value="7" Text="Other"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator43" runat="server" ForeColor="Red" ControlToValidate="ddlGeneratingEarthingUsed2" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Used For"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-12">
                                            <asp:TextBox class="form-control" ID="txtOtherEarthing2" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator62" runat="server" ForeColor="Red" ControlToValidate="txtOtherEarthing2" ValidationGroup="Submit" ErrorMessage="Please Enter Other Earthing"></asp:RequiredFieldValidator>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>3</td>
                                    <td>
                                        <div class="col-12">
                                            <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlGeneratingEarthing3" selectionmode="Multiple" Style="width: 100% !important">
                                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                                <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ForeColor="Red" ControlToValidate="ddlGeneratingEarthing3" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Select Earth Type"></asp:RequiredFieldValidator>
                                        </div>
                                    </td>
                                    <td>
                                        <div class="col-12">
                                            <asp:TextBox class="form-control" ID="txtGeneratingEarthing3" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" MaxLength="5" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator47" runat="server" ForeColor="Red" ControlToValidate="txtGeneratingEarthing3" ValidationGroup="Submit" ErrorMessage="Please Enter Value"></asp:RequiredFieldValidator>
                                        </div>
                                    </td>
                                    <td>
                                        <div class="col-12">
                                            <asp:DropDownList class="form-control  select-form select2" TabIndex="6" OnSelectedIndexChanged="ddlGeneratingEarthingUsed3_SelectedIndexChanged" runat="server" AutoPostBack="true" ID="ddlGeneratingEarthingUsed3" selectionmode="Multiple" Style="width: 100% !important">
                                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="Neutral Transformer"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="Body Of Transformer"></asp:ListItem>
                                                <asp:ListItem Value="3" Text="LA's"></asp:ListItem>
                                                <asp:ListItem Value="4" Text="HT Panels"></asp:ListItem>
                                                <asp:ListItem Value="5" Text="LT Panels"></asp:ListItem>
                                                <asp:ListItem Value="6" Text="Fencing"></asp:ListItem>
                                                <asp:ListItem Value="7" Text="Other"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator42" runat="server" ForeColor="Red" ControlToValidate="ddlGeneratingEarthingUsed3" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Used For"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-12">
                                            <asp:TextBox class="form-control" ID="txtOtherEarthing3" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator63" runat="server" ForeColor="Red" ControlToValidate="txtOtherEarthing3" ValidationGroup="Submit" ErrorMessage="Please Enter Other Earthing"></asp:RequiredFieldValidator>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>4</td>
                                    <td>
                                        <div class="col-12" id="Div9" runat="server">
                                            <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlGeneratingEarthing4" selectionmode="Multiple" Style="width: 100% !important">

                                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                                <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ForeColor="Red" ControlToValidate="ddlGeneratingEarthing4" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Select Earth Type"></asp:RequiredFieldValidator>
                                        </div>
                                    </td>
                                    <td>
                                        <div class="col-12" id="Div10" runat="server">
                                            <asp:TextBox class="form-control" ID="txtGeneratingEarthing4" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" MaxLength="5" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator48" runat="server" ForeColor="Red" ControlToValidate="txtGeneratingEarthing4" ValidationGroup="Submit" ErrorMessage="Please Enter Value"></asp:RequiredFieldValidator>
                                        </div>
                                    </td>
                                    <td>
                                        <div class="col-12">
                                            <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" OnSelectedIndexChanged="ddlGeneratingEarthingUsed4_SelectedIndexChanged" AutoPostBack="true" ID="ddlGeneratingEarthingUsed4" selectionmode="Multiple" Style="width: 100% !important">
                                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="Neutral Transformer"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="Body Of Transformer"></asp:ListItem>
                                                <asp:ListItem Value="3" Text="LA's"></asp:ListItem>
                                                <asp:ListItem Value="4" Text="HT Panels"></asp:ListItem>
                                                <asp:ListItem Value="5" Text="LT Panels"></asp:ListItem>
                                                <asp:ListItem Value="6" Text="Fencing"></asp:ListItem>
                                                <asp:ListItem Value="7" Text="Other"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator41" runat="server" ForeColor="Red" ControlToValidate="ddlGeneratingEarthingUsed4" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Used For"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-12">
                                            <asp:TextBox class="form-control" ID="txtOtherEarthing4" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator64" runat="server" ForeColor="Red" ControlToValidate="txtOtherEarthing4" ValidationGroup="Submit" ErrorMessage="Please Enter Other Earthing"></asp:RequiredFieldValidator>
                                        </div>
                                    </td>
                                </tr>
                            </div>
                            <tr id="GeneratingEarthing5" runat="server" visible="false">
                                <td>5 </td>
                                <td>
                                    <div class="col-12" id="Div12" runat="server">
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlGeneratingEarthing5" selectionmode="Multiple" Style="width: 100% !important">
                                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ForeColor="Red" ControlToValidate="ddlGeneratingEarthing5" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Select Earth Type"></asp:RequiredFieldValidator>
                                    </div>
                                </td>
                                <td>
                                    <div class="col-12">
                                        <asp:TextBox class="form-control" ID="txtGeneratingEarthing5" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" MaxLength="5" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator49" runat="server" ForeColor="Red" ControlToValidate="txtGeneratingEarthing5" ValidationGroup="Submit" ErrorMessage="Please Enter Value"></asp:RequiredFieldValidator>
                                    </div>
                                </td>
                                <td>
                                    <div class="col-12">
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" OnSelectedIndexChanged="ddlGeneratingEarthingUsed5_SelectedIndexChanged" AutoPostBack="true" ID="ddlGeneratingEarthingUsed5" selectionmode="Multiple" Style="width: 100% !important">
                                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="Neutral Transformer"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Body Of Transformer"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="LA's"></asp:ListItem>
                                            <asp:ListItem Value="4" Text="HT Panels"></asp:ListItem>
                                            <asp:ListItem Value="5" Text="LT Panels"></asp:ListItem>
                                            <asp:ListItem Value="6" Text="Fencing"></asp:ListItem>
                                            <asp:ListItem Value="7" Text="Other"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator40" runat="server" ForeColor="Red" ControlToValidate="ddlGeneratingEarthingUsed5" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Used For"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-12">
                                        <asp:TextBox class="form-control" ID="txtOtherEarthing5" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator65" runat="server" ForeColor="Red" ControlToValidate="txtOtherEarthing5" ValidationGroup="Submit" ErrorMessage="Please Enter Other Earthing"></asp:RequiredFieldValidator>
                                    </div>
                                </td>
                            </tr>
                            <tr id="GeneratingEarthing6" runat="server" visible="false">
                                <td>6</td>
                                <td>
                                    <div class="col-12">
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlGeneratingEarthing6" selectionmode="Multiple" Style="width: 100% !important">
                                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ForeColor="Red" ControlToValidate="ddlGeneratingEarthing6" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Select Earth Type"></asp:RequiredFieldValidator>
                                    </div>
                                </td>
                                <td>
                                    <div class="col-12">
                                        <asp:TextBox class="form-control" ID="txtGeneratingEarthing6" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" MaxLength="5" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator50" runat="server" ForeColor="Red" ControlToValidate="txtGeneratingEarthing6" ValidationGroup="Submit" ErrorMessage="Please Enter Value"></asp:RequiredFieldValidator>
                                    </div>
                                </td>
                                <td>
                                    <div class="col-12">
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" OnSelectedIndexChanged="ddlGeneratingEarthingUsed6_SelectedIndexChanged" AutoPostBack="true" ID="ddlGeneratingEarthingUsed6" selectionmode="Multiple" Style="width: 100% !important">
                                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="Neutral Transformer"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Body Of Transformer"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="LA's"></asp:ListItem>
                                            <asp:ListItem Value="4" Text="HT Panels"></asp:ListItem>
                                            <asp:ListItem Value="5" Text="LT Panels"></asp:ListItem>
                                            <asp:ListItem Value="6" Text="Fencing"></asp:ListItem>
                                            <asp:ListItem Value="7" Text="Other"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator39" runat="server" ForeColor="Red" ControlToValidate="ddlGeneratingEarthingUsed6" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Used For"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-12">
                                        <asp:TextBox class="form-control" ID="txtOtherEarthing6" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" MaxLength="5" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator66" runat="server" ForeColor="Red" ControlToValidate="txtOtherEarthing6" ValidationGroup="Submit" ErrorMessage="Please Enter Other Earthing"></asp:RequiredFieldValidator>
                                    </div>
                                </td>
                            </tr>
                            <tr id="GeneratingEarthing7" runat="server" visible="false">
                                <td>7</td>
                                <td>
                                    <div class="col-12" id="Div13" runat="server">
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlGeneratingEarthing7" selectionmode="Multiple" Style="width: 100% !important">
                                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ForeColor="Red" ControlToValidate="ddlGeneratingEarthing7" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Select Earth Type"></asp:RequiredFieldValidator>
                                    </div>
                                </td>
                                <td>
                                    <div class="col-12">
                                        <asp:TextBox class="form-control" ID="txtGeneratingEarthing7" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" MaxLength="5" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator51" runat="server" ForeColor="Red" ControlToValidate="txtGeneratingEarthing7" ValidationGroup="Submit" ErrorMessage="Please Enter Value"></asp:RequiredFieldValidator>
                                    </div>
                                </td>
                                <td>
                                    <div class="col-12">
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" OnSelectedIndexChanged="ddlGeneratingEarthingUsed7_SelectedIndexChanged" runat="server" AutoPostBack="true" ID="ddlGeneratingEarthingUsed7" selectionmode="Multiple" Style="width: 100% !important">
                                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="Neutral Transformer"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Body Of Transformer"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="LA's"></asp:ListItem>
                                            <asp:ListItem Value="4" Text="HT Panels"></asp:ListItem>
                                            <asp:ListItem Value="5" Text="LT Panels"></asp:ListItem>
                                            <asp:ListItem Value="6" Text="Fencing"></asp:ListItem>
                                            <asp:ListItem Value="7" Text="Other"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator38" runat="server" ForeColor="Red" ControlToValidate="ddlGeneratingEarthingUsed7" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Used For"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-12">
                                        <asp:TextBox class="form-control" ID="txtOtherEarthing7" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator67" runat="server" ForeColor="Red" ControlToValidate="txtOtherEarthing7" ValidationGroup="Submit" ErrorMessage="Please Enter Other Earthing"></asp:RequiredFieldValidator>
                                    </div>
                                </td>
                            </tr>
                            <tr id="GeneratingEarthing8" runat="server" visible="false">
                                <td>8</td>
                                <td>
                                    <div class="col-12">
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlGeneratingEarthing8" selectionmode="Multiple" Style="width: 100% !important">
                                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ForeColor="Red" ControlToValidate="ddlGeneratingEarthing8" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Select Earth Type"></asp:RequiredFieldValidator>
                                    </div>
                                </td>
                                <td>
                                    <div class="col-12">
                                        <asp:TextBox class="form-control" ID="txtGeneratingEarthing8" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" MaxLength="5" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator52" runat="server" ForeColor="Red" ControlToValidate="txtGeneratingEarthing8" ValidationGroup="Submit" ErrorMessage="Please Enter Value"></asp:RequiredFieldValidator>
                                    </div>
                                </td>
                                <td>
                                    <div class="col-12">
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" OnSelectedIndexChanged="ddlGeneratingEarthingUsed8_SelectedIndexChanged" runat="server" AutoPostBack="true" ID="ddlGeneratingEarthingUsed8" selectionmode="Multiple" Style="width: 100% !important">
                                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="Neutral Transformer"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Body Of Transformer"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="LA's"></asp:ListItem>
                                            <asp:ListItem Value="4" Text="HT Panels"></asp:ListItem>
                                            <asp:ListItem Value="5" Text="LT Panels"></asp:ListItem>
                                            <asp:ListItem Value="6" Text="Fencing"></asp:ListItem>
                                            <asp:ListItem Value="7" Text="Other"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator37" runat="server" ForeColor="Red" ControlToValidate="ddlGeneratingEarthingUsed8" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Used For"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-12">
                                        <asp:TextBox class="form-control" ID="txtOtherEarthing8" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator68" runat="server" ForeColor="Red" ControlToValidate="txtOtherEarthing8" ValidationGroup="Submit" ErrorMessage="Please Enter Other Earthing"></asp:RequiredFieldValidator>
                                    </div>
                                </td>
                            </tr>
                            <tr id="GeneratingEarthing9" runat="server" visible="false">
                                <td>9</td>
                                <td>
                                    <div class="col-12">
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlGeneratingEarthing9" selectionmode="Multiple" Style="width: 100% !important">
                                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ForeColor="Red" ControlToValidate="ddlGeneratingEarthing9" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Select Earth Type"></asp:RequiredFieldValidator>
                                    </div>
                                </td>
                                <td>
                                    <div class="col-12">
                                        <asp:TextBox class="form-control" ID="txtGeneratingEarthing9" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" MaxLength="5" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator53" runat="server" ForeColor="Red" ControlToValidate="txtGeneratingEarthing9" ValidationGroup="Submit" ErrorMessage="Please Enter Value"></asp:RequiredFieldValidator>
                                    </div>
                                </td>
                                <td>
                                    <div class="col-12">
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" OnSelectedIndexChanged="ddlGeneratingEarthingUsed9_SelectedIndexChanged" AutoPostBack="true" ID="ddlGeneratingEarthingUsed9" selectionmode="Multiple" Style="width: 100% !important">
                                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="Neutral Transformer"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Body Of Transformer"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="LA's"></asp:ListItem>
                                            <asp:ListItem Value="4" Text="HT Panels"></asp:ListItem>
                                            <asp:ListItem Value="5" Text="LT Panels"></asp:ListItem>
                                            <asp:ListItem Value="6" Text="Fencing"></asp:ListItem>
                                            <asp:ListItem Value="7" Text="Other"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator36" runat="server" ForeColor="Red" ControlToValidate="ddlGeneratingEarthingUsed9" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Used For"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-12">
                                        <asp:TextBox class="form-control" ID="txtOtherEarthing9" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator69" runat="server" ForeColor="Red" ControlToValidate="txtOtherEarthing9" ValidationGroup="Submit" ErrorMessage="Please Enter Other Earthing"></asp:RequiredFieldValidator>
                                    </div>
                                </td>
                            </tr>
                            <tr id="GeneratingEarthing10" runat="server" visible="false">
                                <td>10</td>
                                <td>
                                    <div class="col-12">
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlGeneratingEarthing10" selectionmode="Multiple" Style="width: 100% !important">
                                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ForeColor="Red" ControlToValidate="ddlGeneratingEarthing10" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Select Earth Type"></asp:RequiredFieldValidator>
                                    </div>
                                </td>
                                <td>
                                    <div class="col-12">
                                        <asp:TextBox class="form-control" ID="txtGeneratingEarthing10" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" MaxLength="5" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator54" runat="server" ForeColor="Red" ControlToValidate="txtGeneratingEarthing10" ValidationGroup="Submit" ErrorMessage="Please Enter Value"></asp:RequiredFieldValidator>
                                    </div>
                                </td>
                                <td>
                                    <div class="col-12">
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" OnSelectedIndexChanged="ddlGeneratingEarthingUsed10_SelectedIndexChanged" runat="server" AutoPostBack="true" ID="ddlGeneratingEarthingUsed10" selectionmode="Multiple" Style="width: 100% !important">
                                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="Neutral Transformer"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Body Of Transformer"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="LA's"></asp:ListItem>
                                            <asp:ListItem Value="4" Text="HT Panels"></asp:ListItem>
                                            <asp:ListItem Value="5" Text="LT Panels"></asp:ListItem>
                                            <asp:ListItem Value="6" Text="Fencing"></asp:ListItem>
                                            <asp:ListItem Value="7" Text="Other"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server" ForeColor="Red" ControlToValidate="ddlGeneratingEarthingUsed10" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Used For"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-12">
                                        <asp:TextBox class="form-control" ID="txtOtherEarthing10" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator70" runat="server" ForeColor="Red" ControlToValidate="txtOtherEarthing10" ValidationGroup="Submit" ErrorMessage="Please Enter Other Earthing"></asp:RequiredFieldValidator>
                                    </div>
                                </td>
                            </tr>
                            <tr id="GeneratingEarthing11" runat="server" visible="false">
                                <td>11</td>
                                <td>
                                    <div class="col-12">
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlGeneratingEarthing11" selectionmode="Multiple" Style="width: 100% !important">
                                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ForeColor="Red" ControlToValidate="ddlGeneratingEarthing11" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Select Earth Type"></asp:RequiredFieldValidator>
                                    </div>
                                </td>
                                <td>
                                    <div class="col-12">
                                        <asp:TextBox class="form-control" ID="txtGeneratingEarthing11" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" MaxLength="5" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator55" runat="server" ForeColor="Red" ControlToValidate="txtGeneratingEarthing11" ValidationGroup="Submit" ErrorMessage="Please Enter Value"></asp:RequiredFieldValidator>
                                    </div>
                                </td>
                                <td>
                                    <div class="col-12">
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" OnSelectedIndexChanged="ddlGeneratingEarthingUsed11_SelectedIndexChanged" runat="server" AutoPostBack="true" ID="ddlGeneratingEarthingUsed11" selectionmode="Multiple" Style="width: 100% !important">
                                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="Neutral Transformer"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Body Of Transformer"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="LA's"></asp:ListItem>
                                            <asp:ListItem Value="4" Text="HT Panels"></asp:ListItem>
                                            <asp:ListItem Value="5" Text="LT Panels"></asp:ListItem>
                                            <asp:ListItem Value="6" Text="Fencing"></asp:ListItem>
                                            <asp:ListItem Value="7" Text="Other"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator34" runat="server" ForeColor="Red" ControlToValidate="ddlGeneratingEarthingUsed11" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Used For"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-12">
                                        <asp:TextBox class="form-control" ID="txtOtherEarthing11" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator71" runat="server" ForeColor="Red" ControlToValidate="txtOtherEarthing11" ValidationGroup="Submit" ErrorMessage="Please Enter Other Earthing"></asp:RequiredFieldValidator>
                                    </div>
                                </td>
                            </tr>
                            <tr id="GeneratingEarthing12" runat="server" visible="false">
                                <td>12</td>
                                <td>
                                    <div class="col-12">
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlGeneratingEarthing12" selectionmode="Multiple" Style="width: 100% !important">
                                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ForeColor="Red" ControlToValidate="ddlGeneratingEarthing12" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Select Earth Type"></asp:RequiredFieldValidator>
                                    </div>
                                </td>
                                <td>
                                    <div class="col-12">
                                        <asp:TextBox class="form-control" ID="txtGeneratingEarthing12" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" MaxLength="5" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator56" runat="server" ForeColor="Red" ControlToValidate="txtGeneratingEarthing12" ValidationGroup="Submit" ErrorMessage="Please Enter Value"></asp:RequiredFieldValidator>
                                    </div>
                                </td>
                                <td>
                                    <div class="col-12">
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" OnSelectedIndexChanged="ddlGeneratingEarthingUsed12_SelectedIndexChanged" AutoPostBack="true" ID="ddlGeneratingEarthingUsed12" selectionmode="Multiple" Style="width: 100% !important">
                                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="Neutral Transformer"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Body Of Transformer"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="LA's"></asp:ListItem>
                                            <asp:ListItem Value="4" Text="HT Panels"></asp:ListItem>
                                            <asp:ListItem Value="5" Text="LT Panels"></asp:ListItem>
                                            <asp:ListItem Value="6" Text="Fencing"></asp:ListItem>
                                            <asp:ListItem Value="7" Text="Other"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator33" runat="server" ForeColor="Red" ControlToValidate="ddlGeneratingEarthingUsed12" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Used For"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-12">
                                        <asp:TextBox class="form-control" ID="txtOtherEarthing12" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator72" runat="server" ForeColor="Red" ControlToValidate="txtOtherEarthing12" ValidationGroup="Submit" ErrorMessage="Please Enter Other Earthing"></asp:RequiredFieldValidator>
                                    </div>
                                </td>
                            </tr>
                            <tr id="GeneratingEarthing13" runat="server" visible="false">
                                <td>13</td>
                                <td>
                                    <div class="col-12">
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlGeneratingEarthing13" selectionmode="Multiple" Style="width: 100% !important">
                                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ForeColor="Red" ControlToValidate="ddlGeneratingEarthing13" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Select Earth Type"></asp:RequiredFieldValidator>
                                    </div>
                                </td>
                                <td>
                                    <div class="col-12">
                                        <asp:TextBox class="form-control" ID="txtGeneratingEarthing13" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" MaxLength="5" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator57" runat="server" ForeColor="Red" ControlToValidate="txtGeneratingEarthing13" ValidationGroup="Submit" ErrorMessage="Please Enter Value"></asp:RequiredFieldValidator>
                                    </div>
                                </td>
                                <td>
                                    <div class="col-12">
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" OnSelectedIndexChanged="ddlGeneratingEarthingUsed13_SelectedIndexChanged" AutoPostBack="true" ID="ddlGeneratingEarthingUsed13" selectionmode="Multiple" Style="width: 100% !important">
                                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="Neutral Transformer"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Body Of Transformer"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="LA's"></asp:ListItem>
                                            <asp:ListItem Value="4" Text="HT Panels"></asp:ListItem>
                                            <asp:ListItem Value="5" Text="LT Panels"></asp:ListItem>
                                            <asp:ListItem Value="6" Text="Fencing"></asp:ListItem>
                                            <asp:ListItem Value="7" Text="Other"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ForeColor="Red" ControlToValidate="ddlGeneratingEarthingUsed13" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Used For"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-12">
                                        <asp:TextBox class="form-control" ID="txtOtherEarthing13" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator73" runat="server" ForeColor="Red" ControlToValidate="txtOtherEarthing13" ValidationGroup="Submit" ErrorMessage="Please Enter Other Earthing"></asp:RequiredFieldValidator>
                                    </div>
                                </td>
                            </tr>
                            <tr id="GeneratingEarthing14" runat="server" visible="false">
                                <td>14</td>
                                <td>
                                    <div class="col-12">
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlGeneratingEarthing14" selectionmode="Multiple" Style="width: 100% !important">
                                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" ForeColor="Red" ControlToValidate="ddlGeneratingEarthing14" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Select Earth Type"></asp:RequiredFieldValidator>
                                    </div>
                                </td>
                                <td>
                                    <div class="col-12">
                                        <asp:TextBox class="form-control" ID="txtGeneratingEarthing14" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" MaxLength="5" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator58" runat="server" ForeColor="Red" ControlToValidate="txtGeneratingEarthing14" ValidationGroup="Submit" ErrorMessage="Please Enter Value"></asp:RequiredFieldValidator>
                                    </div>
                                </td>
                                <td>
                                    <div class="col-12">
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" OnSelectedIndexChanged="ddlGeneratingEarthingUsed14_SelectedIndexChanged" AutoPostBack="true" ID="ddlGeneratingEarthingUsed14" selectionmode="Multiple" Style="width: 100% !important">
                                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="Neutral Transformer"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Body Of Transformer"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="LA's"></asp:ListItem>
                                            <asp:ListItem Value="4" Text="HT Panels"></asp:ListItem>
                                            <asp:ListItem Value="5" Text="LT Panels"></asp:ListItem>
                                            <asp:ListItem Value="6" Text="Fencing"></asp:ListItem>
                                            <asp:ListItem Value="7" Text="Other"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ForeColor="Red" ControlToValidate="ddlGeneratingEarthingUsed14" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Used For"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-12">
                                        <asp:TextBox class="form-control" ID="txtOtherEarthing14" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator74" runat="server" ForeColor="Red" ControlToValidate="txtOtherEarthing14" ValidationGroup="Submit" ErrorMessage="Please Enter Other Earthing"></asp:RequiredFieldValidator>
                                    </div>
                                </td>
                            </tr>
                            <tr id="GeneratingEarthing15" runat="server" visible="false">
                                <td>15</td>
                                <td>
                                    <div class="col-12">
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlGeneratingEarthing15" selectionmode="Multiple" Style="width: 100% !important">
                                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ForeColor="Red" ControlToValidate="ddlGeneratingEarthing15" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Select Earth Type"></asp:RequiredFieldValidator>
                                    </div>
                                </td>
                                <td>
                                    <div class="col-12">
                                        <asp:TextBox class="form-control" ID="txtGeneratingEarthing15" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" MaxLength="5" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator59" runat="server" ForeColor="Red" ControlToValidate="txtGeneratingEarthing15" ValidationGroup="Submit" ErrorMessage="Please Enter Value"></asp:RequiredFieldValidator>
                                    </div>
                                </td>
                                <td>
                                    <div class="col-12">
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="6" OnSelectedIndexChanged="ddlGeneratingEarthingUsed15_SelectedIndexChanged" runat="server" AutoPostBack="true" ID="ddlGeneratingEarthingUsed15" selectionmode="Multiple" Style="width: 100% !important">
                                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="Neutral Transformer"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Body Of Transformer"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="LA's"></asp:ListItem>
                                            <asp:ListItem Value="4" Text="HT Panels"></asp:ListItem>
                                            <asp:ListItem Value="5" Text="LT Panels"></asp:ListItem>
                                            <asp:ListItem Value="6" Text="Fencing"></asp:ListItem>
                                            <asp:ListItem Value="7" Text="Other"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ForeColor="Red" ControlToValidate="ddlGeneratingEarthingUsed15" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Used For"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-12">
                                        <asp:TextBox class="form-control" ID="txtOtherEarthing15" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator75" runat="server" ForeColor="Red" ControlToValidate="txtOtherEarthing15" ValidationGroup="Submit" ErrorMessage="Please Enter Other Earthing"></asp:RequiredFieldValidator>
                                    </div>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div id="SolarPanelGeneratingSet" runat="server" visible="false">
                    <div class="row">
                        <div class="col-4">
                            <label for="Name">
                                Type of plant<samp style="color: red">* </samp>
                            </label>
                            <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlPlantType" selectionmode="Multiple" Style="width: 100% !important">
                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Ground Mounted" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Roof top" Value="2"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ForeColor="Red" ControlToValidate="ddlPlantType" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Plant Type"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-2" style="margin-top: -15px;">
                            <label for="Name">
                                capacity of plant
                                        <samp style="color: red">* </samp>
                            </label>
                            <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlPlantCapacity" Style="width: 100% !important">
                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                <asp:ListItem Text="KW" Value="1"></asp:ListItem>
                                <asp:ListItem Text="MW" Value="2"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator60" runat="server" ForeColor="Red" ControlToValidate="ddlPlantCapacity" InitialValue="0" ValidationGroup="Submit" ErrorMessage="Please Select Plant Type"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-2" style="margin-top: -15px;">
                            <label for="Name">
                                capacity of plant      
                            </label>
                            <asp:TextBox class="form-control" ID="txtPlantCapacity" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder=" between DC phase wire to earth wire" autocomplete="off" TabIndex="2" MaxLength="3" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ForeColor="Red" ControlToValidate="txtPlantCapacity" ValidationGroup="Submit" ErrorMessage="Please Enter Plant capacity"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-2" id="Div184" runat="server" style="margin-top: -15px;">
                            <label for="Name">
                                DC string       
                            </label>
                            <asp:TextBox class="form-control" ID="txtDCString" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" MaxLength="2" placeholder=" Highest Voltage" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ForeColor="Red" ControlToValidate="txtDCString" ValidationGroup="Submit" ErrorMessage="Please Enter Dc String"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-2" id="Div185" runat="server" style="margin-top: -15px;">
                            <label for="Name" style="text-align: initial; font-size: 12px;">
                                Lowest Insulation Resistance        
                            </label>
                            <asp:TextBox class="form-control" ID="txtLowestInsulation" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" MaxLength="4" placeholder=" between DC phase wire to earth wire" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ForeColor="Red" ControlToValidate="txtLowestInsulation" ValidationGroup="Submit" ErrorMessage="Please Enter Lowest Insulation"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-4" id="Div186" runat="server">
                            <label for="Name">
                                No of PCV or Solar Inverter        
                            </label>
                            <asp:TextBox class="form-control" ID="txtPCVOrSolar" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ForeColor="Red" ControlToValidate="txtPCVOrSolar" ValidationGroup="Submit" ErrorMessage="Please Enter Pvc"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-4" id="Div187" runat="server">
                            <label for="Name">
                                capacity of main LTAC Breaker        
                            </label>
                            <asp:TextBox class="form-control" ID="txtLTACCapacity" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" placeholder="" autocomplete="off" TabIndex="2" runat="server" MaxLength="4" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ForeColor="Red" ControlToValidate="txtLTACCapacity" ValidationGroup="Submit" ErrorMessage="Please Enter LTAC Capacity"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-4" id="Div188" runat="server">
                            <label for="Name">
                                Lowest Insulation resistance of AC cables       
                            </label>
                            <asp:TextBox class="form-control" ID="txtLowestInsulationAC" onkeydown="return preventEnterSubmit(event)" onkeypress="return isNumberKey(event);" MaxLength="4" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ForeColor="Red" ControlToValidate="txtLowestInsulationAC" ValidationGroup="Submit" ErrorMessage="Please Enter Lowest Insulation Resistance of Ac"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="row" style="margin-top: 100px;" id="Declaration" runat="server" visible="false">
                    <%--  <div class="col-2"></div>--%>
                    <div class="col-12" style="text-align: center;">
                        <asp:CheckBox ID="CheckBox3" runat="server" OnCheckedChanged="CheckBox3_CheckedChanged" AutoPostBack="true" Text="&nbsp;I hereby declare that all information submitted as part of the form is true to my knowledge." Font-Size="Medium" Font-Bold="True" />
                        <br />
                        <label id="label2" runat="server" visible="false" style="color: red; font-size: 1.125rem">
                            Please Verify this.
                        </label>
                    </div>
                </div>
            </ContentTemplate>
       
        <div class="row" id="OTP" runat="server" visible="false">
            <div class="col-4"></div>
            <div class="col-4">
                <label>
                    Enter the OTP you received to Your Phone Number
                                            <samp style="color: red">* </samp>
                </label>
                <asp:TextBox class="form-control" ID="txtOTP" MaxLength="6" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator76" ControlToValidate="txtOTP" runat="server" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Enter OTP"></asp:RequiredFieldValidator>

            </div>
        </div>
        <div class="row">
            <div class="col-12">
            </div>

            <div class="col-12" style="text-align: center;">
                <asp:Button ID="BtnBack" runat="server" Text="Back" Visible="false" class="btn btn-primary mr-2" OnClick="BtnBack_Click" />
                <asp:Button ID="btnVerify" Text="Verify Details" Visible="false" runat="server" class="btn btn-primary mr-2" ValidationGroup="Submit" OnClick="btnVerify_Click" />
                <asp:Button ID="BtnSubmitGeneratingSet" Text="Generate Test Report" runat="server" ValidationGroup="Submit" class="btn btn-primary mr-2"
                    OnClick="BtnSubmitGeneratingSet_Click" />
            </div>
            <div class="col-4">
                <asp:HiddenField ID="hdn" Value="0" runat="server" />
            </div>
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
