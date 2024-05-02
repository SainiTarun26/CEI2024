<%@ Page Title="" Language="C#" MasterPageFile="~/Supervisor/Supervisor.Master" AutoEventWireup="true"  EnableEventValidation="false" CodeBehind="SubstationTestReport.aspx.cs" Inherits="CEIHaryana.Supervisor.SubstationTestReport" %>
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
      function preventZero(event) {
          var key = event.keyCode || event.charCode;
          var textboxValue = event.target.value;
          if (key === 48 && textboxValue.length === 0) { // Check if the pressed key is '0'
              event.preventDefault();
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
      input#ContentPlaceHolder1_txtapplication {
    display: block;
    width: 100%;
    padding: .375rem .75rem;
    font-size: 1rem;
    line-height: 1.5;
    color: #495057;
    background-color: #fff;
    background-clip: padding-box;
    border: 1px solid #ced4da;
    border-radius: .25rem;
    transition: border-color .15s ease-in-out, box-shadow .15s ease-in-out;
}
      input#ContentPlaceHolder1_txtid {
    display: block;
    width: 100%;
    padding: .375rem .75rem;
    font-size: 1rem;
    line-height: 1.5;
    color: #495057;
    background-color: #fff;
    background-clip: padding-box;
    border: 1px solid #ced4da;
    border-radius: .25rem;
    transition: border-color .15s ease-in-out, box-shadow .15s ease-in-out;
}
      input#ContentPlaceHolder1_txtInstallation {
    display: block;
    width: 100%;
    padding: .375rem .75rem;
    font-size: 1rem;
    line-height: 1.5;
    color: #495057;
    background-color: #fff;
    background-clip: padding-box;
    border: 1px solid #ced4da;
    border-radius: .25rem;
    transition: border-color .15s ease-in-out, box-shadow .15s ease-in-out;
}
      input#ContentPlaceHolder1_txtNOOfInstallation {
    display: block;
    width: 100%;
    padding: .375rem .75rem;
    font-size: 1rem;
    line-height: 1.5;
    color: #495057;
    background-color: #fff;
    background-clip: padding-box;
    border: 1px solid #ced4da;
    border-radius: .25rem;
    transition: border-color .15s ease-in-out, box-shadow .15s ease-in-out;
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
                     <h7 class="card-title fw-semibold mb-4" id="maincard">SUBSTATION TRANSFORMER TEST REPORT</h7>
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
                     <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; background:#d4d7ec; margin-bottom: 25px; border-radius: 10px; margin-top: 10px; padding-top: 10px; padding-bottom: 5px;">
                         <div class="row">
                                <div class="col-3" id="Div8" runat="server">
                                    <label for="Name">
                                        Applicant
            <samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtapplication" Enabled="false" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="width:100%"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtapplication" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Length of Line</asp:RequiredFieldValidator>

                                </div>
                                <div class="col-3" id="Div9" runat="server">
                                    <label for="Name">
                                        WorkIntimation ID
            <samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtid" Enabled="false" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" ></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator102" runat="server" ControlToValidate="txtid" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Length of Line</asp:RequiredFieldValidator>

                                </div>
                                <div class="col-3" id="Div10" runat="server">
                                    <label for="Name">
                                        Type of Installation
            <samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtInstallation" Enabled="false" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" ></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator103" runat="server" ControlToValidate="txtInstallation" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Length of Line</asp:RequiredFieldValidator>

                                </div>
                                <div class="col-3" id="Div12" runat="server">
                                    <label for="Name">
                                        No of Installations
            <samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtNOOfInstallation" Enabled="false" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" MaxLength="3" placeholder="" autocomplete="off" TabIndex="2" runat="server" ></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator104" runat="server" ControlToValidate="txtNOOfInstallation" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Length of Line</asp:RequiredFieldValidator>

                                </div>
                            </div>
                     </div>
                     <div class="row" style="margin-top: 10px;">
                         <div class="col-12" style="text-align: left;">
                             <h7 class="card-title fw-semibold mb-4" style="font-size: 20px !important;">Installation Details</h7>
                         </div>
                     </div>
                     <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                     
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
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <div class="row">
                            <div class="col-3" id="Div121" runat="server">
                                <label for="Voltage">
                                    Serial number of transformer  
                                        <samp style="color: red">* </samp>
                                </label>
                                <asp:TextBox class="form-control" AutoPostBack="true" ID="txtTransformerSerialNumber"  MaxLength="20" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="1" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rvftransformerSerialnumber" ForeColor="Red" ControlToValidate="txtTransformerSerialNumber" runat="server" ErrorMessage="Please Enter Serial Number" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-3">
                                <label>
                                    Capacity of transformer
                                        <samp style="color: red">* </samp>
                                </label>
                                <asp:DropDownList class="form-control  select-form select2" TabIndex="2" runat="server" AutoPostBack="true" ID="ddltransformerCapacity" selectionmode="Multiple" Style="width: 100% !important">
                                    <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="KVA"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="MVA"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" ControlToValidate="ddltransformerCapacity" runat="server" InitialValue="0" ErrorMessage="Please Select Transformer Capacity" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                <%-- <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlTransformerCapacity" selectionmode="Multiple" Style="width: 100% !important">
                                                        </asp:DropDownList>--%>
                            </div>
                            <div class="col-3" >
                                <label>
                                    Capacity of transformer 
                                        <samp style="color: red">* </samp>
                                </label>
                                <asp:TextBox class="form-control" AutoPostBack="true" OnTextChanged="txtTransformerCapacity_TextChanged" ID="txtTransformerCapacity" MaxLength="5" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="3" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" ControlToValidate="txtTransformerCapacity" runat="server" ErrorMessage="Please Enter Transformer Capacity" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                <%-- <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlTransformerCapacity" selectionmode="Multiple" Style="width: 100% !important">
                                                        </asp:DropDownList>--%>
                            </div>
                            <div class="col-3">
                                <label>
                                    Type of transformer
                                        <samp style="color: red">* </samp>
                                </label>
                                <asp:DropDownList class="form-control  select-form select2" TabIndex="4" runat="server" OnSelectedIndexChanged="ddltransformerType_SelectedIndexChanged" AutoPostBack="true" ID="ddltransformerType" selectionmode="Multiple" Style="width: 100% !important">
                                    <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="Oil"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="Dry"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ForeColor="Red" ControlToValidate="ddltransformerType" runat="server" ErrorMessage="Please SelectTransformerType" InitialValue="0" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div id="InCaseOfOil" runat="server" visible="false">
                            <div class="row">
                                <div class="col-3" id="PrimaryVoltageLevel" runat="server" Visible="false">
                                    <label for="Voltage">
                                        Primary voltage(in volte)  
                            <samp style="color: red">* </samp>
                                    </label>
                                       <asp:DropDownList class="form-control  select-form select2" TabIndex="4" runat="server"  AutoPostBack="true" ID="PrimaryVoltage" selectionmode="Multiple" Style="width: 100% !important">
                                </asp:DropDownList>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ForeColor="Red" ControlToValidate="PrimaryVoltage" runat="server" ErrorMessage="Please Select Primary Voltage" InitialValue="0" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                              </div>
                                <div class="col-3">
                                    <label for="Voltage">
                                        Secondary Voltage(in volte)  
                                        <samp style="color: red">* </samp>
                                    </label>
                                    <asp:DropDownList class="form-control  select-form select2" TabIndex="4" runat="server" AutoPostBack="true" ID="ddlSecondaryVoltage" selectionmode="Multiple" Style="width: 100% !important">
                                </asp:DropDownList>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ForeColor="Red" ControlToValidate="PrimaryVoltage" runat="server" ErrorMessage="Please Select Secondary Voltage" InitialValue="0" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                               </div>
                                <div id="Capacity" class="col-3" runat="server" visible="false">
                                    <label for="Voltage">
                                        Capacity of oil(in liters)  
                                        <samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" AutoPostBack="true" ID="txtOilCapacity" MaxLength="5" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="7" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ForeColor="Red" ControlToValidate="txtOilCapacity" runat="server" ErrorMessage="Please Enter Oil Capacity" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                </div>
                                <div id="BDV" class="col-3" runat="server" visible="false">
                                    <label for="Voltage">
                                        BDV level of oil Break down voltage  
                <samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" AutoPostBack="true" ID="txtOilBDV" MaxLength="3" onKeyPress="return isNumberKey(event);" onkeydown="return preventEnterSubmit(event)" placeholder="(in kv) " autocomplete="off" TabIndex="8" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ForeColor="Red" ControlToValidate="txtOilBDV" runat="server" ErrorMessage="Please Enter Oil BDV" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <label style="margin-bottom: 20px; font-size: 17px !important; font-weight: 700;">HT/LT side Insulation Resistance</label>
                            <div class="HTInsulationResistance">
                                <div class="row" style="margin-top: -15px;">
                                    <div class="col-4" id="Div124" runat="server">
                                        <label for="Voltage" style="margin-top: 10px;">
                                            HT side Insulation Resistance— HV/Earth
                                                        <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" AutoPostBack="true" onKeyPress="return isNumberKey(event);" ID="txtHTsideInsulation" MaxLength="5" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="9" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ForeColor="Red" ControlToValidate="txtHTsideInsulation" runat="server" ErrorMessage="Please Enter HTSideInsulation" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-4" style="margin-top:7px;">                                        
                                        <label for="Voltage">
                                            LT side Insulation Resistance—LV/Earth
                                            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" AutoPostBack="true" onKeyPress="return isNumberKey(event);" ID="txtLTSideInsulation" MaxLength="5" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="10" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ForeColor="Red" ControlToValidate="txtLTSideInsulation" runat="server" ErrorMessage="Please Enter LTSideInsulation" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-4" style="margin-top: -41px;">
                                        <br /> <br />
                                   <%--     <label style="margin-bottom: 0px; font-size: 1rem !important; font-weight: 600;">Lowest value between HT LT Side</label>--%>
                                        <label for="Voltage" style="margin-top: -15px;">
                                            Insulation Resistance between HT LT Side 
            <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" AutoPostBack="true" onKeyPress="return isNumberKey(event);" ID="txtLowestValue" MaxLength="5" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="11" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ForeColor="Red" ControlToValidate="txtLowestValue" runat="server" ErrorMessage="Please Enter Lowest Value" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-4">
                                       <label for="Voltage">
                                           Lightning Arrestor (LA) Location  
