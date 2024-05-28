<%@ Page Title="" Language="C#" MasterPageFile="~/Officers/Officers.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="ConsolidatedReport.aspx.cs" Inherits="CEIHaryana.Officers.ConsolidatedReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="shortcut icon" type="image/png" href="/css2/style.min.css" />
    <link rel="stylesheet" href="/css2/style.css" />
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <!------ Include the above in your HEAD tag ---------->
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/css/select2.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/js/select2.min.js"></script>

    <link href="ScriptCalendar/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="ScriptCalender/jquery-1.11.0.min.js"></script>
    <script type="text/javascript" src="ScriptCalender/jquery-ui.min.js"></script>


    <%--<script type="text/javascript">
     $(document).ready(function () {
         $("#<%=txtDateofIntialissue.ClientID%>").datepicker({
             dateFormat: "dd/mm/yy",
             changeMonth: true,
             changeYear: true,
             minDate: -7,
             maxDate: +7
         });
         $("#<%=txtDateofIntialissue.ClientID%>").keydown(function () {
             //code to not allow any changes to be made to input field
             return false;
         });

         Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
         function EndRequestHandler(sender, args) {
             $("#<%=txtDateofIntialissue.ClientID%>").datepicker({
                 dateFormat: "dd/mm/yy",
                 changeMonth: true,
                 changeYear: true,
                 minDate: -7,
                 maxDate: +7
             });
             $("#<%=txtDateofIntialissue.ClientID%>").keydown(function () {
                 //code to not allow any changes to be made to input field
                 return false;
             });
         }
     });
     }
 </script>--%>
    <%--<script type="text/javascript">
     function isNumberKey(evt) {
         var charCode = (evt.which) ? evt.which : event.keyCode
         if (charCode > 31 && (charCode < 48 || charCode > 57)) {
             return false;
         }
         return true;
     }

     //Allow Only Aplhabet, Delete and Backspace

     function isAlpha(keyCode) {

         return ((keyCode >= 65 && keyCode <= 90) || keyCode == 8 || keyCode == 32 || keyCode == 190)

     }

     function alphabetKey(e) {
         var allow = ' ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz \b'
         var k;
         k = document.all ? parseInt(e.keyCode) : parseInt(e.which);
         return (allow.indexOf(String.fromCharCode(k)) != -1);
     }
 </script>--%>
    <%--<script type="text/javascript">
      function alertWithRedirectdata() {
          if (confirm('Data Added Successfully')) {
              window.location.href = "/Admin/AddContractorDetails.aspx";
          } else {
          }
      }
  </script>--%>
    <%--     <script>
     
      function printDiv(printableDiv) {
          var printContents = document.getElementById(printableDiv).innerHTML;
          var originalContents = document.body.innerHTML;

          document.body.innerHTML = printContents;

          window.print();

          document.body.innerHTML = originalContents;
      }
  </script>--%>

    <style>
        .example {
            -ms-overflow-style: none; /* IE and Edge */
            scrollbar-width: none; /* Firefox */
        }

        .col-md-4 {
            top: 0px;
            left: 0px;
        }

        .form-control {
            box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
            margin-left: 0px !important;
            height: 30px;
            font-size: 12px !important;
        }

        select.form-control {
            box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
            margin-left: 0px !important;
            height: 30px !important;
            font-size: 12px !important;
        }

        label {
            font-size: 13px;
        }

        .form-control:focus {
            border: 2px solid #80bdff;
            font-size: 12px !important;
        }

        select.form-control:focus {
            border: 2px solid #80bdff;
            font-size: 12px !important;
        }

        .select2-container .select2-selection--single .form-control {
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
            font-size: 1rem !important;
        }

        .btn-primary:hover {
            box-shadow: rgba(50, 50, 93, 0.25) 0px 30px 60px -12px inset, rgba(0, 0, 0, 0.3) 0px 18px 36px -18px inset;
        }

        button.btn.btn-primary.mr-2 {
            padding: 10px 25px 10px 25px;
            font-size: 18px;
        }

        span.select2-dropdown.select2-dropdown--below {
            margin-top: 50px !important;
        }

        table.table.table-responsive.table-striped.table-hover {
            margin-bottom: 0px;
        }

        th#request {
            color: blue;
            text-decoration: underline;
        }
    </style>
     <script>
         function printDiv(printableDiv) {
             var printContents = document.getElementById(printableDiv).innerHTML;
             var originalContents = document.body.innerHTML;

             // Print as HTML
             document.body.innerHTML = printContents;
             window.print();

             // Restore original content
             document.body.innerHTML = originalContents;
         }

     </script>
    <%--<script type="text/javascript">
        $(document).ready(function () {
            // Attach the change event to the dropdown
            $("#ddlInstallatiosType").change(function () {
                // Call the JavaScript function to filter the GridView
                filterGridView();
            });
        });

        function filterGridView() {
            // Get the selected value from the dropdown
            var filterValue = $("#ddlInstallatiosType").val().toLowerCase();

            // Loop through each row in the GridView
            $("#<%= GridView1.ClientID %> tr:gt(0)").each(function () {
                // Get the text content of the cell in the specified column
                var cellText = $(this).find("td:eq(1)").text().toLowerCase(); // Assuming the filter is based on the second column

                // Show or hide the row based on whether it matches the selected value
                if (filterValue === "all" || cellText.indexOf(filterValue) !== -1) {
                    $(this).show();
                } else {
                    $(this).hide();
                }
            });
        }
    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="content-wrapper">
        <div class="card" style="box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px; border-radius: 5px !important">
            <div class="card-body">
                <div class="row">
                    <div class="col-md-4"></div>
                    <div class="col-md-4" style="text-align: center; box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding-top: 8px; padding-bottom: 8px; border-radius: 10px; top: 0px; left: 0px;">
                        <h6 class="card-title fw-semibold mb-4" style="font-weight: 700; margin-bottom: 0px !important;">CONSOLIDATED REPORT</h6>
                    </div>
                    <br />
                    <div class="col-md-4"></div>
                </div>
                <%-- <h7 class="card-title fw-semibold mb-4">Personal Details</h7>--%>
                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 35px;">
                    <div class="row" style="margin-top: 15px;">
                        <div class="col-md-4">
                            <label>
                                Type of Installation:        
                            </label>
                            <asp:DropDownList Style="width: 100% !important;" class="form-control select-form select2" ID="ddlInstallatiosType" TabIndex="8" runat="server" AutoPostBack="true">
                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                <asp:ListItem Value="1" Text="Line"></asp:ListItem>
                                <asp:ListItem Value="2" Text="Substation Transformer"></asp:ListItem>
                                <asp:ListItem Value="3" Text="Generating Station"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-4">
                            <label>
                                Division:
                            </label>
                            <asp:DropDownList Style="width: 100% !important;" class="form-control select-form select2" ID="DdlDivision" TabIndex="8" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DdlDivision_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-4">
                            <label>
                                District:
                            </label>
                            <asp:DropDownList Style="width: 100% !important;" class="form-control select-form select2" ID="DdlDistrict" TabIndex="8" runat="server" AutoPostBack="true">
                               <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row" style="margin-top: 15px;">
                        <div class="col-md-4">
                            <label for="DateofRenewal">
                                Application Submission Date From:
                            </label>
                            <asp:TextBox class="form-control" autocomplete="off" onkeydown="return preventEnterSubmit(event)" ID="txtSubmitted" min='0000-01-01' max='9999-01-01' Type="Date" TabIndex="19" runat="server" Style="margin-left: 18px"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <label for="DateofRenewal">
                                Application Submission Date To:
                            </label>
                            <asp:TextBox class="form-control" autocomplete="off" onkeydown="return preventEnterSubmit(event)" ID="txtEndDate" min='0000-01-01' max='9999-01-01' Type="Date" TabIndex="19" runat="server" Style="margin-left: 18px"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <label for="LicenceNew">
                                Owner Application No.:
                            </label>
                            <asp:TextBox class="form-control" MaxLength="50" onkeydown="return preventEnterSubmit(event)" ID="txtownerApplication" autocomplete="off" runat="server" Style="margin-left: 18px" TabIndex="15"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row" style="margin-top: 15px;">
                        <div class="col-md-4">
                            <label for="LicenceNew">
                                GST No.:
                            </label>
                            <asp:TextBox class="form-control" MaxLength="50" onkeydown="return preventEnterSubmit(event)" ID="txtGST" autocomplete="off" runat="server" Style="margin-left: 18px" TabIndex="15"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <label>
                                Status:        
                            </label>
                            <asp:DropDownList Style="width: 100% !important;" class="form-control select-form select2" ID="ddlStatus" TabIndex="8" runat="server" AutoPostBack="true">
                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                <asp:ListItem Value="1" Text="Initiated"></asp:ListItem>
                                <asp:ListItem Value="2" Text="Accepted"></asp:ListItem>
                                <asp:ListItem Value="3" Text="Rejected"></asp:ListItem>
                                <asp:ListItem Value="4" Text="Pending"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-4">
                            <label>
                                Pending With:
                            </label>
                            <asp:DropDownList Style="width: 100% !important;" class="form-control select-form select2" ID="DdlStaffPendingWith" TabIndex="8" runat="server" AutoPostBack="true">
                             <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="row" style="margin-top: 15px;">
                    <div class="col-md-4"></div>
                    <div class="col-md-4" style="text-align: center;">
                        <asp:Button ID="btnSubmit" Text="Show" runat="server" ValidationGroup="Submit" class="btn btn-primary mr-2" OnClick="btnSubmit_Click" />
                        <asp:Button ID="BtnExport"  Text="Export" OnClientClick="printDiv('printableDiv');" runat="server" class="btn btn-primary mr-2"
                            Style="padding-left: 17px; padding-right: 17px;" /> 
                        <asp:Button ID="BtnReset"  Text="Reset" runat="server" class="btn btn-primary mr-2"
                            Style="padding-left: 17px; padding-right: 17px;" OnClick="BtnReset_Click" />
                        <%--                              <asp:Button ID="btnPrint" Text="Print" runat="server" class="btn btn-primary mr-2" 
                Style="background: linear-gradient(135deg, hsla(318, 44%, 51%, 1) 0%, hsla(347, 94%, 48%, 1) 100%); border-color: #d42766;" OnClientClick="printDiv('printableDiv');"/>--%>
                    </div>
                    <div class="col-md-4">
                        <asp:HiddenField ID="hdnId" runat="server" />
                    </div>
                </div>
                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 35px;">
                    <div class="card" id="printableDiv">
                        <asp:GridView ID="GridView1" class="table-responsive table table-striped table-hover" runat="server"
                            Width="100%" AllowPaging="true" PageSize="20" OnPageIndexChanging="GridView3_PageIndexChanging" AutoGenerateColumns="false" BorderWidth="1px" BorderColor="#dbddff" OnRowCommand="GridView1_RowCommand">

                            <PagerStyle CssClass="pagination-ys" />
                            <Columns>
                                <asp:TemplateField HeaderText="Id" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblID" runat="server" Text='<%#Eval("Id") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                             <asp:TemplateField HeaderText="Id" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblTestRportId" runat="server" Text='<%#Eval("TestRportId") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Id" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblApproval" runat="server" Text='<%#Eval("ApplicationStatus") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>  
                            <asp:TemplateField HeaderText="Id" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblInstallationType" runat="server" Text='<%#Eval("InstallationType") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderStyle Width="10%" CssClass="headercolor" />
                                    <ItemStyle Width="10%" />
                                    <HeaderTemplate>
                                        Application For Inspection
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument=' <%#Eval("ApplicationForInspection") %> ' CommandName="Select"><%#Eval("ApplicationForInspection") %></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Createddate1" HeaderText="Application Date">
                                    <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                    <ItemStyle HorizontalAlign="center" Width="15%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Installationfor" HeaderText="Installation Applied For">
                                    <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                    <ItemStyle HorizontalAlign="center" Width="15%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Id" HeaderText="Owner Application Number">
                                    <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                    <ItemStyle HorizontalAlign="center" Width="15%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="AcceptedOrRejected" HeaderText="Status">
                                    <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                    <ItemStyle HorizontalAlign="center" Width="15%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="AssignedStaff" HeaderText="Pending With">
                                    <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                    <ItemStyle HorizontalAlign="center" Width="15%" />
                                </asp:BoundField>

                            </Columns>
                        </asp:GridView>
                       <div class="row" style="margin-top: 10px; margin-bottom: 10px;">
    <div class="col-md-4"></div>
    <div class="col-md-4" style="text-align:center;">
<asp:LinkButton ID="LinkButton2" runat="server" CssClass="btn btn-primary" OnClick="LinkButton2_Click">Download in Excel</asp:LinkButton>
</div>
    <div class="col-md-4"></div>
    </div>
                        <%-- <table class="table table-responsive table-striped table-hover table-bordered example">
                            <thead style="background: #604db8; color: white;">
                                <tr>
                                    <th scope="col" style="width: 1%;">All Application request</th>
                                    <th scope="col" style="text-align: center;">Application Date</th>
                                    <th scope="col">Installation applied for</th>
                                    <th scope="col" style="text-align: center;">Owner application Number </th>
                                    <th scope="col">Application Status</th>
                                    <th scope="col">Pending with</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <th scope="row" id="request">Rewari-Line-Substation-GeneratingSet</th>
                                    <td style="text-align: center;">28-06-2001</td>
                                    <td>Line</td>
                                    <td style="text-align: center;">100001</td>
                                    <td>Pending</td>
                                    <td>JE_GURUGRAM-I</td>
                                </tr>
                            </tbody>
                        </table>--%>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
