<%@ Page Title="" Language="C#" MasterPageFile="~/SiteOwnerPages/SiteOwner.Master" AutoEventWireup="true" CodeBehind="ProcessInspectionRenewalCart.aspx.cs" Inherits="CEIHaryana.SiteOwnerPages.ProcessInspectionRenewalCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="shortcut icon" type="image/png" href="/css2/style.min.css" />
    <link rel="stylesheet" href="/css2/style.css" />
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css" />
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/css/select2.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/js/select2.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
    <script src="https://cdn.rawgit.com/harvesthq/chosen/gh-pages/chosen.jquery.min.js"></script>
    <link href="https://cdn.rawgit.com/harvesthq/chosen/gh-pages/chosen.min.css" rel="stylesheet" />
    <script defer src="https://use.fontawesome.com/releases/v5.15.4/js/all.js"></script>
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

        span {
            font-weight: 400;
            font-size: 12px;
        }

        th.headercolor {
            background: #9292cc;
            color: white;
        }

        th {
            background: #9292cc;
            color: white;
            width: 1%;
            text-align: center;
        }

        td {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
<div class="row " id="InspectionDetailsHeading" visible="false" runat="server">
     <div class="col-sm-4 col-md-4">
         <h6 class="card-title fw-semibold mb-4">
             <asp:Label ID="Label3" runat="server"></asp:Label>Inspection Details</h6>
     </div>
 </div>
 <div class="card-body" id="InspectionDetails" visible="false" runat="server" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px;">

     <div class="row">
         <div class="col-12">
            <asp:GridView ID="GridView3" CssClass="table table-bordered table-striped table-responsive" runat="server" AutoGenerateColumns="false">
                 <HeaderStyle BackColor="#B7E2F0" />
                 <Columns>
                     <asp:TemplateField HeaderText="SNo">
                         <HeaderStyle Width="5%" CssClass="headercolor" />
                         <ItemStyle Width="5%" />
                         <ItemTemplate>
                             <%#Container.DataItemIndex+1 %>
                         </ItemTemplate>
                     </asp:TemplateField>
                   <%--  <asp:BoundField DataField="Id" HeaderText="Inspection Id">
                         <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                         <ItemStyle HorizontalAlign="Left" Width="15%" />
                     </asp:BoundField>--%>
                     <asp:BoundField DataField="InstallationType" HeaderText="Installation Type">
                         <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                         <ItemStyle HorizontalAlign="Left" Width="15%" />
                     </asp:BoundField>

                     <asp:BoundField DataField="ActionTaken" HeaderText="ActionTaken">
                         <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                         <ItemStyle HorizontalAlign="Left" Width="15%" />
                     </asp:BoundField>
                     <asp:BoundField DataField="ActionDate" HeaderText="ActionDate">
                         <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                         <ItemStyle HorizontalAlign="Left" Width="15%" />
                     </asp:BoundField>
                     <asp:BoundField DataField="AssignTo" HeaderText="AssignTo">
                         <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                         <ItemStyle HorizontalAlign="Left" Width="15%" ForeColor="Red" />
                     </asp:BoundField>
                    <%-- <asp:BoundField DataField="ReturnDate" HeaderText="ReturnDate">
                         <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                         <ItemStyle HorizontalAlign="Left" Width="15%" />
                     </asp:BoundField>--%>
                     <asp:BoundField DataField="Remarks" HeaderText="Remarks">
                         <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                         <ItemStyle HorizontalAlign="Left" Width="15%" />
                     </asp:BoundField>
                     <asp:TemplateField HeaderText="Id" Visible="False">
                         <ItemTemplate>
                             <asp:Label ID="lblSubmittedDate" runat="server" Text='<%#Eval("ActionDate") %>'></asp:Label>
                         </ItemTemplate>
                     </asp:TemplateField>
                 </Columns>
                 <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" />
             </asp:GridView>

         </div>
     </div>
 </div>

            <div class="row ">
                <div class="col-sm-4 col-md-4">
                    <h6 class="card-title fw-semibold mb-4">
                        <asp:Label ID="lblData" runat="server"></asp:Label>Submit Periodic Inspection</h6>
                </div>
            </div>
            <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px;">
                <h2 style="font-size: 15px; color: brown">
     Note : Before proceeding to document checklist kindly pay your requisite fees first and then upload documents along with the treasury challan (PDF).

 </h2>
                <div class="row">
                    <div class="col-12">
                        <table class="table table-bordered table-striped table-responsive table-hover">
                            <thead>
                                <tr>
                                    <th scope="col">Total Capacity</th>
                                    <th scope="col">Highest Voltage</th>
                                    <th scope="col">Payment Amount</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td scope="row">
                                        <asp:Label ID="LblCapacity" Font-Bold="true" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="LblVoltage" Font-Bold="true" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        ₹ <asp:Label ID="LblAmount" Font-Bold="true" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
            <div class="row ">
                <div class="col-sm-4 col-md-4">
                    <h6 class="card-title fw-semibold mb-4">
                        <asp:Label ID="Label1" runat="server"></asp:Label>Documents Checklist</h6>
                </div>
            </div>
            <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px;">
                <div class="row">
                   <%-- <div class="col-md-12">
                        <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="true" OnCheckedChanged="CheckBox1_CheckedChanged" />  If You don't have Previous Inspection Report 
                        </div>--%>
                    </div>
                <div class="row">
                    <div class="col-12">
                        <asp:GridView class="table-responsive table table-striped" ID="GridView1" runat="server" Width="100%" 
                            AutoGenerateColumns="false" BorderWidth="1px" BorderColor="#dbddff">
                            <%-- OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand"--%>

                            <PagerStyle CssClass="pagination-ys" />
                            <Columns>
                                <asp:TemplateField HeaderText="SNo">
                                    <HeaderStyle Width="5%" CssClass="headercolor" />
                                    <ItemStyle Width="5%" />
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="InstallationType" HeaderText="Inspection Of Type">
                                    <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Document Name">
                                    <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblDocumentName" runat="server" Text='<%#Eval("DocumentName") %>'></asp:Label>
                                        <asp:Label ID="lblMandatory1" runat="server" Text="*" ForeColor="Red" Visible='<%# Eval("DocumentName").ToString() != "Other Document" %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Upload Document">
                                    <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                                    <ItemTemplate>
                                        <asp:FileUpload ID="FileUpload1" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Id" Visible="False">
                                    <ItemTemplate>
                                    <%--    <asp:Label ID="LblInstallationType" runat="server" Text='<%#Eval("InstallationName") %>'></asp:Label>--%>
                                        <asp:Label ID="LblInstallationType" runat="server" Text='<%#Eval("InstallationType") %>'></asp:Label>

                                        <asp:Label ID="LblCategory" runat="server" Text='<%#Eval("InstallationName") %>'></asp:Label>
                                        <asp:Label ID="LblInspectionId" runat="server" Text='<%#Eval("InspectionId") %>'></asp:Label>
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
                    </div>
                </div>

                <div class="row">
                    <div class="col-12">
                        <asp:GridView class="table-responsive table table-striped" ID="GridView2" runat="server" Width="100%" 
                            AutoGenerateColumns="false" BorderWidth="1px" BorderColor="#dbddff" OnRowCommand="GridView2_RowCommand">
                            <PagerStyle CssClass="pagination-ys" />
                            <Columns>
                                <asp:TemplateField HeaderText="SNo">
                                    <HeaderStyle Width="5%" CssClass="headercolor" />
                                    <ItemStyle Width="5%" />
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="InstallationType" HeaderText="Inspection Of Type">
                                    <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Document Name">
                                    <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblDocumentName2" runat="server" Text='<%#Eval("DocumentName") %>'></asp:Label>
                                    <asp:Label ID="lblMandatory2" runat="server" Text="*" ForeColor="Red" Visible='<%# Eval("DocumentName").ToString() != "Other Document" %>'></asp:Label>                           
                                        </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Uploaded Documents" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="4%">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LnkDocumemtPath2" runat="server" CommandArgument='<%# Bind("DocumentPath") %>' CommandName="Select"> View document </asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="2%" CssClass="headercolor"></ItemStyle>
                                    <HeaderStyle HorizontalAlign="Left" CssClass="headercolor" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Upload Document">
                                    <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                                    <ItemTemplate>


                                        <asp:FileUpload ID="FileUpload2" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Id" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="LblInstallationType2" runat="server" Text='<%#Eval("InstallationType") %>'></asp:Label>
                                        <asp:Label ID="LblCategory2" runat="server" Text='<%#Eval("InstallationType") %>'></asp:Label>
                                        <asp:Label ID="LblInspectionId2" runat="server" Text='<%#Eval("InspectionId") %>'></asp:Label>
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
                    </div>
                </div>

            </div>
            <div class="row ">
                <div class="col-sm-4 col-md-4">
                    <h6 class="card-title fw-semibold mb-4">
                        <asp:Label ID="Label2" runat="server"></asp:Label>Fees</h6>
                </div>
            </div>
            <%--   <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px;">
                <div class="row">
                    <div class="col-12">
                        <table class="table table-bordered table-striped table-responsive table-hover">
                            <thead>
                                <tr>
                                    <th>Payment Amount</th>
                                    <td style="width: 1% !important;">
                                        <asp:Label ID="LblAmount" runat="server"></asp:Label></td>
                                </tr>
                            </thead>
                        </table>
                    </div>
                </div>
            </div>--%>
            <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px;">
                <div class="row">
                    <div class="col-md-4">
                        <label for="Phone">
                            Transaction Id (GRN Number)<samp style="color: red">* </samp>
                        </label>
                        <asp:TextBox class="form-control" ID="txtTransactionId" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTransactionId" ValidationGroup="Submit" ForeColor="Red">Please Enter TransactionId</asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-4" runat="server">
                        <label for="Email">
                            Transaction Date<samp style="color: red">* </samp>
                        </label>
                        <asp:TextBox type="date" class="form-control" ID="txtTransactiondate" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTransactiondate" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Select Transactiondate</asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>

            <div class="row" id="Declaration" runat="server" visible="true" style="margin-left: 1%; margin-bottom: 20px;">
                <label style="display: flex; align-items: center;">
                    <asp:CheckBox ID="Check" runat="server" TabIndex="24" Style="margin-top: -5px;" />
                    <span style="margin-left: 8px; font-size: 17px; line-height: 20px; margin-top: 9px;">We undertake that we shall maintain and operate all the electrical installations in a condition free from danger and as recommended by the manufacturer and/or by the relevant Code of Practice of the Bureau of Indian Standards.
                    </span>
                </label>
            </div>
            <div class="row">
                <div class="col-4" style="text-align: center;">
                    <asp:Button ID="btnSubmit" Text="Submit" runat="server" ValidationGroup="Submit" class="btn btn-primary mr-2" OnClick="btnSubmit_Click" />
                </div>
            </div>
            <div class="row1">
                <div class="col-4" style="text-align: center;">
                    <asp:HiddenField ID="HF_para_InspectID" runat="server" />
                      <asp:HiddenField ID="hfOwner" runat="server" />
                </div>
            </div>
        </div>
    </div>
  

    <script type="text/javascript">
        window.onload = function () {
            // Get the current date in YYYY-MM-DD format
            var today = new Date();
            var dd = String(today.getDate()).padStart(2, '0');
            var mm = String(today.getMonth() + 1).padStart(2, '0'); // January is 0!
            var yyyy = today.getFullYear();

            today = yyyy + '-' + mm + '-' + dd;

            // Set the max date for the txtTransactiondate input to the current date
            document.getElementById('<%= txtTransactiondate.ClientID %>').setAttribute('max', today);
        }
</script>
</asp:Content>
