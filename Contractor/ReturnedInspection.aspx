<%@ Page Title="" Language="C#" MasterPageFile="~/Contractor/Contractor.Master" AutoEventWireup="true" CodeBehind="ReturnedInspection.aspx.cs" EnableEventValidation="false" Inherits="CEIHaryana.Contractor.ReturnedInspection" %>

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
        .jquery-modal.blocker.current {
            width: 100%;
            background-color: rgba(0, 0, 0, 0);
        }

        div#modal1 {
            margin-left: 58%;
            top: 50%;
        }

        a.close-modal {
            width: 0px !important;
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
            /display: inline-block;/
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
            width: 32%;
        }

        td.itemstylecss {
            text-align: left;
            padding-left: 12px;
        }

        .ReturnedRowColor {
            background-color: #f9c7c7 !important;
        }

        th {
            width: 1%;
            background:#9292cc;
}
        input#ContentPlaceHolder1_txtRemarksForSupervisor {
    height: 30px;
    padding-left: 10px;
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
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="card" style="box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px; border-radius: 5px !important">
            <div class="card-body">
                <div class="row ">
                    <div class="col-sm-4 col-md-4">
                        <h6 class="card-title fw-semibold mb-4">
                            <asp:Label ID="lblData" runat="server"></asp:Label></h6>
                    </div>
                </div>
                <div class="row" style="margin-bottom: 8px;">
                    <div class="col-md-12">
                        <h7 class="card-title fw-semibold mb-4" style="font-size: 18px !important;">Returned Test Reports</h7>
                    </div>
                </div>
                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">

                    <div style="margin-top: 3%">
                        <asp:GridView ID="GridView1" class="table-responsive table table-hover table-striped" runat="server" Width="100%" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" AutoGenerateColumns="false" BorderWidth="1px" BorderColor="#dbddff">
                            <Columns>
                                <asp:TemplateField ItemStyle-HorizontalAlign="left" ItemStyle-VerticalAlign="Middle">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chkSelectAll" runat="server" Style="text-align: left !important;" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBox1" runat="server" HorizontalAlign="center" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="InspectionId" HeaderText="InspectionId">
                                    <HeaderStyle HorizontalAlign="Left" CssClass="headercolor textalignleft colwidth" />
                                    <ItemStyle HorizontalAlign="center" />
                                </asp:BoundField>                               
                                <asp:TemplateField HeaderText="TestReportId">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkTestReportId" runat="server" Text='<%# Eval("TestReportId") %>' CommandName="ViewTestReport" CommandArgument='<%# Eval("TestReportId") %>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="InstallationType" HeaderText="InstallationType">
                                    <HeaderStyle HorizontalAlign="Center" CssClass="headercolor textalignCenter" />
                                    <ItemStyle HorizontalAlign="Center" CssClass="textalignCenter" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ApplicationStatus" HeaderText="ApplicationStatus">
                                    <HeaderStyle HorizontalAlign="center" CssClass="headercolor textalignCenter" />
                                    <ItemStyle HorizontalAlign="center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ReasonType" HeaderText="Return Based">
                                    <HeaderStyle HorizontalAlign="center" CssClass="headercolor textalignCenter" />
                                    <ItemStyle HorizontalAlign="center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="RemarkForContractor" HeaderText="RemarksForContractor">
                                    <HeaderStyle HorizontalAlign="center" CssClass="headercolor textalignCenter" />
                                    <ItemStyle HorizontalAlign="center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Id" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIntimation" runat="server" Text='<%#Eval("IntimationId") %>'></asp:Label>
                                        <asp:Label ID="LblInstallationType" runat="server" Text='<%#Eval("InstallationType") %>'></asp:Label>
                                        <asp:Label ID="lblTestReportCount" runat="server" Text='<%#Eval("TestReportCount") %>'></asp:Label>      
                                        <asp:Label ID="lblTestReportId" runat="server" Text='<%#Eval("TestReportId") %>'></asp:Label>
                                    </ItemTemplate>
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
                    <!-- Link to open the modal -->
                    <%--   <p style="margin-top:30px !important;"><a href="#ex1" rel="modal:open">Open Modal</a></p>--%>
                   
                            <div class="row" id="AssignSupervisor" runat="server">
                                
                            <div class="col-md-4" runat="server" id="AssignedSupervisor" style="margin-top: 20px;">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                                <label>
                                    Select Assigned Supervisor
                                   <samp style="color: red">* </samp>
                                </label>
                                <asp:DropDownList ID="ddlAssignSupervisor" TabIndex="3" runat="server" AutoPostBack="true" class="form-control  select-form select2" Style="width: 100% !important; height: 30px;">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator21" Text="Required" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlAssignSupervisor" runat="server" InitialValue="-1" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" SetFocusOnError="true" />
                           </ContentTemplate>
                    </asp:UpdatePanel>
                            </div>
                              <div class="col-12" id="Div1" runat="server"  Style="margin-top: 15px">
                                        <label>
                                             Remarks For Supervisor
                                        </label>
                                        <asp:TextBox class="form-control" ID="txtRemarksForSupervisor" onkeydown="return preventEnterSubmit(event)"  autocomplete="off" MaxLength="500" runat="server"></asp:TextBox>
                                    </div>
                      
                                
                    <div class="col-md-4"></div>
                    <div class="col-md-4" style="text-align: center; margin-top:15px;">
                        <asp:Button ID="BtnSubmit" Text="Submit" runat="server"  ValidationGroup="Submit" OnClick="BtnSubmit_Click" OnClientClick="this.disabled=true;this.value='Processing...';" UseSubmitBehavior="false" class="btn btn-primary mr-2" />
                   
                </div>
                                </div>
                            </div>
                       
                </div>
                
                <div class="row" style="margin-bottom: 8px;">
                    <div class="col-md-12">
                        <h7 class="card-title fw-semibold mb-4" style="font-size: 18px !important;">Assigned Supervisor/Contractor</h7>
                    </div>
                </div>
                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">

                    <div style="margin-top: 3%">
                        <asp:GridView ID="GridView2" class="table-responsive table table-hover table-striped" runat="server" Width="100%" OnRowCommand="GridView2_RowCommand" AutoGenerateColumns="false" BorderWidth="1px" BorderColor="#dbddff">
                        <Columns>
                            <asp:BoundField DataField="InspectionId" HeaderText="InspectionId">
                                <HeaderStyle HorizontalAlign="Left" CssClass="headercolor textalignleft colwidth" />
                                <ItemStyle HorizontalAlign="center" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="TestReportId">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkTestReportId" runat="server" Text='<%# Eval("TestReportId") %>' CommandName="ViewTestReport" CommandArgument='<%# Eval("TestReportId") %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Id" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblIntimation" runat="server" Text='<%#Eval("IntimationId") %>'></asp:Label>
                                    <asp:Label ID="LblInstallationType" runat="server" Text='<%#Eval("InstallationType") %>'></asp:Label>
                                    <asp:Label ID="lblOffRemarks" runat="server" Text='<%#Eval("OfficerRemarks") %>'></asp:Label>
                                    <asp:Label ID="lblSORemarks" runat="server" Text='<%#Eval("SiteOwnerRemarks") %>'></asp:Label>
                                    <asp:Label ID="lblContRemarks" runat="server" Text='<%#Eval("ContractorRemarks") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="InstallationType" HeaderText="InstallationType">
                                <HeaderStyle HorizontalAlign="Center" CssClass="headercolor textalignCenter" />
                                <ItemStyle HorizontalAlign="Center" CssClass="textalignCenter" />
                            </asp:BoundField>
                            <asp:BoundField DataField="AssignTo" HeaderText="AssignTo">
                                <HeaderStyle HorizontalAlign="center" CssClass="headercolor textalignCenter" />
                                <ItemStyle HorizontalAlign="center" />
                            </asp:BoundField>
                            <%--  <asp:BoundField DataField="SiteOwnerRemarks" HeaderText="Siteowner Remarks">
                                <HeaderStyle HorizontalAlign="center" CssClass="headercolor textalignCenter" />
                                <ItemStyle HorizontalAlign="center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="OfficerRemarks" HeaderText="Officer Remarks">
                                <HeaderStyle HorizontalAlign="center" CssClass="headercolor textalignCenter" />
                                <ItemStyle HorizontalAlign="center" />
                            </asp:BoundField>--%>
                            <asp:TemplateField HeaderText="Remarks">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkReadMore" runat="server" data-modal="modal1" OnClick="lnkReadMore_Click">Read more</asp:LinkButton>
                                </ItemTemplate>
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
                     <div id="modal1" class="modal">
                    <div class="modal-content">
                        <span class="close" data-modal="modal1">&times;</span>
                        <div class="card-title">
                            Officer Remarks
                               </div>
                        <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 15px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                            <asp:Label ID="lblModalOffRemarks" runat="server"></asp:Label>
                        </div>
                        <div class="card-title">
                            SiteOwner Remarks
                               </div>
                        <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 15px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                            <asp:Label ID="lblModalSORemarks" runat="server"></asp:Label>
                        </div>
                        <div class="card-title">
                            Contractor Remarks
                               </div>
                        <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 15px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                            <asp:Label ID="lblModalContRemarks" runat="server"></asp:Label>
                        </div>
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

     <script type="text/javascript">
         function SelectAllCheckboxes(headerCheckbox) {
             var checkboxes = document.querySelectorAll('[id*=CheckBox1]');
             for (var i = 0; i < checkboxes.length; i++) {
                 checkboxes[i].checked = headerCheckbox.checked;
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

</asp:Content>