<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin_Master.Master" AutoEventWireup="true" CodeBehind="Transfer_Sld_ToDifferentStaff_ByAdmin.aspx.cs" Inherits="CEIHaryana.Admin.Transfer_Sld_ToDifferentStaff_ByAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="shortcut icon" type="image/png" href="/css2/style.min.css" />
    <link rel="stylesheet" href="/css2/style.css" />
    <script src="https://code.jquery.com/jquery-3.7.0.js"></script>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/css/select2.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/js/select2.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.5.2/css/bootstrap.css" rel="stylesheet" />
    <link href="https://cdn.datatables.net/1.13.5/css/dataTables.bootstrap4.min.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.7.0.js"></script>
    <script src="https://cdn.datatables.net/1.13.5/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.13.5/js/dataTables.bootstrap4.min.js"></script>
    <script src="https://kit.fontawesome.com/57676f1d80.js" crossorigin="anonymous"></script>
    <style>
        th {
            background: #639fc2;
        }

            th.headercolor {
                background: #9292cc;
                color: white;
                width: 30%;
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

        .col-md-4 {
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

        th {
            background: #9292cc;
        }

            th.thwidth {
                width: 1%;
            }

            th.thwidth1 {
                width: 35%;
            }

            th.headercolor.thwidth {
                width: 70% !important;
            }

            th.headercolor.sld {
                width: 1% !important;
            }

        #ownerPopup {
            display: none;
            position: fixed;
            top: 30%;
            left: 60%;
            transform: translate(-50%, -30%);
            background-color: white;
            border: 1px solid #ccc;
            padding: 20px;
            z-index: 1001;
            box-shadow: 0 0 10px #999;
            width: 75%;
        }

        #popupOverlay {
            display: none;
            position: fixed;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            background-color: rgba(0,0,0,0.4);
            z-index: 1000;
        }

        .modal-content {
            width: 1000px !important;
            right: 110px !important;
        }

        span#ContentPlaceHolder1_lblOwnerName {
            font-size: 13px !important;
        }

        span#ContentPlaceHolder1_lblAgencyName {
            font-size: 13px !important;
        }

        .modal-backdrop {
            position: fixed !important;
            top: 0;
            left: 0;
            width: 100vw;
            height: 100vh;
            z-index: 1040;
        }
        .fade {
    width: 101% !important;
    height: 100% !important;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <div class="card-body" id="CardId" runat="server" style="background: white; box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
            <div class="card-title" style="margin-bottom: 20px; margin-top: 05px; font-size: 17px; font-weight: 600; margin-left: 5px; text-align: center; font-size: 20px !important;">
                Transfer Sld
            </div>
            <%--   <div class="row">
                <div class="col-md-12">
                    <asp:RadioButtonList ID="RadioButtonAction" AutoPostBack="true" runat="server" RepeatDirection="Horizontal" TabIndex="25">
                        <asp:ListItem Text="Transfer" Value="1" style="margin-top: auto; margin-bottom: auto; padding-left: 10px;"></asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>--%>
            <div class="card" style="background: white; box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                <div class="row" id="TransferButton" runat="server" visible="true" style="margin-top: -50px;">

                    <div class="col-md-3" id="DivToAssign" runat="server" visible="true">
                        <br />
                        <br />
                        <label>
                            Pending At Staff
                         <samp style="color: red">* </samp>
                        </label>
                        <asp:DropDownList class="form-control  select-form select2" runat="server" AutoPostBack="true" ID="ddlToAssign" selectionmode="Multiple" OnSelectedIndexChanged="ddlToAssign_SelectedIndexChanged" Style="width: 100% !important;">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="ddlToAssign" runat="server" InitialValue="0" ForeColor="Red" ValidationGroup="Search" ErrorMessage="Required"></asp:RequiredFieldValidator>




                    </div>

                    <div class="col-md-6" runat="server" style="margin-top: 45px !important;">
                        <label>
                            &nbsp;
                        </label>
                        <!-- Search Box -->
                        <asp:TextBox ID="txtSearch" runat="server"
                            PlaceHolder="Other Search Parameters Like OwnerName,SldId etc.."
                            class="form-control" Style="height: 35px !important;" />

                    </div>

                    <div class="col-md-3" id="Div2" runat="server" visible="true" style="margin-top: 79px;">
                        <asp:Button ID="Button1" Class="btn btn-primary" runat="server" ValidationGroup="Search" Text="Search" Style="height: 30px; padding: 0px 10px 0px 10px;"
                            OnClick="Button1_Click" />
                    </div>
                </div>


                <div class="row">
                    <div class="col-md-12">

                        <%-- Add GridView Here --%>

                        <asp:GridView class="table-responsive table table-hover table-striped" ID="GridView1" runat="server" Width="100%"
                            AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" AllowPaging="true" PageSize="100" OnPageIndexChanging="GridView1_PageIndexChanging" BorderWidth="1px" BorderColor="#dbddff">
                            <PagerStyle CssClass="pagination-ys" />
                            <Columns>
                                <asp:TemplateField ItemStyle-HorizontalAlign="left" ItemStyle-VerticalAlign="Middle">
                                    <HeaderStyle CssClass="thwidth" />
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chkSelectAll" runat="server" OnCheckedChanged="chkSelectAll_CheckedChanged" AutoPostBack="True" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBox1" runat="server" HorizontalAlign="center" AutoPostBack="true" OnCheckedChanged="CheckBox1_CheckedChanged" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <HeaderStyle CssClass="headercolor sld" />
                                    <ItemStyle />
                                    <HeaderTemplate>
                                        SLD ID                                    
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblSLD_ID" runat="server" Text='<%#Eval("SLD_ID") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="Request Letter OwnerName" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="4%">
                                    <HeaderStyle Width="5%" CssClass="headercolor" />
                                    <ItemTemplate>
                                        <asp:LinkButton
                                            ID="lnkOwnerName"
                                            runat="server"
                                            Text='<%# Eval("OwnerName") %>'
                                            CommandName="ShowPopup"
                                            CommandArgument='<%# Eval("SLD_ID") %>'
                                            OnCommand="lnkOwnerName_Command"
                                            CssClass="owner-link" />

                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="2%"></ItemStyle>
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:TemplateField>


                                <asp:BoundField DataField="Status_type" HeaderText="Status">
                                    <HeaderStyle HorizontalAlign="center" CssClass="headercolor" />
                                    <ItemStyle HorizontalAlign="center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText=" Attached Document" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="4%">
                                    <HeaderStyle CssClass="headercolor" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Bind("Path") %>' CommandName="Select1">View document </asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Request Letter" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="4%">
                                    <HeaderStyle CssClass="headercolor" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="Lnkbtn" runat="server" CommandArgument='<%# Bind("RequestLetter") %>' CommandName="Print">View document </asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="SubmittedDate" HeaderText="Submit Date">
                                    <HeaderStyle HorizontalAlign="center" CssClass="headercolor" />
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
                        <div class="modal fade" id="ownerModal" tabindex="-1" role="dialog" aria-labelledby="ownerModalLabel" aria-hidden="true">
                            <div class="modal-dialog" role="document">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h5 class="modal-title" id="ownerModalLabel">Owner Details</h5>
                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                            <span aria-hidden="true">&times;</span>
                                        </button>
                                    </div>
                                    <div class="modal-body" id="modalContent">
                                        <!-- Dynamic content will go here -->
                                        <div class="row">

                                            <div class="col-md-6">
                                                <div id="OwnerNameDiv" runat="server">
                                                    <asp:Label ID="lblOwnerName" runat="server" Text="Name of Owner"></asp:Label>

                                                    <asp:TextBox CssClass="form-control" ID="txtNameOfOwner" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px" />
                                                </div>
                                                <div id="AgencyNameDiv" runat="server">
                                                    <asp:Label ID="lblAgencyName" runat="server" Text="Name of Agency"></asp:Label>
                                                    <asp:TextBox CssClass="form-control" ID="txtNameOfAgency" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px" />
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <label>
                                                    PanNo
                                                </label>
                                                <asp:TextBox class="form-control" ID="txtPanNoOrTanNo" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>

                                            <div class="col-md-12">
                                                <label>
                                                    Address
         
                                                </label>
                                                <asp:TextBox class="form-control" ID="txtAddress" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>

                                            </div>


                                            <div class="col-md-6">
                                                <label>
                                                    ContactNo
                                                </label>
                                                <asp:TextBox class="form-control" ID="txtContactNo" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>

                                            <div class="col-md-6">
                                                <label>
                                                    Email
                                                </label>
                                                <asp:TextBox class="form-control" ID="txtEmail" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>

                                            <div class="col-md-6">
                                                <label>
                                                    Applicant Type
         
                                                </label>
                                                <asp:TextBox class="form-control" ID="txtApplicant" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>


                                            </div>
                                            <div class="col-md-6">
                                                <label>
                                                    ContractorType
                                                </label>
                                                <asp:TextBox class="form-control" ID="txtContractorType" ReadOnly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                            </div>


                                        </div>
                                        <div class="row">
                                            <div class="col-md-12">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row" style="margin-left: 0px;">

                            <div class="col-md-4" id="ddlNewAssigneediv" runat="server" visible="true" style="margin-top: -33px; padding-left: 0px;">
                                <br />
                                <br />
                                <label>
                                    TransferTo
                            <samp style="color: red">* </samp>
                                </label>
                                <asp:DropDownList class="form-control  select-form select2" runat="server" AutoPostBack="true" ID="ddlNewAssignee" selectionmode="Multiple" Style="width: 100% !important;">
                                    <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="ddlNewAssignee" runat="server" InitialValue="0" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Required"></asp:RequiredFieldValidator>
                            </div>


                        </div>
                        <div class="row">
                            <div class="col-md-12" style="text-align: center;">
                                <asp:Button type="submit" Visible="false" ID="btnSubmit" TabIndex="22" OnClientClick="return validateFileUpload();" ValidationGroup="Submit" Text="Submit" runat="server" class="btn btn-primary mr-2" OnClick="btnSubmit_Click" />

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- Bootstrap Modal -->
    <!-- Bootstrap Modal -->

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
        window.onload = function () {

        };

        function SelectAllCheckboxes(headerCheckbox) {
            var checkboxes = document.querySelectorAll('[id*=CheckBox1]');
            for (var i = 0; i < checkboxes.length; i++) {
                checkboxes[i].checked = headerCheckbox.checked;
            }
        }

        function alertWithRedirectUpdation() {
            alert('Sld Transfered Successfully');
            window.location.href = "/Admin/Transfer_Sld_ToDifferentStaff_ByAdmin.aspx";

        }


        let isSubmitting = false;

        function validateFileUpload() {
            if (isSubmitting) {
                return false;
            }

            var newAssignee = document.getElementById('<%= ddlNewAssignee.ClientID %>');
            if (newAssignee.value == "0") {
                alert("Please select a staff member to transfer the SLD.");
                return false;
            }


            var ddlToAssign = document.getElementById('<%= ddlToAssign.ClientID %>');
            if (ddlToAssign.value == "0") {
                alert("Please select Current staff member .");
                return false;
            }

            if (Page_ClientValidate()) {
                isSubmitting = true;
                return true;
            } else {
                return false;
            }
            function showPopup(content) {
                var popup = document.getElementById("ownerPopup");
                var popupContent = document.getElementById("popupContent");
                popupContent.innerHTML = content;
                popup.style.display = "block";
            }

            function closePopup() {
                document.getElementById("ownerPopup").style.display = "none";
            }

        }


    </script>


</asp:Content>