<samp style="color: red">* </samp>
                                       </label>
                                       <asp:DropDownList class="form-control  select-form select2" TabIndex="13" runat="server" AutoPostBack="true" ID="ddlLghtningArrestor" selectionmode="Multiple" Style="width: 100% !important" OnSelectedIndexChanged="ddlLghtningArrestor_SelectedIndexChanged">
                                           <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                           <asp:ListItem Value="1" Text="On HT side"></asp:ListItem>
                                           <asp:ListItem Value="2" Text="On LT side"></asp:ListItem>
                                           <asp:ListItem Value="3" Text="Other"></asp:ListItem>
                                       </asp:DropDownList>
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator101" ForeColor="Red" ControlToValidate="ddlLghtningArrestor" runat="server" ErrorMessage="Please Select (LA) Location" InitialValue="0" ValidationGroup="Submit"></asp:RequiredFieldValidator>

                                   </div>
                                </div>
                                <div class="row">                                    
                                    <div class="col-4" runat="server" id="OtherLaDiv" visible="false">
                                        <label for="Voltage">
                                            Other (LA) Location  
 <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" AutoPostBack="true" ID="txtLightningArrestor" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="12" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ForeColor="Red" ControlToValidate="txtLightningArrestor" runat="server" ErrorMessage="Please Enter Lightning Arrestor" ValidationGroup="Submit"></asp:RequiredFieldValidator>

                                    </div>
                                    <div class="col-4">
                                        <label>
                                            Type of HT (Primary Side/ Switch)<samp style="color: red"> * </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="13" runat="server" AutoPostBack="true" ID="ddlHTType" OnSelectedIndexChanged="ddlHTType_SelectedIndexChanged" selectionmode="Multiple" Style="width: 100% !important">
                                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="Breaker"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ForeColor="Red" ControlToValidate="ddlHTType" runat="server" ErrorMessage="Please Select HT Type" InitialValue="0" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                        <asp:DropDownList class="form-control  select-form select2" runat="server" AutoPostBack="true" ID="ddlBreaker" selectionmode="Multiple" Visible="false" Style="width: 100% !important">
                                            <asp:ListItem Value="1" Text="Breaker" Selected="True"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                     </div>
                                 </div>
                            <div id="TypeOfHTBreaker" runat="server" visible="false">
                                <div class="row">
                                    <div class="col-4">
                                        <label for="Voltage">
                                            Load breaking capacity of breaker   
                                                    <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" AutoPostBack="true"  ID="txtBreakerCapacity" onKeyPress="return isNumberKey(event);" MaxLength="4" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="15" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" ForeColor="Red" ControlToValidate="txtBreakerCapacity" runat="server" ErrorMessage="Please Enter Breaker Capacity" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-4">
                                        <label>
                                            Type of LT protection
                                                    <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="16" runat="server" AutoPostBack="true" ID="ddlLTProtection" OnSelectedIndexChanged="ddlLTProtection_SelectedIndexChanged" selectionmode="Multiple" Style="width: 100% !important">
                                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="Fuse Unit"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Breaker"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" ForeColor="Red" ControlToValidate="ddlLTProtection" runat="server" InitialValue="0" ErrorMessage="Please Select LT Protection" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-4" id="FuseUnit" runat="server" visible="false">
                                        <label for="Voltage">
                                            Capacity of individual fuse(IN AMPS)  
                                                    <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" AutoPostBack="true" ID="txtIndividualCapacity" onKeyPress="return isNumberKey(event);" MaxLength="4" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="18" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" ForeColor="Red" ControlToValidate="txtIndividualCapacity" runat="server" ErrorMessage="Please Enter Individual Capacity" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>

                            <div id="Breaker" runat="server" visible="false">
                                <div class="row">
                                    <div class="col-4" id="Div167" runat="server">
                                        <label for="Voltage">
                                            Capacity of LT Breaker(IN AMPS)  
                                                    <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" AutoPostBack="true" ID="txtLTBreakerCapacity" onKeyPress="return isNumberKey(event);" MaxLength="4" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" ForeColor="Red" ControlToValidate="txtLTBreakerCapacity" runat="server" ErrorMessage="Please Enter LT Breaker Capacity" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-4" id="Div168" runat="server">
                                        <label for="Voltage">
                                            Load Breaking Capacity of Breaker
                                                    <samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" AutoPostBack="true" ID="txtLoadBreakingCapacity" onKeyPress="return isNumberKey(event);" MaxLength="4" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" ForeColor="Red" ControlToValidate="txtLoadBreakingCapacity" runat="server" ErrorMessage="Please Enter Load Breaking Capacity" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                    </div>
                               <div class="col-4" id="Div169" runat="server">
       <label for="Voltage">
           Mean Sea Level of transformer plinth   
       </label>
       <asp:TextBox class="form-control" AutoPostBack="true" ID="txtSealLevelPlinth" onKeyPress="return isNumberKey(event);" MaxLength="5" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
       </div>
                                </div>
                            </div>
                               <div class="row" id="MeanSeaPlinth" runat="server" visible="false">
                                 
                                   </div>
                        </div>                        
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="row" style="margin-top: 50px;" id="Declaration" runat="server" visible="false">
                    <div class="col-12" style="text-align: center;">
                        <asp:CheckBox ID="CheckBox2" runat="server" OnCheckedChanged="CheckBox2_CheckedChanged" AutoPostBack="true" Text="&nbsp;I hereby declare that all information submitted as part of the form is true to my knowledge." Font-Size="Medium" Font-Bold="True" />
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
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator100" ControlToValidate="txtOTP" runat="server" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please Enter OTP"></asp:RequiredFieldValidator>
                                                           
                                    </div>
                                 </div>
                









                     </div> 
                     <div class="row" style="margin-top: 10px;">
    <div class="col-12" style="text-align: left;">
        <h7 class="card-title fw-semibold mb-4" style="font-size: 20px !important;">Earthing Details</h7>
    </div>
