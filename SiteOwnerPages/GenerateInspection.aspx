<%@ Page Title="" Language="C#" MasterPageFile="~/SiteOwnerPages/SiteOwner.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="GenerateInspection.aspx.cs" Inherits="CEIHaryana.SiteOwnerPages.GenerateInspection" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       <link rel="shortcut icon" type="image/png" href="/css2/style.min.css" />
    <link rel="stylesheet" href="/css2/style.css" />
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/css/select2.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/js/select2.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.5.2/css/bootstrap.css" rel="stylesheet" />
    <link href="https://cdn.datatables.net/1.13.5/css/dataTables.bootstrap4.min.css" rel="stylesheet" />

    <script src="https://code.jquery.com/jquery-3.7.0.js"></script>
    <script src="https://cdn.datatables.net/1.13.5/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.13.5/js/dataTables.bootstrap4.min.js"></script>
    <script src="https://kit.fontawesome.com/57676f1d80.js" crossorigin="anonymous"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">  <script type="text/javascript">
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
          th.headercolor {
    background: #9292cc;
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

        .col-4 {
            margin-bottom: 15px;
        }

        .form-control {
            box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
            margin-left: 0px !important;
            height: 30px;
        }

        select.form-control {
            box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
            margin-left: 0px !important;
            height: 30px;
        }

        label {
            font-size: 13px;
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="content-wrapper">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="card" style="box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px; border-radius: 5px !important">
            <div class="card-body">
                <h7 class="card-title fw-semibold mb-4">INSPECTION REPORT</h7>
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
                        <div class="row" id="Test" runat="server" visible="false">
                              <%--  <div class="col-4">
                                    <label>Request Type </label>
                                    <asp:DropDownList class="form-control  select-form select2" ID="ddlRequestType" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlRequestType_SelectedIndexChanged">
                                        <asp:ListItem>Select</asp:ListItem>
                                        <asp:ListItem>New</asp:ListItem>
                                        <asp:ListItem>Re-inspection</asp:ListItem>
                                    </asp:DropDownList>
                                </div>--%>
                                <div class="col-4">
                                    <label>
                                        Type of Inspection
                                        <samp style="color: red">* </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtPremises" ReadOnly="true" MaxLength="6" onkeydown="return preventEnterSubmit(event)" onkeyup="ValidatePincode();" onKeyPress="return isNumberKey(event);" autocomplete="off" TabIndex="7" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                </div>
                                <div class="col-4">
                                    <label>
                                        Type of Applicant<samp style="color: red"> * </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtApplicantType" ReadOnly="true" MaxLength="6" onkeydown="return preventEnterSubmit(event)" onkeyup="ValidatePincode();" onKeyPress="return isNumberKey(event);" autocomplete="off" TabIndex="7" runat="server" Style="margin-left: 18px"></asp:TextBox>

                                </div>
                                <div class="col-4">
                                    <label>
                                        Type of Installation<samp style="color: red"> * </samp>
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtWorkType" ReadOnly="true" MaxLength="6" onkeydown="return preventEnterSubmit(event)" onkeyup="ValidatePincode();" onKeyPress="return isNumberKey(event);" autocomplete="off" TabIndex="7" runat="server" Style="margin-left: 18px"></asp:TextBox>

                                </div>
                                <div class="col-4" runat="server">
                                    <label for="Pin">Voltage Level</label>
                                    <asp:TextBox class="form-control" ID="txtVoltage" ReadOnly="true" MaxLength="6" onkeydown="return preventEnterSubmit(event)" onkeyup="ValidatePincode();" onKeyPress="return isNumberKey(event);" autocomplete="off" TabIndex="7" runat="server" Style="margin-left: 18px"></asp:TextBox>

                                </div>
                                <div class="col-4" runat="server">
                                    <label for="Pin">Date</label>
                                    <asp:TextBox class="form-control" ID="txtDate" ReadOnly="true" runat="server" autocomplete="off" Style="margin-left: 18px"></asp:TextBox>
                                </div>
                                   <div class="col-4" runat="server">
                                    <label for="Pin">Contact Number</label>
                                    <asp:TextBox class="form-control" ID="txtContact" ReadOnly="true" runat="server" autocomplete="off" Style="margin-left: 18px"></asp:TextBox>
                                </div> 
                                <div class="col-4" runat="server" visible="false">
                                    <label for="Pin">Line Length</label>
                                    <asp:TextBox class="form-control" ID="txtLineLength" ReadOnly="true" runat="server" autocomplete="off" Style="margin-left: 18px"></asp:TextBox>
                                </div>
                            </div>
                        <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                         <asp:GridView class="table-responsive table table-hover table-striped" Autopostback="true" ID="GridView1" runat="server" Width="100%" AllowPaging="true" PageSize="10"
                            AutoGenerateColumns="false" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand" OnPageIndexChanging="GridView1_PageIndexChanging" BorderWidth="1px" BorderColor="#dbddff">
                            <PagerStyle CssClass="pagination-ys" />
                            <Columns>
                                <asp:TemplateField >
                                     <HeaderStyle Width="5%" CssClass="headercolor" />
                                    <ItemStyle Width="5%" />
                                    <HeaderTemplate>
                                     <%--   <asp:CheckBox ID="chkSelectAll" runat="server" />--%>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBox1" AutoPostBack="true" runat="server" HorizontalAlign="center" OnCheckedChanged="chkSelect_CheckedChanged" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Id" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCategory" runat="server" Text='<%#Eval("Typs") %>'></asp:Label>
                                        <asp:Label ID="lblVoltageLevel" runat="server" Text='<%#Eval("VoltageLevel") %>'></asp:Label>
                                        <asp:Label ID="lblApplicant" runat="server" Text='<%#Eval("Applicant") %>'></asp:Label>
                                        <asp:Label ID="lblDivision" runat="server" Text='<%#Eval("Division") %>'></asp:Label>
                                        <asp:Label ID="lblDistrict" runat="server" Text='<%#Eval("District") %>'></asp:Label>
                                        <asp:Label ID="lblNoOfInstallations" runat="server" Text='<%#Eval("NoOfInstallations") %>'></asp:Label> 
                                        <asp:Label ID="lblPermises" runat="server" Text='<%#Eval("Permises") %>'></asp:Label>
                                        <asp:Label ID="lblApplicantTypeCode" runat="server" Text='<%#Eval("ApplicantTypeCode") %>'></asp:Label>

                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SNo">
                                    <HeaderStyle Width="5%" CssClass="headercolor" />
                                    <ItemStyle Width="5%" />
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Typs" HeaderText="Installations Type">
                                    <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NoOfInstallations" HeaderText="Installations No.">
                                    <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="history" HeaderText="Test Report">
                                    <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                                </asp:BoundField>
                                   <asp:TemplateField HeaderText="Application">
                                    <HeaderStyle Width="25%" CssClass="headercolor"  />
                                    <ItemStyle Width="25%" />
                                    <ItemTemplate>
                                           <asp:LinkButton ID="LinkButton4" runat="server" AutoPostBack="true" 
                                               CommandName="Select" >View Test Report</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>


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
                   <div class="row" id="Documents" runat="server" visible="false">
                         <div class="col-4">
                            <label>
                                Document Uploaded for
                            </label>
                            <asp:DropDownList Style="width: 100% !important;" class="form-control select-form select2" ID="ddlDocumentFor" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDocumentFor_SelectedIndexChanged">
                                
                            </asp:DropDownList>
                               <asp:RequiredFieldValidator ID="Req_state" Text="Required" ErrorMessage="Required" ControlToValidate="ddlDocumentFor" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                             
                        </div>
                       </div>                            

                          <%--  <div class="row">
                                <div class="table-responsive pt-3" id="Div1" runat="server" >
                                    <table class="table table-bordered table-striped" id="DocumentsTable" runat="server">
                                        <thead class="table-dark">
                                            <tr>
                                                <th>Name of Documents
                                                </th>
                                                <th>Upload Documents
                                                </th>
                                            </tr>
                                        </thead>
                                        </table>
                                  </div>
                                </div>--%>

                            <div class="row">
                                <div class="table-responsive pt-3" id="Uploads" runat="server" visible="false">
                                    <table class="table table-bordered table-striped">
                                        <thead class="table-dark">
                                            <tr>
                                                <th>Name of Documents
                                                </th>
                                                <th>Upload Documents
                                                </th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <div id="LineSubstationSupplier" runat="server" visible="false">
                                                <tr id="Tr1" runat="server" visible="true">
                                                    <td>
                                                        <div class="col-12">
                                                            Request letter from concerned Officer<samp style="color: red"> * </samp>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div class="col-12">
                                                            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control" Style="padding: 0px;" />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                                ControlToValidate="FileUpload1" ErrorMessage="Please select a file" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr id="Tr2" runat="server" visible="true">
                                                    <td>
                                                        <div class="col-12">
                                                            Manufacturing test report of equipment<samp style="color: red"> * </samp>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div class="col-12">
                                                            <asp:FileUpload ID="FileUpload2" runat="server" CssClass="form-control" Style="padding: 0px;" />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                                                ControlToValidate="FileUpload2" ErrorMessage="Please select a file" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </div>
                                            <div id="SupplierSub" runat="server" visible="false">
                                                <tr id="Tr3" runat="server" visible="true">
                                                    <td>
                                                        <div class="col-12">
                                                            Single line diagram of Line<samp style="color: red"> * </samp>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div class="col-12">
                                                            <asp:FileUpload ID="FileUpload3" runat="server" CssClass="form-control" Style="padding: 0px; height: 31px;" />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                                                ControlToValidate="FileUpload3" ErrorMessage="Please select a file" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </div>
                                            <div id="PersonalSub" runat="server" visible="false">
                                                <tr id="Tr4" runat="server" visible="true">
                                                    <td>
                                                        <div class="col-12">
                                                            Copy of demand notice issued by UHDVN/ DHBVN<samp style="color: red"> * </samp>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div class="col-12">
                                                            <asp:FileUpload ID="FileUpload4" runat="server" CssClass="form-control" Style="padding: 0px;" />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                                                ControlToValidate="FileUpload4" ErrorMessage="Please select a file" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>

                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr id="Tr5" runat="server" visible="true">
                                                    <td>
                                                        <div class="col-12">
                                                            Invoice of transformer<samp style="color: red"> * </samp>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div class="col-12">
                                                            <asp:FileUpload ID="FileUpload5" runat="server" CssClass="form-control" Style="padding: 0px; height: 31px;" />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                                                ControlToValidate="FileUpload5" ErrorMessage="Please select a file" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>

                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr id="Tr6" runat="server" visible="true">
                                                    <td>
                                                        <div class="col-12">
                                                            Manufacturing test certificate of transformer<samp style="color: red"> * </samp>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div class="col-12">
                                                            <asp:FileUpload ID="FileUpload6" runat="server" CssClass="form-control" Style="padding: 0px;" />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                                                ControlToValidate="FileUpload6" ErrorMessage="Please select a file" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>

                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr id="Tr7" runat="server" visible="true">
                                                    <td>
                                                        <div class="col-12">
                                                            Single line diagram
                                                        <samp style="color: red">* </samp>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div class="col-12">
                                                            <asp:FileUpload ID="FileUpload7" runat="server" CssClass="form-control" Style="padding: 0px; height: 31px;" />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                                                                ControlToValidate="FileUpload7" ErrorMessage="Please select a file" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>

                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr id="Tr8" runat="server" visible="true">
                                                    <td>
                                                        <div class="col-12">
                                                            Invoice of fire extinguisher system, apparatus installed at the site<samp style="color: red"> * </samp>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div class="col-12">
                                                            <asp:FileUpload ID="FileUpload8" runat="server" CssClass="form-control" Style="padding: 0px;" />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                                                                ControlToValidate="FileUpload8" ErrorMessage="Please select a file" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>

                                                        </div>
                                                    </td>
                                                </tr>
                                            </div>
                                            <div id="PersonalGenerating" runat="server" visible="false">
                                                <tr id="Tr9" runat="server" visible="true">
                                                    <td>
                                                        <div class="col-12">
                                                            Invoice of DG set<samp style="color: red"> * </samp>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div class="col-12">
                                                            <asp:FileUpload ID="FileUpload9" runat="server" CssClass="form-control" Style="padding: 0px; height: 31px;" />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"
                                                                ControlToValidate="FileUpload9" ErrorMessage="Please select a file" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>

                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr id="Tr10" runat="server" visible="true">
                                                    <td>
                                                        <div class="col-12">
                                                            Manufacturing test certificate of DG set
                                                        <samp style="color: red">* </samp>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div class="col-12">
                                                            <asp:FileUpload ID="FileUpload10" runat="server" CssClass="form-control" Style="padding: 0px;" />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"
                                                                ControlToValidate="FileUpload10" ErrorMessage="Please select a file" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>

                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr id="Tr13" runat="server" visible="true">
                                                    <td>
                                                        <div class="col-12">
                                                            Invoice Of fire Extinguisher/apparatus installed at the site<samp style="color: red"> * </samp>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div class="col-12">
                                                            <asp:FileUpload ID="FileUpload13" runat="server" CssClass="form-control" Style="padding: 0px; height: 31px;" />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server"
                                                                ControlToValidate="FileUpload13" ErrorMessage="Please select a file" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>

                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr id="Tr11" runat="server" visible="true">
                                                    <td>
                                                        <div class="col-12">
                                                            Structure stability report issued by authorized engineer<samp style="color: red"> * </samp>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div class="col-12">
                                                            <asp:FileUpload ID="FileUpload11" runat="server" CssClass="form-control" Style="padding: 0px; height: 31px;" />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server"
                                                                ControlToValidate="FileUpload11" ErrorMessage="Please select a file" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>

                                                        </div>
                                                    </td>
                                                </tr>
                                            </div>

                                            <tr id="LinePersonal" runat="server" visible="false">
                                                <td>
                                                    <div class="col-12">
                                                        Demand Notice<samp style="color: red"> * </samp>
                                                    </div>
                                                </td>
                                                <td>
                                                    <div class="col-12">
                                                        <asp:FileUpload ID="FileUpload12" runat="server" CssClass="form-control" Style="padding: 0px;" />
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server"
                                                            ControlToValidate="FileUpload12" ErrorMessage="Please select a file" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>

                                                    </div>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                     <asp:PlaceHolder runat="server" ID="divContainer"></asp:PlaceHolder>
                                    <%--<div class="col-4" runat="server">
                                        <label for="Pin">Request Details</label>
                                        <asp:TextBox class="form-control" ID="txtRequestDetails" TextMode="MultiLine" Rows="5" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>--%>
                                </div>
                            </div>
                        </div>
                <div class="card" style=" box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px !important; margin-bottom:20px;">
                        <asp:GridView class="table-responsive table table-hover table-striped" CssClass="grid1" ID="GridView2" runat="server" Width="100%" AllowPaging="true" PageSize="20" OnPageIndexChanging="GridView1_PageIndexChanging"
                            AutoGenerateColumns="false">
                            <Columns>
                                <asp:TemplateField HeaderText="Id" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblId" runat="server" Text='<%#Eval("ID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Id" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblInstallationType" runat="server" Text='<%#Eval("InstallationType") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Id" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblVoltageLevel" runat="server" Text='<%#Eval("VoltageLevel") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="ApplicantName" HeaderText="Name">
                                    <HeaderStyle HorizontalAlign="Left" Width="15%" />
                                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="InstallationType" HeaderText="Installation Type">
                                    <HeaderStyle HorizontalAlign="Left" Width="15%" />
                                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                                </asp:BoundField>
                              <%--  <asp:BoundField DataField="ApplicantType" HeaderText="Applicant Type">
                                    <HeaderStyle HorizontalAlign="center" Width="12%" />
                                    <ItemStyle HorizontalAlign="center" Width="12%" />
                                </asp:BoundField>--%>
                                <asp:BoundField DataField="VoltageLevel" HeaderText="Voltage Level">
                                    <HeaderStyle HorizontalAlign="center" Width="15%" />
                                    <ItemStyle HorizontalAlign="center" Width="15%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Payment" HeaderText="Payment">
                                    <HeaderStyle HorizontalAlign="center" Width="15%" />
                                    <ItemStyle HorizontalAlign="center" Width="15%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CreatedDate1" HeaderText="Created Date">
                                    <HeaderStyle HorizontalAlign="center" Width="13%" />
                                    <ItemStyle HorizontalAlign="center" Width="13%" />
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
                        <div id="TotalPayment" runat="server" visible="false" class="row" style="margin-bottom: -30px; margin-left: 30px;">
                            <div class="col-6">
                                <div class="form-group row">
                                    <label for="search" class="col-sm-3 col-form-label">Total payment:</label>
                                     <div class="col-sm-8" style="margin-left:-35px;">
                                    <div class="col-sm-8">
<%--                                        <svg xmlns="http://www.w3.org/2000/svg" height="16" width="12" viewBox="0 0 320 512"><!--!Font Awesome Free 6.5.1 by @fontawesome - https://fontawesome.com License - https://fontawesome.com/license/free Copyright 2023 Fonticons, Inc.--><path d="M0 64C0 46.3 14.3 32 32 32H96h16H288c17.7 0 32 14.3 32 32s-14.3 32-32 32H231.8c9.6 14.4 16.7 30.6 20.7 48H288c17.7 0 32 14.3 32 32s-14.3 32-32 32H252.4c-13.2 58.3-61.9 103.2-122.2 110.9L274.6 422c14.4 10.3 17.7 30.3 7.4 44.6s-30.3 17.7-44.6 7.4L13.4 314C2.1 306-2.7 291.5 1.5 278.2S18.1 256 32 256h80c32.8 0 61-19.7 73.3-48H32c-17.7 0-32-14.3-32-32s14.3-32 32-32H185.3C173 115.7 144.8 96 112 96H96 32C14.3 96 0 81.7 0 64z"/></svg>--%>
                                        <asp:TextBox ID="txtPayment" runat="server" ReadOnly="true" class="form-control" onkeydown="return SearchOnEnter(event);" Font-Size="12px" onkeyup="Search_Gridview(this)" Style="margin-top: 4px"></asp:TextBox><br />
                                    </div>
                                </div>
                            </div>
                                </div>
                            <div class="col-6" style="margin-bottom: auto;">

                                 Paymant Mode
               <asp:RadioButtonList ID="RadioButtonList2" OnSelectedIndexChanged="RadioButtonList2_SelectedIndexChanged" AutoPostBack="true" runat="server" RepeatDirection="Horizontal" TabIndex="25">
                   <asp:ListItem Text="Online" Value="0" Enabled="false"></asp:ListItem>
                   <asp:ListItem Text="Offline" Value="1" Selected="True"></asp:ListItem>
               </asp:RadioButtonList>
                            <asp:RequiredFieldValidator ID="rfvRbList" runat="server" ControlToValidate="RadioButtonList2" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please select a value" Display="Dynamic" />
                        </div>
                           <%-- <asp:Button type="submit" ID="btnOnline" ValidationGroup="Submit"  disabled="true" Text="Online Payment" runat="server" class="btn btn-primary mr-2" />                   
                <asp:Button type="submit" ID="ChallanUpload"  Text="Offline" runat="server" class="btn btn-primary mr-2" onclick="ChallanUpload_Click" />
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtInspectionDetails" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Required</asp:RequiredFieldValidator>     
                        </div>--%>
                            </div>
                

                    <div id="ChallanDetail" runat="server" visible="false" class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 35px;">
                    <div class="row" style="margin-top: 15px; margin-bottom: 15PX !important;">
                        <div class="col-6">
                            <label>
                                Inspection Request details   <samp style="color: red"> * </samp>
                            </label>
                            <asp:TextBox ID="txtInspectionDetails" runat="server" ReadOnly="true" class="form-control" onkeydown="return SearchOnEnter(event);" Font-Size="12px" onkeyup="Search_Gridview(this)" Style="height: 30px;"></asp:TextBox><br />

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtInspectionDetails" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Required</asp:RequiredFieldValidator>

                        </div>

                        <div class="col-6">
                            <label>Transaction Id<samp style="color: red"> * </samp></label>
                            <asp:TextBox ID="txttransactionId" runat="server" class="form-control" onkeydown="return SearchOnEnter(event);" Font-Size="12px" onkeyup="Search_Gridview(this)" Style="height: 30px;"></asp:TextBox><br />

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txttransactionId" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Required</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="row" style="margin-top: -40px !important;">
                        <div class="col-6">
                            <label>Transaction Date<samp style="color: red"> * </samp></label>
                            <asp:TextBox ID="txttransactionDate" min='0000-01-01' max='9999-01-01' Type="Date" runat="server" class="form-control" onkeydown="return SearchOnEnter(event);" Font-Size="12px" onkeyup="Search_Gridview(this)" Style="height: 30px;"></asp:TextBox><br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txttransactionDate" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Required</asp:RequiredFieldValidator>

                        </div>

                        <div class="col-6">
                            <label>
                                Upload Challan (Only PDF Allowed)<samp style="color: red"> * </samp>
                            </label>
                            <asp:FileUpload ID="FileUpload14" runat="server" class="form-control" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="FileUpload14" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Required</asp:RequiredFieldValidator>
                        </div>
                        
                    </div>
                </div>
                <div>
                    <div class="row">
                        <div class="col-4"></div>
                        <div class="col-4" style="text-align: center;">
                            <asp:Button ID="btnSubmit" Text="Submit" runat="server" ValidationGroup="Submit"  class="btn btn-primary mr-2"
                                OnClick="btnSubmit_Click" />
                            <asp:Button type="submit" ID="btnReset" Text="Reset" runat="server" class="btn btn-primary mr-2" />
                            <asp:Button type="Back" ID="btnBack" Text="Back" runat="server" Visible="false" class="btn btn-primary mr-2" />
                        </div>
                        <div class="col-4"></div>
                    </div>
                    <asp:HiddenField ID="hdnId" runat="server" />
                    <asp:HiddenField ID="hdnId2" runat="server" />
                    <div>
                    </div>
                </div>
            </div>
        </div>
     </div>
    <footer class="footer">
    </footer>

    <script type="text/javascript">
        function alertWithRedirectdata() {
            if (confirm('Inspection Added Successfully')) {
                window.location.href = "/SiteOwnerPages/InspectionHistory.aspx";
            } else {
            }
        }
    </script>
    <script type="text/javascript">
        function alertWithRedirect() {
            if (confirm('Select all PDF files only')) {
            } else {
            }
        }
    </script>
    <script type="text/javascript">
        function SelectAllCheckboxes(headerCheckbox) {
            var checkboxes = document.querySelectorAll('[id*=CheckBox1]');
            for (var i = 0; i < checkboxes.length; i++) {
                checkboxes[i].checked = headerCheckbox.checked;
            }
        }
    </script>
</asp:Content>
