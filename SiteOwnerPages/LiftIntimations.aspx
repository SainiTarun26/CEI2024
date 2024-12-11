<%@ Page Title="" Language="C#" MasterPageFile="~/SiteOwnerPages/SiteOwner.Master" AutoEventWireup="true" CodeBehind="LiftIntimations.aspx.cs" Inherits="CEIHaryana.SiteOwnerPages.LiftIntimations" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <script src="https://kit.fontawesome.com/57676f1d80.js" crossorigin="anonymous"></script>
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
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
                        <asp:GridView class="table-responsive table table-striped table-hover" ID="GridView1" AutoPostBack="true" runat="server" Width="100%" AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand"
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
                                <asp:TemplateField HeaderText="Site Id">
                                    <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                                    <ItemTemplate>
                                        <%--  <asp:LinkButton ID="LinkButton4" runat="server" CommandName="Select"><%#Eval("Id") %></asp:LinkButton> --%>
                                        <asp:LinkButton ID="LinkButton4" runat="server" AutoPostBack="true" CommandArgument=' <%#Eval("Id") %> ' CommandName="Select"><%#Eval("Id") %></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="NameOfOwner" HeaderText="Site Owner Name">
                                    <HeaderStyle HorizontalAlign="center" CssClass="GridViewRowHeader headercolor" />
                                    <ItemStyle HorizontalAlign="center" CssClass="GridViewRowItems itemstylecss" />
                                </asp:BoundField>
                                <asp:BoundField DataField="District" HeaderText="District">
                                    <HeaderStyle HorizontalAlign="center" CssClass="GridViewRowHeader headercolor" />
                                    <ItemStyle HorizontalAlign="left" CssClass="GridViewRowItems itemstylecss" />
                                </asp:BoundField>

                                <asp:BoundField DataField="CreatedDate" HeaderText="Request Date">
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
                    </div>
                    

                    <!-- Link to open the modal -->
                    <%--   <p style="margin-top:30px !important;"><a href="#ex1" rel="modal:open">Open Modal</a></p>--%>
                </div>
            </div>
        </div>
    </div>




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
