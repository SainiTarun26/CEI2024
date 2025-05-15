<%@ Page Title="" Language="C#" MasterPageFile="~/Officers/Officers.Master" AutoEventWireup="true" CodeBehind="TotalRequestInspectionForOfficer_SearchWithCafId.aspx.cs" Inherits="CEIHaryana.Officers.TotalRequestInspectionForOfficer_SearchWithCafId" %>

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
        .headercolor {
            background-color: #9292cc;
        }

        .col-4 {
            margin-bottom: 8px;
        }

        .form-control {
            box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
            margin-left: 0px !important;
            height: 30px;
            padding-top: 1px;
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
        th.textjustify {
    text-align: justify;
}
        td.owner-name {
    text-align: justify;
}
        select#ContentPlaceHolder1_ddldivision {
    padding: 0px 0px 3px 5px;
}
        .form-group label{
            font-size:16px !important;
        }
        th {
    background: #9292cc;
}
                     input#ContentPlaceHolder1_RadioButtonList1_0 {
    margin-right: 7px;
}
input#ContentPlaceHolder1_RadioButtonList1_1 {
    margin-left: 10px;
    margin-right: 7px;
}
input#ContentPlaceHolder1_RadioButtonList2_1 {
    margin-left: 10px;
    margin-right: 7px;
}
input#ContentPlaceHolder1_RadioButtonList2_0 {
    margin-right: 7px;
}
body{
    zoom:90%;
}
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <div class="card" style="box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px; border-radius: 5px !important">
            <div class="card-body">
                <div class="row">
                    <div class="col-sm-4 col-md-4">
                        <h6 class="card-title fw-semibold mb-4">
                            <asp:Label ID="lblData" runat="server"></asp:Label></h6>
                    </div>
                    <div class="col-sm-6 col-md-6"></div>

                </div>
                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                                          <div class="row align-items-center" style="margin-bottom: 15px;">

    <!-- Search Box -->
    <div class="col-md-3">
        <div class="form-group d-flex align-items-center mb-0">
            <label for="search" class="mr-2 mb-0" style="white-space: nowrap;">Search:</label>
            <asp:TextBox ID="txtSearch" runat="server"
                         PlaceHolder="Search Minimum 4 characters Also (Caf Id)"
                         class="form-control"
                         Font-Size="15px"
                         AutoPostBack="false"
                         oninput="triggerTextChanged()"
                         OnTextChanged="txtSearch_TextChanged"
                         style="width: 100%; min-width: 180px;" />
        </div>
    </div>

    <!-- Radio Button List 1 -->
    <div class="col-md-4 text-center" style="padding-top:15px;">
        <asp:RadioButtonList ID="RadioButtonList1"
                             AutoPostBack="true"
                             runat="server"
                             RepeatDirection="Horizontal"
                             OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged"
                             CssClass="d-inline-block">
            <asp:ListItem Text="Lift/Escalator" Value="1" />
            <asp:ListItem Text="Line/Substration/Generating Set" Value="0" />
        </asp:RadioButtonList>
    </div>

    <!-- Radio Button List 2 -->
    <div class="col-md-2" style="padding-top:15px;">
        <asp:RadioButtonList ID="RadioButtonList2"
                             AutoPostBack="true"
                             runat="server"
                             RepeatDirection="Horizontal"
                             CssClass="d-inline-block" OnSelectedIndexChanged="RadioButtonList2_SelectedIndexChanged">
            <asp:ListItem Text="Industry" Value="Industry" Selected="True" />
            <asp:ListItem Text="Non-Industry" Value="NonIndustry" />
        </asp:RadioButtonList>
    </div>

    <!-- Division Dropdown -->
    <div class="col-md-3">
        <div class="form-group d-flex align-items-center mb-0">
            <label for="ddldivision" class="mr-2 mb-0" style="white-space: nowrap;">Division:</label>
            <asp:DropDownList ID="ddldivision"
                              runat="server"
                              AutoPostBack="true"
                              OnSelectedIndexChanged="ddldivision_SelectedIndexChanged"
                              class="form-control select2"
                              style="width: 100%; min-width: 160px; height: 30px;" />
        </div>
    </div>

