<%@ Page Title="" Language="C#" MasterPageFile="~/Supervisor/Supervisor.Master" AutoEventWireup="true" CodeBehind="TestReportIntimationHistory.aspx.cs" Inherits="CEIHaryana.Supervisor.TestReportIntimationHistory" %>
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
    <style>
        .col-4 {
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
                                    <asp:TextBox ID="txtSearch" runat="server" PlaceHolder="Auto Search" class="form-control" AutoPostBack="true" Font-Size="12px"  Style="font-size: 12px; height: 30px;"></asp:TextBox><br />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div style="margin-top:3%">
                        <asp:GridView class="table-responsive table table-striped table-hover"  ID="GridView1" AutoPostBack="true" runat="server" Width="100%" AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand"
                            AllowPaging="true" PageSize="20" OnPageIndexChanging="GridView1_PageIndexChanging" BorderWidth="1px" BorderColor="#dbddff">
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
                                    <HeaderStyle Width="25%" CssClass="headercolor"  />
                                    <ItemStyle Width="25%" />
                                    <ItemTemplate>
                                      <%--  <asp:LinkButton ID="LinkButton4" runat="server" CommandName="Select"><%#Eval("Id") %></asp:LinkButton> --%>
                                        <asp:LinkButton ID="LinkButton4" runat="server" AutoPostBack="true" OnClick="ShowPopup_Click"  CommandArgument=' <%#Eval("Name") %> ' CommandName="Select"><%#Eval("Name") %></asp:LinkButton>
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
                    <div id="ex1" class="modal" style="height:auto;">
                        <div class="modal-header" style="font-size: 22px;"><b>Work Intimation Details</b></div>
                        <div class="col-md-12">
                            <div class="row row-modal">
                                <div class="col-6" runat="server">
                                    <label for="Name">
                                        Electrical Installation For
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtInstallation" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                </div>
                                <div class="col-6" id="agency" runat="server" visible="false">
                                    <label for="agency">Name of Firm/ Org./ Company/ Department</label>
                                    <asp:TextBox class="form-control" ID="txtagency" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                </div>
                                <div class="col-6" id="individual" runat="server">
                                    <label for="Name">
                                        Name of Owner/ Consumer
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtName" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row row-modal">
                              <%--  <div class="col-6" id="individual9" runat="server">
                                    <label for="Name">
                                        Contact No.(Contractor)
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtPhone" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                </div>--%>
                                <div class="col-6" id="individual10" runat="server">
                                    <label for="Name">
                                        Address 
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtAddress" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                </div>
                                <div class="col-6" id="individual5" runat="server">
                                    <label for="Name">
                                        Contact Details 
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtPhone" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row row-modal">
                                <div class="col-6" id="individual2" runat="server">
                                    <label for="Name">
                                        Type of Premises
                                    </label>
                                    <asp:TextBox class="form-control" ID="TxtPremises" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                </div>
                                <div class="col-6" id="individual3" runat="server">
                                    <label for="Name">
                                        Highest Voltage Level of Work
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtVoltagelevel" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row row-modal">
                              <%--  <div class="col-6" id="individual4" runat="server">
                                    <label for="Name">
                                        Work Details
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtWorkDetail" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                </div>--%>
                                
                            </div>
                            <div class="row row-modal">
                                <div class="col-6" id="individual6" runat="server">
                                    <label for="Name">
                                        Work Start Date
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtStartDate" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                </div>
                                <div class="col-6" id="individual11" runat="server">
                                    <label for="Name">
                                        Tentative Work Completition Date
                                    </label>
                                    <asp:TextBox class="form-control" ID="txtCompletitionDate" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="modal-footer" style="margin-top: 10px;">
                            <asp:Button ID="btnSubmit" Text="Next" OnClientClick="return CloseModalAndRedirect()" AutoPostBack="true" runat="server" ValidationGroup="Submit" class="btn btn-primary mr-2"
                                />
                         
                            <%--<a href="#" onclick="closeModal();">Close</a>--%>
                        </div>
                    </div>

                    <!-- Link to open the modal -->
                    <%--   <p style="margin-top:30px !important;"><a href="#ex1" rel="modal:open">Open Modal</a></p>--%>
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

    <%-- <script type="text/javascript">
        function openPopup() {
            debugger;
            var url = 'SupervisorDashboard.aspx';

            // Set the size and position of the popup window
            var width = 800;
            var height = 600;
            var left = (window.innerWidth - width) / 2;
            var top = (window.innerHeight - height) / 2;

            // Open the ASPX page in a popup window
            var popup = window.open(url, 'PopupWindow', 'width=' + width + ',height=' + height + ',left=' + left + ',top=' + top + ',resizable=yes,scrollbars=yes,toolbar=no,menubar=no,location=no,directories=no,status=no');

            // Focus the popup window (if it's not blocked by the browser)
            if (popup) {
                popup.focus();
            }

            // Prevent the LinkButton from performing a postback
            return false;
        }
    </script>--%>

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
    <%--  <script>
  function openPopup() {
    // Check if the popupDiv is already visible
    var popupDiv = document.getElementById("popupDiv");
    if (popupDiv.style.display === "block") {
        // The popup is already visible; close it
        popupDiv.style.display = "none";
    } else {
        // The popup is not visible; show it
        popupDiv.style.display = "block";
    }
}
    </script>--%>
</asp:Content>
