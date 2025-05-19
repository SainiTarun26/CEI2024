<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InspectionRequestPrint_IndustryLift.aspx.cs" Inherits="CEIHaryana.Industry_Master.SiteOwnerPages.InspectionRequestPrint_IndustryLift" %>

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
            height: 30px;
            border-bottom: 1px solid !important;
            border: 0px solid black;
            border-radius: 0px;
            margin-top: 5px;
            border-style: dashed !important;
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
        input#txtInstallationType {
    font-size: 16px !important;            
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
                    <div class="col-12" style="text-align: initial; margin-top: auto; margin-bottom: auto;">
                        <asp:Button ID="Button1" Text="Back" runat="server" class="btn btn-primary mr-2" 
                            Style="margin-top: 5px; margin-bottom: -40px; font-size: 20px; padding-left: 25px; padding-right: 25px; position: fixed; z-index: 50;" OnClick="Button1_Click" />
                    </div>
                    <div class="card-body">
                        <div id="printableDiv">
                            <div class="row" style="margin-bottom: 15PX;">
                                <div class="col-sm-12" style="text-align: center; padding-top: 8px; padding-bottom: 8px; border-radius: 10px;">
                                    <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important; font-size: 32PX;">Application For Inspection Request</h6>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-6" style="text-align: end; padding-right: 0px;">
                                    <label for="Name">Installation Type : </label>
                                </div>
                                <div class="col-3" style="padding-left: 0px;">
                                    <asp:TextBox class="form-control" ID="txtInstallationType" runat="server" autocomplete="off" ReadOnly="true" Style="margin-left: 18px; border-bottom: 0px solid black !important;"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-6" style="text-align: end; padding-right: 0px;">
                                    <label for="Name">Installation Request No. : </label>
                                </div>
                                <div class="col-3" style="padding-left: 0px;">
                                    <asp:TextBox class="form-control" ID="txtReqNumber" runat="server" autocomplete="off" ReadOnly="true" Style="margin-left: 18px; border-bottom: 0px solid black !important;"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row" id="TRNumber" runat="server" visible="false">
    <div class="col-6" style="text-align: end; padding-right: 0px;">
        <label for="Name">Test Report No.    : </label>
    </div>
    <div class="col-3" style="padding-left: 0px;">
        <asp:TextBox class="form-control" ID="txtTestReportNo" runat="server" autocomplete="off" ReadOnly="true" Style="margin-left: 18px; border-bottom: 0px solid black !important;"></asp:TextBox>
    </div>