</div>
<div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px; padding-top: 10px; padding-bottom: 0px;">
                         
                     <div class="col-3">
                                        <label for="Name">
                                            Number of Earthing:
                                        <samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" TabIndex="14" runat="server" OnSelectedIndexChanged="ddlEarthingsubstation_SelectedIndexChanged" AutoPostBack="true" ID="ddlEarthingsubstation" selectionmode="Multiple" Style="width: 100% !important">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" ForeColor="Red" ControlToValidate="ddlEarthingsubstation" runat="server" ErrorMessage="Please Select Earthing No" InitialValue="0" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                    </div>
                     <div class="table-responsive pt-3" id="SubstationEarthingDiv" runat="server" visible="false">
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
                                                <div id="EarthingSubstation4" runat="server" visible="false">
                                                    <tr>
                                                        <td>1</td>
                                                        <td>
                                                            <div class="col-12">
                                                                <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlSubstationEarthing1" selectionmode="Multiple" Style="width: 100% !important">
                                                                    <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                                    <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                                                    <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                                                    <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator20" ForeColor="Red" ControlToValidate="ddlSubstationEarthing1" runat="server" ErrorMessage="Please Select Earthing Type" InitialValue="0" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div class="col-12">
                                                                <asp:TextBox class="form-control" ID="txtSubstationEarthing1" MaxLength="5" onKeyPress="return isNumberKey(event) && preventZero(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator22" ForeColor="Red" ControlToValidate="txtSubstationEarthing1" runat="server" ErrorMessage="Please Enter Value" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div class="col-12">
                                                                <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlUsedFor1" selectionmode="Multiple" Style="width: 100% !important" OnSelectedIndexChanged="ddlUsedFor1_SelectedIndexChanged">
                                                                    <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                                    <asp:ListItem Value="1" Text="Neutral Transformer"></asp:ListItem>
                                                                    <asp:ListItem Value="2" Text="Body Of Transformer"></asp:ListItem>
                                                                    <asp:ListItem Value="3" Text="LA's"></asp:ListItem>
                                                                    <asp:ListItem Value="4" Text="HT Panels"></asp:ListItem>
                                                                    <asp:ListItem Value="5" Text="LT Panels"></asp:ListItem>
                                                                    <asp:ListItem Value="6" Text="Fencing"></asp:ListItem>
                                                                    <asp:ListItem Value="7" Text="Neutral Of Generator"></asp:ListItem> 
                                                            <asp:ListItem Value="8" Text="Body Of Generator"></asp:ListItem> 
                                                            <asp:ListItem Value="9" Text="Other"></asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator21" ForeColor="Red" ControlToValidate="ddlUsedFor1" runat="server" ErrorMessage="Please Select Used For" InitialValue="0" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                            </div>
                                                            <div class="col-12">
                                                                <asp:TextBox class="form-control" ID="txtOtherEarthing1" MaxLength="50" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator99" ForeColor="Red" Visible="false" ControlToValidate="txtOtherEarthing1" runat="server" ErrorMessage="Please Enter Other Earthing" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>2</td>
                                                        <td>
                                                            <div class="col-12">
                                                                <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlSubstationEarthing2" selectionmode="Multiple" Style="width: 100% !important">
                                                                    <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                                    <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                                                    <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                                                    <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator24" ForeColor="Red" ControlToValidate="ddlSubstationEarthing2" runat="server" ErrorMessage="Please Select Earthing Type" InitialValue="0" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div class="col-12">
                                                                <asp:TextBox class="form-control" ID="txtSubstationEarthing2" MaxLength="5" onKeyPress="return isNumberKey(event) && preventZero(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator26" ForeColor="Red" ControlToValidate="txtSubstationEarthing2" runat="server" ErrorMessage="Please Enter Value" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div class="col-12">
                                                                <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" OnSelectedIndexChanged="ddlUsedFor2_SelectedIndexChanged" AutoPostBack="true" ID="ddlUsedFor2" selectionmode="Multiple" Style="width: 100% !important">
                                                                    <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                                    <asp:ListItem Value="1" Text="Neutral Transformer"></asp:ListItem>
                                                                    <asp:ListItem Value="2" Text="Body Of Transformer"></asp:ListItem>
                                                                    <asp:ListItem Value="3" Text="LA's"></asp:ListItem>
                                                                    <asp:ListItem Value="4" Text="HT Panels"></asp:ListItem>
                                                                    <asp:ListItem Value="5" Text="LT Panels"></asp:ListItem>
                                                                    <asp:ListItem Value="6" Text="Fencing"></asp:ListItem>
                                                                   <asp:ListItem Value="7" Text="Neutral Of Generator"></asp:ListItem> 
                                                            <asp:ListItem Value="8" Text="Body Of Generator"></asp:ListItem> 
                                                            <asp:ListItem Value="9" Text="Other"></asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator27" ForeColor="Red" ControlToValidate="ddlUsedFor2" runat="server" ErrorMessage="Please Select Used For" InitialValue="0" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                            </div>
                                                            <div class="col-12">
                                                                <asp:TextBox class="form-control" ID="txtOtherEarthing2" MaxLength="50" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator98" Visible="false" ForeColor="Red" ControlToValidate="txtOtherEarthing2" runat="server" ErrorMessage="Please Enter Other Earthing" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>3</td>
                                                        <td>
                                                            <div class="col-12">
                                                                <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlSubstationEarthing3" selectionmode="Multiple" Style="width: 100% !important">
                                                                    <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                                    <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                                                    <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                                                    <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator29" ForeColor="Red" ControlToValidate="ddlSubstationEarthing3" runat="server" ErrorMessage="Please Select Earthing Type" InitialValue="0" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div class="col-12">
                                                                <asp:TextBox class="form-control" ID="txtSubstationEarthing3" MaxLength="5" onKeyPress="return isNumberKey(event) && preventZero(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator30" ForeColor="Red" ControlToValidate="txtSubstationEarthing3" runat="server" ErrorMessage="Please Enter Value" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div class="col-12">
                                                                <asp:DropDownList class="form-control  select-form select2" TabIndex="6" OnSelectedIndexChanged="ddlUsedFor3_SelectedIndexChanged" runat="server" AutoPostBack="true" ID="ddlUsedFor3" selectionmode="Multiple" Style="width: 100% !important">
                                                                    <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                                    <asp:ListItem Value="1" Text="Neutral Transformer"></asp:ListItem>
                                                                    <asp:ListItem Value="2" Text="Body Of Transformer"></asp:ListItem>
                                                                    <asp:ListItem Value="3" Text="LA's"></asp:ListItem>
                                                                    <asp:ListItem Value="4" Text="HT Panels"></asp:ListItem>
                                                                    <asp:ListItem Value="5" Text="LT Panels"></asp:ListItem>
                                                                    <asp:ListItem Value="6" Text="Fencing"></asp:ListItem>
                                                                    <asp:ListItem Value="7" Text="Neutral Of Generator"></asp:ListItem> 
                                                            <asp:ListItem Value="8" Text="Body Of Generator"></asp:ListItem> 
                                                            <asp:ListItem Value="9" Text="Other"></asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator31" ForeColor="Red" ControlToValidate="ddlUsedFor3" runat="server" ErrorMessage="Please Select Used For" InitialValue="0" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                            </div>
                                                            <div class="col-12">
                                                                <asp:TextBox class="form-control" ID="txtOtherEarthing3" MaxLength="50" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator97" ForeColor="Red" Visible="false" ControlToValidate="txtOtherEarthing3" runat="server" ErrorMessage="Please Enter Other Earthing" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>4</td>
                                                        <td>
                                                            <div class="col-12" id="Div52" runat="server">
                                                                <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlSubstationEarthing4" selectionmode="Multiple" Style="width: 100% !important">
                                                                    <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                                    <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                                                    <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                                                    <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator32" ForeColor="Red" ControlToValidate="ddlSubstationEarthing4" runat="server" ErrorMessage="Please Select Earthing Type" InitialValue="0" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div class="col-12" id="Div53" runat="server">
                                                                <asp:TextBox class="form-control" ID="txtSubstationEarthing4" MaxLength="5" onKeyPress="return isNumberKey(event) && preventZero(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator33" ForeColor="Red" ControlToValidate="txtSubstationEarthing4" runat="server" ErrorMessage="Please Enter Value" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div class="col-12">
                                                                <asp:DropDownList class="form-control  select-form select2" OnSelectedIndexChanged="ddlUsedFor4_SelectedIndexChanged" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlUsedFor4" selectionmode="Multiple" Style="width: 100% !important">
                                                                    <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                                    <asp:ListItem Value="1" Text="Neutral Transformer"></asp:ListItem>
                                                                    <asp:ListItem Value="2" Text="Body Of Transformer"></asp:ListItem>
                                                                    <asp:ListItem Value="3" Text="LA's"></asp:ListItem>
                                                                    <asp:ListItem Value="4" Text="HT Panels"></asp:ListItem>
                                                                    <asp:ListItem Value="5" Text="LT Panels"></asp:ListItem>
                                                                    <asp:ListItem Value="6" Text="Fencing"></asp:ListItem>
                                                                    <asp:ListItem Value="7" Text="Neutral Of Generator"></asp:ListItem> 
                                                            <asp:ListItem Value="8" Text="Body Of Generator"></asp:ListItem> 
                                                            <asp:ListItem Value="9" Text="Other"></asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator34" ForeColor="Red" ControlToValidate="ddlUsedFor4" runat="server" ErrorMessage="Please Select Used For" InitialValue="0" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                            </div>
                                                            <div class="col-12">
                                                                <asp:TextBox class="form-control" ID="txtOtherEarthing4" MaxLength="50" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator96" ForeColor="Red" Visible="false" ControlToValidate="txtOtherEarthing4" runat="server" ErrorMessage="Please Enter Other Earthing" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </div>
                                                <tr id="EathingSubstation5" runat="server" visible="false">
                                                    <td>5</td>
                                                    <td>
                                                        <div class="col-12" id="Div54" runat="server">
                                                            <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlSubstationEarthing5" selectionmode="Multiple" Style="width: 100% !important">
                                                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator36" ForeColor="Red" ControlToValidate="ddlSubstationEarthing5" runat="server" ErrorMessage="Please Select Earthing Type" InitialValue="0" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div class="col-12">
                                                            <asp:TextBox class="form-control" ID="txtSubstationEarthing5" MaxLength="5" onKeyPress="return isNumberKey(event) && preventZero(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator37" ForeColor="Red" ControlToValidate="txtSubstationEarthing5" runat="server" ErrorMessage="Please Enter Value" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div class="col-12">
                                                            <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" OnSelectedIndexChanged="ddlUsedFor5_SelectedIndexChanged" AutoPostBack="true" ID="ddlUsedFor5" selectionmode="Multiple" Style="width: 100% !important">
                                                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="Neutral Transformer"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="Body Of Transformer"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="LA's"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="HT Panels"></asp:ListItem>
                                                                <asp:ListItem Value="5" Text="LT Panels"></asp:ListItem>
                                                                <asp:ListItem Value="6" Text="Fencing"></asp:ListItem>
                                                                <asp:ListItem Value="7" Text="Neutral Of Generator"></asp:ListItem> 
                                                            <asp:ListItem Value="8" Text="Body Of Generator"></asp:ListItem> 
                                                            <asp:ListItem Value="9" Text="Other"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator38" ForeColor="Red" ControlToValidate="ddlUsedFor5" runat="server" ErrorMessage="Please Select Used For" InitialValue="0" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="col-12">
                                                            <asp:TextBox class="form-control" ID="txtOtherEarthing5" MaxLength="50" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator95" ForeColor="Red" Visible="false" ControlToValidate="txtOtherEarthing5" runat="server" ErrorMessage="Please Enter Other Earthing" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr id="EathingSubstation6" runat="server" visible="false">
                                                    <td>6</td>
                                                    <td>
                                                        <div class="col-12">
                                                            <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlSubstationEarthing6" selectionmode="Multiple" Style="width: 100% !important">
                                                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator40" ForeColor="Red" ControlToValidate="ddlSubstationEarthing6" runat="server" ErrorMessage="Please Select Earthing Type" InitialValue="0" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div class="col-12">
                                                            <asp:TextBox class="form-control" ID="txtSubstationEarthing6" MaxLength="5" onKeyPress="return isNumberKey(event) && preventZero(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator41" ForeColor="Red" ControlToValidate="txtSubstationEarthing6" runat="server" ErrorMessage="Please Enter Value" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div class="col-12">
                                                            <asp:DropDownList class="form-control  select-form select2" TabIndex="6" OnSelectedIndexChanged="ddlUsedFor6_SelectedIndexChanged" runat="server" AutoPostBack="true" ID="ddlUsedFor6" selectionmode="Multiple" Style="width: 100% !important">
                                                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="Neutral Transformer"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="Body Of Transformer"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="LA's"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="HT Panels"></asp:ListItem>
                                                                <asp:ListItem Value="5" Text="LT Panels"></asp:ListItem>
                                                                <asp:ListItem Value="6" Text="Fencing"></asp:ListItem>
                                                               <asp:ListItem Value="7" Text="Neutral Of Generator"></asp:ListItem> 
                                                            <asp:ListItem Value="8" Text="Body Of Generator"></asp:ListItem> 
                                                            <asp:ListItem Value="9" Text="Other"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator42" ForeColor="Red" ControlToValidate="ddlUsedFor6" runat="server" ErrorMessage="Please Select Used For" InitialValue="0" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="col-12">
                                                            <asp:TextBox class="form-control" ID="txtOtherEarthing6" MaxLength="50" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator79" ForeColor="Red" Visible="false" ControlToValidate="txtOtherEarthing6" runat="server" ErrorMessage="Please Enter Other Earthing" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr id="EathingSubstation7" runat="server" visible="false">
                                                    <td>7</td>
                                                    <td>
                                                        <div class="col-12" id="Div68" runat="server">
                                                            <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlSubstationEarthing7" selectionmode="Multiple" Style="width: 100% !important">
                                                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator44" ForeColor="Red" ControlToValidate="ddlSubstationEarthing7" runat="server" ErrorMessage="Please Select Earthing Type" InitialValue="0" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div class="col-12">
                                                            <asp:TextBox class="form-control" ID="txtSubstationEarthing7" MaxLength="5" onKeyPress="return isNumberKey(event) && preventZero(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator45" ForeColor="Red" ControlToValidate="txtSubstationEarthing7" runat="server" ErrorMessage="Please Enter Value" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div class="col-12">
                                                            <asp:DropDownList class="form-control  select-form select2" OnSelectedIndexChanged="ddlUsedFor7_SelectedIndexChanged" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlUsedFor7" selectionmode="Multiple" Style="width: 100% !important">
                                                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="Neutral Transformer"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="Body Of Transformer"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="LA's"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="HT Panels"></asp:ListItem>
                                                                <asp:ListItem Value="5" Text="LT Panels"></asp:ListItem>
                                                                <asp:ListItem Value="6" Text="Fencing"></asp:ListItem>
                                                                <asp:ListItem Value="7" Text="Neutral Of Generator"></asp:ListItem> 
                                                            <asp:ListItem Value="8" Text="Body Of Generator"></asp:ListItem> 
                                                            <asp:ListItem Value="9" Text="Other"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator46" ForeColor="Red" ControlToValidate="ddlUsedFor7" runat="server" ErrorMessage="Please Select Used For" InitialValue="0" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="col-12">
                                                            <asp:TextBox class="form-control" ID="txtOtherEarthing7" MaxLength="50" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator75" ForeColor="Red" Visible="false" ControlToValidate="txtOtherEarthing7" runat="server" ErrorMessage="Please Enter Other Earthing" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr id="EathingSubstation8" runat="server" visible="false">
                                                    <td>8</td>
                                                    <td>
                                                        <div class="col-12">
                                                            <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlSubstationEarthing8" selectionmode="Multiple" Style="width: 100% !important">
                                                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator48" ForeColor="Red" ControlToValidate="ddlSubstationEarthing8" runat="server" ErrorMessage="Please Select Earthing Type" InitialValue="0" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div class="col-12">
                                                            <asp:TextBox class="form-control" ID="txtSubstationEarthing8" MaxLength="5" onKeyPress="return isNumberKey(event) && preventZero(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator49" ForeColor="Red" ControlToValidate="txtSubstationEarthing8" runat="server" ErrorMessage="Please Enter Value" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div class="col-12">
                                                            <asp:DropDownList class="form-control  select-form select2" TabIndex="6" OnSelectedIndexChanged="ddlUsedFor8_SelectedIndexChanged" runat="server" AutoPostBack="true" ID="ddlUsedFor8" selectionmode="Multiple" Style="width: 100% !important">
                                                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="Neutral Transformer"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="Body Of Transformer"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="LA's"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="HT Panels"></asp:ListItem>
                                                                <asp:ListItem Value="5" Text="LT Panels"></asp:ListItem>
                                                                <asp:ListItem Value="6" Text="Fencing"></asp:ListItem>
                                                                <asp:ListItem Value="7" Text="Neutral Of Generator"></asp:ListItem> 
                                                            <asp:ListItem Value="8" Text="Body Of Generator"></asp:ListItem> 
                                                            <asp:ListItem Value="9" Text="Other"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator50" ForeColor="Red" ControlToValidate="ddlUsedFor8" runat="server" ErrorMessage="Please Select Used For" InitialValue="0" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="col-12">
                                                            <asp:TextBox class="form-control" ID="txtOtherEarthing8" MaxLength="50" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator71" ForeColor="Red" Visible="false" ControlToValidate="txtOtherEarthing8" runat="server" ErrorMessage="Please Enter Other Earthing" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr id="EathingSubstation9" runat="server" visible="false">
                                                    <td>9</td>
                                                    <td>
                                                        <div class="col-12">
                                                            <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlSubstationEarthing9" selectionmode="Multiple" Style="width: 100% !important">
                                                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator52" ForeColor="Red" ControlToValidate="ddlSubstationEarthing9" runat="server" ErrorMessage="Please Select Earthing Type" InitialValue="0" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div class="col-12">
                                                            <asp:TextBox class="form-control" ID="txtSubstationEarthing9" MaxLength="5" onKeyPress="return isNumberKey(event) && preventZero(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator53" ForeColor="Red" ControlToValidate="txtSubstationEarthing9" runat="server" ErrorMessage="Please Enter Value" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div class="col-12">
                                                            <asp:DropDownList class="form-control  select-form select2" OnSelectedIndexChanged="ddlUsedFor9_SelectedIndexChanged" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlUsedFor9" selectionmode="Multiple" Style="width: 100% !important">
                                                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="Neutral Transformer"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="Body Of Transformer"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="LA's"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="HT Panels"></asp:ListItem>
                                                                <asp:ListItem Value="5" Text="LT Panels"></asp:ListItem>
                                                                <asp:ListItem Value="6" Text="Fencing"></asp:ListItem>
                                                                <asp:ListItem Value="7" Text="Neutral Of Generator"></asp:ListItem> 
                                                            <asp:ListItem Value="8" Text="Body Of Generator"></asp:ListItem> 
                                                            <asp:ListItem Value="9" Text="Other"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator54" ForeColor="Red" ControlToValidate="ddlUsedFor9" runat="server" ErrorMessage="Please Select Used For" InitialValue="0" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="col-12">
                                                            <asp:TextBox class="form-control" ID="txtOtherEarthing9" MaxLength="50" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator67" ForeColor="Red" Visible="false" ControlToValidate="txtOtherEarthing9" runat="server" ErrorMessage="Please Enter Other Earthing" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr id="EathingSubstation10" runat="server" visible="false">
                                                    <td>10</td>
                                                    <td>
                                                        <div class="col-12">
                                                            <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlSubstationEarthing10" selectionmode="Multiple" Style="width: 100% !important">
                                                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator56" ForeColor="Red" ControlToValidate="ddlSubstationEarthing10" runat="server" ErrorMessage="Please Select Earthing Type" InitialValue="0" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div class="col-12">
                                                            <asp:TextBox class="form-control" ID="txtSubstationEarthing10" MaxLength="5" onKeyPress="return isNumberKey(event) && preventZero(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator57" ForeColor="Red" ControlToValidate="txtSubstationEarthing10" runat="server" ErrorMessage="Please Enter Value" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div class="col-12">
                                                            <asp:DropDownList class="form-control  select-form select2" OnSelectedIndexChanged="ddlUsedFor10_SelectedIndexChanged" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlUsedFor10" selectionmode="Multiple" Style="width: 100% !important">
                                                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="Neutral Transformer"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="Body Of Transformer"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="LA's"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="HT Panels"></asp:ListItem>
                                                                <asp:ListItem Value="5" Text="LT Panels"></asp:ListItem>
                                                                <asp:ListItem Value="6" Text="Fencing"></asp:ListItem>
                                                                <asp:ListItem Value="7" Text="Neutral Of Generator"></asp:ListItem> 
                                                            <asp:ListItem Value="8" Text="Body Of Generator"></asp:ListItem> 
                                                            <asp:ListItem Value="9" Text="Other"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator58" ForeColor="Red" ControlToValidate="ddlUsedFor10" runat="server" ErrorMessage="Please Select Used For" InitialValue="0" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="col-12">
                                                            <asp:TextBox class="form-control" ID="txtOtherEarthing10" MaxLength="50" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator63" ForeColor="Red" Visible="false" ControlToValidate="txtOtherEarthing10" runat="server" ErrorMessage="Please Enter Other Earthing" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr id="EathingSubstation11" runat="server" visible="false">
                                                    <td>11</td>
                                                    <td>
                                                        <div class="col-12">
                                                            <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlSubstationEarthing11" selectionmode="Multiple" Style="width: 100% !important">
                                                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator60" ForeColor="Red" ControlToValidate="ddlSubstationEarthing11" runat="server" ErrorMessage="Please Select Earthing Type" InitialValue="0" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div class="col-12">
                                                            <asp:TextBox class="form-control" ID="txtSubstationEarthing11" MaxLength="5" onKeyPress="return isNumberKey(event) && preventZero(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator61" ForeColor="Red" ControlToValidate="txtSubstationEarthing11" runat="server" ErrorMessage="Please Enter Value" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div class="col-12">
                                                            <asp:DropDownList class="form-control  select-form select2" OnSelectedIndexChanged="ddlUsedFor11_SelectedIndexChanged" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlUsedFor11" selectionmode="Multiple" Style="width: 100% !important">
                                                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="Neutral Transformer"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="Body Of Transformer"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="LA's"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="HT Panels"></asp:ListItem>
                                                                <asp:ListItem Value="5" Text="LT Panels"></asp:ListItem>
                                                                <asp:ListItem Value="6" Text="Fencing"></asp:ListItem>
                                                                <asp:ListItem Value="7" Text="Neutral Of Generator"></asp:ListItem> 
                                                            <asp:ListItem Value="8" Text="Body Of Generator"></asp:ListItem> 
                                                            <asp:ListItem Value="9" Text="Other"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator62" ForeColor="Red" ControlToValidate="ddlUsedFor11" runat="server" ErrorMessage="Please Select Used For" InitialValue="0" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="col-12">
                                                            <asp:TextBox class="form-control" ID="txtOtherEarthing11" MaxLength="50" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator59" ForeColor="Red" Visible="false" ControlToValidate="txtOtherEarthing11" runat="server" ErrorMessage="Please Enter Other Earthing" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr id="EathingSubstation12" runat="server" visible="false">
                                                    <td>12</td>
                                                    <td>
                                                        <div class="col-12">
                                                            <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlSubstationEarthing12" selectionmode="Multiple" Style="width: 100% !important">
                                                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator64" ForeColor="Red" ControlToValidate="ddlSubstationEarthing12" runat="server" ErrorMessage="Please Select Earthing Type" InitialValue="0" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div class="col-12">
                                                            <asp:TextBox class="form-control" ID="txtSubstationEarthing12" MaxLength="5" onKeyPress="return isNumberKey(event) && preventZero(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator65" ForeColor="Red" ControlToValidate="txtSubstationEarthing12" runat="server" ErrorMessage="Please Enter Value" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div class="col-12">
                                                            <asp:DropDownList class="form-control  select-form select2" TabIndex="6" OnSelectedIndexChanged="ddlUsedFor12_SelectedIndexChanged" runat="server" AutoPostBack="true" ID="ddlUsedFor12" selectionmode="Multiple" Style="width: 100% !important">
                                                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="Neutral Transformer"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="Body Of Transformer"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="LA's"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="HT Panels"></asp:ListItem>
                                                                <asp:ListItem Value="5" Text="LT Panels"></asp:ListItem>
                                                                <asp:ListItem Value="6" Text="Fencing"></asp:ListItem>
                                                                <asp:ListItem Value="7" Text="Neutral Of Generator"></asp:ListItem> 
                                                            <asp:ListItem Value="8" Text="Body Of Generator"></asp:ListItem> 
                                                            <asp:ListItem Value="9" Text="Other"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator66" ForeColor="Red" ControlToValidate="ddlUsedFor12" runat="server" ErrorMessage="Please Select Used For" InitialValue="0" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="col-12">
                                                            <asp:TextBox class="form-control" ID="txtOtherEarthing12" MaxLength="50" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator55" ForeColor="Red" Visible="false" ControlToValidate="txtOtherEarthing12" runat="server" ErrorMessage="Please Enter Other Earthing" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr id="EathingSubstation13" runat="server" visible="false">
                                                    <td>13</td>
                                                    <td>
                                                        <div class="col-12">
                                                            <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlSubstationEarthing13" selectionmode="Multiple" Style="width: 100% !important">
                                                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator68" ForeColor="Red" ControlToValidate="ddlSubstationEarthing13" runat="server" ErrorMessage="Please Select Earthing Type" InitialValue="0" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div class="col-12">
                                                            <asp:TextBox class="form-control" ID="txtSubstationEarthing13" MaxLength="5" onKeyPress="return isNumberKey(event) && preventZero(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator69" ForeColor="Red" ControlToValidate="txtSubstationEarthing13" runat="server" ErrorMessage="Please Enter Value" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div class="col-12">
                                                            <asp:DropDownList class="form-control  select-form select2" OnSelectedIndexChanged="ddlUsedFor13_SelectedIndexChanged" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlUsedFor13" selectionmode="Multiple" Style="width: 100% !important">
                                                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="Neutral Transformer"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="Body Of Transformer"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="LA's"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="HT Panels"></asp:ListItem>
                                                                <asp:ListItem Value="5" Text="LT Panels"></asp:ListItem>
                                                                <asp:ListItem Value="6" Text="Fencing"></asp:ListItem>
                                                               <asp:ListItem Value="7" Text="Neutral Of Generator"></asp:ListItem> 
                                                            <asp:ListItem Value="8" Text="Body Of Generator"></asp:ListItem> 
                                                            <asp:ListItem Value="9" Text="Other"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator70" ForeColor="Red" ControlToValidate="ddlUsedFor13" runat="server" ErrorMessage="Please Select Used For" InitialValue="0" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="col-12">
                                                            <asp:TextBox class="form-control" ID="txtOtherEarthing13" MaxLength="50" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator51" ForeColor="Red" Visible="false" ControlToValidate="txtOtherEarthing13" runat="server" ErrorMessage="Please Enter Other Earthing" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr id="EathingSubstation14" runat="server" visible="false">
                                                    <td>14</td>
                                                    <td>
                                                        <div class="col-12">
                                                            <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlSubstationEarthing14" selectionmode="Multiple" Style="width: 100% !important">
                                                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator72" ForeColor="Red" ControlToValidate="ddlSubstationEarthing14" runat="server" ErrorMessage="Please Select Earthing Type" InitialValue="0" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div class="col-12">
                                                            <asp:TextBox class="form-control" ID="txtSubstationEarthing14" MaxLength="5" onKeyPress="return isNumberKey(event) && preventZero(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator73" ForeColor="Red" ControlToValidate="txtSubstationEarthing14" runat="server" ErrorMessage="Please Enter Value" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div class="col-12">
                                                            <asp:DropDownList class="form-control  select-form select2" TabIndex="6" OnSelectedIndexChanged="ddlUsedFor14_SelectedIndexChanged" runat="server" AutoPostBack="true" ID="ddlUsedFor14" selectionmode="Multiple" Style="width: 100% !important">
                                                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="Neutral Transformer"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="Body Of Transformer"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="LA's"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="HT Panels"></asp:ListItem>
                                                                <asp:ListItem Value="5" Text="LT Panels"></asp:ListItem>
                                                                <asp:ListItem Value="6" Text="Fencing"></asp:ListItem>
                                                                <asp:ListItem Value="7" Text="Neutral Of Generator"></asp:ListItem> 
                                                            <asp:ListItem Value="8" Text="Body Of Generator"></asp:ListItem> 
                                                            <asp:ListItem Value="9" Text="Other"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator74" ForeColor="Red" ControlToValidate="ddlUsedFor14" runat="server" ErrorMessage="Please Select Used For" InitialValue="0" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="col-12">
                                                            <asp:TextBox class="form-control" ID="txtOtherEarthing14" MaxLength="50" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator47" ForeColor="Red" Visible="false" ControlToValidate="txtOtherEarthing14" runat="server" ErrorMessage="Please Enter Other Earthing" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr id="EathingSubstation15" runat="server" visible="false">
                                                    <td>15</td>
                                                    <td>
                                                        <div class="col-12">
                                                            <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlSubstationEarthing15" selectionmode="Multiple" Style="width: 100% !important">
                                                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator76" ForeColor="Red" ControlToValidate="ddlSubstationEarthing15" runat="server" ErrorMessage="Please Select Earthing Type" InitialValue="0" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div class="col-12">
                                                            <asp:TextBox class="form-control" ID="txtSubstationEarthing15" MaxLength="5" onKeyPress="return isNumberKey(event) && preventZero(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator77" ForeColor="Red" ControlToValidate="txtSubstationEarthing15" runat="server" ErrorMessage="Please Enter Value" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div class="col-12">
                                                            <asp:DropDownList class="form-control  select-form select2" OnSelectedIndexChanged="ddlUsedFor15_SelectedIndexChanged" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlUsedFor15" selectionmode="Multiple" Style="width: 100% !important">
                                                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="Neutral Transformer"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="Body Of Transformer"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="LA's"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="HT Panels"></asp:ListItem>
                                                                <asp:ListItem Value="5" Text="LT Panels"></asp:ListItem>
                                                                <asp:ListItem Value="6" Text="Fencing"></asp:ListItem>
                                                                <asp:ListItem Value="7" Text="Neutral Of Generator"></asp:ListItem> 
                                                            <asp:ListItem Value="8" Text="Body Of Generator"></asp:ListItem> 
                                                            <asp:ListItem Value="9" Text="Other"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator78" ForeColor="Red" ControlToValidate="ddlUsedFor15" runat="server" ErrorMessage="Please Select Used For" InitialValue="0" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="col-12">
                                                            <asp:TextBox class="form-control" ID="txtOtherEarthing15" MaxLength="50" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator23" ForeColor="Red" Visible="false" ControlToValidate="txtOtherEarthing15" runat="server" ErrorMessage="Please Enter Other Earthing" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr id="EathingSubstation16" runat="server" visible="false">
                                                    <td>16</td>
                                                    <td>
                                                        <div class="col-12">
                                                            <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlSubstationEarthing16" selectionmode="Multiple" Style="width: 100% !important">
                                                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator80" ForeColor="Red" ControlToValidate="ddlSubstationEarthing16" runat="server" ErrorMessage="Please Select Earthing Type" InitialValue="0" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div class="col-12">
                                                            <asp:TextBox class="form-control" ID="txtSubstationEarthing16" MaxLength="5" onKeyPress="return isNumberKey(event) && preventZero(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator81" ForeColor="Red" ControlToValidate="txtSubstationEarthing16" runat="server" ErrorMessage="Please Enter Value" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div class="col-12">
                                                            <asp:DropDownList class="form-control  select-form select2" OnSelectedIndexChanged="ddlUsedFor16_SelectedIndexChanged" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlUsedFor16" selectionmode="Multiple" Style="width: 100% !important">
                                                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="Neutral Transformer"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="Body Of Transformer"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="LA's"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="HT Panels"></asp:ListItem>
                                                                <asp:ListItem Value="5" Text="LT Panels"></asp:ListItem>
                                                                <asp:ListItem Value="6" Text="Fencing"></asp:ListItem>
                                                                <asp:ListItem Value="7" Text="Neutral Of Generator"></asp:ListItem> 
                                                            <asp:ListItem Value="8" Text="Body Of Generator"></asp:ListItem> 
                                                            <asp:ListItem Value="9" Text="Other"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator82" ForeColor="Red" ControlToValidate="ddlUsedFor16" runat="server" ErrorMessage="Please Select Used For" InitialValue="0" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="col-12">
                                                            <asp:TextBox class="form-control" ID="txtOtherEarthing16" onkeydown="return preventEnterSubmit(event)" MaxLength="50" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator25" Visible="false" ForeColor="Red" ControlToValidate="txtOtherEarthing16" runat="server" ErrorMessage="Please Enter Other Earthing" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr id="EathingSubstation17" runat="server" visible="false">
                                                    <td>17
                                                    </td>
                                                    <td>
                                                        <div class="col-12">
                                                            <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlSubstationEarthing17" selectionmode="Multiple" Style="width: 100% !important">
                                                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator83" ForeColor="Red" ControlToValidate="ddlSubstationEarthing17" runat="server" ErrorMessage="Please Select Earthing Type" InitialValue="0" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div class="col-12">
                                                            <asp:TextBox class="form-control" ID="txtSubstationEarthing17" MaxLength="5" onKeyPress="return isNumberKey(event) && preventZero(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator84" ForeColor="Red" ControlToValidate="txtSubstationEarthing17" runat="server" ErrorMessage="Please Enter Value " ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div class="col-12">
                                                            <asp:DropDownList class="form-control  select-form select2" TabIndex="6" OnSelectedIndexChanged="ddlUsedFor17_SelectedIndexChanged" runat="server" AutoPostBack="true" ID="ddlUsedFor17" selectionmode="Multiple" Style="width: 100% !important">
                                                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="Neutral Transformer"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="Body Of Transformer"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="LA's"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="HT Panels"></asp:ListItem>
                                                                <asp:ListItem Value="5" Text="LT Panels"></asp:ListItem>
                                                                <asp:ListItem Value="6" Text="Fencing"></asp:ListItem>
                                                                <asp:ListItem Value="7" Text="Neutral Of Generator"></asp:ListItem> 
                                                            <asp:ListItem Value="8" Text="Body Of Generator"></asp:ListItem> 
                                                            <asp:ListItem Value="9" Text="Other"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator85" ForeColor="Red" ControlToValidate="ddlUsedFor17" runat="server" ErrorMessage="Please Select  Used For" InitialValue="0" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="col-12">
                                                            <asp:TextBox class="form-control" ID="txtOtherEarthing17" onkeydown="return preventEnterSubmit(event)" MaxLength="50" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator28" Visible="false" ForeColor="Red" ControlToValidate="txtOtherEarthing17" runat="server" ErrorMessage="Please Enter Other Earthing" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr id="EathingSubstation18" runat="server" visible="false">
                                                    <td>18</td>
                                                    <td>
                                                        <div class="col-12">
                                                            <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlSubstationEarthing18" selectionmode="Multiple" Style="width: 100% !important">
                                                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator86" ForeColor="Red" ControlToValidate="ddlSubstationEarthing18" runat="server" ErrorMessage="Please Select Earthing Type" InitialValue="0" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div class="col-12">
                                                            <asp:TextBox class="form-control" ID="txtSubstationEarthing18" MaxLength="5" onKeyPress="return isNumberKey(event) && preventZero(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator87" ForeColor="Red" ControlToValidate="txtSubstationEarthing18" runat="server" ErrorMessage="Please Enter Value" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div class="col-12">
                                                            <asp:DropDownList class="form-control  select-form select2" OnSelectedIndexChanged="ddlUsedFor18_SelectedIndexChanged" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlUsedFor18" selectionmode="Multiple" Style="width: 100% !important">
                                                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="Neutral Transformer"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="Body Of Transformer"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="LA's"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="HT Panels"></asp:ListItem>
                                                                <asp:ListItem Value="5" Text="LT Panels"></asp:ListItem>
                                                                <asp:ListItem Value="6" Text="Fencing"></asp:ListItem>
                                                                <asp:ListItem Value="7" Text="Neutral Of Generator"></asp:ListItem> 
                                                            <asp:ListItem Value="8" Text="Body Of Generator"></asp:ListItem> 
                                                            <asp:ListItem Value="9" Text="Other"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator88" ForeColor="Red" ControlToValidate="ddlUsedFor18" runat="server" ErrorMessage="Please Select Used For" InitialValue="0" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="col-12">
                                                            <asp:TextBox class="form-control" ID="txtOtherEarthing18" onkeydown="return preventEnterSubmit(event)" MaxLength="50" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator35" Visible="false" ForeColor="Red" ControlToValidate="txtOtherEarthing18" runat="server" ErrorMessage="Please Enter Other Earthing" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr id="EathingSubstation19" runat="server" visible="false">
                                                    <td>19</td>
                                                    <td>
                                                        <div class="col-12">
                                                            <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlSubstationEarthing19" selectionmode="Multiple" Style="width: 100% !important">
                                                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator89" ForeColor="Red" ControlToValidate="ddlSubstationEarthing19" runat="server" ErrorMessage="Please Select Earthing Type" InitialValue="0" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div class="col-12">
                                                            <asp:TextBox class="form-control" ID="txtSubstationEarthing19" MaxLength="5" onKeyPress="return isNumberKey(event) && preventZero(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator90" ForeColor="Red" ControlToValidate="txtSubstationEarthing19" runat="server" ErrorMessage="Please Enter Value" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div class="col-12">
                                                            <asp:DropDownList class="form-control  select-form select2" OnSelectedIndexChanged="ddlUsedFor19_SelectedIndexChanged" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlUsedFor19" selectionmode="Multiple" Style="width: 100% !important">
                                                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="Neutral Transformer"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="Body Of Transformer"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="LA's"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="HT Panels"></asp:ListItem>
                                                                <asp:ListItem Value="5" Text="LT Panels"></asp:ListItem>
                                                                <asp:ListItem Value="6" Text="Fencing"></asp:ListItem>
                                                                <asp:ListItem Value="7" Text="Neutral Of Generator"></asp:ListItem> 
                                                            <asp:ListItem Value="8" Text="Body Of Generator"></asp:ListItem> 
                                                            <asp:ListItem Value="9" Text="Other"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator91" ForeColor="Red" ControlToValidate="ddlUsedFor19" runat="server" ErrorMessage="Please Select Used For" InitialValue="0" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="col-12">
                                                            <asp:TextBox class="form-control" ID="txtOtherEarthing19" onkeydown="return preventEnterSubmit(event)" MaxLength="50" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator39" Visible="false" ForeColor="Red" ControlToValidate="txtOtherEarthing19" runat="server" ErrorMessage="Please Enter Other Earthing" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr id="EathingSubstation20" runat="server" visible="false">
                                                    <td>2</td>
                                                    <td>
                                                        <div class="col-12">
                                                            <asp:DropDownList class="form-control  select-form select2" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlSubstationEarthing20" selectionmode="Multiple" Style="width: 100% !important">
                                                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="Rode"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="Pipe"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="Plate"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator92" ForeColor="Red" ControlToValidate="ddlSubstationEarthing20" runat="server" ErrorMessage="Please Select Earthing Type" InitialValue="0" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div class="col-12">
                                                            <asp:TextBox class="form-control" ID="txtSubstationEarthing20" MaxLength="5" onKeyPress="return isNumberKey(event) && preventZero(event);" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator93" ForeColor="Red" ControlToValidate="txtSubstationEarthing20" runat="server" ErrorMessage="Please Enter Value" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div class="col-12">
                                                            <asp:DropDownList class="form-control  select-form select2" OnSelectedIndexChanged="ddlUsedFor20_SelectedIndexChanged" TabIndex="6" runat="server" AutoPostBack="true" ID="ddlUsedFor20" selectionmode="Multiple" Style="width: 100% !important">
                                                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="Neutral Transformer"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="Body Of Transformer"></asp:ListItem>
                                                                <asp:ListItem Value="3" Text="LA's"></asp:ListItem>
                                                                <asp:ListItem Value="4" Text="HT Panels"></asp:ListItem>
                                                                <asp:ListItem Value="5" Text="LT Panels"></asp:ListItem>
                                                                <asp:ListItem Value="6" Text="Fencing"></asp:ListItem>
                                                                <asp:ListItem Value="7" Text="Neutral Of Generator"></asp:ListItem> 
                                                            <asp:ListItem Value="8" Text="Body Of Generator"></asp:ListItem> 
                                                            <asp:ListItem Value="9" Text="Other"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator94" ForeColor="Red" ControlToValidate="ddlUsedFor20" runat="server" ErrorMessage="Please Select Used For" InitialValue="0" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="col-12">
                                                            <asp:TextBox class="form-control" ID="txtOtherEarthing20" onkeydown="return preventEnterSubmit(event)" MaxLength="50" placeholder="" autocomplete="off" TabIndex="2" runat="server" Visible="false" Style="margin-left: 18px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator43" Visible="false" ForeColor="Red" ControlToValidate="txtOtherEarthing20" runat="server" ErrorMessage="Please Enter Other Earthing" ValidationGroup="Submit"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
    </div>

                      <div class="row" style="margin-left: 1%; margin-bottom: 20px;">
                     <asp:CheckBox ID="Check" runat="server" TabIndex="24" />&nbsp;
                         <text>
                              I hereby declare that the information furnished in the application is correct.
                        </text>
                    </div>
                     <div class="row">
    <div class="col-4"></div>
    <div class="col-4" style="text-align: center;">
        <asp:Button ID="BtnBack" runat="server" Text="Back" Visible="false" class="btn btn-primary mr-2" OnClick="BtnBack_Click" />
         <asp:Button ID="btnVerify" Text="Verify Details" Visible="false" runat="server" class="btn btn-primary mr-2" ValidationGroup="Submit" OnClick="btnVerify_Click" />
        <asp:Button ID="BtnSubmitSubstation" Text="Submit" runat="server" ValidationGroup="Submit" class="btn btn-primary mr-2"
            OnClick="BtnSubmitSubstation_Click" />
    </div>
    <div class="col-4">
        <asp:HiddenField ID="hdn" Value="0" runat="server" />
        <asp:TextBox class="form-control" AutoPostBack="true" ID="txtValue" Visible="false" MaxLength="10" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>

    </div>
</div>
                 </ContentTemplate>
                 <Triggers>
                 
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
     <script type="text/javascript">
         function alertWithRedirectdata() {
             if (confirm('Test Report Submitted Successfully')) {
                 window.location.href = "/Supervisor/InstallationDetails.aspx";
             } else {
             }
         }
     </script>
</asp:Content>
