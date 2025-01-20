<%@ Page Title="" Language="C#" MasterPageFile="~/SiteOwnerPages/SiteOwner.Master" AutoEventWireup="true" CodeBehind="SldHistory.aspx.cs" Inherits="CEIHaryana.SiteOwnerPages.SldHistory" %>
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
        th {
    background: #9292cc;
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
                            <asp:Label ID="lblData" runat="server"></asp:Label>SINGLE LINE DOCUMENT HISTORY</h6>
                    </div>
                    <div class="col-sm-6 col-md-6"></div>
                </div>
                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px;">
                    <div class="row" style="margin-bottom: -30px;">
                        <div class="col-4">
                            <div class="form-group row">
                                <label for="search" class="col-sm-3 col-form-label" style="margin-top: -6px;">Search:</label>
                                <div class="col-sm-9" style="margin-left: -35px;">
                                    <asp:TextBox ID="txtSearch" runat="server" PlaceHolder="Auto Search" class="form-control" onkeydown="return SearchOnEnter(event);" Style="margin-top: 4px;" Font-Size="12px" onkeyup="Search_Gridview(this)"></asp:TextBox><br />
                                </div>
                            </div>
                        </div>
                    </div>
                                  <asp:GridView class="table-responsive table table-hover table-striped" ID="GridView1" runat="server" Width="100%" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound"
                   OnPageIndexChanging="GridView1_PageIndexChanging"
                   AutoGenerateColumns="false" AllowPaging="true" PageSize="10" BorderWidth="1px" BorderColor="#dbddff">
                   <PagerStyle CssClass="pagination-ys" />
                   <Columns>
                       <asp:BoundField DataField="SLD_ID" HeaderText="SLD Id">
                           <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                           <ItemStyle HorizontalAlign="center" Width="15%" />
                       </asp:BoundField>

                       <asp:BoundField DataField="SiteOwnerAddress" HeaderText="Address">
                           <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                           <ItemStyle HorizontalAlign="center" Width="15%" />
                       </asp:BoundField>

                       <%--  <asp:TemplateField HeaderText="Document Name">
    <HeaderStyle Width="5%" CssClass="headercolor" />
    <ItemStyle Width="5%" />
    <ItemTemplate>
        Single Line Diagram
   
    </ItemTemplate>
</asp:TemplateField>--%>

                       <asp:BoundField DataField="Status_type" HeaderText="Application Status">
                           <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                           <ItemStyle HorizontalAlign="center" Width="15%" />
                       </asp:BoundField>


                       <asp:TemplateField HeaderText=" SLD Document" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="4%">
                           <HeaderStyle Width="5%" CssClass="headercolor" />
                           <ItemTemplate>
                               <%-- <asp:LinkButton ID="LnkDocumemtPath" runat="server" CommandArgument='<%# Bind("SLDApproved") %>' CommandName="Select">View document </asp:LinkButton>--%>
                               <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Bind("Path") %>' CommandName="Select1">View document </asp:LinkButton>
                           </ItemTemplate>
                           <ItemStyle HorizontalAlign="Center" Width="2%"></ItemStyle>
                           <HeaderStyle HorizontalAlign="Left" />
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText=" Request Letter" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="4%">
                           <HeaderStyle Width="5%" CssClass="headercolor" />
                           <ItemTemplate>
                               <asp:LinkButton ID="Lnkbtn" runat="server" CommandArgument='<%# Bind("RequestLetter") %>' CommandName="Print">View document </asp:LinkButton>

                           </ItemTemplate>
                           <ItemStyle HorizontalAlign="Center" Width="2%"></ItemStyle>
                           <HeaderStyle HorizontalAlign="Left" />
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText=" SLD Approved" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="4%">
                           <HeaderStyle Width="5%" CssClass="headercolor" />
                           <ItemTemplate>
                               <asp:LinkButton ID="LnkDocumemtPath" runat="server" CommandArgument='<%# Bind("SLDApproved") %>' CommandName="Select">View document </asp:LinkButton>

                           </ItemTemplate>
                           <ItemStyle HorizontalAlign="Center" Width="2%"></ItemStyle>
                           <HeaderStyle HorizontalAlign="Left" />
                       </asp:TemplateField>
                       <asp:BoundField DataField="SubmittedDate" HeaderText="Submitted Date">
                           <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                           <ItemStyle HorizontalAlign="center" Width="15%" />
                       </asp:BoundField>
                       <asp:BoundField DataField="AcceptedOrReturnDate" HeaderText="Accepted/Returned Date">
                           <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                           <ItemStyle HorizontalAlign="center" Width="15%" />
                       </asp:BoundField>
                       <asp:BoundField DataField="Rejection" HeaderText="ReturnOrRejection Reason">
                           <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                           <ItemStyle HorizontalAlign="center" Width="15%" />
                       </asp:BoundField>
                       <asp:BoundField DataField="ApprovedOrRejectedDate" HeaderText="Approved/Rejected Date">
                           <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                           <ItemStyle HorizontalAlign="center" Width="15%" />
                       </asp:BoundField>
                       <asp:BoundField DataField="Remarks" HeaderText="Remarks">
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
    <script type="text/javascript">
        document.addEventListener("DOMContentLoaded", function () {
            const elements = document.querySelectorAll('.break-text-10');

            elements.forEach(function (element) {
                let text = element.innerText;
                let formattedText = '';
                let currentIndex = 0;

                while (currentIndex < text.length) {
                    // Take a chunk of up to 20 characters
                    let chunk = text.slice(currentIndex, currentIndex + 35);

                    if (chunk.length < 35) {
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
                        currentIndex += 35;
                    }
                }

                element.innerHTML = formattedText.trim(); // Remove any trailing <br>
            });
        });
</script>
</asp:Content>
