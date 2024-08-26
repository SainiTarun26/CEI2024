<%@ Page Title="" Language="C#" MasterPageFile="~/Supervisor/Supervisor.Master" AutoEventWireup="true" CodeBehind="IntimationDataForPeriodic.aspx.cs" Inherits="CEIHaryana.Supervisor.IntimationDataForPeriodic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://kit.fontawesome.com/57676f1d80.js" crossorigin="anonymous"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <!-- Remember to include jQuery :) -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.0.0/jquery.min.js"></script>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-modal/0.9.2/jquery.modal.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/jquery-modal/0.9.2/jquery.modal.min.css" />
    <!-- jQuery Modal -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-modal/0.9.1/jquery.modal.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/jquery-modal/0.9.1/jquery.modal.min.css" />
    <style type="text/css">
        a.close-modal {
            width: 0px !important;
        }

        .jquery-modal.blocker.current {
            margin-top: 50px;
            height: 95%;
        }

        .modal {
            max-width: 60%; /* Adjust the maximum width as needed */
            margin: -40px; /* Center the modal horizontally */
            background-color: white; /* Background color for the modal */
            padding: 20px; /* Add padding for content */
            border-radius: 10px; /* Rounded corners for the modal */
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.5); /* Optional shadow effect */
            position: fixed; /* Fixed positioning to make it a popup */
            top: 50%; /* Center vertically */
            left: 50%; /* Center horizontally */
            transform: translate(-50%, -40%); /* Center using transform */
            z-index: 9999; /* Ensure it's on top of other content */
        }

        .row-modal {
            margin-top: 15px;
        }



        th.GridViewRowHeader {
            padding: 10px 17px 10px 10px;
            width: 1%;
        }

        th.AlignHeader {
            text-align: left;
        }

        td.NameRow {
            text-align: initial;
            padding: 5px;
            width: 20%;
        }

        th.WorkDetails {
            text-align: initial;
        }

        td.WorkDetailsRow {
            text-align: initial;
            padding: 0px 5px 0px 5px;
        }

        th.WorkDetails {
            padding: 0px 0px 0px 10px;
        }

        td.IntimationIdRow {
            padding: 0px 5px 0px 5px;
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

        .headercolor {
            background-color: #9292cc;
        }

        th.headercolor {
            text-align: left;
            color: white;
        }

        td.itemstylecss {
            text-align: left;
            padding-left: 12px;
        }

        .ReturnedRowColor {
            background-color: #f9c7c7 !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <div class="card" style="box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px; border-radius: 5px !important">
            <div class="card-body">
                <div class="row ">
                    <div class="col-sm-4 col-md-4">
                        <h6 class="card-title fw-semibold mb-4">
                            <asp:Label ID="lblData" runat="server"></asp:Label></h6>
                    </div>
                </div>
                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                    <div class="row" style="margin-bottom: -30px;">
                        <div class="col-12">
                            <div class="form-group row" style="margin-bottom: 0px !important;">
                                <label for="search" class="col-sm-2 col-form-label" style="margin-top: -6px;">Search:</label>
                                <div class="col-sm-10" style="margin-left: -130px; margin-top: auto; margin-bottom: auto;">
                                    <asp:TextBox ID="txtSearch" runat="server" PlaceHolder="Auto Search" class="form-control" AutoPostBack="true" onkeydown="return SearchOnEnter(event);" onkeyup="Search_Gridview(this)" Font-Size="12px" Style="font-size: 12px; height: 30px;"></asp:TextBox><br />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div style="margin-top: 3%">
                        <asp:GridView class="table-responsive table table-striped table-hover" ID="GridView1" AutoPostBack="true" runat="server" Width="100%" AutoGenerateColumns="false"
                            BorderWidth="1px" BorderColor="#dbddff">
                            <PagerStyle CssClass="pagination-ys" />
                            <Columns>
                                <asp:TemplateField HeaderText="SNo">
                                    <HeaderStyle Width="5%" CssClass="headercolor" />
                                    <ItemStyle Width="5%" />
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Id" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblInspectionId" runat="server" Text='<%#Eval("InspectionId") %>'></asp:Label>
                                        <asp:Label ID="lblIntimationId" runat="server" Text='<%#Eval("IntimationId") %>'></asp:Label>
                                        <%--<asp:Label ID="lblTestReportCount" runat="server" Text='<%#Eval("TestReportCount") %>'></asp:Label>
                                         <asp:Label ID="lblInstallationName" runat="server" Text='<%#Eval("InstallationName") %>'></asp:Label>
                                     <asp:Label ID="lblApplicationStatus" runat="server" Text='<%#Eval("ApplicationStatus") %>'></asp:Label>
                                          <asp:Label ID="lblAssignedSupervisor" runat="server" Text='<%#Eval("AssignedSupervisor") %>'></asp:Label>
                                        --%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Inspection ID">
                                    <HeaderStyle HorizontalAlign="Left" Width="25%" CssClass="headercolor" />
                                    <ItemStyle HorizontalAlign="Left" Width="25%" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton4" runat="server" AutoPostBack="true" CommandArgument=' <%#Eval("InspectionId") %> ' CommandName="Select" OnClick="LinkButton4_Click"><%#Eval("InspectionId") %></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="InstallationType" HeaderText="Installation Type">
                                    <HeaderStyle HorizontalAlign="center" CssClass="GridViewRowHeader headercolor" />
                                    <ItemStyle HorizontalAlign="center" CssClass="GridViewRowItems itemstylecss" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NameOfOwner" HeaderText="Owner Name">
                                    <HeaderStyle HorizontalAlign="center" CssClass="GridViewRowHeader headercolor" />
                                    <ItemStyle HorizontalAlign="left" CssClass="GridViewRowItems itemstylecss" />
                                </asp:BoundField>
                                <asp:BoundField DataField="District" HeaderText="District">
                                    <HeaderStyle HorizontalAlign="center" CssClass="GridViewRowHeader headercolor" />
                                    <ItemStyle HorizontalAlign="left" CssClass="GridViewRowItems itemstylecss" />
                                </asp:BoundField>
                                <asp:BoundField DataField="MaxVoltage" HeaderText="Voltage Level">
                                    <HeaderStyle HorizontalAlign="center" CssClass="GridViewRowHeader headercolor" />
                                    <ItemStyle HorizontalAlign="center" CssClass="GridViewRowItems " />
                                </asp:BoundField>
                                <asp:BoundField DataField="ReasonOnBased" HeaderText="ReasonOnBased">
                                    <HeaderStyle HorizontalAlign="center" CssClass="GridViewRowHeader headercolor" />
                                    <ItemStyle HorizontalAlign="center" CssClass="GridViewRowItems" />
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
                    <div class="card" style="margin: -11px; margin-top: 15px; padding: 11px; margin-bottom: 20px;" id="DivViewCart" runat="server" visible="false">
                        <div class="col-12" style="padding: 0px;">
                            <asp:GridView ID="GridView3" CssClass="table table-bordered table-striped table-responsive" runat="server" AutoGenerateColumns="false">
                                <HeaderStyle BackColor="#B7E2F0" />
                                <Columns>
                                    <asp:TemplateField HeaderText="SNo">
                                        <HeaderStyle Width="5%" CssClass="headercolor" />
                                        <ItemStyle Width="5%" />
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="InstallationType" HeaderText="Installation Type">
                                        <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TestReportId" HeaderText="TestReportId" Visible="false">
                                        <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Id" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblId" runat="server" Text='<%#Eval("NewInspectionId") %>'></asp:Label>
                                            <asp:Label ID="IntimationId" runat="server" Text='<%#Eval("IntimationId") %>'></asp:Label>
                                            <asp:Label ID="LblInstallationName" runat="server" Text='<%#Eval("InstallationName") %>'></asp:Label>
                                            <asp:Label ID="LblTestReportCount" runat="server" Text='<%#Eval("TestReportCount") %>'></asp:Label>
                                            <asp:Label ID="LblNewInspectionId" runat="server" Text='<%#Eval("NewInspectionId") %>'></asp:Label>
                                            <asp:Label ID="lblApplicationStatus" runat="server" Text='<%#Eval("ApplicationStatus") %>'></asp:Label>
                                            <%--<asp:Label ID="lblAssignedSupervisor" runat="server" Text='<%#Eval("AssignedSupervisor") %>'></asp:Label>--%>
                                              <asp:Label ID="lblVoltageLevel" runat="server" Text='<%#Eval("VoltageLevel") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="View Test Reports" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="4%">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkRedirect1" runat="server" Text="View Test Report" CommandName="ViewTestReport" OnClick="lnkRedirect1_Click" CommandArgument='<%# Eval("TestReportId") %>' />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="2%"></ItemStyle>
                                        <HeaderStyle HorizontalAlign="Left" CssClass="headercolor" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Recreate Test Report" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="4%">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LnkToCreate" runat="server" Text="Click to Create" OnClick="LnkToCreate_Click"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="2%"></ItemStyle>
                                        <HeaderStyle HorizontalAlign="Left" CssClass="headercolor" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script>
        function showModal() {
            $('#ex1').modal('show');
        }
        function CloseModalAndRedirect() {
            $('#ex1').modal('hide');
            window.location.href = "TestReportForm.aspx";
        }
    </script>
    <script type="text/javascript">
        function Search_Gridview(strKey) {
            var strData = strKey.value.toLowerCase().split(" ");
            var tblData = document.getElementById("<%=GridView1.ClientID %>");
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
                event.preventDefault();
                Search_Gridview(document.getElementById('txtSearch'));
            }
        }
    </script>
</asp:Content>
