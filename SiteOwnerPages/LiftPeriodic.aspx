<%@ Page Title="" Language="C#" MasterPageFile="~/SiteOwnerPages/SiteOwner.Master" AutoEventWireup="true" CodeBehind="LiftPeriodic.aspx.cs" Inherits="CEIHaryana.SiteOwnerPages.LiftPeriodic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="shortcut icon" type="image/png" href="/css2/style.min.css" />
    <link rel="stylesheet" href="/css2/style.css" />
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css" />
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/css/select2.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/js/select2.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.5.2/css/bootstrap.css" rel="stylesheet" />
    <link href="https://cdn.datatables.net/1.13.5/css/dataTables.bootstrap4.min.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.7.0.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css">
    <script src="https://cdn.datatables.net/1.13.5/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.13.5/js/dataTables.bootstrap4.min.js"></script>
    <script src="https://kit.fontawesome.com/57676f1d80.js" crossorigin="anonymous"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <style>
        .fade {
            transition: opacity 0.15s linear;
            width: 110% !important;
            height: 100% !important;
        }

        .pagination-ys {
            /*display: inline-block;*/
            padding-left: 0;
            margin: 20px 0;
            border-radius: 4px;
        }

            .pagination-ys table > tbody > tr > td {
                display: contents;
            }

                .pagination-ys table > tbody > tr > td > a,
                .pagination-ys table > tbody > tr > td > span {
                    position: relative;
                    float: left;
                    padding: 8px 12px;
                    line-height: 1.42857143;
                    text-decoration: none;
                    color: #dd4814;
                    background-color: #ffffff;
                    border: 1px solid #dddddd;
                    margin-left: -1px;
                }

                .pagination-ys table > tbody > tr > td > span {
                    position: relative;
                    float: left;
                    padding: 8px 12px;
                    line-height: 1.42857143;
                    text-decoration: none;
                    margin-left: -1px;
                    z-index: 2;
                    color: #aea79f;
                    background-color: #f5f5f5;
                    border-color: #dddddd;
                    cursor: default;
                }

                .pagination-ys table > tbody > tr > td:first-child > a,
                .pagination-ys table > tbody > tr > td:first-child > span {
                    margin-left: 0;
                    border-bottom-left-radius: 4px;
                    border-top-left-radius: 4px;
                }

                .pagination-ys table > tbody > tr > td:last-child > a,
                .pagination-ys table > tbody > tr > td:last-child > span {
                    border-bottom-right-radius: 4px;
                    border-top-right-radius: 4px;
                }

                .pagination-ys table > tbody > tr > td > a:hover,
                .pagination-ys table > tbody > tr > td > span:hover,
                .pagination-ys table > tbody > tr > td > a:focus,
                .pagination-ys table > tbody > tr > td > span:focus {
                    color: #97310e;
                    background-color: #eeeeee;
                    border-color: #dddddd;
                }

        .col-md-4 {
            margin-bottom: 8px;
        }

        .form-control {
            box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
            margin-left: 0px !important;
            height: 25px;
        }

        select.form-control {
            box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
            margin-left: 0px !important;
            height: 25px;
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
            font-size: 1.4rem !important;
        }

        .btn-primary:hover {
            box-shadow: rgba(50, 50, 93, 0.25) 0px 30px 60px -12px inset, rgba(0, 0, 0, 0.3) 0px 18px 36px -18px inset;
        }

        button.btn.btn-primary.mr-2 {
            padding: 10px 25px 10px 25px;
            font-size: 18px;
        }

        h6.card-title.fw-semibold.mb-4 {
            margin-bottom: 10px !important;
        }

        input.form-control.form-control-sm {
            margin-left: 7px !important;
        }

        td {
            text-align: center;
        }

        .headercolor {
            background-color: #9292cc;
        }

        .text-wrap {
            white-space: normal;
            overflow-wrap: break-word;
            word-wrap: break-word;
            max-width: 100%;
        }

        th {
            background-color: #9292cc;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <div class="card" style="box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px; border-radius: 5px !important">
            <div class="card-body">
                <div class="row ">
                    <div class="col-md-4 col-md-4">
                        <h6 class="card-title fw-semibold mb-4">Renewal of Lift/Escalator
                        </h6>
                    </div>
                    <div class="col-md-5 col-md-5"></div>
                    <div class="col-md-2 col-md-2" style="margin-left: -45px;">
                        <asp:Button ID="btnAddnew" OnClick="btnAddnew_Click" runat="server" class="btn btn-primary" Style="margin-left: 10px;" Text="+ Add Existing Lift/Escalator Details" />
                    </div>
                </div>
                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                    <div class="row">
                        <div class="col-md-4" runat="server">
                            <label>
                                Select District<samp style="color: red"> * </samp>
                            </label>
                            <asp:DropDownList class="form-control  select-form select2" runat="server" AutoPostBack="true" ID="ddlDistrict" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" Style="width: 100% !important">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator25" ErrorMessage="Required" ControlToValidate="ddlDistrict" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                        </div>
                    </div>
                    <asp:GridView class="table-responsive table table-striped" ID="GridView1" runat="server" OnRowCommand="GridView1_RowCommand" AutoGenerateColumns="false" BorderWidth="1px" BorderColor="#dbddff" AutoPostBack="true">
                        <PagerStyle CssClass="pagination-ys" />
                        <Columns>
                            <asp:TemplateField ItemStyle-HorizontalAlign="left" ItemStyle-VerticalAlign="Middle">
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" HorizontalAlign="center" AutoPostBack="true" OnCheckedChanged="CheckBox1_CheckedChanged" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SNo">
                                <HeaderStyle Width="5%" CssClass="headercolor" />
                                <ItemStyle Width="5%" />
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="InstallationType" HeaderText="Installation Type">
                                <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="RegistrationNo" HeaderText="Registration No">
                                <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PreviousChallanDate" HeaderText="PreviousChallan Date" Visible="false">
                                <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ApplicantDistrict" HeaderText="District" Visible="false">
                                <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SerialNo" HeaderText="Serial No">
                                <HeaderStyle HorizontalAlign="center" Width="12%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="center" Width="12%" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="View Report" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="4%">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkRedirect1" runat="server" Text="View Report" CommandName="Select" CommandArgument='<%# Eval("RegistrationNo") %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="2%"></ItemStyle>
                                <HeaderStyle HorizontalAlign="Left" CssClass="headercolor" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Id" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="LblCategory" runat="server" Text='<%#Eval("InstallationType") %>'></asp:Label>
                                    <asp:Label ID="LblRegistrationNo" runat="server" Text='<%#Eval("RegistrationNo") %>'></asp:Label>
                                    <asp:Label ID="LblDistrict" runat="server" Text='<%#Eval("ApplicantDistrict") %>'></asp:Label>
                                    <asp:Label ID="LblYearsDifference" runat="server" Text='<%#Eval("YearsDifference") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="TypeOfLift" HeaderText="Type Of Lift" Visible="false">
                                <HeaderStyle HorizontalAlign="center" Width="12%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="center" Width="12%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TypeOfControl" HeaderText="TypeOfControl" Visible="false">
                                <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Capacity" HeaderText="Capacity(Persons)" Visible="false">
                                <HeaderStyle HorizontalAlign="center" Width="12%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="center" Width="12%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Weight" HeaderText="Weight(In Kgs)" Visible="false">
                                <HeaderStyle HorizontalAlign="center" Width="12%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="center" Width="12%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TypeOfInstallation" HeaderText="Type Of Installation" Visible="false">
                                <HeaderStyle HorizontalAlign="center" Width="12%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="center" Width="12%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PreviousChallanDate" HeaderText="Last Challan date">
                                <HeaderStyle HorizontalAlign="center" Width="12%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="center" Width="12%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="YearsDifference" HeaderText="Years Difference">
                                <HeaderStyle HorizontalAlign="center" Width="12%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="center" Width="12%" />
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
                <div id="FeesDetails" runat="server" visible="false">
                    <h7 class="card-title fw-semibold mb-4">Fees Details</h7>
                    <div class="card" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                        <h7 class="card-title fw-semibold mb-4" style="font-size: 30px; color: brown">
                            Note : Before proceeding to document checklist kindly pay your requisite fees first and then upload documents along with the treasury challan (PDF).
                        </h7>
                        <asp:GridView class="table-responsive table table-hover table-striped" Autopostback="true" ID="GridViewPayment" OnRowDataBound="GridViewPayment_RowDataBound" runat="server" Width="100%"
                            AutoGenerateColumns="false" BorderWidth="1px" BorderColor="#dbddff" ShowFooter="true">
                            <PagerStyle CssClass="pagination-ys" />
                            <Columns>
                                <asp:TemplateField HeaderText="Id" Visible="False">
                                    <ItemTemplate>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SNo">
                                    <HeaderStyle Width="5%" CssClass="headercolor" />
                                    <ItemStyle Width="5%" />
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Installation Type">
                                    <HeaderStyle HorizontalAlign="Left" Width="30%" CssClass="headercolor" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblInstallationType" runat="server" Text='<%#Eval("InstallationType") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="InstallationType" runat="server" Text="Total" Style="font-weight: bold;"></asp:Label>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Calculated Payment Only For">
                                    <HeaderStyle HorizontalAlign="Left" Width="30%" CssClass="headercolor" />
                                    <ItemStyle HorizontalAlign="Left" Width="30%" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblQuantity" runat="server" Text='<%#Eval("Quantity") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblFooterQuantity" runat="server" Text="0" Style="font-weight: bold;"></asp:Label>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Total Amount">
                                    <HeaderStyle HorizontalAlign="Left" Width="25%" CssClass="headercolor" />
                                    <ItemStyle HorizontalAlign="Left" Width="25%" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblInstallationAmount" runat="server" Text='<%#Eval("TotalAmount") %>'></asp:Label>
                                      </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblFooterAmount" runat="server" Text="0" Style="font-weight: bold;"></asp:Label>
                                    </FooterTemplate>
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
                        <div id="TotalPayment" runat="server" visible="false" class="row" style="margin-bottom: -30px; margin-top: 30px;">
                            <div class="row" style="margin-left: 0%; margin-top: 6px;">
                            </div>
                        </div>
                    </div>
                </div>
                <div id="UploadDocuments" runat="server" visible="true">
                    <h7 class="card-title fw-semibold mb-4">Document Checklist</h7>
                    <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                        <h7 class="card-title" style="color: #a52a2a; margin-bottom: 5px;">Note: Size of all the Attachments should not be more than 2mb.</h7>
                        <div class="row">
                            <div class="col-12">
                                <asp:GridView class="table-responsive table table-hover table-striped" ID="Grd_Document" runat="server" AutoGenerateColumns="false">
                                    <PagerStyle CssClass="pagination-ys" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="SNo">
                                            <HeaderStyle Width="5%" CssClass="headercolor" />
                                            <ItemStyle Width="5%" />
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="DocumentName" HeaderText="DocumentName">
                                            <HeaderStyle HorizontalAlign="Left" Width="70%" CssClass="headercolor leftalign" />
                                            <ItemStyle HorizontalAlign="Left" Width="70%" />
                                        </asp:BoundField>
                                        <%--  <asp:TemplateField HeaderText="Uploaded Documents" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="4%">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LnkDocumemtPath" runat="server" CommandArgument='<%# Bind("DocumentPath") %>' CommandName="Select"> View document </asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="2%" CssClass="headercolor"></ItemStyle>
                                            <HeaderStyle HorizontalAlign="Left" CssClass="headercolor" />
                                        </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="File Upload (1MB PDF Only)">
                                            <HeaderStyle HorizontalAlign="Left" CssClass="headercolor leftalign" />
                                            <ItemTemplate>
                                                 <%--<input type="hidden" id="Req" runat="server" value='<%# Eval("Req") %>' />--%>
                                                <input type="hidden" id="DocumentShortName" runat="server" value='<%# Eval("DocumentShortName") %>' />
                                                <input type="hidden" id="DocumentName" data-req='<%# Eval("DocumentName") %>' />
                                                <input type="hidden" id="DocumentID" runat="server" value='<%# Eval("DocumentID") %>' />
                                                <asp:FileUpload ID="FileUpload1" runat="server" OnClientClick="return validateFileUpload(this);" onchange="return validateFileUpload(this);" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="White" ForeColor="#000066" />
                                    <HeaderStyle BackColor="#9292cc" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
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
                </div>
                <div id="PaymentDetails" runat="server" visible="False">
                    <h7 class="card-title fw-semibold mb-4">Payment Details</h7>
                    <div id="ChallanDetail" runat="server" visible="false" class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 15px;">
                        <div class="row" style="margin-top: 15px; margin-bottom: 15PX !important;">
                        </div>
                        <div class="row" style="margin-top: -40px !important;">
                            <div class="col-4">
                                <label>
                                    Transaction Id<samp style="color: red"> * </samp>
                                </label>
                                <asp:TextBox ID="txttransactionId" runat="server" class="form-control" Font-Size="12px" Style="height: 30px;"></asp:TextBox><br />
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txttransactionId" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please enter Transcation Id</asp:RequiredFieldValidator>--%>
                            </div>
                            <div class="col-4">
                                <label>
                                    Transaction Date<samp style="color: red"> * </samp>
                                </label>
                                <asp:TextBox ID="txttransactionDate" onfocus="disableFutureDates()" min='0000-01-01' onkeydown="return false;" max='9999-01-01' TextMode="Date" runat="server" class="form-control" Font-Size="12px" Style="height: 30px;"></asp:TextBox><br />
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txttransactionDate" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please enter Transcation Date</asp:RequiredFieldValidator>--%>
                            </div>
                            <div class="col-4" style="margin-top: auto; margin-bottom: auto;">
                                <label>
                                    Payment Mode
                                </label>
                                <asp:RadioButtonList ID="RadioButtonList2" AutoPostBack="true" runat="server" RepeatDirection="Horizontal" TabIndex="25">
                                    <asp:ListItem Text="Online" Value="0" Enabled="false"></asp:ListItem>
                                    <asp:ListItem Text="Offline" Value="1" Selected="True"></asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:RequiredFieldValidator ID="rfvRbList" runat="server" ControlToValidate="RadioButtonList2" ForeColor="Red" ValidationGroup="Submit" ErrorMessage="Please select a value" Display="Dynamic" />
                            </div>
                        </div>
                    </div>
                    <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 15px;">
                        <div class="row">
                            <div class="col-md-12">
                                <label for="Remarks">
                                    Inspection Remarks<samp style="color: red"> * </samp>
                                </label>
                                <asp:TextBox class="form-control" ID="txtInspectionRemarks" runat="server" autocomplete="off" MaxLength="500" Style="margin-left: 18px" TabIndex="3"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtInspectionRemarks" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Inspection Remarks</asp:RequiredFieldValidator>--%>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-4"></div>
                <div class="col-4" style="text-align: center;">
                    <asp:Button ID="btnSubmit" Text="Submit" OnClick="btnSubmit_Click" runat="server" ValidationGroup="Submit" class="btn btn-primary mr-2" />
                    <asp:Button type="submit" ID="btnReset" Text="Reset" runat="server" Visible="false" class="btn btn-primary mr-2" />
                    <asp:Button type="Back" ID="btnBack" Text="Back" runat="server" Visible="false" class="btn btn-primary mr-2" />
                </div>
                <asp:HiddenField ID="hdnInstallationType" runat="server" />
                 <asp:HiddenField ID="HdnDistrict" runat="server" />
                 <asp:HiddenField ID="HdnDivision" runat="server" />
                   <asp:HiddenField ID="InspectionIdClientSideCheckedRow" runat="server" />
                <div class="col-4"></div>
            </div>
        </div>
    </div>
        <script type="text/javascript">
        // Validate if the file is a PDF and the size is less than 1MB
        function validateFileUpload(sender) {
            var fileUpload = sender;
            var filePath = fileUpload.value;
            var fileExtension = filePath.substring(filePath.lastIndexOf('.') + 1).toLowerCase();
            var fileSize = fileUpload.files[0].size; // Size in bytes

            // Check file extension
            if (fileExtension !== "pdf") {
                alert("Only PDF files are allowed.");
                fileUpload.value = ""; // Clear the file input
                return false;
            }

            // Check file size (1MB = 1048576 bytes)
            if (fileSize > 1048576) {
                alert("File size should not exceed 1MB.");
                fileUpload.value = ""; // Clear the file input
                return false;
            }

            return true;
        }
        </script>
</asp:Content>
