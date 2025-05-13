<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin_Master.Master" AutoEventWireup="true" CodeBehind="Transfer_Inspections_ToDifferentStaff_ByAdmin.aspx.cs" Inherits="CEIHaryana.Admin.Transfer_Inspections_ToDifferentStaff_ByAdmin" EnableViewState="true" %>

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
    <style>
        th {
            width: 1%;
            background: #639fc2;
        }

            th.headercolor {
                background: #9292cc;
                color: white;
                width: 1%;
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <div class="card-body" id="CardId" runat="server" style="background:white;box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
            <div class="card-title" style="margin-bottom: 20px; margin-top: 05px; font-size: 17px; font-weight: 600; margin-left: 5px; text-align: center; font-size: 20px !important;">
                Transfer Inspections
            </div>
            <%--   <div class="row">
                <div class="col-md-12">
                    <asp:RadioButtonList ID="RadioButtonAction" AutoPostBack="true" runat="server" RepeatDirection="Horizontal" TabIndex="25">
                        <asp:ListItem Text="Transfer" Value="1" style="margin-top: auto; margin-bottom: auto; padding-left: 10px;"></asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>--%>
            <div class="card" style="background:white;box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
            <div class="row" id="TransferButton" runat="server" visible="true" style="margin-top: -50px;">
                <div class="col-md-3" id="ApprovalRequired" runat="server">
                    <br />
                    <br />
                    <label>
                        Division
                <samp style="color: red">* </samp>
                    </label>
                    <asp:DropDownList OnSelectedIndexChanged="ddlDivisions_SelectedIndexChanged" class="form-control  select-form select2" runat="server" AutoPostBack="true" ID="ddlDivisions" Style="width: 100% !important;">
                        <%--OnSelectedIndexChanged="ddlDivisions_SelectedIndexChanged"--%>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="ddlDivisions" runat="server" InitialValue="0" ForeColor="Red" ValidationGroup="Search" ErrorMessage="Required"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-3" id="DivToAssign" runat="server" visible="true">
                    <br />
                    <br />
                    <label>
                        Select Staff
                <samp style="color: red">* </samp>
                    </label>
                    <asp:DropDownList class="form-control  select-form select2" runat="server" AutoPostBack="true" ID="ddlToAssign" selectionmode="Multiple" Style="width: 100% !important;" OnSelectedIndexChanged="ddlToAssign_SelectedIndexChanged">
                        <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="ddlToAssign" runat="server" InitialValue="0" ForeColor="Red" ValidationGroup="Search" ErrorMessage="Required"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-3" id="Div1" runat="server" visible="false">
                    <br />
                    <br />
                    <label>
                        District
                        <samp style="color: red">* </samp>
                    </label>
                    <asp:DropDownList class="form-control  select-form select2" runat="server" AutoPostBack="True" ID="DropDownList1" selectionmode="Multiple" Style="width: 100% !important;" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                        <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="DropDownList1" runat="server" InitialValue="0" ForeColor="Red" ValidationGroup="Search" ErrorMessage="Required"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-3" id="Div2" runat="server" visible="true" style="margin-top: 79px;">
                    <asp:Button ID="Button1" Class="btn btn-primary" runat="server" ValidationGroup="Search" Text="Search" Style="height: 30px; padding: 0px 10px 0px 10px;"
                        OnClick="Button1_Click" />
                </div>
            </div>
            <%-- <div class="row" id="Action" runat="server" visible="false">
                <asp:RadioButtonList ID="RdbtnAccptReturn" AutoPostBack="true" runat="server" RepeatDirection="Horizontal" TabIndex="25">
                    <asp:ListItem Text="Yes(Accept)" Value="0" style="margin-top: auto; margin-bottom: auto; padding-left: 10px;"></asp:ListItem>
                    <asp:ListItem Text="No(Return)" Value="1" style="margin-top: auto; margin-bottom: auto; padding-left: 10px;"></asp:ListItem>
                    <asp:ListItem Text="Reject" Value="2" style="margin-top: auto; margin-bottom: auto; padding-left: 10px;"></asp:ListItem>
                </asp:RadioButtonList>
            </div>--%>

            <div class="row">
                <div class="col-md-12">

                    <%-- Add GridView Here --%>

                    <asp:GridView ID="GridView1" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand" class="table-responsive table table-hover table-striped" runat="server" Width="100%" AutoGenerateColumns="false" BorderWidth="1px" BorderColor="#dbddff">
                        <Columns>
                            <asp:TemplateField ItemStyle-HorizontalAlign="left" ItemStyle-VerticalAlign="Middle">
                                <HeaderTemplate>
                                    <%--<asp:CheckBox ID="chkSelectAll" runat="server" CssClass="header-checkbox" />--%>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" HorizontalAlign="center" AutoPostBack="true" OnCheckedChanged="CheckBox1_CheckedChanged" />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="InspectionId" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblInspectionId" runat="server" Text='<%#Eval("Id") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField>
                                <HeaderStyle Width="35%" CssClass="headercolor" />
                                <ItemStyle Width="35%" />
                                <HeaderTemplate>
                                    InspectionId                                    
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton4" runat="server" CommandArgument=' <%#Eval("Id") %> ' CommandName="Select"><%#Eval("Id") %></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="District">
                                <ItemTemplate>
                                    <asp:Label ID="lblDistrict" runat="server" Text='<%#Eval("District") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Currently Assigned To">
                                <ItemTemplate>
                                    <asp:Label ID="lblAssignTo" runat="server" Text='<%#Eval("AssignTo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField DataField="Id" HeaderText="Id" Visible="False">
                                <HeaderStyle HorizontalAlign="Left" CssClass="headercolor textalignleft colwidth" />
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
                    <div class="row" style="margin-left:0px;">
                        
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

                    <div class="col-md-4" id="hiddenfield1" runat="server" style="margin-top:18px;">
                        <label class="form-label" for="CustomFile" style="margin-bottom:5px !important">
                            Transfer Order Document (2MB PDF ONLY)<samp style="color: red"> * </samp>
                        </label>
                        <br />
                        <asp:FileUpload ID="CustomFile" TabIndex="19" runat="server" CssClass="form-control"
                            Style="margin-left: 18px; padding: 0px; font-size: 15px;" accept=".pdf" />

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                            ControlToValidate="CustomFile" ErrorMessage="Required" ValidationGroup="Submit" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>

                        </div>
                    <div class="row">
                        <div class="col-md-12" style="text-align:center;">
                                                <asp:Button type="submit" Visible="false" ID="btnSubmit" TabIndex="22" OnClientClick="return validateFileUpload();" ValidationGroup="Submit" Text="Submit" runat="server" class="btn btn-primary mr-2" OnClick="btnSubmit_Click" />

                        </div>
                    </div>
                </div>
            </div>
                </div>
        </div>
    </div>

    <script type="text/javascript">
        window.onload = function () {
            ddldistrictcontrol = document.getElementById('<%= DropDownList1.ClientID %>');
        };

        function SelectAllCheckboxes(headerCheckbox) {
            var checkboxes = document.querySelectorAll('[id*=CheckBox1]');
            for (var i = 0; i < checkboxes.length; i++) {
                checkboxes[i].checked = headerCheckbox.checked;
            }
        }

        function alertWithRedirectUpdation() {
            alert('Inspection Transfered Successfully');
            window.location.href = "/Admin/Transfer_Inspections_ToDifferentStaff_ByAdmin.aspx";

        }


        let isSubmitting = false;

        function validateFileUpload() {
            if (isSubmitting) {
                return false;
            }

            var newAssignee = document.getElementById('<%= ddlNewAssignee.ClientID %>');
            if (newAssignee.value == "0") {
                alert("Please select a staff member to transfer the inspection.");
                return false;
            }

            var ddlDivisions = document.getElementById('<%= ddlDivisions.ClientID %>');
            if (ddlDivisions.value == "0") {
                alert("Please select a division.");
                return false;
            }

            var ddlToAssign = document.getElementById('<%= ddlToAssign.ClientID %>');
            if (ddlToAssign.value == "0") {
                alert("Please select Current staff member .");
                return false;
            }


            if (ddldistrictcontrol) {
                var ddlDistrict = document.getElementById('<%= DropDownList1.ClientID %>');
                if (ddlDistrict.value == "0") {
                    alert("Please select a district.");
                    return false;
                }
            }
             
            var customFile = document.getElementById('<%= CustomFile.ClientID %>');
            if (!customFile.value) {
                alert("Please upload a Transfer Order document (PDF only).");
                return false;
            }

            var fileExtension = customFile.value.split('.').pop().toLowerCase();
            if (fileExtension !== "pdf") {
                alert("Please upload a PDF file only.");
                return false;
            }

            var fileSize = customFile.files[0].size; 
            if (fileSize > 2 * 1024 * 1024) { 
                alert("File size should not exceed 2MB.");
                return false;
            }

            if (Page_ClientValidate()) {
                isSubmitting = true;
                return true;
            } else {
                return false;
            }
        }


    </script>
</asp:Content>
