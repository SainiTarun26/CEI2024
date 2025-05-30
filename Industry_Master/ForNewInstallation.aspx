﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Industry_Master/NewInstallation.Master" AutoEventWireup="true" CodeBehind="ForNewInstallation.aspx.cs" Inherits="CEIHaryana.Industry_Master.ForNewInstallation" %>
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
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <style type="text/css">
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
            font-size: 1rem;
            margin-bottom: 16px !important;
        }

        table#ContentPlaceHolder1_GridView1 {
            margin-top: -6px !important;
        }

        .ReturnedRowColor {
            background-color: #f9c7c7 !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div class="card" style="box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px; border-radius: 5px !important">
            <div class="card-body">
                <div class="row ">
                    <div class="col-sm-4 col-md-12">
                        <h6 class="card-title fw-semibold mb-12">
                            <asp:Label ID="lblData" runat="server"></asp:Label>LIST OF NEW INSTALLATIONS(Work Completion And Test Report Issued By Authorised Electrical Contractor)</h6>
                    </div>
                    <%--  <div class="col-sm-6 col-md-6"></div>
                    <div class="col-sm-2 col-md-2">
                        <asp:Button ID="btnAddnew" runat="server" class="btn btn-primary" Style="margin-left: 10px;" Text="Add New" OnClick="btnAddnew_Click" />
                    </div>--%>
                </div>
                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px;">
                    <%--<div class="row" style="margin-bottom: -30px;">
                        <div class="col-4">
                            <div class="form-group row">
                                <label for="search" class="col-sm-3 col-form-label" style="margin-top: -6px;">Search:</label>
                                <div class="col-sm-9" style="margin-left: -35px;">
                                    <asp:TextBox ID="txtSearch" runat="server" PlaceHolder="Auto Search" class="form-control" onkeydown="return SearchOnEnter(event);" Font-Size="12px" onkeyup="Search_Gridview(this)"></asp:TextBox><br />
                                </div>
                            </div>
                        </div>
                    </div>--%>
                    <asp:Panel ID="pnlSearch" runat="server" DefaultButton="btnSearch">
                        <div class="row" style="margin-bottom: -30px;">
                            <div class="col-md-6">
                                <div class="form-group row">
                                    <label for="search" class="col-md-1 col-form-label" style="margin-top: 3px; padding: 0px;">Search:</label>
                                    <div class="col-md-6" style="margin-left: -10px;">
                                        <asp:TextBox ID="txtSearch" runat="server" PlaceHolder="Auto Search" class="form-control" Font-Size="12px"></asp:TextBox><br />
                                    </div>
                                    <div class="col-md-2">
                                        <asp:Button ID="btnSearch" runat="server" class="btn btn-primary" Text="Search" Style="padding-top: 1px; padding-bottom: 1px;" />  <%--  OnClick="btnSearch_Click" --%>
                                    </div>
                                    <div class="col-md-2">
                                        <asp:Button ID="btnReset" runat="server" class="btn btn-primary" Text="Reset" Style="padding-top: 1px; padding-bottom: 1px; padding-left: 17px; padding-right: 17px;" /> <%-- OnClick="btnReset_Click" --%>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>

                    <table class="table table-responsive">
                        <asp:GridView class="table-responsive table table-striped table-hover" ID="GridView1" AutoPostBack="true" runat="server" Width="100%" AutoGenerateColumns="false" 
                            AllowPaging="true" PageSize="20" BorderWidth="1px" BorderColor="#dbddff"  OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" OnPageIndexChanging="GridView1_PageIndexChanging">
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
                                        <asp:Label ID="lblID" runat="server" Text='<%#Eval("Id") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Application">
                                    <HeaderStyle Width="25%" CssClass="headercolor" />
                                    <ItemStyle Width="25%" />
                                    <ItemTemplate>
                                        <%--  <asp:LinkButton ID="LinkButton4" runat="server" CommandName="Select"><%#Eval("Id") %></asp:LinkButton> --%>
                                        <asp:LinkButton ID="LinkButton4" runat="server" AutoPostBack="true" CommandArgument=' <%#Eval("Name") %> ' CommandName="Select"><%#Eval("Name") %></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="VoltageLevel" HeaderText="Voltage Level">
                                    <HeaderStyle HorizontalAlign="center" CssClass="GridViewRowHeader headercolor" />
                                    <ItemStyle HorizontalAlign="center" CssClass="GridViewRowItems" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CreatedDate1" HeaderText="Request Date">
                                    <HeaderStyle HorizontalAlign="center" CssClass="GridViewRowHeader headercolor" />
                                    <ItemStyle HorizontalAlign="center" CssClass="GridViewRowItems" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CompletionDate1" HeaderText="Completion Date">
                                    <HeaderStyle HorizontalAlign="center" CssClass="GridViewRowHeader headercolor" />
                                    <ItemStyle HorizontalAlign="center" CssClass="GridViewRowItems" />
                                </asp:BoundField>

                                <asp:BoundField DataField="ReportType" HeaderText="ReportType">
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
                        <%-- <asp:GridView class="table-responsive table table-hover table-striped" ID="GridView1" runat="server" Width="100%" AllowPaging="true" PageSize="10"
                            AutoGenerateColumns="false" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand" OnPageIndexChanging="GridView1_PageIndexChanging" BorderWidth="1px" BorderColor="#dbddff">
                            <PagerStyle CssClass="pagination-ys" />
                            <Columns>
                                <asp:TemplateField >
                                     <HeaderStyle Width="5%" CssClass="headercolor" />
                                    <ItemStyle Width="5%" />
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chkSelectAll" runat="server" />
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
                                <asp:TemplateField HeaderText="Id" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIntimations" runat="server" Text='<%#Eval("Intimations") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Id" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblID" runat="server" Text='<%#Eval("Ids") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                  
                                <asp:TemplateField HeaderText="Id" Visible="False">

                                    <ItemTemplate>
                                       <%-- <asp:Label ID="lblVoltageLevel" runat="server" Visible="false" Text='<%#Eval("VoltageLevel") %>'></asp:Label>--%>

                        <%--<asp:Label ID="lblTyps" runat="server" Text='<%#Eval("Typs") %>'></asp:Label>
                                        <asp:Label ID="lblhistory" runat="server" Text='<%#Eval("history") %>'></asp:Label>
                                        <asp:Label ID="lblNoOfInstallations" runat="server" Text='<%#Eval("NoOfInstallations") %>'></asp:Label>
                                        <asp:Label ID="lblIHID" runat="server" Text='<%#Eval("IHID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                    <asp:TemplateField HeaderText="Application">
                                    <HeaderStyle Width="25%" CssClass="headercolor"  />
                                    <ItemStyle Width="25%" />
                                    <ItemTemplate>
                                         <asp:Label ID="lblApllication" runat="server" Visible="false" Text='<%#Eval("Apllication") %>'></asp:Label>
                                           <asp:LinkButton ID="LinkButton4" runat="server" AutoPostBack="true" CommandArgument=' <%#Eval("Apllication") %> ' 
                                               CommandName="Select" ><%#Eval("Apllication") %></asp:LinkButton>
                                    </ItemTemplate>

                                </asp:TemplateField>
                                <asp:BoundField DataField="Typs" HeaderText="Installations Type">
                                    <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor"/>
                                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NoOfInstallations" HeaderText="Installations">
                                    <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor"/>
                                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="history" HeaderText="Test Report">
                                    <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor"/>
                                    <ItemStyle HorizontalAlign="Left" Width="15%" />
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
                        </asp:GridView>--%>
                    </table>
                    <div class="row" id="Note" runat="server" visible="false">

                        <div class="col-12">
                            <samp style="color: red; font-weight: bold; font-size: 15px;">NOTE:</samp>&nbsp;
            
                            <label for="Phone" style="font-weight: bold; font-size: 15px;">
                                Please contact your contractor whether test reports are approved. <br/>
                               
                            </label>
                            
                        </div>
                        <div>
                         <label for="Phone" style="font-weight: bold; font-size: 20px;">
                                     Please verify that the PAN number entered in the CAF matches with the PAN number given to the contractor.
                             </label>
                             <asp:HiddenField ID="hfOwner" runat="server" />
                            </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function Search_Gridview(strKey) {
            var strData = strKey.value.toLowerCase().split(" ");
            var tblData = document.getElementById("<%=GridView1.ClientID %>");
            var rowData;

            for (var i = 1; i < tblData.rows.length; i++) {
                rowData = tblData.rows[i].innerHTML;
                var styleDisplay = 'none';

                // Initialize a variable to keep track of whether any strData keyword is found in the row
                var found = false;

                for (var j = 0; j < strData.length; j++) {
                    if (rowData.toLowerCase().indexOf(strData[j]) >= 0) {
                        found = true;
                        break;
                    }
                }

                // If any strData keyword is found in the row, display it; otherwise, hide it
                styleDisplay = found ? '' : 'none';
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
    <script type="text/javascript">
        function SelectAllCheckboxes(headerCheckbox) {
            var checkboxes = document.querySelectorAll('[id*=CheckBox1]');
            for (var i = 0; i < checkboxes.length; i++) {
                checkboxes[i].checked = headerCheckbox.checked;
            }
        }
    </script>

     <script>
         function alertWithRedirectdata_InvalidSession() {
             alert('Your Session Expired..');
             window.location.href = 'https://staging.investharyana.in/#/';
         }
     </script>

         

</asp:Content>