</div>
                    <asp:GridView class="table-responsive table table-striped table-hover" ID="GridView1" runat="server" Width="100%"
                        AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand" AllowPaging="true" PageSize="100" OnPageIndexChanging="GridView1_PageIndexChanging" BorderWidth="1px" BorderColor="#dbddff">
                        <Columns>

                            <asp:TemplateField HeaderText="Id" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblID" runat="server" Text='<%#Eval("InspectionId") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%-- <asp:TemplateField HeaderText="Id" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIntimationId" runat="server" Text='<%#Eval("IntimationId") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField> --%>
                            <asp:TemplateField HeaderText="Id" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblApproval" runat="server" Text='<%#Eval("ApplicationStatus") %>'></asp:Label>
                                    <asp:Label ID="lblInstallationFor" runat="server" Text='<%#Eval("Installationfor") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SNo">
                                <HeaderStyle Width="5%" CssClass="headercolor" />
                                <ItemStyle Width="5%" />
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField>
                                    <HeaderStyle Width="35%" CssClass="headercolor"/>
                                    <ItemStyle Width="35%" />
                                    <HeaderTemplate>
                                      InspectionId  <br/>  (CAF Id)
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton4" runat="server" CommandArgument=' <%#Eval("InspectionId") %> ' CommandName="Select"><%#Eval("InspectionId") %>   <%# Eval("cafpin") != DBNull.Value && Eval("cafpin") != null ? " (" + Eval("cafpin") + ")" : "" %></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>

                            <%--<asp:BoundField DataField="InspectionId" HeaderText="Inspection Id">
                                <HeaderStyle HorizontalAlign="center" Width="28%" CssClass="headercolor" />

                                <ItemStyle HorizontalAlign="center" Width="28%" />
                            </asp:BoundField>--%>

                            <asp:TemplateField HeaderText="Owner Name">
    <HeaderStyle Width="35%" CssClass="headercolor textjustify" />
    <ItemStyle Width="35%" CssClass="owner-name" />
    <ItemTemplate>
        <asp:Label ID="lblOwnerName" runat="server" Text='<%# Eval("OwnerName") %>' CssClass="break-text"></asp:Label>
    </ItemTemplate>
</asp:TemplateField>
                           <asp:TemplateField HeaderText="Contractor Name">
    <HeaderStyle Width="32%" CssClass="headercolor textjustify" />
    <ItemStyle Width="35%" CssClass="owner-name" />
    <ItemTemplate>
        <asp:Label ID="lblContractorName" runat="server" Text='<%# Eval("ContractorName") %>' CssClass="break-text"></asp:Label>
    </ItemTemplate>
</asp:TemplateField>
                            <%--<asp:TemplateField HeaderText="Applicant Type">
    <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
    <ItemStyle HorizontalAlign="center" Width="15%" />
    <ItemTemplate>
        <asp:Label ID="lblApplicantType" runat="server" Text='<%# Eval("ApplicantFor") %>' CssClass="break-text-10"></asp:Label>
    </ItemTemplate>
</asp:TemplateField>--%>
                           <%-- <asp:BoundField DataField="Installationfor" HeaderText="Intallation Type">
                                <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="center" Width="15%" />
                            </asp:BoundField>--%>
                            <asp:BoundField DataField="RequestDate" HeaderText="Request Date">
                                <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />

                                <ItemStyle HorizontalAlign="center" Width="15%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="RequestStatus" HeaderText="Status">
                                <HeaderStyle HorizontalAlign="center" Width="15%" CssClass="headercolor" />
                                <ItemStyle HorizontalAlign="center" Width="15%" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="">
    <HeaderTemplate>
        <div class="headercolor" style="text-align:center; width:100%;">Inspection<br />Type</div>
    </HeaderTemplate>
    <ItemTemplate>
        <%# Eval("TypeOfInspection") %>
    </ItemTemplate>
    <HeaderStyle HorizontalAlign="center" Width="15%" />
    <ItemStyle HorizontalAlign="center" Width="15%" />
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
    <script type="text/javascript">
        document.addEventListener("DOMContentLoaded", function () {
            const elements = document.querySelectorAll('.break-text');

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
    <script type="text/javascript">
        document.addEventListener("DOMContentLoaded", function () {
            const elements = document.querySelectorAll('.break-text-10');

            elements.forEach(function (element) {
                let text = element.innerText;
                let formattedText = '';
                let currentIndex = 0;

                while (currentIndex < text.length) {
                    // Get a 30-character substring
                    let chunk = text.slice(currentIndex, currentIndex + 25);

                    // Find the nearest whitespace in this chunk
                    let breakIndex = chunk.lastIndexOf(" ");

                    // If a whitespace is found, break at that whitespace
                    if (breakIndex !== -1) {
                        formattedText += chunk.slice(0, breakIndex) + '<br>';
                        currentIndex += breakIndex + 1; // Move past the whitespace
                    } else {
                        // If no whitespace is found, break at the 30-character limit
                        formattedText += chunk + '<br>';
                        currentIndex += 25;
                    }
                }

                // Apply the formatted text with <br> to the element's innerHTML
                element.innerHTML = formattedText.trim(); // Remove any trailing <br>
            });
        });
    </script>

    <script type="text/javascript">
        function triggerTextChanged() {
            var textBox = document.getElementById('<%= txtSearch.ClientID %>');
        if (textBox.value.length >= 4) {
            __doPostBack('<%= txtSearch.UniqueID %>', '');
        }
            if (textBox.value.length == 0) {
                __doPostBack('<%= txtSearch.UniqueID %>', '');
            }
        }
    </script>


</asp:Content>

