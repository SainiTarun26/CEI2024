﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Contractor/Contractor.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Approved_Test_Reports.aspx.cs" Inherits="CEIHaryana.Contractor.Approved_Test_Reports" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"> <link rel="shortcut icon" type="image/png" href="/css2/style.min.css" />
    <link rel="stylesheet" href="/css2/style.css" />
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css" />
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
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <style>
        .form-group.row {
            margin-bottom: -5px;
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

        h6.card-title.fw-semibold.mb-4 {
            font-size: 1rem !important;
            margin-bottom: 3px !important;
        }
        th.textalignleft {
    text-align: left;
}
        td.textalignleft {
    text-align: left;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="content-wrapper">
        <div class="card" style="box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px; border-radius: 5px !important">
            <div class="card-body">
                <div class="row ">
                    <div class="col-sm-6 col-md-6">
                        <h6 class="card-title fw-semibold mb-4">
                            <asp:Label ID="Label1" runat="server"></asp:Label>WORK COMPLETETION AND TEST REPORT DETAILS</h6>
                    </div>
                    <%--  <div class="col-sm-6 col-md-6"></div>
    <div class="col-sm-2 col-md-2">
        <asp:Button ID="btnAddnew" runat="server" class="btn btn-primary" Style="margin-left: 10px;" Text="Add New" OnClick="btnAddnew_Click" />
    </div>--%>
                </div>
                <div class="row ">
                    <div class="col-sm-4 col-md-4">
                        <h6 class="card-title fw-semibold mb-4">
                            <asp:Label ID="lblData" runat="server"></asp:Label></h6>
                    </div>
                    <div class="col-sm-6 col-md-6"></div>
                </div>
                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                    <div class="row" style="margin-bottom: -30px;">
                        <div class="col-md-4">
                            <div class="form-group row">
                                <label for="search" class="col-md-3 col-form-label" style="margin-top: -6px;">Search:</label>
                                <div class="col-md-9" style="margin-left: -35px;">
                                    <asp:TextBox ID="txtSearch" runat="server" onkeydown="return SearchOnEnter(event);" onkeyup="Search_Gridview(this)" PlaceHolder="Auto Search" class="form-control" Font-Size="12px"></asp:TextBox><br />
                                    <asp:TextBox ID="txtapproval" runat="server" Visible="false" class="form-control" Font-Size="12px"></asp:TextBox><br />
                                </div>
                            </div>
                        </div>
                    </div>
                    <asp:GridView class="table-responsive table table-striped table-hover" ID="GridView1" runat="server" Width="100%" AllowPaging="true" PageSize="20" OnRowDataBound="GridView1_RowDataBound" OnPageIndexChanging="GridView1_PageIndexChanging"
                        AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand" BorderWidth="1px" BorderColor="#dbddff">
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
                                    <asp:Label ID="lblApproval" runat="server" Text='<%#Eval("Approval") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                           <%-- <asp:TemplateField HeaderText="Id" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="LblReasionforRejection" runat="server" Text='<%#Eval("ReasonForRejection") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Id" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblTypeOf" runat="server" Text='<%#Eval("Type") %>'></asp:Label>
                                    <asp:Label ID="lblInspectionType" runat="server" Text='<%#Eval("InspectionType") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Id" Visible="False">
                                <ItemTemplate>
                                    <%--<asp:Label ID="lblID" runat="server" Text='<%#Eval("ID") %>'></asp:Label>--%>
                                    <asp:Label ID="lblIntimationId" runat="server" Text='<%#Eval("IntimationId") %>'></asp:Label>
                                    <asp:Label ID="lblCounts" runat="server" Text='<%#Eval("Counts") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderStyle Width="34%" CssClass="headercolor leftalign" />
                                <ItemStyle Width="34%" cssclass="leftalign" />
                                <HeaderTemplate>
                                  <%--  Test Report Application--%>
                                    Intimation Id
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton4" runat="server" CommandArgument=' <%#Eval("IntimationId") %> ' CommandName="Select" Style="text-align: left;"><%#Eval("IntimationId") %></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="NameofSiteOwner" HeaderText="SiteOwner">
    <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor textalignleft" />
    <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="break-text-site-owner textalignleft" />
</asp:BoundField>

                            <asp:TemplateField HeaderText="">
    <HeaderTemplate>
        Installation<br />Type
    </HeaderTemplate>
    <ItemTemplate>
        <%# Eval("TypeOf") %>
    </ItemTemplate>
    <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor leftalign" />
    <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="leftalign break-after-space" />
</asp:TemplateField>


                         
                            <asp:BoundField DataField="Voltagelevel" HeaderText="Voltagelevel">
                                <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" />
                            </asp:BoundField>
                             <asp:TemplateField>
            <HeaderStyle Width="5%" CssClass="headercolor" />
            <ItemStyle Width="5%" />
            <HeaderTemplate>
              Installation <br/> Invoice
            </HeaderTemplate>
            <ItemTemplate>
                <%--<asp:LinkButton ID="LinkButton4" runat="server" CommandArgument=' <%#Eval("DocumentPath") %> ' CommandName="Select"><%#Eval("DocumentPath") %>  Text="Click here to view document"</asp:LinkButton>--%>
                <asp:LinkButton ID="LnkInovoice" runat="server" AutoPostBack="true" CommandArgument='<%#Eval("invoice") %>' CommandName="View">
                   View Document
                </asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <HeaderStyle Width="5%" CssClass="headercolor" />
            <ItemStyle Width="5%" />
            <HeaderTemplate>
                Manufacturing<br/>Test Report
            </HeaderTemplate>
            <ItemTemplate>
                <%--<asp:LinkButton ID="LinkButton4" runat="server" CommandArgument=' <%#Eval("DocumentPath") %> ' CommandName="Select"><%#Eval("DocumentPath") %>  Text="Click here to view document"</asp:LinkButton>--%>
                <asp:LinkButton ID="lnkReport" runat="server" AutoPostBack="true" CommandArgument='<%#Eval("report") %>' CommandName="View">
                   View Documents
                </asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
                              <asp:TemplateField HeaderText="">
    <HeaderTemplate>
        <div class="headercolor" style="text-align:center; width:100%;">Approved<br />Date</div>
    </HeaderTemplate>
    <ItemTemplate>
        <%# Eval("Approveddate") %>
    </ItemTemplate>
    <HeaderStyle HorizontalAlign="center" Width="12%" cssclass="headercolor"/>
    <ItemStyle HorizontalAlign="center" Width="12%" />
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
    </div>
    <footer class="footer">
    </footer>
    <script>
        new DataTable('#example');
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
                event.preventDefault(); // Prevent default form submission
                Search_Gridview(document.getElementById('txtSearch'));
            }
        }
    </script>
    <script>
        function preventEnterSubmit(event) {
            if (event.keyCode === 13) {
                event.preventDefault(); // Prevent form submission
                return false;
            }
        }
    </script>
    <script type="text/javascript">
        document.addEventListener("DOMContentLoaded", function () {
            const elements = document.querySelectorAll('.break-text-site-owner');

            elements.forEach(function (element) {
                let text = element.innerText;
                let formattedText = '';
                let currentIndex = 0;

                while (currentIndex < text.length) {
                    // Take a chunk of up to 20 characters
                    let chunk = text.slice(currentIndex, currentIndex + 20);

                    if (chunk.length < 20) {
                        // If the chunk is less than 20 characters, add it without breaking
                        formattedText += chunk;
                        break; // Exit the loop as we've processed the remaining text
                    }

                    // For chunks of 20 or more characters, try to break at the last whitespace
                    let breakIndex = chunk.lastIndexOf(" ");
                    if (breakIndex !== -1) {
                        // If there's a whitespace, break at that space
                        formattedText += chunk.slice(0, breakIndex) + '<br>';
                        currentIndex += breakIndex + 1; // Move past the space
                    } else {
                        // Otherwise, break at the 20-character limit
                        formattedText += chunk + '<br>';
                        currentIndex += 20;
                    }
                }

                element.innerHTML = formattedText.trim(); // Remove any trailing <br>
            });
        });
    </script>
    <script>
        document.addEventListener("DOMContentLoaded", function () {
            // Select all cells with the "break-after-space" class
            var cells = document.querySelectorAll(".break-after-space");

            cells.forEach(function (cell) {
                // Insert line break at each whitespace
                cell.innerHTML = cell.innerText.replace(/\s+/g, "<br>");
            });
        });
    </script>

</asp:Content>
