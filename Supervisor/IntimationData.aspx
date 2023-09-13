<%@ Page Title="" Language="C#" MasterPageFile="~/Supervisor/Supervisor.Master" AutoEventWireup="true" CodeBehind="IntimationData.aspx.cs" Inherits="CEIHaryana.Supervisor.IntimationData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://kit.fontawesome.com/57676f1d80.js" crossorigin="anonymous"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <!-- Remember to include jQuery :) -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.0.0/jquery.min.js"></script>

    <!-- jQuery Modal -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-modal/0.9.1/jquery.modal.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/jquery-modal/0.9.1/jquery.modal.min.css" />
    <style type="text/css">
        .jquery-modal.blocker.current {
            margin-top: 50px;
            height: 95%;
        }
        .modal{
            max-width:50% !important;
            height:auto !important;
        }
        .row-modal {
    margin-top: 15px;
}
        a.close-modal {
    position: absolute;
    top: 0px !important;
    right: 0px !important;
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
                        <div class="col-4">
                            <div class="form-group row">
                                <label for="search" class="col-sm-3 col-form-label" style="margin-top: -6px;">Search:</label>
                                <div class="col-sm-9" style="margin-left: -35px;">
                                    <asp:TextBox ID="txtSearch" runat="server" PlaceHolder="Auto Search" class="form-control" onkeydown="return SearchOnEnter(event);" Font-Size="12px" onkeyup="Search_Gridview(this)"></asp:TextBox><br />
                                </div>
                            </div>
                        </div>
                    </div>
                    <table class="table table-responsive">
                        <asp:GridView class="table-responsive" ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="Id" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblID" runat="server" Text='<%#Eval("Id") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                  <asp:TemplateField>
                                    <HeaderStyle Width="10%" />
                                    <ItemStyle Width="10%" />
                                       <HeaderTemplate>
               IntimationId
         </HeaderTemplate>
                                    <ItemTemplate>
                                      <%--  <a href="#ex1" rel="modal:open">Open Modal</a>--%>
                                    <%--     <asp:LinkButton runat="server" ID="LinkButton4" OnClientClick="return openPopup();" Text="View Details"  CommandName="Select" CommandArgument='<%#Eval("Id") %>' />--%>
 <asp:LinkButton ID="LinkButton4" runat ="server" CommandArgument=' <%#Eval("Id") %> ' CommandName ="Select" ><%#Eval("Id") %></asp:LinkButton> 
                                    </ItemTemplate>
                                </asp:TemplateField>
                               <%-- <asp:BoundField DataField="Id" HeaderText="IntimationId">
                                    <HeaderStyle HorizontalAlign="center" Width="8%" />
                                    <ItemStyle HorizontalAlign="center" Width="8%" />
                                </asp:BoundField>--%>
                                <asp:BoundField DataField="Name" HeaderText="Name">
                                <HeaderStyle HorizontalAlign="Left" Width="15%"/>
                                <ItemStyle HorizontalAlign="Left" Width="15%"/>
                                 </asp:BoundField>
                             <asp:BoundField DataField="ContactNo" HeaderText="Contact No">
                                <HeaderStyle HorizontalAlign="center" Width="12%"/>
                                <ItemStyle HorizontalAlign="center" Width="12%"/>
                            </asp:BoundField>
                             <asp:BoundField DataField="WorkDetails" HeaderText="WorkDetails">
                                <HeaderStyle HorizontalAlign="center" Width="20%"/>
                                <ItemStyle HorizontalAlign="center" Width="20%"/>
                            </asp:BoundField>
                              <asp:BoundField DataField="VoltageLevel" HeaderText="Voltage Level">
                                <HeaderStyle HorizontalAlign="center" Width="12%"/>
                                <ItemStyle HorizontalAlign="center" Width="12%"/>
                            </asp:BoundField>
                            <asp:BoundField DataField="CreatedDate1" HeaderText="Request Date">
                                <HeaderStyle HorizontalAlign="center" Width="12%"/>
                                <ItemStyle HorizontalAlign="center" Width="12%"/>
                            </asp:BoundField>
                             <asp:BoundField DataField="CompletionDate1" HeaderText="Completion Date">
                                <HeaderStyle HorizontalAlign="center" Width="13%"/>
                                <ItemStyle HorizontalAlign="center" Width="13%"/>
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
                    </table>
                    <div id="ex1" class="modal">
                        <div class="modal-header" style="font-size:22px;"><b>Work Intimation Details</b></div>
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
                            <div class="col-6" id="individual9" runat="server">
                                <label for="Name">
                                    Contact No.(Contractor)
                                </label>
                                <asp:TextBox class="form-control" ID="txtPhone" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            </div>
                            <div class="col-6" id="individual10" runat="server">
                                <label for="Name">
                                    Address of Site
                                </label>
                                <asp:TextBox class="form-control" ID="txtAddress" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
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
                            <div class="col-6" id="individual4" runat="server">
                                <label for="Name">
                                    Work Details
                                </label>
                                <asp:TextBox class="form-control" ID="txtWorkDetail" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            </div>
                            <div class="col-6" id="individual5" runat="server">
                                <label for="Name">
                                    Contact Details of Site Owner
                                </label>
                                <asp:TextBox class="form-control" ID="txtSiteContact" onkeydown="return preventEnterSubmit(event)" autocomplete="off" TabIndex="2" runat="server" Style="margin-left: 18px"></asp:TextBox>
                            </div>
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

                        <div class="modal-footer" style="margin-top:10px;">
                            <asp:Button ID="btnSubmit" Text="Generate Test Report" runat="server" ValidationGroup="Submit" class="btn btn-primary mr-2"
    Style="background: linear-gradient(135deg, hsla(318, 44%, 51%, 1) 0%, hsla(347, 94%, 48%, 1) 100%); border-color: #d42766;" />
                        <%--<a href="#" rel="modal:close">Close</a>--%>
                            </div>
                    </div>
                   
                    <!-- Link to open the modal -->
                    <p><a href="#ex1" rel="modal:open">Open Modal</a></p>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
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
