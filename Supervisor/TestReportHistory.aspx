﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Supervisor/Supervisor.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="TestReportHistory.aspx.cs" Inherits="CEIHaryana.Supervisor.TestReportHistory" %>
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

     <!-- jQuery Modal -->
 <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-modal/0.9.1/jquery.modal.min.js"></script>
 <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/jquery-modal/0.9.1/jquery.modal.min.css" />

    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <style>
        .col-md-4 {
            margin-bottom: 8px;
        }

          a.close-modal {
     width: 0px !important;
 }
        .jquery-modal.blocker.current {
            width: 100%;
            background-color: rgba(0, 0, 0, 0);
        }

        div#modal1 {
            margin-left: 58%;
            top: 50%;
        }

        .modal {
            max-width: 85%; /* Adjust the maximum width as needed */
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

        .card-body {
            margin-bottom: 11px !important;
            margin-top: 5px !important;
        }

        .modal {
            display: none; /* Hidden by default */
            position: fixed; /* Stay in place */
            z-index: 1; /* Sit on top */
            left: 0;
            top: 0;
            width: 100%;
            height: 100%;
            overflow: auto; /* Enable scroll if needed */
            background-color: rgb(0,0,0); /* Fallback color */
            background-color: rgba(0,0,0,0.4); /* Black w/ opacity */
        }

        .modal-content {
            background-color: #fefefe;
            margin: 5% auto; /* 15% from the top and centered */
            padding: 20px;
            border: 1px solid #888;
            width: 100%; /* Could be more or less, depending on screen size */
        }

        .close {
            color: #aaa;
            float: right;
            font-size: 28px;
            font-weight: bold;
            margin-left: 98%;
        }

            .close:hover,
            .close:focus {
                color: black;
                text-decoration: none;
                cursor: pointer;
            }

        .card .card-title {
            font-size: 1.4rem !important;
            margin-bottom: 0px !important;
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
        .ReturnedRowColor {
            background-color: #f9c7c7 !important;
        }
        .card-body {
     margin-bottom: 11px !important;
     margin-top: 5px !important;
 }

 .modal {
     display: none; /* Hidden by default */
     position: fixed; /* Stay in place */
     z-index: 1; /* Sit on top */
     left: 0;
     top: 0;
     width: 100%;
     height: 100%;
     overflow: auto; /* Enable scroll if needed */
     background-color: rgb(0,0,0); /* Fallback color */
     background-color: rgba(0,0,0,0.4); /* Black w/ opacity */
 }

 .modal-content {
     background-color: #fefefe;
     margin: 5% auto; /* 15% from the top and centered */
     padding: 20px;
     border: 1px solid #888;
     width: 100%; /* Could be more or less, depending on screen size */
 }

 .close {
     color: #aaa;
     float: right;
     font-size: 28px;
     font-weight: bold;
     margin-left: 98%;
 }

     .close:hover,
     .close:focus {
         color: black;
         text-decoration: none;
         cursor: pointer;
     }

        .card .card-title {
            font-size: 1.4rem !important;
            margin-bottom: 0px !important;
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
                    <div class="col-sm-6 col-md-6"></div>
                </div>
                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                    <div class="row" style="margin-bottom: -30px;">
                        <div class="col-md-4">
                            <div class="form-group row">
                                <label for="search" class="col-md-3 col-form-label" style="margin-top: -6px;">Search:</label>
                                <div class="col-md-9" style="margin-left: -35px;">
                                    <asp:TextBox ID="txtSearch" runat="server" onkeydown="return SearchOnEnter(event);" onkeyup="Search_Gridview(this)"  PlaceHolder="Auto Search" class="form-control" Font-Size="12px"></asp:TextBox><br />
                                    <asp:TextBox ID="txtapproval" runat="server" Visible="false" class="form-control" Font-Size="12px"></asp:TextBox><br />

                                </div>
                            </div>
                        </div>
                    </div>
                    <asp:GridView class="table-responsive table table-striped table-hover" OnRowDataBound="GridView1_RowDataBound" ID="GridView1" runat="server" Width="100%" AllowPaging="true" PageSize="50" OnPageIndexChanging="GridView1_PageIndexChanging"
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
                            <%--   <asp:TemplateField HeaderText="Id" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblID" runat="server" Text='<%#Eval("ID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Id" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblTestReportId" runat="server" Text='<%#Eval("Intimations") %>'></asp:Label>
                                     <asp:Label ID="lblTypeOf" runat="server" Text='<%#Eval("Typs") %>'></asp:Label>
                                    <asp:Label ID="lblIntimations" runat="server" Text='<%#Eval("IntimationId") %>'></asp:Label>
                                    <asp:Label ID="lblVoltage" runat="server" Text='<%#Eval("Voltagelevel") %>'></asp:Label>
                                    <asp:Label ID="lblInstallationLine" runat="server" Text='<%#Eval("NoOfInstallations") %>'></asp:Label>
                                    <%--<asp:Label ID="lblIHID" runat="server" Text='<%#Eval("IHID") %>'></asp:Label>--%>
                                    <asp:Label ID="lblApplicationForTestReport" runat="server" Text='<%#Eval("Apllication") %>'></asp:Label>

                                     <asp:Label ID="lblOffRemarks" runat="server" Text='<%#Eval("OfficerRemarks") %>'></asp:Label>
                                    <asp:Label ID="lblSORemarks" runat="server" Text='<%#Eval("SiteOwnerRemarks") %>'></asp:Label>
                                    <asp:Label ID="lblContRemarks" runat="server" Text='<%#Eval("ContractorRemarksForSuprvisor") %>'></asp:Label>

                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderStyle Width="24%" CssClass="headercolor" />
                                <ItemStyle Width="24%" />
                                <HeaderTemplate>
                                    TestReport Id
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton4" runat="server" CommandArgument=' <%#Eval("Intimations") %> ' CommandName="Select"><%#Eval("Intimations") %></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField DataField="IntimationId" HeaderText="Intimation Id">
                                <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Typs" HeaderText="Installation Type">
                                <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NoOfInstallations" HeaderText="Installation No.">
                                <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Name" HeaderText="Owner Name">
                                <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" CssClass="break-text-10" />
                            </asp:BoundField>
                            <asp:BoundField DataField="District" HeaderText="District">
                                <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Voltagelevel" HeaderText="Voltage">
                                <HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="Left" Width="15%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Approval" HeaderText="Status">
                                <HeaderStyle HorizontalAlign="center" Width="12%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="center" Width="12%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Reporttype" HeaderText="ReportType">
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
                <div id="modal1" class="modal">
      <div class="modal-content">
          <span class="close" data-modal="modal1">&times;</span>
          <div id="OffRemarks" visible="false" runat="server">
              <div class="card-title">
                  Officer Remarks
              </div>
              <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 15px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                  <asp:Label ID="lblModalOffRemarks" runat="server"></asp:Label>
              </div>
          </div>
          <div id="SORemarks" visible="false" runat="server">
              <div class="card-title">
                  SiteOwner Remarks
              </div>
              <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 15px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                  <asp:Label ID="lblModalSORemarks" runat="server"></asp:Label>
              </div>
          </div>
          <div id="ContRemarks" visible="false" runat="server">
              <div class="card-title">
                  Contractor Remarks
              </div>
              <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 15px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                  <asp:Label ID="lblModalContRemarks" runat="server"></asp:Label>
              </div>
          </div>
      </div>

  </div>
            </div>
        </div>

    </div>
    <footer class="footer">
    </footer>
    <script>
        new DataTable('#example');
    </script>
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
     <script>
         // Get all close elements
         const closeElements = document.querySelectorAll('.close');
         // Add click event listener to each close element
         closeElements.forEach(close => {
             close.addEventListener('click', () => {
                 const modalId = close.getAttribute('data-modal');
                 const modal = document.getElementById(modalId);
                 if (modal) {
                     modal.style.display = 'none';
                 }
             });
         });
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
                    let chunk = text.slice(currentIndex, currentIndex + 30);

                    if (chunk.length < 30) {
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
                        currentIndex += 30;
                    }
                }

                element.innerHTML = formattedText.trim(); // Remove any trailing <br>
            });
        });
</script>
</asp:Content>
