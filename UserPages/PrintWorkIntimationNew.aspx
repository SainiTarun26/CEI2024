<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintWorkIntimationNew.aspx.cs" Inherits="CEIHaryana.UserPages.PrintWorkIntimationNew" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="shortcut icon" type="image/png" href="/css2/style.min.css" />
    <link rel="stylesheet" href="/css2/style.css" />
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" />
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <!------ Include the above in your HEAD tag ---------->
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/css/select2.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/js/select2.min.js"></script>

    <link href="ScriptCalendar/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="ScriptCalender/jquery-1.11.0.min.js"></script>
    <script type="text/javascript" src="ScriptCalender/jquery-ui.min.js"></script>

    <style>
        body {
            box-sizing: border-box;
            min-height: 100vh;
            margin: 0px;
            border: solid 1px black;
            PADDING: 10PX;
        }

        input#txtInstallationType {
            font-size: 25px !important;
            font-weight: 700;
            text-align: end;
        }

        input#txtTestReportId {
            font-size: 25px !important;
            font-weight: 700;
            text-align: initial;
            border-bottom: 0px solid !important;
        }

        .col-4 {
            top: 0px;
            left: 0px;
        }

        .form-control {
            margin-left: 0px !important;
            font-size: 16px !important;
            height: 37px;
            border-bottom: 1px solid !important;
            border: 0px solid black;
            border-radius: 0px;
            margin-top: 5px;
        }

        label {
            font-size: 18px;
            margin-top: 5px;
            font-weight: 600;
        }

        .card .card-title {
            color: #010101;
            margin-bottom: 1.2rem;
            text-transform: capitalize;
            font-size: 20px;
            font-weight: 600;
        }

        u {
            font-size: 22px;
        }

        input#txtInstallationType {
            border-bottom: 0px solid !important;
        }
        th {
    width: 1%;
}
    </style>
    <script>

        function
            printDiv(printableDiv) {
            var printContents = document.getElementById(printableDiv).innerHTML;
            var originalContents = document.body.innerHTML;

            document.body.innerHTML = printContents;

            window.print();

            document.body.innerHTML = originalContents;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="content-wrapper">
                <div class="card" style="box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px; border-radius: 5px !important">
                    <div class="col-12" style="text-align: end; margin-top: auto; margin-bottom: auto;">
                        <asp:Button ID="btnPrint" Text="Print" runat="server" class="btn btn-primary mr-2"
                            Style="margin-top: 5px; margin-bottom: -40px; font-size: 20px; padding-left: 25px; padding-right: 25px; position: fixed; margin-left: -100px; z-index: 50;" OnClientClick="printDiv('printableDiv');" />
                    </div>
                    <div class="card-body">
                        <div id="printableDiv">
                            <div class="row" style="margin-bottom: 15PX;">
                                <div class="col-sm-12" style="text-align: center; padding-top: 8px; padding-bottom: 8px; border-radius: 10px;">
                                    <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important; font-size: 32PX;">Work Intimation</h6>

                                    <div class="row">
                                        <div class="col-3" style="margin-top: 0px;"></div>
                                        <div class="col-6" style="margin-top: 0px; padding-left: 0px; text-align: center;">
                                            <asp:TextBox class="form-control" ID="txtwIpID" runat="server" autocomplete="off" ReadOnly="true" onKeyPress="return alphabetKey(event);" TabIndex="1"
                                                MaxLength="30" Style="margin-left: 18px;text-align:center;border-bottom: 0px solid !important;" Text="12341/tarun-2024">
                                            </asp:TextBox>
                                        </div>
                                        <div class="col-3" style="margin-top: 0px;"></div>
                                    </div>
                                </div>
                            </div>

                            <br />
                            <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important;"><u>Site Owner Information</u></h6>
                            <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                                <div class="row">
                                    <div class="col-4">
                                        <label for="Name">
                                            Applicant Type:
                                        </label>
                                        <asp:DropDownList class="form-control select-form select2" disabled AutoPostBack="true" Style="width: 100% !important;" ID="ddlApplicantType" TabIndex="2" runat="server" OnSelectedIndexChanged="ddlWorkDetail_SelectedIndexChanged">
                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                           <asp:ListItem Text="Private/Personal Installation" Value="AT001"></asp:ListItem>
                                           <asp:ListItem Text="Other Department/Organization" Value="AT003"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-4" runat="server" id="DivPancard_PanNo" visible="false">
                                        <label for="FatherName">Pan Card:</label>
                                        <asp:TextBox class="form-control" ID="txtPAN" autocomplete="off" readonly="true" runat="server" Style="margin-left: 18px">
                                        </asp:TextBox>
                                    </div>

                                    <div class="col-4" runat="server" id="TanNumber" visible="false">
                                        <label>Tan Number:</label>
                                        <asp:TextBox class="form-control" ID="txtTanNumber" autocomplete="off" readonly="true" runat="server" onKeyPress="return alphabetKey(event);" TabIndex="2"
                                            MaxLength="30" Style="margin-left: 18px">
                                        </asp:TextBox>
                                    </div>


                                    <div class="col-4" runat="server" id="DivPoweUtility" visible="false">
                                        <label>Name Of Power Utility</label>
                                        <asp:DropDownList class="form-control  select-form select2" readonly="true" AutoPostBack="true" Style="width: 100% !important;" ID="ddlPoweUtility" TabIndex="2" runat="server">
                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                            <%--<asp:ListItem Text="Supplier Installation" Value="1"></asp:ListItem>--%>
                                            <asp:ListItem Text="UHBVN" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="DHBVN" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="HVPNL" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="HPGST" Value="4"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>

                                    <div class="col-4" runat="server" id="DivPoweUtilityWing" visible="false">
                                        <label>Type of Wing</label>
                                        <asp:DropDownList ID="ddlPowerUtilityWing" readonly="true" runat="server" AutoPostBack="true" class="form-control  select-form select2" Style="width: 100% !important;">
                                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="Construction Wing"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Operation Wing"></asp:ListItem>

                                        </asp:DropDownList>
                                    </div>

                                    <div class="col-4">
                                        <label>Electrical Installation For</label>
                                        <asp:DropDownList ID="ddlworktype" TabIndex="3" runat="server" disabled  AutoPostBack="true" class="form-control  select-form select2" OnSelectedIndexChanged="ddlworktype_SelectedIndexChanged" Style="width: 100% !important;">
                                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="Individual Person"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Firm/Organization/Company/Department"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>

                                </div>
                                <div class="row" style="margin-top: 35px;" id="row2">
                                    <div class="col-4" id="individual" runat="server">
                                        <label>
                                            Name of Owner/ Consumer:
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtName" runat="server" readonly="true" autocomplete="off" onKeyPress="return alphabetKey(event);" TabIndex="1"
                                            MaxLength="30" Style="margin-left: 18px;">
                                        </asp:TextBox>
                                    </div>
                                    <div class="col-4" id="agency" runat="server">
                                        <label>Name of Firm/ Org./ Company/ Department</label>

                                        <asp:TextBox class="form-control" ID="txtagency" autocomplete="off" readonly="true" runat="server" onKeyPress="return alphabetKey(event);" TabIndex="2"
                                            MaxLength="30" Style="margin-left: 18px">
                                        </asp:TextBox>
                                    </div>

                                    <div class="col-4">
                                        <label>Address of Site:</label>
                                        <asp:TextBox class="form-control" ID="txtAddress" autocomplete="off" readonly="true" runat="server" onKeyPress="return alphabetKey(event);" TabIndex="2"
                                            MaxLength="30" Style="margin-left: 18px">
                                        </asp:TextBox>
                                    </div>

                                </div>
                                <div class="row" style="margin-top: 35px;" id="row3">
                                    <div class="col-4" runat="server">
                                        <label>State:</label>
                                        <asp:TextBox class="form-control" ID="txtState" Text="Haryana" readonly="true" autocomplete="off" runat="server" onKeyPress="return alphabetKey(event);" TabIndex="2"
                                            MaxLength="30" Style="margin-left: 18px">
                                        </asp:TextBox>
                                    </div>

                                    <div class="col-4" runat="server">
                                        <label>District:</label>
                                        <asp:DropDownList class="form-control  select-form select2" disabled runat="server" AutoPostBack="true" ID="ddlDistrict" selectionmode="Multiple" Style="width: 100% !important">
                                        </asp:DropDownList>
                                    </div>

                                    <div class="col-4" id="pin" visible="false" runat="server">
                                        <label>PinCode</label>
                                        <asp:TextBox class="form-control" ID="txtPin" readonly="true" MaxLength="6" onkeydown="return preventEnterSubmit(event)" onkeyup="ValidatePincode();" onKeyPress="return isNumberKey(event);" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="row" style="margin-top: 35px;">
                                    <div class="col-4">
                                        <label>Contact No.:</label>
                                        <asp:TextBox class="form-control" ID="txtPhone" readonly="true" autocomplete="off" runat="server" onKeyPress="return alphabetKey(event);" TabIndex="2"
                                            MaxLength="30" Style="margin-left: 18px">
                                        </asp:TextBox>
                                    </div>
                                    <div class="col-4">
                                        <label>Email:</label>
                                        <asp:TextBox class="form-control" ID="txtEmail" readonly="true" autocomplete="off" runat="server" onKeyPress="return alphabetKey(event);" TabIndex="2"
                                            MaxLength="30" Style="margin-left: 18px">
                                        </asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important;"><u>Applicant Details</u></h6>
                            <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                                <div class="row" style="margin-top: 35px;">
                                    <div class="col-4">
                                        <label>Type of Premises</label>

                                        <asp:DropDownList class="form-control  select-form select2" disabled runat="server" AutoPostBack="true" ID="ddlPremises" TabIndex="10" selectionmode="Multiple" Style="width: 100% !important">
                                        </asp:DropDownList>
                                    </div>

                                    <div class="col-4" id="OtherPremises" runat="server">
                                        <label>Other Premises</label>
                                        <asp:TextBox class="form-control" ID="txtOtherPremises" readonly="true"  onkeydown="return preventEnterSubmit(event)" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                    </div>

                                    <div class="col-4">
                                        <label>Highest Voltage Level of Installation</label>
                                        <asp:DropDownList class="form-control  select-form select2" disabled Style="width: 100% !important;" AutoPostBack="true" ID="ddlVoltageLevel" TabIndex="12" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-12">
                                        <div class="table-responsive pt-3" id="Installation" runat="server">
                                            <table class="table table-bordered table-striped">
                                                <thead class="table-dark">
                                                    <tr>
                                                        <th style="width: 70%;">Installation Type
                                                        </th>
                                                        <th style="width: 20%;">No of Installations
                                                        </th>
                                                       
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <div id="installationType1" runat="server">
                                                        <tr>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ID="txtinstallationType1" ReadOnly="true" Text="Line" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ID="txtinstallationNo1" ReadOnly="true"   autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>                                                           
                                                        </tr>
                                                    </div>
                                                    <div id="installationType2" runat="server">
                                                        <tr>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ID="txtinstallationType2" Text="Substation Transformer" ReadOnly="true"  autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ID="txtinstallationNo2"  readonly="true" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>                                                        
                                                        </tr>
                                                    </div>
                                                    <div id="installationType3" runat="server">
                                                        <tr>
                                                            <td>
                                                                <div class="col-12">
                                                                    <asp:TextBox class="form-control" ID="txtinstallationType3" Text="Generating Set" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" placeholder="" autocomplete="off" runat="server" Style="margin-left: 18px;"></asp:TextBox>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <div style="margin-left: 15px !important; margin-right: 15px !important;">
                                                                    <asp:TextBox class="form-control" ID="txtinstallationNo3" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" onKeyPress="return restrictInput(event)" placeholder="" MaxLength="1" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                                                </div>
                                                            </td>                                                        
                                                        </tr>
                                                    </div>

                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </div>

                                <div class="row" style="margin-top: -10px;">
                                    <div class="col-4" id="InstallationType" runat="server" visible="false">
                                        <label>
                                            Select Installation Type
              
                                        </label>
                                        <asp:DropDownList class="form-control  select-form select2" AutoPostBack="true" Style="width: 100% !important;" ID="ddlWorkDetail" runat="server" OnSelectedIndexChanged="ddlWorkDetail_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:TextBox class="form-control" ID="WorkDetail" autocomplete="off" onkeydown="return preventEnterSubmit(event)" Visible="false" runat="server" Style="margin-left: 18px"></asp:TextBox>

                                    </div>
                                </div>
                            </div>
                            <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important;"><u>Work/Testing Schedule</u></h6>
                            <div runat="server" class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                                <div class="row">
                                    <div class="col-4">
                                        <label>
                                            Tentative Work Start Date:
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtStartDate" runat="server" autocomplete="off" readonly="true" onKeyPress="return alphabetKey(event);" TabIndex="1"
                                            MaxLength="30" Style="margin-left: 18px;">
                                        </asp:TextBox>
                                    </div>
                                    <div class="col-4">
                                        <label>Tentative Work Completition Date:</label>

                                        <asp:TextBox class="form-control" ID="txtCompletitionDate" autocomplete="off" readonly="true" runat="server" onKeyPress="return alphabetKey(event);" TabIndex="2"
                                            MaxLength="30" Style="margin-left: 18px">
                                        </asp:TextBox>
                                    </div>
                                    <div class="col-4">
                                        <label>Work Order Issued by Dept./Owner:</label>

                                        <asp:DropDownList class="form-control  select-form select2" disabled ID="ddlAnyWork" TabIndex="18" Style="width: 100% !important;" runat="server" AutoPostBack="true">
                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                            <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row" style="margin-top: 35px;">
                                  <%--  <div class="col-4" id="hiddenfield" runat="server">
                                        <label>
                                            Attached Copy of Work Order:
                                        </label>
                                        <asp:FileUpload ID="customFile" TabIndex="19" runat="server" CssClass="form-control" Visible="false" Style="margin-left: 18px; padding: 0px; font-size: 15px;" />
                                        <asp:LinkButton ID="lnkFile" runat="server" AutoPostBack="true" Visible="false" OnClick="lnkFile_Click" Text="Open Document" />
                                        <asp:TextBox class="form-control" ID="customFileLocation" autocomplete="off" runat="server" Style="margin-left: 18px" Visible="false"></asp:TextBox>
                                    </div>--%>
                                    <div class="col-4" id="hiddenfield1" runat="server">
                                        <label for="Name">
                                            Completion Date as per Work Order:
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtCompletionDateAPWO" runat="server" readonly="true" autocomplete="off" onKeyPress="return alphabetKey(event);" TabIndex="1"
                                            MaxLength="30" Style="margin-left: 18px;">
                                        </asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important;"><u>Assign Supervisor Details For Above Work</u></h6>
                            <div id="Div1" runat="server" class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                               
                                    <asp:GridView ID="GridView1" class="table-responsive table table-hover table-striped" runat="server" Width="100%" AutoGenerateColumns="false" BorderWidth="1px" BorderColor="#dbddff">
                                        <Columns>
                                            <asp:TemplateField Visible="False" ItemStyle-HorizontalAlign="left" ItemStyle-VerticalAlign="Middle">
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="chkSelectAll" runat="server" Style="text-align: left !important;" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="CheckBox1" runat="server" HorizontalAlign="center" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Id" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCategory" runat="server" Text='<%#Eval("Category") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="REID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblREID" runat="server" Text='<%#Eval("REID") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="REID" HeaderText="ID" Visible="False">
                                                <HeaderStyle HorizontalAlign="Left" Width="30%" CssClass="headercolor textalignleft colwidth" />
                                                <ItemStyle HorizontalAlign="center" />
                                            </asp:BoundField>

                                            <asp:BoundField DataField="Name" HeaderText="Name">
                                                <HeaderStyle HorizontalAlign="Center" CssClass="headercolor textalignCenter" />
                                                <ItemStyle HorizontalAlign="Center" CssClass="textalignCenter" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="LicenseNo" HeaderText="Competency Certificate Number">
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
                                    <div class="row" id="Helpline" runat="server" visible="false">
                                        <h4>HELPLINE:</h4>
                                        <span style="margin-right: 12px;"></span>
                                        <asp:LinkButton ID="LinkButton1" runat="server" AutoPostBack="false">cei_goh@yahoo.com</asp:LinkButton>
                                        <span style="margin-right: 12px;"></span>
                                        <h5>0172-2704090</h5>
                                    </div>
                              
                            </div>



                               <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important;"><u>Work Schedule</u></h6>
   <div runat="server" class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
       <div class="row">
           <div class="col-4">
               <label>Created Date:</label>
               <asp:TextBox class="form-control" ID="txtCreatedDate" runat="server" autocomplete="off" readonly="true" Style="margin-left: 18px;">
               </asp:TextBox>
           </div>
           <div class="col-4">
               <label>Created By:</label>
               <asp:TextBox class="form-control" ID="txtCreatedBy" autocomplete="off" runat="server" readonly="true" Style="margin-left: 18px">
               </asp:TextBox>
           </div>
       </div>
   </div>



                        </div>
                        <div class="row">
                            <div class="col-4"></div>
                            <div class="col-4">
                                <asp:HiddenField ID="hdnId" runat="server" />
                                <asp:HiddenField ID="hdnId2" runat="server" />

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <footer class="footer">
        </footer>
    </form>
</body>
</html>
