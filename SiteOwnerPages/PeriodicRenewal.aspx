<%@ Page Title="" Language="C#" MasterPageFile="~/SiteOwnerPages/SiteOwner.Master" AutoEventWireup="true" CodeBehind="PeriodicRenewal.aspx.cs" EnableEventValidation="false" Inherits="CEIHaryana.SiteOwnerPages.PeriodicRenewal" %>

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
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css">
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

            alert('Data added to cart Successfully');
            window.location.href = "/SiteOwnerPages/InspectionRenewalCart.aspx";

        }
    </script>



    <style>
        .headercolor1 {
            text-align: initial !important;
        }

        td {
            padding: 10px !important;
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
            font-size: 13px;
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

        .headercolor {
            background-color: #9292cc;
        }

        th {
            background: #9292cc;
        }

        .card .card-title {
            font-size: 20px !important;
            color: #010101;
            text-transform: capitalize;
            font-weight: 700;
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



        svg#search1:hover {
            height: 22px;
            width: 22px;
            fill: #4b49ac;
            transition: ease-out;
            margin-left: -2px;
            cursor: pointer;
        }

        th.textalignleft {
            text-align: justify !important;
            padding: 9px !important;
        }

        th.headercolor {
            width: 28% !important;
        }

        th {
            width: 1%;
        }

        .input-box {
            display: flex;
            align-items: center;
            max-width: 300px;
            background: #fff;
            border: 1px solid #a0a0a0;
            border-radius: 4px;
            padding-left: 0.5rem;
            overflow: hidden;
            font-family: sans-serif;
        }

            .input-box .prefix {
                font-weight: 300;
                font-size: 14px;
                color: black;
            }

            .input-box input {
                flex-grow: 1;
                font-size: 14px;
                background: #fff;
                border: none;
                outline: none;
                padding: 0.5rem;
            }

            .input-box:focus-within {
                border-color: #777;
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
                        <h7 class="card-title fw-semibold mb-4" id="maincard1" style="text-transform: uppercase;">Periodic Renewal</h7>
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
                <%--  <asp:UpdatePanel ID="UpdatePanel1" runat="server">--%>
                <contenttemplate>
                    <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                        <div class="row" style="margin-bottom: 20px;">
                            <div class="col-md-4">
                                <label>
                                    Address Wise
        <samp style="color: red">* </samp>
                                </label>
                                <asp:DropDownList class="form-control  select-form select2" AutoPostBack="true" Style="width: 100% !important;" ID="ddlAdress" TabIndex="2" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator" Text="Please Select Applicant Type" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlAdress" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                            </div>
                            <%-- <div class="col-md-3">
                                <label>
                                    Intimation Wise
                                </label>
                                <asp:DropDownList class="form-control  select-form select2" AutoPostBack="true" Style="width: 100% !important;" ID="ddlIntimation" TabIndex="2" runat="server">
                                    
                                </asp:DropDownList>
                            </div>--%>
                            <div class="col-md-4">
                                <label>
                                    Installation Wise
                                </label>
                                <asp:DropDownList class="form-control  select-form select2" AutoPostBack="true" Style="width: 100% !important;" ID="ddlInstallationType" TabIndex="2" runat="server">
                                </asp:DropDownList>
                            </div>
                            <div class="col-1" style="margin-top: auto; padding-left: 0px;">

                                <asp:Button type="submit" ID="btnSearch" TabIndex="23" Text="Search" runat="server" class="btn btn-primary mr-2" OnClick="btnSearch_Click" Style="padding-left: 18px; padding-right: 18px; height: 34px; padding-top: 2px;" />
                            </div>
                        </div>
                        <div>
                            <div class="card" style="padding: 15px; box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px; padding-bottom: 30px;">
                                <asp:GridView class="table-responsive table table-striped table-hover" ID="GridView1" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" runat="server" DataKeyNames="Id" Width="100%" AllowPaging="true" PageSize="20" OnPageIndexChanging="GridView1_PageIndexChanging"
                                    AutoGenerateColumns="false" BorderWidth="1px" BorderColor="#dbddff">
                                    <PagerStyle CssClass="pagination-ys" />
                                    <Columns>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="left" ItemStyle-VerticalAlign="Middle">
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="chkSelectAll" runat="server" Style="text-align: left !important;" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="CheckBox1" runat="server" HorizontalAlign="center" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="SNo">
                                            <HeaderStyle Width="5%" CssClass="headercolor" />
                                            <ItemStyle Width="5%" />
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:BoundField DataField="IntimationId" HeaderText="Intimation Id">
                                            <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Id" HeaderText="Inspection Id">
                                            <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                        </asp:BoundField>


                                        <asp:BoundField DataField="TypeOf" HeaderText="Installation Type">
                                            <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                        </asp:BoundField>
                                        <%-- <asp:BoundField DataField="number" HeaderText="Number of Line">
                                <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor leftalign" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="leftalign" />
                            </asp:BoundField>--%>
                                        <asp:TemplateField HeaderText="TestReportId">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkTestReportId" runat="server" Text='<%# Eval("TestRportId") %>' CommandName="ViewTestReport" CommandArgument='<%# Eval("TestRportId") %>'></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="TestRportId" HeaderText="TestReportId" Visible="false">
                                            <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="InspectionDate" HeaderText="Inspection Date">
                                            <HeaderStyle HorizontalAlign="center" Width="12%" CssClass="headercolor" />
                                            <ItemStyle HorizontalAlign="center" Width="12%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="InspectionDueDate" HeaderText="Due Date">
                                            <HeaderStyle HorizontalAlign="center" Width="12%" CssClass="headercolor" />
                                            <ItemStyle HorizontalAlign="center" Width="12%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Numberofdays" HeaderText="Remaining days">
                                            <HeaderStyle HorizontalAlign="center" Width="12%" CssClass="headercolor" />
                                            <ItemStyle HorizontalAlign="center" Width="12%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Voltage" HeaderText="Voltage">
                                            <HeaderStyle HorizontalAlign="center" Width="12%" CssClass="headercolor" />
                                            <ItemStyle HorizontalAlign="center" Width="12%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Capacity" HeaderText="Capacity">
                                            <HeaderStyle HorizontalAlign="center" Width="12%" CssClass="headercolor" />
                                            <ItemStyle HorizontalAlign="center" Width="12%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="InstallationType" HeaderText="Installation Type" Visible="false">
                                            <HeaderStyle HorizontalAlign="center" Width="12%" CssClass="headercolor" />
                                            <ItemStyle HorizontalAlign="center" Width="12%" />
                                        </asp:BoundField>

                                        <asp:TemplateField HeaderText="Id" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="LblInstallationType" runat="server" Text='<%#Eval("InstallationType") %>'></asp:Label>
                                                <asp:Label ID="LblTestReportId" runat="server" Text='<%#Eval("TestRportId") %>'></asp:Label>
                                                <asp:Label ID="LblInspectionDate" runat="server" Text='<%#Eval("InspectionDate") %>'></asp:Label>
                                                <asp:Label ID="LblInspectionDueDate" runat="server" Text='<%#Eval("InspectionDueDate") %>'></asp:Label>
                                                <asp:Label ID="LblNumberofdays" runat="server" Text='<%#Eval("Numberofdays") %>'></asp:Label>
                                                <asp:Label ID="LblVoltage" runat="server" Text='<%#Eval("Voltage") %>'></asp:Label>
                                                <asp:Label ID="LblCapacity" runat="server" Text='<%#Eval("Capacity") %>'></asp:Label>                                                
                                                <asp:Label ID="LblAddress" runat="server" Text='<%#Eval("Address") %>'></asp:Label>

                                                <%--<asp:Label ID="lblID" runat="server" Text='<%#Eval("Id") %>'></asp:Label>--%>
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
                            <div class="row" style="margin-top: 25px; margin-bottom: -15px;">
                                <div class="col-4" style="margin-top: auto;">
                                    <%--<asp:Button type="submit" ID="btnSubmit" ValidationGroup="Submit" Text="Submit" OnClientClick="return validateCheckBoxes();" runat="server" class="btn btn-primary mr-2" OnClick="Submit_Click" />--%>
                                    <%--<asp:Button type="submit" ID="BtnProcess" TabIndex="23" Text="Process" runat="server" OnClick="BtnProcess_Click"  class="btn btn-primary mr-2" Style="padding-left: 18px; padding-right: 18px;" />--%>
                                    <asp:Button type="submit" ID="BtnCart" TabIndex="23" Text="Add To Cart" runat="server" OnClick="BtnCart_Click" class="btn btn-primary mr-2" Style="padding-left: 18px; padding-right: 18px;" />
                                </div>
                            </div>
                        </div>
                    </div>


                    <asp:HiddenField ID="hdnId" runat="server" />
                    <asp:HiddenField ID="hdnId2" runat="server" />
                    <div>
                    </div>
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
        function FileName() {
            var fileInput = document.getElementById('customFile');
            var selectedFileName = document.getElementById('customFileLocation');

            if (fileInput.files.length > 0) {
                // Update the TextBox value with the selected file name
                selectedFileName.value = fileInput.files[0].name;
            }
        }
    </script>

    <script type="text/javascript">
        function alertWithRedirect() {
            if (confirm('User Created Successfully User Id And password will be sent Via Text Mesaage.')) {
                window.location.href = "/Contractor/Work_Intimation.aspx";
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