</div>
                            <br />
                            <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important;"><u>Site Owner Details</u></h6>
                            <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                                <div class="row">
                                    <div class="col-4">
                                        <label for="Name">
                                            Site Owner Name:
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtName" runat="server" autocomplete="off" onKeyPress="return alphabetKey(event);" ReadOnly="true" Style="margin-left: 18px;">
                                        </asp:TextBox>
                                    </div>
                                    <div class="col-4">
                                        <label>Intimation Id:</label>
                                        <asp:TextBox class="form-control" ID="txtIntimationId" autocomplete="off" runat="server" onKeyPress="return alphabetKey(event);" ReadOnly="true" Style="margin-left: 18px">
                                        </asp:TextBox>
                                    </div>
                                    <div class="col-4" id="Premises" runat="server" visible="true" >
                                        <label>Type 0f Permises</label>
                                        <asp:TextBox class="form-control" ID="txtPermisestype" autocomplete="off" runat="server" onKeyPress="return alphabetKey(event);" ReadOnly="true" Style="margin-left: 18px">
                                        </asp:TextBox>
                                    </div>
                                </div>
                                <div class="row" style="margin-top: 35px;">
                                    <div class="col-4">
                                        <label>
                                            District:
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtDistrict" runat="server" autocomplete="off" onKeyPress="return alphabetKey(event);" ReadOnly="true" Style="margin-left: 18px;">
                                        </asp:TextBox>
                                    </div>
                                    <div class="col-4">
                                        <label>Applicant Type:</label>
                                        <asp:TextBox class="form-control" ID="txtApplicant" autocomplete="off" runat="server" onKeyPress="return alphabetKey(event);" ReadOnly="true" Style="margin-left: 18px">
                                        </asp:TextBox>
                                    </div>
                                </div>
                                <div class="row" style="margin-top: 35px;">
                                    <div class="col-12">
                                        <label>Address</label>
                                        <asp:TextBox class="form-control" ID="txtAddress" autocomplete="off" runat="server" onKeyPress="return alphabetKey(event);" ReadOnly="true" Style="margin-left: 18px">
                                        </asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important;"><u>Attachments</u></h6>
                            <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                                <asp:GridView ID="GridView1" class="table-responsive table table-hover table-striped" runat="server" Width="100%"
                                    AutoGenerateColumns="false" BorderWidth="1px" BorderColor="#dbddff">
                                    <PagerStyle CssClass="pagination-ys" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="DocumentID" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDocumentID" runat="server" Text='<%#Eval("DocumentID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="SNo">
                                            <HeaderStyle Width="5%" CssClass="headercolor" />
                                            <ItemStyle HorizontalAlign="center" Width="5%" />
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="DocumentName" HeaderText="Document Attached">
                                            <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                            <ItemStyle HorizontalAlign="center" Width="15%" />
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
                                <div class="row" id="statement" runat="server" visible="false">
                                    <label for="CompletionDateasperWorkOrder" style="font-size: 16px; font-weight: bold;">
                                      No any Document Attached                                             
                                    </label>
                                </div>                                
                            </div>
                            <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important;"><u>Payment Details</u></h6>
                            <div id="Earthing" runat="server" class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                                <div class="row">
                                    <div class="col-4">
                                        <label for="Name">
                                            Transaction ID (GRN Number):
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtUTRN" runat="server" autocomplete="off" onKeyPress="return alphabetKey(event);" ReadOnly="true" Style="margin-left: 18px;">
                                        </asp:TextBox>
                                    </div>
                                    <div class="col-4">
                                        <label for="FatherName">Transaction Date:</label>
                                        <asp:TextBox class="form-control" ID="txtTransactionDate" autocomplete="off" runat="server" onKeyPress="return alphabetKey(event);" ReadOnly="true" Style="margin-left: 18px">
                                        </asp:TextBox>
                                    </div>
                                    <div class="col-4">
                                        <label>Payment Mode</label>
                                        <asp:TextBox class="form-control" ID="txtPaymentMode" autocomplete="off" runat="server" onKeyPress="return alphabetKey(event);" ReadOnly="true" Style="margin-left: 18px">
                                        </asp:TextBox>
                                    </div>
                                    <div class="col-4" style="margin-top:35px;">
                                        <label>Payment Amount</label>
                                        <asp:TextBox class="form-control" ID="txtPaymentAmount" autocomplete="off" runat="server" onKeyPress="return alphabetKey(event);" ReadOnly="true" Style="margin-left: 18px">
                                        </asp:TextBox>
                                    </div>
                                    <div class="col-4" style="margin-top:35px;">
                                        <label for="SubmissionDate">Submission Date:</label>

                                        <asp:TextBox class="form-control" ID="txtSubmissionDate" ReadOnly="true" autocomplete="off" runat="server"  TabIndex="2"
                                             Style="margin-left: 18px">
                                        </asp:TextBox>
                                    </div>
                                    <div class="col-4" style="margin-top:35px;">
                                        <label for="SubmissionDate">RTS Due Date:</label>

                                        <asp:TextBox class="form-control" ID="txtRTSDueDate" ReadOnly="true" autocomplete="off" runat="server" TabIndex="2"
                                            Style="margin-left: 18px">
                                        </asp:TextBox>
                                    </div>
                                </div>
                                
                                <div class="row" id="Declaration" runat="server" visible="true" style="margin-left: 1%; margin-bottom: 20px;">
                                    <label style="display: flex; align-items: center;">
                                        <asp:CheckBox ID="Check" Enabled="false" runat="server" Checked="true" TabIndex="24" Style="margin-top: -5px;" />
                                        <span style="margin-left: 8px; font-size: 16px; line-height: 20px; margin-top: 10px; padding-right: 1%;">We undertake that we shall maintain and operate all the electrical installations in a condition free from danger and as recommended by the manufacturer and/or by the relevant Code of Practice of the Bureau of Indian Standards.
                                        </span>
                                    </label>
                                </div>                                
                                <div class="row" style="margin-top: 25px; margin-left: 0px !important; text-align: center !important;">
                                    <div class="col-12" style="text-align: center !important;">
                                        <p style="color: red; font-weight: bold;">Note: This RTS due date is valid only if all the documents and information of this application is correct in all the aspects. "</p>
                                    </div>                                    
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-4"></div>
                            <div class="col-4">
                                <asp:HiddenField ID="hdnId" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- partial:../../partials/_footer.html -->
        <footer class="footer">
        </footer>
    </form>
</body>
</html>
