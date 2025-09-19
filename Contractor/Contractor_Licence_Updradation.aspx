<%@ Page Title="" Language="C#" MasterPageFile="~/Contractor/Contractor.Master" AutoEventWireup="true" CodeBehind="Contractor_Licence_Updradation.aspx.cs" Inherits="CEIHaryana.Contractor.Contractor_Licence_Updradation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="shortcut icon" type="image/png" href="/css2/style.min.css" />
    <link rel="stylesheet" href="/css2/style.css" />
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css" />
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.7.2/font/bootstrap-icons.css" rel="stylesheet" />
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <!------ Include the above in your HEAD tag ---------->
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>

    <!---------------------   Dropdown With Search Option   ---------------------->
    <%-- <link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/css/select2.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/js/select2.min.js"></script>--%>

    <link href="ScriptCalendar/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="ScriptCalender/jquery-1.11.0.min.js"></script>
    <script type="text/javascript" src="ScriptCalender/jquery-ui.min.js"></script>
    <style>
          textarea#txtPenalities {
      height: 100px;
      margin-top: 19px;
  }

  #penaltyContainer {
      min-height: 100px;
      padding: 8px;
      border: 1px solid #ced4da;
      border-radius: 5px;
      display: flex;
      flex-wrap: wrap;
  }

  .penalty-tag {
      background: white;
      border: 1px solid black;
      color: black;
      padding: 10px 10px;
      border-radius: 20px;
      margin: 4px;
      display: flex;
      align-items: center;
      font-size: 14px;
      height: 30px;
  }

      .penalty-tag span.remove-icon {
          cursor: pointer;
          margin-left: 10px;
          font-weight: bold;
          color: red;
          font-size: 11px;
          background: #cbcbcb;
          border-radius: 40px;
          height: 16px;
          padding-left: 4px;
          padding-right: 4px;
      }

        .modal-backdrop.show {
    opacity: .5;
    display: none;
}
        button, input, optgroup, select, textarea {
            margin: 0;
            font-family: inherit;
            font-size: inherit;
            line-height: inherit;
            display: block;
            width: 100%;
            padding: 0px 0px 0px 5px;
            font-size: 1rem;
            line-height: 1.5;
            color: #495057;
            background-color: #fff;
            background-clip: padding-box;
            border: 1px solid #ced4da;
            border-radius: .25rem;
            transition: border-color .15s ease-in-out, box-shadow .15s ease-in-out;
            height: 30px;
            box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
            margin-left: 0px !important;
            height: 30px;
            font-size: 12px !important;
        }

        .glyphicon {
            position: relative;
            top: 1px;
            display: inline-block;
            font-family: 'Glyphicons Halflings';
            -webkit-font-smoothing: antialiased;
            font-style: normal;
            font-weight: normal;
            line-height: 1
        }

        .glyphicon-search:before {
            content: "\e003"
        }

        .table {
            width: 100%;
            max-width: 100%;
            margin-bottom: 0rem !important;
            background-color: transparent;
        }

        select#ContentPlaceHolder1_ddlTraningUnder {
            display: block;
            width: 100%;
            font-size: 13PX;
            line-height: 1.5;
            color: #495057;
            background-color: #fff;
            background-clip: padding-box;
            border: 1px solid #ced4da;
            border-radius: 0.25rem;
            transition: border-color .15s ease-in-out,box-shadow .15s ease-in-out;
            height: 30px;
        }

        select#ContentPlaceHolder1_ddlExperiene {
            display: block;
            width: 100%;
            font-size: 13PX;
            line-height: 1.5;
            color: #495057;
            background-color: #fff;
            background-clip: padding-box;
            border: 1px solid #ced4da;
            border-radius: 0.25rem;
            transition: border-color .15s ease-in-out,box-shadow .15s ease-in-out;
            height: 30px;
        }

        .pt-3, .py-3 {
            padding-top: 0rem !important;
        }

        .table td, .jsgrid .jsgrid-table td {
            font-size: 13px;
            padding: 14px 15px 0px 15px;
        }

        input#ContentPlaceHolder1_RadioButtonList1_0 {
            margin-right: 5px;
        }

        input#ContentPlaceHolder1_RadioButtonList1_1 {
            margin-left: 10px;
            margin-right: 5px;
        }

        input#ContentPlaceHolder1_RadioButtonList3_0 {
            margin-right: 5px;
        }

        input#ContentPlaceHolder1_RadioButtonList3_1 {
            margin-left: 10px;
            margin-right: 5px;
        }

        input#ContentPlaceHolder1_RadioButtonList2_1 {
            margin-left: 10px;
            margin-right: 3px;
        }

        input#ContentPlaceHolder1_RadioButtonList2_0 {
            margin-left: 10px;
            margin-right: 3px;
        }

        .col-md-4 {
            top: 0px;
            left: 0px;
        }

        .form-control {
            box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
            margin-left: 0px !important;
            height: 30px;
            font-size: 12px !important;
        }

        select.form-control {
            box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
            margin-left: 0px !important;
            height: 30px !important;
            font-size: 12px !important;
        }

        label {
            font-size: 13px;
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
            margin-top: 50px !important;
        }

        input#ContentPlaceHolder1_btnMedicalCertificate {
            padding: 6px 5px 0px 5px;
            padding-top: 0px;
            border-top-right-radius: 5px;
            border-bottom-right-radius: 5px;
        }

            input#ContentPlaceHolder1_btnMedicalCertificate:Hover {
                padding: 6px 5px 0px 5px;
                padding-top: 0px;
                border-top-right-radius: 5px;
                border-bottom-right-radius: 5px;
                box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px !important;
            }

        input#ContentPlaceHolder1_txtMedicalCertificate {
            background: white;
        }

        .table-bordered td, .table-bordered th {
            border: 1px solid #dee2e6;
            padding: 13px;
            font-size: 13px;
        }

        label {
            float: left;
        }

        span {
            display: block;
            overflow: hidden;
            padding: 0px 4px 0px 6px;
        }

        td {
            padding: 10px 10px 10px 10px !important;
        }

        th.headercolor {
            width: 1% !important;
        }

            th.headercolor.textalignCenter.width {
                width: 35% !important;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <div class="content-wrapper">
         <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
        <div class="card" style="box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px; border-radius: 5px !important">
            <div class="card-body">
            
                        <div class="row">
                            <div class="col-md-4"></div>
                            <div class="col-md-4" style="text-align: center; box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding-top: 8px; padding-bottom: 8px; border-radius: 10px; top: 0px; left: 0px;">
                                <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important;">LICENCE UPGRADATION REQUEST</h6>
                            </div>
                            <br />
                            <div class="col-md-4"></div>
                        </div>
                        <div class="row">
                            <div class="col-md-4"></div>
                            <div class="col-md-4" style="text-align: center;">
                                <label id="DataUpdated" runat="server" visible="false" style="color: red; font-size: 1.125rem">
                                    Data Updated Successfully !!!.
                                </label>
                                <label id="DataSaved" runat="server" visible="false" style="color: red; font-size: 1.125rem">
                                    Data Saved Successfully !!!.
                                </label>
                            </div>
                        </div>
                        <br />
                        <h7 class="card-title fw-semibold mb-4">Personal Details</h7>
                        <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                            <div class="row">
                                
                                
                                
                             
                            </div>




                            <div class="row">
                                <div class="col-md-4">
                                <div class="form-group">
    <label>
        Level of licence applied for upgradation
      <samp style="color: red">* </samp>
    </label>
    <asp:DropDownList Style="width: 100% !important;" class="form-control  select-form select2" ID="ddlVoltageLevel" runat="server" TabIndex="16">
    </asp:DropDownList>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator43" ErrorMessage="Required" ControlToValidate="ddlVoltageLevel" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
</div>
                                    </div>
                              
                                    <div class="col-md-4">
    <label>
        Firm Name<samp style="color: red">* </samp>
    </label>
    <asp:TextBox class="form-control" ID="txtFirmName" runat="server" autocomplete="off" TabIndex="1" MaxLength="200" Style="margin-left: 18px;" AutoPostBack="true">
    </asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator54" ErrorMessage="Required" ControlToValidate="txtFirmName" runat="server" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
</div>
                               <div class="col-md-4">
    <label>
        Name<samp style="color: red">* </samp>
    </label>
    <asp:TextBox class="form-control" ID="txtContractName" runat="server" autocomplete="off" TabIndex="1" MaxLength="100" Style="margin-left: 18px;" AutoPostBack="true">
    </asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator55" ErrorMessage="Required" ControlToValidate="txtContractName" runat="server" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
</div> 
                                                               <div class="col-md-4">
                                   
                                     <div class="form-group">
     <label>
         Current Level of licence 
       <samp style="color: red">* </samp>
     </label>
     <asp:TextBox class="form-control" ID="txtCurrentVoltage" runat="server" autocomplete="off" ReadOnly="true" TabIndex="1" MaxLength="200" Style="margin-left: 18px;" AutoPostBack="true">
</asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator56" ErrorMessage="Required" ControlToValidate="txtCurrentVoltage" runat="server" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                              </div>
                                                                   </div>
                                                                      <div class="col-md-4">
       <label>
           Date Of Birth<samp style="color: red">* </samp>
       </label>
       <asp:TextBox class="form-control" ID="txtDob" runat="server" Type="Date" autocomplete="off" TabIndex="1"
           MaxLength="200" Style="margin-left: 18px;" OnTextChanged="txtDob_TextChanged" AutoPostBack="true" onchange="validateDOB();">
       </asp:TextBox>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator39" ErrorMessage="Required" ControlToValidate="txtDob" runat="server" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
   </div>
   <div class="col-md-4">
       <label>
           Current Age<samp style="color: red">* </samp>
       </label>
       <asp:TextBox class="form-control" ID="txtCurrentAge" runat="server" autocomplete="off" TabIndex="1" ReadOnly="true"
           MaxLength="200" Style="margin-left: 18px;">
       </asp:TextBox>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator40" ErrorMessage="Required" ControlToValidate="txtCurrentAge" runat="server" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
   </div>

   <div class="col-md-4">
       <label>
           Old Certificate No.<samp style="color: red">* </samp>
       </label>
       <asp:TextBox class="form-control" ID="txtOldCertificateNo" runat="server" autocomplete="off" TabIndex="1"
           MaxLength="10" Style="margin-left: 18px;">
       </asp:TextBox>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator41" ErrorMessage="Required" ControlToValidate="txtOldCertificateNo" runat="server" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
   </div>
   <div class="col-md-4">
       <label>
           New Certificate No.<samp style="color: red">* </samp>
       </label>
       <asp:TextBox class="form-control" ID="txtNewCertificateNo" runat="server" autocomplete="off" TabIndex="1"
           MaxLength="10" Style="margin-left: 18px;">
       </asp:TextBox>
       <asp:RequiredFieldValidator ID="RequiredFieldValidator42" ErrorMessage="Required" ControlToValidate="txtNewCertificateNo" runat="server" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
   </div>
                               </div>
                            </div>
                      
                <asp:UpdatePanel runat="server" ID="updatePanel">
        <ContentTemplate>
                        <br />
                        <h7 class="card-title fw-semibold mb-4">Organisation Details</h7>
                        <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                            <div class="row">
                                <div class="form-group">
                                    <button type="button" runat="server" visible="false" style="padding: 10px 20px 10px 20px;" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#myModal">
                                        Open modal
                                    </button>
                                    <div class="modal" id="myModal">
                                        <div class="modal-dialog" style="width: 60%; max-width: 70%; margin-left: 30%;box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px;">
                                            <div class="modal-content">
                                                <!-- Modal Header -->
                                                <div class="modal-header">
                                                    <h3 class="modal-title">Director/Partner Details</h3>
                                                    <%--   <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>--%>
                                                </div>
                                                <!-- Modal body -->
                                                <div class="modal-body">
                                                    <div style="margin: -20px; padding: 17px; padding-bottom: 0px;">
                                                        <div class="row">
                                                            <div class="col-md-4">
                                                                <div class="forms-sample">
                                                                    <div class="form-group">
                                                                        <label id="Label6" runat="server" visible="true">
                                                                            Type of Authority<samp style="color: red">* </samp>
                                                                        </label>
                                                                        <asp:DropDownList class="select-form select2" Style="border: 1px solid #ced4da; border-radius: 5px;"
                                                                            ID="ddlAuthority" runat="server" TabIndex="5">
                                                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                            <asp:ListItem Text="Director" Value="1"></asp:ListItem>
                                                                            <asp:ListItem Text="Partner" Value="2"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlAuthority" InitialValue="0" CssClass="validation_required" ErrorMessage="Required" ValidationGroup="ModalSubmit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4">
                                                                <div class="forms-sample">
                                                                    <div class="form-group">
                                                                        <label id="Label8" runat="server" visible="true">
                                                                            Full Name<samp style="color: red">* </samp>
                                                                        </label>
                                                                        <asp:TextBox class="form-control" ID="txtName" autocomplete="off" onKeyPress="return alphabetKey(event);" runat="server" TabIndex="6"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ErrorMessage="Required" ControlToValidate="txtName" runat="server" Display="Dynamic" ValidationGroup="ModalSubmit" ForeColor="Red" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4">
                                                                <div class="forms-sample">
                                                                    <div class="form-group">
                                                                        <label id="Label9" runat="server" visible="true">
                                                                            Address<samp style="color: red">* </samp>
                                                                        </label>
                                                                        <asp:TextBox class="form-control" ID="txtAddress" autocomplete="off" runat="server" TabIndex="7"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator23" Text="Required" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtAddress" runat="server" ValidationGroup="ModalSubmit" ForeColor="Red" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-md-4">
                                                                <div class="forms-sample">
                                                                    <div class="form-group">
                                                                        <label>
                                                                            State<samp style="color: red">* </samp>
                                                                        </label>
                                                                        <asp:DropDownList class="select-form select2" Style="border: 1px solid #ced4da; border-radius: 5px;"
                                                                            ID="ddlState" AutoPostBack="true" runat="server" TabIndex="8" OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator24" Text="Please Select State" ErrorMessage="Required" ControlToValidate="ddlState" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="ModalSubmit" ForeColor="Red" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4">
                                                                <div class="forms-sample">
                                                                    <div class="form-group">
                                                                        <label>
                                                                            District<samp style="color: red">* </samp>
                                                                        </label>
                                                                        <asp:DropDownList class="select-form select2" Style="border: 1px solid #ced4da; border-radius: 5px;"
                                                                            ID="ddlDistrict" runat="server" TabIndex="9">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator25" ErrorMessage="Required" ControlToValidate="ddlDistrict" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="ModalSubmit" ForeColor="Red" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4">
                                                                <div class="forms-sample">
                                                                    <div class="form-group">
                                                                        <label id="Label11" runat="server" visible="true">
                                                                            Pin Code<samp style="color: red">* </samp>
                                                                        </label>
                                                                        <asp:TextBox class="form-control" ID="txtPinCode" autocomplete="off" onKeyPress="return isNumberKey(event);" runat="server" MaxLength="6" TabIndex="10"> </asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="txtPinCode"
                                                                            ErrorMessage="Required" ValidationGroup="ModalSubmit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-12" style="text-align: center;">
                                                                <asp:Button type="Submit" OnClientClick="return validateFormodal();" ID="btnModalSubmit" OnClick="btnModalSubmit_Click" Text="Add" runat="server" class="btn btn-primary" Style="border-radius: 5px; width: 15%;" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <hr style="margin-top: 45px; margin-bottom: 10px;" />
                                                   
                                                           <div class="row">
                                                                <asp:GridView class="table-responsive table table-hover table-striped table-bordered" ID="GridView1" runat="server" Width="100%"
                                                                    AutoGenerateColumns="false" BorderWidth="1px" BorderColor="#dbddff" DataKeyNames="Id" OnRowCommand="GridView1_RowCommand">

                                                                    <PagerStyle CssClass="pagination-ys" />
                                                                    <Columns>
                                                                        <asp:BoundField DataField="TypeOfAuthority" HeaderText="Type Of Authority">
                                                                            <HeaderStyle HorizontalAlign="center" CssClass="headercolor" />
                                                                            <ItemStyle HorizontalAlign="center" CssClass="tdpadding" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="Name" HeaderText="Name">
                                                                            <HeaderStyle HorizontalAlign="left" CssClass="headercolor" />
                                                                            <ItemStyle HorizontalAlign="left" CssClass="tdpadding" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="State" HeaderText="State">
                                                                            <HeaderStyle HorizontalAlign="center" CssClass="headercolor" />
                                                                            <ItemStyle HorizontalAlign="center" CssClass="tdpadding" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="District" HeaderText="District">
                                                                            <HeaderStyle HorizontalAlign="center" CssClass="headercolor" />
                                                                            <ItemStyle HorizontalAlign="center" CssClass="tdpadding" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="PinCode" HeaderText="PinCode">
                                                                            <HeaderStyle HorizontalAlign="center" CssClass="headercolor" />
                                                                            <ItemStyle HorizontalAlign="center" CssClass="tdpadding" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="Address" HeaderText="Address">
                                                                            <HeaderStyle HorizontalAlign="center" CssClass="headercolor" />
                                                                            <ItemStyle HorizontalAlign="center" CssClass="tdpadding" />
                                                                        </asp:BoundField>
                                                                        <asp:TemplateField HeaderText="Delete">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lnkDelete" runat="server" CommandName="DeleteRecord"
                                                                                    Text="Delete" ForeColor="Red" CommandArgument='<%# Eval("Id") %>'>
                                                                                </asp:LinkButton>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" CssClass="headercolor" />
                                                                            <ItemStyle HorizontalAlign="Center" CssClass="tdpadding" />
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                                                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                                                                    <RowStyle ForeColor="#000066" CssClass="gridViewRow" />
                                                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                                                                </asp:GridView>
                                                            </div>
                                                       

                                                   
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                               
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label id="contractor" runat="server" visible="true">
                                            GST No.<samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtGstNumber" autocomplete="off" ReadOnly="true" runat="server" onKeyPress="return isNumberKey(event) || alphabetKey(event);" TabIndex="1" MaxLength="15"> </asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtGstNumber"
                                            CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="regexValidatorGST" runat="server" ControlToValidate="txtGstNumber"  ValidationExpression="^(06|04|07)[A-Z]{5}[0-9]{4}[A-Z]{1}[1-9A-Z]{1}Z[0-9A-Z]{1}$"
 ValidationGroup="Submit"
 ErrorMessage="GST is incorrect. Only GST numbers from Haryana (06), Chandigarh (04), and Delhi (07) are allowed." ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>

                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>
                                            Style of Company<samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="select-form select2" Style="border: 1px solid #ced4da; border-radius: 5px;"
                                            ID="ddlCompanyStyle" runat="server" TabIndex="2" AutoPostBack="true" OnSelectedIndexChanged="ddlCompanyStyle_SelectedIndexChanged">
                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="Proprietary Concern" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Company(Limited)" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="Firm(Registered under the company's act.)" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="Partnership Firm" Value="4"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" ErrorMessage="Required" ControlToValidate="ddlCompanyStyle" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                    </div>
                                </div>
                                <div class="col-md-4" id="DivAgentName" runat="server" visible="false">
                                    <div class="form-group">
                                        <label id="Label2" runat="server" visible="true">
                                            Full Name of Agent/Manager<samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtAgentName" autocomplete="off" onKeyPress="return alphabetKey(event);" runat="server"> </asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ControlToValidate="txtAgentName"
                                            CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label id="Lbl1" runat="server" visible="true">
                                            Name Of Proprietary Concern<samp style="color: red">* </samp>
                                        </label>
                                        <label id="Lbl2" runat="server" visible="false">
                                            Name Of Company(Limited)<samp style="color: red">* </samp>
                                        </label>
                                        <label id="Lbl3" runat="server" visible="false">
                                            Name Of Firm(Registered under the company's act.)<samp style="color: red">* </samp>
                                        </label>
                                        <label id="Lbl4" runat="server" visible="false">
                                            Name Of Partnership Firm<samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtNameOfCompany" autocomplete="off" runat="server" MaxLength="100"> </asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="txtNameOfCompany" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Required</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>
                                            Business Address<samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtBusinessAddress" autocomplete="off" runat="server" MaxLength="250"> </asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="txtBusinessAddress" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>
                                            State<samp style="color: red">* </samp>
                                        </label>
                                        <%-- <asp:TextBox class="form-control" ID="txtbusinessState" autocomplete="off" ReadOnly="true" runat="server" TabIndex="7"> </asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ControlToValidate="txtbusinessState" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                        --%>
                                        <asp:DropDownList ID="ddlBusinessState" class="select-form select2" Style="border: 1px solid #ced4da; border-radius: 5px;" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlBusinessState_SelectedIndexChanged"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator31" ErrorMessage="Required" ControlToValidate="ddlBusinessState" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>
                                            District<samp style="color: red">* </samp>
                                        </label>
                                        <%--  <asp:TextBox class="form-control" ID="txtbusinessDistrict" autocomplete="off" ReadOnly="true" runat="server" TabIndex="7"> </asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ControlToValidate="txtbusinessDistrict" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                        --%>
                                        <asp:DropDownList class="select-form select2" Style="border: 1px solid #ced4da; border-radius: 5px; width: 100%; height: 25px; box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;"
                                            ID="ddlBusinessDistrict" AutoPostBack="true" runat="server" TabIndex="9">
                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator32" CssClass="validation_required" ErrorMessage="Required" ControlToValidate="ddlBusinessDistrict" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>
                                            Business Pin Code<samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtBusinessPin" autocomplete="off" runat="server" onKeyPress="return isNumberKey(event);" MaxLength="6"> </asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator33" runat="server" ControlToValidate="txtBusinessPin" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Required</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator
                                            ID="RegexPin" runat="server" ControlToValidate="txtBusinessPin" ErrorMessage="Enter valid 6-digit Pin Code" ForeColor="Red" Display="Dynamic" ValidationGroup="Submit" ValidationExpression="^[1-9][0-9]{5}$">
                                        </asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>
                                            Business E-mail<samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtBusinessEmail" autocomplete="off" runat="server" MaxLength="50" onkeyup="return ValidateEmail();"> </asp:TextBox>
                                        <span id="lblError" style="color: red"></span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator34" CssClass="validation_required" runat="server" ControlToValidate="txtBusinessEmail"
                                            ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtBusinessEmail" ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$" ErrorMessage="Invalid Email Address" ValidationGroup="Submit"
                                            ForeColor="Red"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>
                                            Business Phone No.<samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtBusinessPhoneNo" autocomplete="off" runat="server" onkeyup="return isvalidphoneno();" onKeyPress="return isNumberKey(event);" MaxLength="10"> </asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server" ControlToValidate="txtBusinessPhoneNo" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Required</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="revPhone" runat="server" ControlToValidate="txtBusinessPhoneNo" ValidationExpression="^[6-9]\d{9}$" ErrorMessage="Enter a valid phone number" ValidationGroup="Submit" ForeColor="Red" Display="Dynamic">
                                        </asp:RegularExpressionValidator>
                                    </div>
                                </div>
                                <div class="col-md-4" style="margin-top:-30px;">
                                    <div class="form-group">
                                        <label>
                                            Name of authorized person signing document<samp style="color: red">* </samp>
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtauthorizedperson" autocomplete="off" runat="server" onKeyPress="return alphabetKey(event);" MaxLength="100"> </asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator44" runat="server" ControlToValidate="txtauthorizedperson" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Required</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-md-4" style="margin-top:-30px;">
    <div class="form-group">
        <label for="Gender">
            Registered office in (Haryana/UT Chandigarh/ NCT Delhi)<samp style="color: red">* </samp>
        </label>
        <asp:DropDownList class="select-form select2" Style="border: 1px solid #ced4da; border-radius: 5px;"
            ID="ddlOffice" runat="server" TabIndex="3">
            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
            <asp:ListItem Text="YES" Value="1"></asp:ListItem>
            <asp:ListItem Text="NO" Value="2"></asp:ListItem>
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator28" Text="Required" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlOffice" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
    </div>
</div>
                            </div>
                        </div>
                        <h7 class="card-title fw-semibold mb-4">Other Organisation Details</h7>
                        <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                            <div class="row">
                                <div class="col-md-4">
                                    <label id="Label4" runat="server" visible="true">
                                        Is Applicant a manufacturing firm or production unit<samp style="color: red">* </samp>
                                    </label>
                                    <asp:DropDownList class="select-form select2" Style="border: 1px solid #ced4da; border-radius: 5px;"
                                        ID="ddlUnitOrNot" runat="server">
                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="YES" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="NO" Value="2"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" Text="Required" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlUnitOrNot" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                </div>
                                <div class="col-md-4">
                                    <label id="Label13" runat="server" visible="true">
                                        Is Contractor License Previously Granted with same name<samp style="color: red">* </samp>
                                    </label>
                                    <asp:DropDownList class="select-form select2" Style="border: 1px solid #ced4da; border-radius: 5px;"
                                        ID="ddlSameNameLicense" runat="server" OnSelectedIndexChanged="ddlSameNameLicense_SelectedIndexChanged" AutoPostBack="true">
                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="YES" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="NO" Value="2"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" Text="Required" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlSameNameLicense" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                </div>
                                <div class="col-md-4" id="DivLicenseNo" runat="server" visible="false">
                                    <label id="Label14" runat="server" visible="true">
                                        Enter License No.<samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtLicenseNo" autocomplete="off" MaxLength="10" onkeypress="return isValidLicenseKey(event);" runat="server"> </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtLicenseNo"
                                        CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-4" id="DivLicenseIssueDateifSameName" runat="server" visible="false">
                                    <label id="Labe20" runat="server" visible="true">
                                        Date of Issue<samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" type="date" autocomplete="off" ID="txtLicenseIssue" Onchange="validateDate()" placeholder="dd/mm/yyyy" runat="server" AutoPostBack="true"> </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtLicenseIssue"
                                        CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-4">
                                    <label id="Label5" runat="server" visible="true">
                                        Is Contractor License Previously Granted with same name from other state<samp style="color: red">* </samp>
                                    </label>
                                    <asp:DropDownList class="select-form select2" Style="border: 1px solid #ced4da; border-radius: 5px;"
                                        ID="ddlLicenseGranted" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlLicenseGranted_SelectedIndexChanged">
                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="YES" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="NO" Value="2"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" Text="Required" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlLicenseGranted" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                </div>
                                <div class="col-md-4" id="divIssueAuthority" runat="server" visible="false">
                                    <label id="Label7" runat="server" visible="true">
                                        Name of Issuing Authority<samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtIssusuingName" autocomplete="off" MaxLength="100" onKeyPress="return alphabetKey(event);" runat="server"> </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtIssusuingName"
                                        CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-4" id="divLicenseIssueDate" runat="server" visible="false">
                                    <label>
                                        Date of Issue<samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" type="date" autocomplete="off" ID="txtIssuedateOtherState" Onchange="validateDate1()" placeholder="dd/mm/yyyy" runat="server" AutoPostBack="true"> </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtIssuedateOtherState"
                                        CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-4" id="divLicenseExpiry" runat="server" visible="false">
                                    <label id="Label15" runat="server" visible="true">
                                        Date of License Expiry<samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" type="date" autocomplete="off" ID="txtLicenseExpiry" placeholder="dd/mm/yyyy" runat="server" AutoPostBack="true" onchange="validateDates1()"> </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtLicenseExpiry"
                                        CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-4" id="divDetailsOfWorkPermit" runat="server" visible="false">
                                    <label id="Label21" runat="server" visible="true">
                                        Details of work permit to be undertaken.<samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtWorkPermitUndertaken" MaxLength="200" autocomplete="off" onKeyPress="return alphabetKey(event);" runat="server"> </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtWorkPermitUndertaken"
                                        CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <h7 class="card-title fw-semibold mb-4">Partners/Directors Details</h7>
                        <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                            <div class="row">
                                <div class="col-md-5">
                                    <div class="form-group">
                                        <label for="Gender">
                                            Whether the company have Partner/Director<samp style="color: red">* </samp>
                                        </label>
                                        <asp:DropDownList class="select-form select2" Style="border: 1px solid #ced4da; border-radius: 5px;" AutoPostBack="true"
                                            ID="DdlPartnerOrDirector" runat="server" OnSelectedIndexChanged="DdlPartnerOrDirector_SelectedIndexChanged" TabIndex="4" Enabled="true">
                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="YES" Value="1" data-bs-toggle="modal" data-bs-target="#myModal"></asp:ListItem>
                                            <asp:ListItem Text="NO" Value="2"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator" Text="Required" ErrorMessage="RequiredFieldValidator" ControlToValidate="DdlPartnerOrDirector" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                    </div>
                                </div>
                                <div class="col-md-3" style="padding-top: 30px;">
                                    <div class="form-group">
                                        <div id="ADDpartner" runat="server" visible="false" class="form-group">
                                            <asp:Button ID="btnShowPartnerDiv" runat="server" Text="Add Partner/Director" OnClick="btnShowPartnerDiv_Click" CssClass="btn btn-primary" Style="border-radius: 5px; font-size: 18px; padding: 4px 8px;" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <hr />
                           
                                <asp:GridView class="table-responsive table table-hover table-striped table-bordered" ID="GridView2" runat="server" Width="100%"
                                    AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand" BorderWidth="1px" BorderColor="#dbddff" DataKeyNames="Id">
                                    <PagerStyle CssClass="pagination-ys" />
                                    <Columns>
                                        <asp:BoundField DataField="TypeOfAuthority" HeaderText="Type Of Authority">
                                            <HeaderStyle HorizontalAlign="center" CssClass="headercolor" />
                                            <ItemStyle HorizontalAlign="center" CssClass="tdpadding" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Name" HeaderText="Name">
                                            <HeaderStyle HorizontalAlign="left" CssClass="headercolor" />
                                            <ItemStyle HorizontalAlign="left" CssClass="tdpadding" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="State" HeaderText="State">
                                            <HeaderStyle HorizontalAlign="center" CssClass="headercolor" />
                                            <ItemStyle HorizontalAlign="center" CssClass="tdpadding" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="District" HeaderText="District">
                                            <HeaderStyle HorizontalAlign="center" CssClass="headercolor" />
                                            <ItemStyle HorizontalAlign="center" CssClass="tdpadding" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="PinCode" HeaderText="PinCode">
                                            <HeaderStyle HorizontalAlign="center" CssClass="headercolor" />
                                            <ItemStyle HorizontalAlign="center" CssClass="tdpadding" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Address" HeaderText="Address">
                                            <HeaderStyle HorizontalAlign="center" CssClass="headercolor" />
                                            <ItemStyle HorizontalAlign="center" CssClass="tdpadding" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkDelete" runat="server" CommandName="DeleteRecord"
                                                    Text="Delete" ForeColor="Red" CommandArgument='<%# Eval("Id") %>'>
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" CssClass="headercolor" />
                                            <ItemStyle HorizontalAlign="Center" CssClass="tdpadding" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                                    <RowStyle ForeColor="#000066" CssClass="gridViewRow" />
                                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                                </asp:GridView>
                            
                        </div>
                        <h7 class="card-title fw-semibold mb-4">Employees Details (from here you can add Supervisor and Wireman)</h7>
                        <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                            <asp:GridView ID="GridView4" class="table-responsive table table-hover table-striped" runat="server" Width="100%" AutoGenerateColumns="false" BorderWidth="1px" BorderColor="#dbddff">
                                <Columns>
                                    <asp:TemplateField HeaderText="SNo">
                                        <HeaderStyle CssClass="headercolor" />
                                        <ItemStyle />
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Id">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCategory" runat="server" Text='<%#Eval("Category") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Name" HeaderText="Name">
                                        <HeaderStyle HorizontalAlign="Center" CssClass="headercolor textalignCenter  width" />
                                        <ItemStyle HorizontalAlign="Center" CssClass="textalignCenter" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="VoltageLevel" HeaderText="Voltage Level">
                                        <HeaderStyle HorizontalAlign="Center" CssClass="headercolor textalignCenter" />
                                        <ItemStyle HorizontalAlign="Center" CssClass="textalignCenter" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="LicenseNo" HeaderText="Certificate Number">
                                        <HeaderStyle HorizontalAlign="Center" CssClass="headercolor textalignCenter" />
                                        <ItemStyle HorizontalAlign="Center" CssClass="textalignCenter" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DateOfExpiry" HeaderText="Valid Upto">
                                        <HeaderStyle HorizontalAlign="center" CssClass="headercolor textalignCenter" />
                                        <ItemStyle HorizontalAlign="center" />
                                    </asp:BoundField>
                                </Columns>
                                <FooterStyle BackColor="White" ForeColor="#000066" />
                                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                                <RowStyle ForeColor="#000066" />
                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                <SortedDescendingHeaderStyle BackColor="#00547E" />
                            </asp:GridView>
                        </div>
                        <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                            <div class="row" style="margin-bottom: 15px;">
                                <asp:HiddenField ID="HiddenField4" runat="server" />
                                <div class="col-md-12">
                                    <label>
                                        Whether the staff indicated under column 13 are exclusively earmark for the work under the condition for licencing and regulation 29 of "Central Electricity Authority (Measuring relating to safety and electric supply)" ?
                                        <samp style="color: red">* </samp>
                                    </label>
                                    <asp:DropDownList class="select-form select2" Style="border: 1px solid #ced4da; border-radius: 5px;"
                                        ID="DdlWorkUnderLicenceConditionsandregulation29" runat="server">
                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="YES" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="NO" Value="2"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator22" Text="Required" ErrorMessage="RequiredFieldValidator" ControlToValidate="DdlWorkUnderLicenceConditionsandregulation29" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                </div>
                                 <div class="col-md-12" id="divbluePrint" runat="server" style="margin-top:20px;">
     <label>
         Whether adequate drawing office facilities for preration of drawings,blue prints etc. is available(in case of above 650 Volt) ?
         <samp style="color: red">* </samp>
     </label>
     <asp:DropDownList class="select-form select2" Style="border: 1px solid #ced4da; border-radius: 5px;"
         ID="ddlBluePrint" runat="server">
         <asp:ListItem Text="Select" Value="0"></asp:ListItem>
         <asp:ListItem Text="YES" Value="1"></asp:ListItem>
         <asp:ListItem Text="NO" Value="2"></asp:ListItem>
     </asp:DropDownList>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator57" Text="Required" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlBluePrint" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
 </div>
                            </div>
                        </div>
                        <h7 class="card-title fw-semibold mb-4">Other Details</h7>
                        <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="forms-sample">
                                        <div class="form-group">
                                            <label for="Gender">
                                                Whether E library/library as per ANNEXURE-2 Available<samp style="color: red">* </samp>
                                            </label>
                                            <asp:DropDownList class="select-form select2" Style="border: 1px solid #ced4da; border-radius: 5px;"
                                                ID="ddlAnnexureOrNot" runat="server">
                                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="YES" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="NO" Value="2"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator36" Text="Required" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlAnnexureOrNot" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="forms-sample">
                                        <div class="form-group">
                                            <label id="Label12" runat="server" visible="true">
                                                Do company/firm have any <b>Penalties or Punishments</b>?<samp style="color: red">* </samp>
                                            </label>
                                            <asp:DropDownList class="select-form select2" AutoPostBack="true" Style="border: 1px solid #ced4da; border-radius: 5px;"
                                                ID="DropDownList2" runat="server" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="YES" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="NO" Value="2"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator37" Text="Required" ErrorMessage="RequiredFieldValidator" ControlToValidate="DropDownList2" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6" id="DdlPenelity" runat="server" visible="false">
                                    <div class="forms-sample">
                                        <div class="form-group">
                                            <label id="Label10" runat="server" visible="true">
                                                Select penalties or punishments<samp style="color: red">* </samp>
                                            </label>
                                            <asp:DropDownList ID="ddlPenalities" runat="server"
                                                CssClass="select-form select2 form-control"
                                                AutoPostBack="false"
                                                onchange="updatePenalityText(this)">
                                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="By state licensing board, Haryana/chief Electrical inspector,Haryana" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="By government & other agencies" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="Any court of law." Value="3"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator38" Text="Required" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtPenalities"
                                                runat="server" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />

                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12">
                                    <div class="form-group" id="ShowPenelity" runat="server" visible="false">
                                        <label id="Label1" runat="server" visible="true"></label>
                                        <div id="penaltyContainer" class="form-control">
                                            <!-- Tags will be added here -->
                                        </div>

                                    </div>
                                </div>
                                <div class="col-md-12" id="DivPenelity" runat="server" visible="false">
                                    <asp:TextBox ID="txtPenalities" runat="server" TextMode="MultiLine"
                                        Rows="2" CssClass="form-control" />
                                </div>
                            </div>
                        </div>
                        <h7 class="card-title fw-semibold mb-4">Challan Details</h7>
                        <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="forms-sample">
                                        <div class="form-group">
                                            <label for="Gender">
                                                Total Amount<samp style="color: red">* </samp>
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtTotalAmount" autocomplete="off" Text="2520/-" ReadOnly="true" runat="server"> </asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator45" runat="server" ControlToValidate="txtTotalAmount"
                                                CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="forms-sample">
                                        <div class="form-group">
                                            <label for="Gender">
                                                GRN No.<samp style="color: red">* </samp>
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtGrNNo" autocomplete="off" MaxLength="10" runat="server" onkeypress="return isAlphaNumeric(event);" > </asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator46" runat="server" ControlToValidate="txtGrNNo"
                                                CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                                                                <asp:RegularExpressionValidator runat="server"  ControlToValidate="txtGrNNo" ValidationGroup="Submit" 
ForeColor="Red"  ErrorMessage="GRN No. must be exactly 10 alphanumeric characters." ValidationExpression="^[a-zA-Z0-9]{10}$"> </asp:RegularExpressionValidator>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="forms-sample">
                                        <div class="form-group">
                                            <label for="Gender">
                                                Challan date<samp style="color: red">* </samp>
                                            </label>
                                            <asp:TextBox class="form-control" ID="txtChallanDate" onchange="validateChallanDate()" ClientIDMode="Static" autocomplete="off" Type="date" runat="server"> </asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator47" runat="server" ControlToValidate="txtChallanDate"
                                                CssClass="validation_required" ErrorMessage="Required" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <h7 class="card-title fw-semibold mb-4">Document Checklist</h7>
                        <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                            <div class="row" style="margin-bottom: 15px;">
                                <div class="col-md-12">
                                    <table class="table table-bordered table-striped">
                                        <tbody>
                                            <tr>
                                                <th>Document Name</th>
                                                <th style="text-align:center;">Upload Document</th>
                                            </tr>
                                            <tr>
                                                <td style="margin-top: auto; margin-bottom: auto;">Certificate of Competency and Wireman Permit, who are working with the<br />
                                                    Firm/Company alongwith their written consent or in person, if think so, necessary.
                (<span style="color: red; display: inline; padding: 0;">★</span>)
                                                </td>
                                                <td style="text-align: center;">
                                                    <text style="color: red; font-size: 12px;" id="text2" runat="server" visible="true">
                                                        Upload Only PDF File not more than 1mb.
                                                    </text>
                                                    <asp:FileUpload ID="FileUpload2" runat="server" CssClass="form-control"
                                                        Style="margin-left: 18px; padding: 0px; font-size: 15px; height: 28px !important;" accept=".pdf" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="FileUpload2"
                                                        ErrorMessage="Required" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    <asp:LinkButton ID="lnkbtn_Save2" Enabled="false" runat="server" Visible="false" CssClass="btn btn-success">
                    <i class="fa fa-check"></i>
                                                    </asp:LinkButton>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td style="margin-top: auto; margin-bottom: auto;">Calibration Certificate from NABL or Government Testing Laboratory in respect of<br />
                                                    Electrical equipments.(<span style="color: red; display: inline; padding: 0;">★</span>)
                                                </td>
                                                <td style="text-align: center;">
                                                    <text style="color: red; font-size: 12px;" id="text3" runat="server" visible="true">
                                                        Upload Only PDF File not more than 1mb.
                                                    </text>
                                                    <asp:FileUpload ID="FileUpload3" runat="server" CssClass="form-control"
                                                        Style="margin-left: 18px; padding: 0px; font-size: 15px; height: 28px !important;" accept=".pdf" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="FileUpload3"
                                                        ErrorMessage="Required" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td style="margin-top: auto; margin-bottom: auto;">Details of works executed annually on the basis of Electrical Contractor License.
                (<span style="color: red; display: inline; padding: 0;">★</span>)
                                                </td>
                                                <td style="text-align: center;">
                                                    <text style="color: red; font-size: 12px;" id="text4" runat="server" visible="true">
                                                        Upload Only PDF File not more than 1mb.
                                                    </text>
                                                    <asp:FileUpload ID="FileUpload4" runat="server" CssClass="form-control"
                                                        Style="margin-left: 18px; padding: 0px; font-size: 15px; height: 28px !important;" accept=".pdf" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="FileUpload4"
                                                        ErrorMessage="Required" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td style="margin-top: auto; margin-bottom: auto;">Copy of Annexure III & V.(<span style="color: red; display: inline; padding: 0;">★</span>)
                                                </td>
                                                <td style="text-align: center;">
                                                    <text style="color: red; font-size: 12px;" id="text5" runat="server" visible="true">
                                                        Upload Only PDF File not more than 1mb.
                                                    </text>
                                                    <asp:FileUpload ID="FileUpload5" runat="server" CssClass="form-control"
                                                        Style="margin-left: 18px; padding: 0px; font-size: 15px; height: 28px !important;" accept=".pdf" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="FileUpload5"
                                                        ErrorMessage="Required" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td style="margin-top: auto; margin-bottom: auto;">Copy of treasury challan of fees deposited in any treasury of Haryana.<br />
                                                    Head of accounts: ‗0043-Taxes and Duties on Electricity –Other Receipts<br />
                                                    i.e. 0043-51-800-99-51—Other Receipts‘.
                (<span style="color: red; display: inline; padding: 0;">★</span>)
                                                </td>
                                                <td style="text-align: center;">
                                                    <text style="color: red; font-size: 12px;" id="text6" runat="server" visible="true">
                                                        Upload Only PDF File not more than 1mb.
                                                    </text>
                                                    <asp:FileUpload ID="FileUpload6" runat="server" CssClass="form-control"
                                                        Style="margin-left: 18px; padding: 0px; font-size: 15px; height: 28px !important;" accept=".pdf" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="FileUpload6"
                                                        ErrorMessage="Required" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>

                                        <%--    <tr>
                                                <td style="margin-top: auto; margin-bottom: auto;">Head of accounts: ‗0043-Taxes and Duties on Electricity –Other Receipts<br />
                                                    i.e. 0043-51-800-99-51—Other Receipts‘.
                (<span style="color: red; display: inline; padding: 0;">★</span>)
                                                </td>
                                                <td style="text-align: center;">
                                                    <text style="color: red; font-size: 12px;" id="text7" runat="server" visible="true">
                                                        Upload Only PDF File not more than 1mb.
                                                    </text>
                                                    <asp:FileUpload ID="FileUpload7" runat="server" CssClass="form-control"
                                                        Style="margin-left: 18px; padding: 0px; font-size: 15px; height: 28px !important;" accept=".pdf" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="FileUpload7"
                                                        ErrorMessage="Required" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>--%>

                                            <tr>
                                                <td style="margin-top: auto; margin-bottom: auto;">Authorized person signing documents.
                (<span style="color: red; display: inline; padding: 0;">★</span>)
                                                </td>
                                                <td style="text-align: center;">
                                                    <text style="color: red; font-size: 12px;" id="text8" runat="server" visible="true">
                                                        Upload Only PDF File not more than 1mb.
                                                    </text>
                                                    <asp:FileUpload ID="FileUpload8" runat="server" CssClass="form-control"
                                                        Style="margin-left: 18px; padding: 0px; font-size: 15px; height: 28px !important;" accept=".pdf" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="FileUpload8"
                                                        ErrorMessage="Required" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>

                                            <tr id="MedicalCertificate" runat="server" visible="false">
                                                <td style="margin-top: auto; margin-bottom: auto;">Copy of Medical Certificate.
                (<span style="color: red; display: inline; padding: 0;">★</span>)
                                                </td>
                                                <td style="text-align: center;">
                                                    <asp:FileUpload ID="FileUpload9" runat="server" CssClass="form-control"
                                                        Style="margin-left: 18px; padding: 0px; font-size: 15px; height: 28px !important;" accept=".pdf" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator48" runat="server" ControlToValidate="FileUpload9"
                                                        ErrorMessage="Required" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td style="margin-top: auto; margin-bottom: auto;">Income tax return for last 3 year(
                <span style="color: red; display: inline; padding: 0;">★</span>)<br />
                                                    (1st Year)
                                                </td>
                                                <td style="text-align: center;">
                                                    <text style="color: red; font-size: 12px;" id="text9" runat="server" visible="true">
                                                        Upload Only PDF File not more than 1mb.
                                                    </text>
                                                    <asp:FileUpload ID="FileUpload10" runat="server" CssClass="form-control"
                                                        Style="margin-left: 18px; padding: 0px; font-size: 15px; height: 28px !important;" accept=".pdf" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator49" runat="server" ControlToValidate="FileUpload10"
                                                        ErrorMessage="Required" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td style="margin-top: auto; margin-bottom: auto;">Income tax return for last 3 year
                (<span style="color: red; display: inline; padding: 0;">★</span>)<br />
                                                    (2nd Year)
                                                </td>
                                                <td style="text-align: center;">
                                                    <text style="color: red; font-size: 12px;" id="text10" runat="server" visible="true">
                                                        Upload Only PDF File not more than 1mb.
                                                    </text>
                                                    <asp:FileUpload ID="FileUpload11" runat="server" CssClass="form-control"
                                                        Style="margin-left: 18px; padding: 0px; font-size: 15px; height: 28px !important;" accept=".pdf" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator50" runat="server" ControlToValidate="FileUpload11"
                                                        ErrorMessage="Required" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td style="margin-top: auto; margin-bottom: auto;">Income tax return for last 3 year
                (<span style="color: red; display: inline; padding: 0;">★</span>)<br />
                                                    (3rd Year)
                                                </td>
                                                <td style="text-align: center;">
                                                    <text style="color: red; font-size: 12px;" id="text11" runat="server" visible="true">
                                                        Upload Only PDF File not more than 1mb.
                                                    </text>
                                                    <asp:FileUpload ID="FileUpload12" runat="server" CssClass="form-control"
                                                        Style="margin-left: 18px; padding: 0px; font-size: 15px; height: 28px !important;" accept=".pdf" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator51" runat="server" ControlToValidate="FileUpload12"
                                                        ErrorMessage="Required" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td style="margin-top: auto; margin-bottom: auto;">Balance sheet of last 1st year
                (<span style="color: red; display: inline; padding: 0;">★</span>)<br />
                                                </td>
                                                <td style="text-align: center;">
                                                    <text style="color: red; font-size: 12px;" id="text1" runat="server" visible="true">
                                                        Upload Only PDF File not more than 1mb.
                                                    </text>
                                                    <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control"
                                                        Style="margin-left: 18px; padding: 0px; font-size: 15px; height: 28px !important;" accept=".pdf" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="FileUpload1"
                                                        ErrorMessage="Required" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td style="margin-top: auto; margin-bottom: auto;">Balance sheet of last 2nd year
                (<span style="color: red; display: inline; padding: 0;">★</span>)<br />
                                                </td>
                                                <td style="text-align: center;">
                                                    <text style="color: red; font-size: 12px;" id="text12" runat="server" visible="true">
                                                        Upload Only PDF File not more than 1mb.
                                                    </text>
                                                    <asp:FileUpload ID="FileUpload13" runat="server" CssClass="form-control"
                                                        Style="margin-left: 18px; padding: 0px; font-size: 15px; height: 28px !important;" accept=".pdf" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator52" runat="server" ControlToValidate="FileUpload13"
                                                        ErrorMessage="Required" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td style="margin-top: auto; margin-bottom: auto;">Balance sheet of last 3rd year
                (<span style="color: red; display: inline; padding: 0;">★</span>)<br />
                                                </td>
                                                <td style="text-align: center;">
                                                    <text style="color: red; font-size: 12px;" id="text13" runat="server" visible="true">
                                                        Upload Only PDF File not more than 1mb.
                                                    </text>
                                                    <asp:FileUpload ID="FileUpload14" runat="server" CssClass="form-control"
                                                        Style="margin-left: 18px; padding: 0px; font-size: 15px; height: 28px !important;" accept=".pdf" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator53" runat="server" ControlToValidate="FileUpload14"
                                                        ErrorMessage="Required" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>

                                </div>
                                <asp:HiddenField ID="HFContractor" runat="server" />
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="row">
                    <div class="col-md-4"></div>
                    <div class="col-md-4" style="text-align: center;">
                        <asp:Button ID="Btn_Submit" Text="Submit" OnClick="Btn_Submit_Click" runat="server"  OnClientClick="return FocusOnError('Submit');" ValidationGroup="Submit" class="btn btn-primary mr-2" />
                    </div>
                </div>
            </div>
             <asp:HiddenField ID="HFVoltage" runat="server" /> 
        </div>
   </div>
    

    <!-- partial:../../partials/_footer.html -->
    <footer class="footer">
    </footer>
    <script src="/assetsnew/vendor/purecounter/purecounter_vanilla.js"></script>
    <script src="/assetsnew/vendor/aos/aos.js"></script>
    <script src="/assetsnew/vendor/bootstrap/js/bootstrap.bundle.min.js"></script>
    <script src="/assetsnew/vendor/glightbox/js/glightbox.min.js"></script>
    <script src="/assetsnew/vendor/isotope-layout/isotope.pkgd.min.js"></script>
    <script src="/assetsnew/vendor/swiper/swiper-bundle.min.js"></script>
    <script src="/assetsnew/vendor/waypoints/noframework.waypoints.js"></script>
    <script src="/assetsnew/vendor/php-email-form/validate.js"></script>
    <!-- Template Main JS File -->
    <script src="/assetsnew/js/main.js"></script>
    <script src="/vendors/js/vendor.bundle.base.js"></script>
    <!-- endinject -->
    <!-- Plugin js for this page -->
    <script src="/vendors/typeahead.js/typeahead.bundle.min.js"></script>
    <script src="/vendors/select2/select2.min.js"></script>
    <!-- End plugin js for this page -->
    <!-- inject:js -->
    <script src="/js2/off-canvas.js"></script>
    <script src="/js2/hoverable-collapse.js"></script>
    <script src="/js2/template.js"></script>
    <script src="/js2/settings.js"></script>
    <script src="/js2/todolist.js"></script>
    <!-- endinject -->
    <!-- Custom js for this page-->
    <script src="/js2/file-upload.js"></script>
    <script src="/js2/typeahead.js"></script>
    <script src="/js2/select2.js"></script>
    <script type="text/javascript">
        function alertWithRedirectdata() {
            if (confirm('Registration Successfull Your UserId Will be sent through email Login For Further process')) {
                window.location.href = "/AdminLogout.aspx";
            } else {
            }
        }
    </script>
    <script>
        $(document).ready(function () {
            // Hide the modal on page load
            $("#myModal").modal("hide");
        });
    </script>
    <script type="text/javascript">
        function PartnerDirectorAlert() {
            if (confirm('Please Add You Partners Or Directors information')) {
                DdlPartnerOrDirector.style.border = '1px solid red';;
            } else {
            }
        }
    </script>

    <script type="text/javascript">
        function CheckVacantSupervisor() {
            if (confirm('Please Add Different Supervisor this is already exits.')) {
                ddlEmployer1.style.border = '1px solid red';;
            } else {
            }
        }
    </script>
    <script type="text/javascript">
        function ContractorTeamAlert() {
            /*if (confirm('Please Add Atleast One Wireman And Supervisor Information')) {*/
            if (confirm('Please Add Atleast 2 employees work under you')) {
                ddlEmployer1.style.border = '1px solid red';;
            } else {
            }
        }
    </script>

    <%-- Multiselect Dropdown --%>
    <script>
        $(document).ready(function () {

            var multipleCancelButton = new Choices('#choices-multiple-remove-button', {
                removeItemButton: true,
                maxItemCount: 3,
                searchResultLimit: 3,
                renderChoiceLimit: 3
            });
        });
    </script>
    <%--    Multiselect Dropdown End    --%>
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
    <script>
        // Function to check if all fields (textboxes and dropdowns) except nationality have values
        function validateForm1() {
            var inputs = document.querySelectorAll('.form-control, .select-form');
            var isValid = true;

            inputs.forEach(function (input) {
                if (input !== document.getElementById('txtNationality')) {
                    if (input.value.trim() === '' || (input.tagName === 'SELECT' && input.value === '0')) {
                        isValid = false;
                        // input.style.border = '1px solid red';
                    } else {
                        input.style.border = '1px solid #ced4da';
                    }
                }
            });

            //if (!isValid) {
            //    alert('Please fill in all the required fields.');
            //}
            return isValid;
        }
        // Add event listeners to remove the red border as the user types/makes selections
        document.querySelectorAll('.form-control, .select-form').forEach(function (input) {
            input.addEventListener('input', function () {
                if (input !== document.getElementById('txtNationality')) {
                    input.style.border = '1px solid #ced4da';
                }
            });
        });
    </script>
    <script>
        mobiscroll.setOptions({
            locale: mobiscroll.localeEn,                                         // Specify language like: locale: mobiscroll.localePl or omit setting to use default
            theme: 'ios',                                                        // Specify theme like: theme: 'ios' or omit setting to use default
            themeVariant: 'light'                                                // More info about themeVariant: https://docs.mobiscroll.com/5-28-1/javascript/select#opt-themeVariant
        });
        mobiscroll.select('#demo-multiple-select', {
            inputElement: document.getElementById('demo-multiple-select-input')  // More info about inputElement: https://docs.mobiscroll.com/5-28-1/javascript/select#opt-inputElement
        });
    </script>
    <script>
        // Initialize function, create initial tokens with itens that are already selected by the user
        function init(element) {
            // Create div that wroaps all the elements inside (select, elements selected, search div) to put select inside
            const wrapper = document.createElement("div");
            wrapper.addEventListener("click", clickOnWrapper);
            wrapper.classList.add("multi-select-component");

            // Create elements of search
            const search_div = document.createElement("div");
            search_div.classList.add("search-container");
            const input = document.createElement("input");
            input.classList.add("selected-input");
            input.setAttribute("autocomplete", "off");
            input.setAttribute("tabindex", "0");
            input.addEventListener("keyup", inputChange);
            input.addEventListener("keydown", deletePressed);
            input.addEventListener("click", openOptions);

            const dropdown_icon = document.createElement("a");
            dropdown_icon.setAttribute("href", "#");
            dropdown_icon.classList.add("dropdown-icon");

            dropdown_icon.addEventListener("click", clickDropdown);
            const autocomplete_list = document.createElement("ul");
            autocomplete_list.classList.add("autocomplete-list")
            search_div.appendChild(input);
            search_div.appendChild(autocomplete_list);
            search_div.appendChild(dropdown_icon);

            // set the wrapper as child (instead of the element)
            element.parentNode.replaceChild(wrapper, element);
            // set element as child of wrapper
            wrapper.appendChild(element);
            wrapper.appendChild(search_div);

            createInitialTokens(element);
            addPlaceholder(wrapper);
        }

        function removePlaceholder(wrapper) {
            const input_search = wrapper.querySelector(".selected-input");
            input_search.removeAttribute("placeholder");
        }

        function addPlaceholder(wrapper) {
            const input_search = wrapper.querySelector(".selected-input");
            const tokens = wrapper.querySelectorAll(".selected-wrapper");
            if (!tokens.length && !(document.activeElement === input_search))
                input_search.setAttribute("placeholder", "---------");
        }

        // Function that create the initial set of tokens with the options selected by the users
        function createInitialTokens(select) {
            let {
                options_selected
            } = getOptions(select);
            const wrapper = select.parentNode;
            for (let i = 0; i < options_selected.length; i++) {
                createToken(wrapper, options_selected[i]);
            }
        }

        // Listener of user search
        function inputChange(e) {
            const wrapper = e.target.parentNode.parentNode;
            const select = wrapper.querySelector("select");
            const dropdown = wrapper.querySelector(".dropdown-icon");

            const input_val = e.target.value;

            if (input_val) {
                dropdown.classList.add("active");
                populateAutocompleteList(select, input_val.trim());
            } else {
                dropdown.classList.remove("active");
                const event = new Event('click');
                dropdown.dispatchEvent(event);
            }
        }

        // Listen for clicks on the wrapper, if click happens focus on the input
        function clickOnWrapper(e) {
            const wrapper = e.target;
            if (wrapper.tagName == "DIV") {
                const input_search = wrapper.querySelector(".selected-input");
                const dropdown = wrapper.querySelector(".dropdown-icon");
                if (!dropdown.classList.contains("active")) {
                    const event = new Event('click');
                    dropdown.dispatchEvent(event);
                }
                input_search.focus();
                removePlaceholder(wrapper);
            }
        }

        function openOptions(e) {
            const input_search = e.target;
            const wrapper = input_search.parentElement.parentElement;
            const dropdown = wrapper.querySelector(".dropdown-icon");
            if (!dropdown.classList.contains("active")) {
                const event = new Event('click');
                dropdown.dispatchEvent(event);
            }
            e.stopPropagation();

        }

        // Function that create a token inside of a wrapper with the given value
        function createToken(wrapper, value) {
            const search = wrapper.querySelector(".search-container");
            // Create token wrapper
            const token = document.createElement("div");
            token.classList.add("selected-wrapper");
            const token_span = document.createElement("span");
            token_span.classList.add("selected-label");
            token_span.innerText = value;
            const close = document.createElement("a");
            close.classList.add("selected-close");
            close.setAttribute("tabindex", "-1");
            close.setAttribute("data-option", value);
            close.setAttribute("data-hits", 0);
            close.setAttribute("href", "#");
            close.innerText = "x";
            close.addEventListener("click", removeToken)
            token.appendChild(token_span);
            token.appendChild(close);
            wrapper.insertBefore(token, search);
        }

        // Listen for clicks in the dropdown option
        function clickDropdown(e) {

            const dropdown = e.target;
            const wrapper = dropdown.parentNode.parentNode;
            const input_search = wrapper.querySelector(".selected-input");
            const select = wrapper.querySelector("select");
            dropdown.classList.toggle("active");

            if (dropdown.classList.contains("active")) {
                removePlaceholder(wrapper);
                input_search.focus();

                if (!input_search.value) {
                    populateAutocompleteList(select, "", true);
                } else {
                    populateAutocompleteList(select, input_search.value);
                }
            } else {
                clearAutocompleteList(select);
                addPlaceholder(wrapper);
            }
        }

        // Clears the results of the autocomplete list
        function clearAutocompleteList(select) {
            const wrapper = select.parentNode;

            const autocomplete_list = wrapper.querySelector(".autocomplete-list");
            autocomplete_list.innerHTML = "";
        }

        // Populate the autocomplete list following a given query from the user
        function populateAutocompleteList(select, query, dropdown = false) {
            const {
                autocomplete_options
            } = getOptions(select);

            let options_to_show;

            if (dropdown)
                options_to_show = autocomplete_options;
            else
                options_to_show = autocomplete(query, autocomplete_options);

            const wrapper = select.parentNode;
            const input_search = wrapper.querySelector(".search-container");
            const autocomplete_list = wrapper.querySelector(".autocomplete-list");
            autocomplete_list.innerHTML = "";
            const result_size = options_to_show.length;

            if (result_size == 1) {
                const li = document.createElement("li");
                li.innerText = options_to_show[0];
                li.setAttribute('data-value', options_to_show[0]);
                li.addEventListener("click", selectOption);
                autocomplete_list.appendChild(li);
                if (query.length == options_to_show[0].length) {
                    const event = new Event('click');
                    li.dispatchEvent(event);

                }
            } else if (result_size > 1) {

                for (let i = 0; i < result_size; i++) {
                    const li = document.createElement("li");
                    li.innerText = options_to_show[i];
                    li.setAttribute('data-value', options_to_show[i]);
                    li.addEventListener("click", selectOption);
                    autocomplete_list.appendChild(li);
                }
            } else {
                const li = document.createElement("li");
                li.classList.add("not-cursor");
                li.innerText = "No options found";
                autocomplete_list.appendChild(li);
            }
        }

        // Listener to autocomplete results when clicked set the selected property in the select option 
        function selectOption(e) {
            const wrapper = e.target.parentNode.parentNode.parentNode;
            const input_search = wrapper.querySelector(".selected-input");
            const option = wrapper.querySelector(`select option[value="${e.target.dataset.value}"]`);

            option.setAttribute("selected", "");
            createToken(wrapper, e.target.dataset.value);
            if (input_search.value) {
                input_search.value = "";
            }

            input_search.focus();

            e.target.remove();
            const autocomplete_list = wrapper.querySelector(".autocomplete-list");

            if (!autocomplete_list.children.length) {
                const li = document.createElement("li");
                li.classList.add("not-cursor");
                li.innerText = "No options found";
                autocomplete_list.appendChild(li);
            }
            const event = new Event('keyup');
            input_search.dispatchEvent(event);
            e.stopPropagation();
        }

        // function that returns a list with the autcomplete list of matches
        function autocomplete(query, options) {
            // No query passed, just return entire list
            if (!query) {
                return options;
            }
            let options_return = [];

            for (let i = 0; i < options.length; i++) {
                if (query.toLowerCase() === options[i].slice(0, query.length).toLowerCase()) {
                    options_return.push(options[i]);
                }
            }
            return options_return;
        }

        // Returns the options that are selected by the user and the ones that are not
        function getOptions(select) {
            // Select all the options available
            const all_options = Array.from(
                select.querySelectorAll("option")
            ).map(el => el.value);

            // Get the options that are selected from the user
            const options_selected = Array.from(
                select.querySelectorAll("option:checked")
            ).map(el => el.value);

            // Create an autocomplete options array with the options that are not selected by the user
            const autocomplete_options = [];
            all_options.forEach(option => {
                if (!options_selected.includes(option)) {
                    autocomplete_options.push(option);
                }
            });

            autocomplete_options.sort();

            return {
                options_selected,
                autocomplete_options
            };

        }

        // Listener for when the user wants to remove a given token.
        function removeToken(e) {
            // Get the value to remove
            const value_to_remove = e.target.dataset.option;
            const wrapper = e.target.parentNode.parentNode;
            const input_search = wrapper.querySelector(".selected-input");
            const dropdown = wrapper.querySelector(".dropdown-icon");
            // Get the options in the select to be unselected
            const option_to_unselect = wrapper.querySelector(`select option[value="${value_to_remove}"]`);
            option_to_unselect.removeAttribute("selected");
            // Remove token attribute
            e.target.parentNode.remove();
            input_search.focus();
            dropdown.classList.remove("active");
            const event = new Event('click');
            dropdown.dispatchEvent(event);
            e.stopPropagation();
        }

        // Listen for 2 sequence of hits on the delete key, if this happens delete the last token if exist
        function deletePressed(e) {
            const wrapper = e.target.parentNode.parentNode;
            const input_search = e.target;
            const key = e.keyCode || e.charCode;
            const tokens = wrapper.querySelectorAll(".selected-wrapper");

            if (tokens.length) {
                const last_token_x = tokens[tokens.length - 1].querySelector("a");
                let hits = +last_token_x.dataset.hits;

                if (key == 8 || key == 46) {
                    if (!input_search.value) {

                        if (hits > 1) {
                            // Trigger delete event
                            const event = new Event('click');
                            last_token_x.dispatchEvent(event);
                        } else {
                            last_token_x.dataset.hits = 2;
                        }
                    }
                } else {
                    last_token_x.dataset.hits = 0;
                }
            }
            return true;
        }

        // You can call this function if you want to add new options to the select plugin
        // Target needs to be a unique identifier from the select you want to append new option for example #multi-select-plugin
        // Example of usage addOption("#multi-select-plugin", "tesla", "Tesla")
        function addOption(target, val, text) {
            const select = document.querySelector(target);
            let opt = document.createElement('option');
            opt.value = val;
            opt.innerHTML = text;
            select.appendChild(opt);
        }

        document.addEventListener("DOMContentLoaded", () => {

            // get select that has the options available
            const select = document.querySelectorAll("[data-multi-select-plugin]");
            select.forEach(select => {

                init(select);
            });

            // Dismiss on outside click
            document.addEventListener('click', () => {
                // get select that has the options available
                const select = document.querySelectorAll("[data-multi-select-plugin]");
                for (let i = 0; i < select.length; i++) {
                    if (event) {
                        var isClickInside = select[i].parentElement.parentElement.contains(event.target);

                        if (!isClickInside) {
                            const wrapper = select[i].parentElement.parentElement;
                            const dropdown = wrapper.querySelector(".dropdown-icon");
                            const autocomplete_list = wrapper.querySelector(".autocomplete-list");
                            //the click was outside the specifiedElement, do something
                            dropdown.classList.remove("active");
                            autocomplete_list.innerHTML = "";
                            addPlaceholder(wrapper);
                        }
                    }
                }
            });
        });
    </script>

    <script type="text/javascript">
        function validateAddTeam() {
            var isValid = true;

            function validatetxtField(element) {
                if (element.value.trim() === '') {
                    isValid = false;
                    element.style.border = '1px solid red';
                } else {
                    element.style.border = '';
                }
            }
            validatetxtField(document.getElementById('txtLicense1'));
            validatetxtField(document.getElementById('txtValidity1'));
            validatetxtField(document.getElementById('txtQualification1'));
            validatetxtField(document.getElementById('txtIssueDate1'));

            if (document.getElementById('ddlEmployer1').value === '0') {
                isValid = false;
                document.getElementById('ddlEmployer1').style.border = '1px solid red';
            }
            else {
                document.getElementById('ddlEmployer1').style.border = '';
            }

            if (!isValid) {
                alert('Please fill in all the required fields.');
            }
            //document.getElementById('hdnIsClientSideValid').value = isValid;
            return isValid;
        }
    </script>
    <script type="text/javascript">
        function validateFormodal() {
            var isValid = true;

            function validateField(element) {
                if (element.value.trim() === '') {
                    isValid = false;
                    element.style.border = '1px solid red';
                } else {
                    element.style.border = '';
                }
            }

            function validateDropdown(element) {
                if (element.value === '0' || element.selectedIndex === 0) {
                    isValid = false;
                    element.style.border = '1px solid red';
                } else {
                    element.style.border = '';
                }
            }

            function validatePinCode(element) {
                var pin = element.value.trim();
                var pinRegex = /^\d{6}$/;
                if (!pinRegex.test(pin)) {
                    isValid = false;
                    element.style.border = '1px solid red';
                } else {
                    element.style.border = '';
                }
            }

            var authority = document.getElementById('<%= ddlAuthority.ClientID %>');
            var name = document.getElementById('<%= txtName.ClientID %>');
            var address = document.getElementById('<%= txtAddress.ClientID %>');
            var state = document.getElementById('<%= ddlState.ClientID %>');
            var district = document.getElementById('<%= ddlDistrict.ClientID %>');
            var pinCode = document.getElementById('<%= txtPinCode.ClientID %>');

            validateDropdown(authority);
            validateField(name);
            validateField(address);
            validateDropdown(state);
            validateDropdown(district);
            validatePinCode(pinCode);

            if (!isValid) {
                alert('Please fill in all the required fields.');
            }

            return isValid;
        }
    </script>

     <script type="text/javascript">
         function FocusOnError(validationGroup) {
             if (typeof (Page_ClientValidate) == 'function') {
                 if (!Page_ClientValidate(validationGroup)) {
                     for (var i = 0; i < Page_Validators.length; i++) {
                         var validator = Page_Validators[i];
                         if (!validator.isvalid && validator.validationGroup === validationGroup) {
                             var control = document.getElementById(validator.controltovalidate);
                             if (control) {
                                 control.focus();
                                 break;
                             }
                         }
                     }
                     return false; // Prevent postback
                 }
             }
             return true; // Allow postback if valid
         }
     </script>
    <script type="text/javascript">
        function validateForm() {
            var isValid = true;

            function validateField(element, fieldName) {
                if (element.value.trim() === '') {
                    isValid = false;
                    element.style.border = '1px solid red';
                } else {
                    element.style.border = '';
                }
            }

            function validateDropdown(element) {
                if (element.value === '0') {
                    isValid = false;
                    element.style.border = '1px solid red';
                } else {
                    element.style.border = '';
                }
            }


            validateField(document.getElementById('txtBusinessAddress'), 'BusinessAddress');
            validateField(document.getElementById('txtBusinessPin'), 'BusinessPin');
            validateField(document.getElementById('txtBusinessEmail'), 'BusinessEmail');
            validateField(document.getElementById('txtBusinessPhoneNo'), 'BusinessPhoneNo');
            validateField(document.getElementById('txtNameOfCompany'), 'NameOfCompany');
            validateField(document.getElementById('txtGstNumber'), 'GstNumber');
            validateDropdown(document.getElementById('ddlCompanyStyle'));
            validateDropdown(document.getElementById('ddlOffice'));
            validateDropdown(document.getElementById('DdlPartnerOrDirector'));
            validateDropdown(document.getElementById('ddlAnnexureOrNot'));

            // Applicant details
            validateField(document.getElementById('txtAgentName'), 'AgentName');
            validateDropdown(document.getElementById('ddlUnitOrNot'));
            validateDropdown(document.getElementById('ddlLicenseGranted'));
            validateDropdown(document.getElementById('ddlSameNameLicense'));

            var ddlLicenseGranted = document.getElementById('ddlLicenseGranted');
            if (ddlLicenseGranted && ddlLicenseGranted.value === '1') {
                validateField(document.getElementById('txtIssusuingName'), 'Issusuing Name');
                validateField(document.getElementById('txtIssuedateOtherState'), 'DOB');
                validateField(document.getElementById('txtLicenseExpiry'), 'License Expiry');
                validateField(document.getElementById('txtWorkPermitUndertaken'), 'Work Permit Undertaken');

            }

            var ddlSameNameLicense = document.getElementById('ddlSameNameLicense');
            if (ddlSameNameLicense && ddlSameNameLicense.value === '1') {
                validateField(document.getElementById('txtLicenseNo'), 'txtLicenseNo');
                validateField(document.getElementById('txtLicenseIssue'), 'LicenseIssue');
            }


            validateDropdown(document.getElementById('DropDownList2'));

            var DropDownList2 = document.getElementById('DropDownList2');
            if (DropDownList2 && DropDownList2.value === '1') {
                validateField(document.getElementById('txtPenalities'), 'Penalities');
            }

            if (!isValid) {
                alert('Please fill in all the required fields.');
            }
            return isValid;
        }
    </script>
    <script type="text/javascript">
        function validateDates1() {
            var issuingDate = document.getElementById('<%=txtIssuedateOtherState.ClientID %>').value;
            var validityDate = document.getElementById('<%=txtLicenseExpiry.ClientID %>').value;

            if (new Date(issuingDate) > new Date(validityDate)) {
                alert('Validity Date should be greater than Issuing Date');
                document.getElementById('<%=txtLicenseExpiry.ClientID %>').value = ''; // Clear the expiry date
            }
        }
    </script>
    <script type="text/javascript">
        function validateDate() {
            var ClnDate = document.getElementById('<%=txtLicenseIssue.ClientID %>');

            var today = new Date();
            today.setHours(0, 0, 0, 0);

            if (ClnDate.value) {
                var ChallanDate = new Date(ClnDate.value);
                if (ChallanDate > today) {
                    alert('Issue Date cannot be a future date.');
                    ClnDate.value = '';
                    ClnDate.focus();
                    return;
                }
            }
        }
    </script>
    <script type="text/javascript">
        function validateDate1() {
            var ClnDate = document.getElementById('<%=txtIssuedateOtherState.ClientID %>');

            var today = new Date();
            today.setHours(0, 0, 0, 0);

            if (ClnDate.value) {
                var ChallanDate = new Date(ClnDate.value);
                if (ChallanDate > today) {
                    alert('Issue Date cannot be a future date.');
                    ClnDate.value = '';
                    ClnDate.focus();
                    return;
                }
            }
        }
    </script>
    <script type="text/javascript">
        function ValidateEmail() {
            var email = document.getElementById("<%= txtBusinessEmail.ClientID %>").value;
            var regex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
            var lblError = document.getElementById("lblError");

            if (email.length > 0 && !regex.test(email)) {
                lblError.innerHTML = "Invalid Email Address";
                return false;
            } else {
                lblError.innerHTML = "";
                return true;
            }
        }
    </script>
    <script type="text/javascript">
        function Search_Gridview(strKey) {
            var strData = strKey.value.toLowerCase().split(" ");
            var tblData = document.getElementById("<%=GridView4.ClientID %>");
            var rowData;
            for (var i = 1; i < tblData.rows.length; i++) {
                rowData = tblData.rows[i].innerHTML;
                var styleDisplay = 'none';
                for (var j = 0; j < strData.length; j++) {
                    if (rowData.toLowerCase().indexOf(strData[j]) >= 0)
                        styleDisplay = '';
                    else {
                        styleDisplay = 'none';
                        break;
                    }
                }
                tblData.rows[i].style.display = styleDisplay;
            }
        }
        function SearchOnEnter(event) {
            if (event.keyCode === 13) {
                event.preventDefault(); // Prevent default form submission
                Search_Gridview(document.getElementById('txtSearch'));
            }
        }
    </script>
    <script type="text/javascript">
        function updatePenalityText(dropdown) {
            var selectedOption = dropdown.options[dropdown.selectedIndex];
            var value = selectedOption.value;
            var text = selectedOption.text;

            if (value === "0") return;

            // Remove selected option from dropdown
            dropdown.remove(dropdown.selectedIndex);

            // Create tag element
            var container = document.getElementById("penaltyContainer");

            var tag = document.createElement("div");
            tag.className = "penalty-tag";
            tag.setAttribute("data-value", value);
            tag.setAttribute("data-text", text);
            tag.innerHTML = '' + text + ' <span class="remove-icon" onclick="removePenaltyTag(this, \'' + value + '\', \'' + text + '\')">&times;</span>';

            container.appendChild(tag);

            renumberPenaltyTags();
            updateHiddenTextbox();
        }

        function removePenaltyTag(span, value, text) {
            var tag = span.parentElement;
            tag.parentNode.removeChild(tag);

            // Re-add option to dropdown
            var ddl = document.getElementById("<%= ddlPenalities.ClientID %>");
            var newOption = document.createElement("option");
            newOption.value = value;
            newOption.text = text;
            ddl.add(newOption);

            ddl.selectedIndex = 0;

            renumberPenaltyTags();
            updateHiddenTextbox();
        }

        function renumberPenaltyTags() {
            var container = document.getElementById("penaltyContainer");
            var tags = container.children;

            for (var i = 0; i < tags.length; i++) {
                var tag = tags[i];
                var value = tag.getAttribute("data-value");
                var text = tag.getAttribute("data-text");

                tag.innerHTML = (i + 1) + '. ' + text + ' <span class="remove-icon" onclick="removePenaltyTag(this, \'' + value + '\', \'' + text + '\')">&times;</span>';
            }
        }

        function updateHiddenTextbox() {
            var tags = document.getElementById("penaltyContainer").children;
            var values = [];

            for (var i = 0; i < tags.length; i++) {
                var tag = tags[i];
                var text = tag.getAttribute("data-text");
                values.push((i + 1) + '. ' + text);
            }

            document.getElementById("<%= txtPenalities.ClientID %>").value = values.join(", ");
        }
    </script>
    <script type="text/javascript">
        function isValidLicenseKey(evt) {
            var charCode = evt.which ? evt.which : evt.keyCode;

            // Allow alphabets (A-Z, a-z)
            if ((charCode >= 65 && charCode <= 90) || (charCode >= 97 && charCode <= 122)) {
                return true;
            }

            // Allow numbers (0-9)
            if (charCode >= 48 && charCode <= 57) {
                return true;
            }

            // Allow - and /
            if (charCode === 45 || charCode === 47) {
                return true;
            }

            // Allow backspace, tab, delete, arrow keys
            if (charCode === 8 || charCode === 9 || charCode === 46 || (charCode >= 37 && charCode <= 40)) {
                return true;
            }

            return false; // Block everything else
        }
    </script>
    <script type="text/javascript">
        function FocusOnError(validationGroup) {
            if (typeof (Page_ClientValidate) == 'function') {
                if (!Page_ClientValidate(validationGroup)) {
                    for (var i = 0; i < Page_Validators.length; i++) {
                        var validator = Page_Validators[i];
                        if (!validator.isvalid && validator.validationGroup === validationGroup) {
                            var control = document.getElementById(validator.controltovalidate);
                            if (control) {
                                control.focus();
                                break;
                            }
                        }
                    }
                    return false; // Prevent postback
                }
            }
            return true; // Allow postback if valid
        }
    </script>
    <script type="text/javascript">
        function validateDOB() {
            var dobInput = document.getElementById('<%= txtDob.ClientID %>');
            var ageInput = document.getElementById('<%= txtCurrentAge.ClientID %>');
            var selectedDate = new Date(dobInput.value);
            var today = new Date();

            // Normalize both dates (remove time)
            today.setHours(0, 0, 0, 0);
            selectedDate.setHours(0, 0, 0, 0);

            // Check if DOB is today or future
            if (selectedDate >= today) {
                alert("Date of Birth cannot be today or a future date.");
                dobInput.value = "";
                if (ageInput) {
                    ageInput.value = "";
                }
                return false;
            }

            // Calculate age in years
            var years = today.getFullYear() - selectedDate.getFullYear();
            var months = today.getMonth() - selectedDate.getMonth();
            var days = today.getDate() - selectedDate.getDate();

            if (months < 0 || (months === 0 && days < 0)) {
                years--;
            }

            // Check if age is 18 or below
            if (years < 18) {
                alert("You must be at least 18 years old to apply.");
                dobInput.value = "";
                if (ageInput) {
                    ageInput.value = "";
                }
                return false;
            }

            // If txtCurrentAge input exists, populate it
            if (ageInput) {
                ageInput.value = years + " years";
            }

            return true;
        }
    </script>

    <script type="text/javascript">
        window.onload = function () {
            const today = new Date();
            today.setDate(today.getDate() - 1); // Yesterday
            const yyyy = today.getFullYear();
            const mm = String(today.getMonth() + 1).padStart(2, '0');
            const dd = String(today.getDate()).padStart(2, '0');
            const maxDate = `${yyyy}-${mm}-${dd}`;
            document.getElementById('txtLicenseIssue').setAttribute('max', maxDate);
        };
    </script>

    <script type="text/javascript">
        function validateChallanDate() {
            var input = document.getElementById("txtChallanDate");
            var selectedDate = new Date(input.value);
            var today = new Date();

            // Clear time part for accurate date-only comparison
            today.setHours(0, 0, 0, 0);
            selectedDate.setHours(0, 0, 0, 0);

            if (selectedDate > today) {
                alert("Future dates are not allowed.");
                input.value = ""; // Clear invalid input
            }
        }
    </script>
      <script type="text/javascript">
          function isAlphaNumeric(evt) {
              var charCode = evt.which ? evt.which : evt.keyCode;
              var charStr = String.fromCharCode(charCode);
              // Allow only letters (a-z, A-Z) and digits (0-9)
              if (!/^[a-zA-Z0-9]$/.test(charStr)) {
                  evt.preventDefault();
                  return false;
              }
              return true;
          }
      </script>
</asp:Content>
