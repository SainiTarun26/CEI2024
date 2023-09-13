<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin_Master.Master" AutoEventWireup="true" CodeBehind="RegistrationDetailsAll.aspx.cs" Inherits="CEIHaryana.Admin.RegistrationDetailsAll1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="shortcut icon" type="image/png" href="/css2/style.min.css" />
    <link rel="stylesheet" href="/css2/style.css" />
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/css/select2.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/js/select2.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css" />
    <link href="ScriptCalendar/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="ScriptCalender/jquery-1.11.0.min.js"></script>
    <script type="text/javascript" src="ScriptCalender/jquery-ui.min.js"></script>
    <script type="text/javascript">
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
    </script>

    <style>
        .col-4 {
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
            font-size: 1rem !important;
        }

        .btn-primary:hover {
            box-shadow: rgba(50, 50, 93, 0.25) 0px 30px 60px -12px inset, rgba(0, 0, 0, 0.3) 0px 18px 36px -18px inset;
        }

        button.btn.btn-primary.mr-2 {
            padding: 10px 25px 10px 25px;
            font-size: 18px;
        }

        td {
            padding: 15px 10px 0px 7px !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <%--  <div class="card-header" style="background: linear-gradient(341deg, rgba(0,255,103,1) 0%, rgba(70,85,252,1) 100%); color: white; margin-bottom: 15px; border-radius: 5px;">
            <h4 style="font-weight: 600; text-align: center;">WIREMEN DETAILS</h4>
        </div>--%>
        <div class="card" style="box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px; border-radius: 5px !important">
            <div class="card-body">
                <h7 class="card-title fw-semibold mb-4">Supervisor Registrations</h7>
                <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
                   <asp:GridView ID="GridView1" runat="server" Width="100%"   AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand" >
                        <Columns>                                            
                                            <asp:TemplateField HeaderText="Id" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRowID" runat="server" Text='<%#Eval("RegistrationId") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="RegistrationId"  HeaderText="User ID">
                                            <HeaderStyle HorizontalAlign="left" Width="8%" />
                                            <ItemStyle HorizontalAlign="center" Width="8%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Name" HeaderText="Name">
                                            <HeaderStyle HorizontalAlign="center" Width="19%" />
                                            <ItemStyle HorizontalAlign="center" Width="19%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="FatherName" HeaderText="FatherName">
                                            <HeaderStyle HorizontalAlign="right" Width="20%" />
                                            <ItemStyle HorizontalAlign="right" Width="20%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DOB" HeaderText="Date of Birth">
                                            <HeaderStyle HorizontalAlign="right" Width="20%" />
                                            <ItemStyle HorizontalAlign="right" Width="20%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Category" HeaderText="Category">
                                            <HeaderStyle HorizontalAlign="Center" Width="11%" />
                                            <ItemStyle HorizontalAlign="Center" Width="11%" />
                                            </asp:BoundField>
                                        <%--    <asp:BoundField DataField="LiciencePeriod" HeaderText="Validity Upto">
                                            <HeaderStyle HorizontalAlign="Center" Width="11%" />
                                            <ItemStyle HorizontalAlign="Center" Width="11%" />
                                            </asp:BoundField>--%>
                                            <asp:TemplateField>
                                            <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="LinkButton4" Style="padding: 0px 5px 0px 5px; font-size: 18px; border-radius: 3px;" 
                                                Text="<i class='fa fa-edit' style='color:white !important;'></i>" CssClass='greenButton btn-primary' CommandName="Select" CommandArgument='<%# Eval("RegistrationId") %>' />
                                            <asp:LinkButton runat="server" ID="LinkButton5" Style="padding: 0px 5px 0px 5px; font-size: 18px; border-radius: 3px;" 
                                                Text="<i class='fa fa-duotone fa-trash'></i>" CommandName="Drop" CommandArgument='<%# Eval("RegistrationId") %>'  OnClientClick="return confirm('Are you sure you want to delete this record?');"  CssClass='redButton btn-danger' />
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                        </Columns>
                                        <FooterStyle BackColor="White" ForeColor="#000066" />
                                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White"  HorizontalAlign="Center"/>
                                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                                        <RowStyle ForeColor="#000066" />
                                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                    </asp:GridView>
                      <asp:HiddenField ID="hdnId" runat="server" />

                </div>
                 <h7 class="card-title fw-semibold mb-4">Wireman Registrations</h7>
                <div class="card-body"

                    style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; border-radius: 10px !important;">
                            <asp:GridView ID="GridView2" runat="server" Width="100%"   AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand">
                        <Columns>                                            
                                            <asp:TemplateField HeaderText="Id" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRowID" runat="server" Text='<%#Eval("RegistrationId") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="RegistrationId"  HeaderText="User ID">
                                            <HeaderStyle HorizontalAlign="left" Width="8%" />
                                            <ItemStyle HorizontalAlign="center" Width="8%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Name" HeaderText="Name">
                                            <HeaderStyle HorizontalAlign="center" Width="19%" />
                                            <ItemStyle HorizontalAlign="center" Width="19%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="FatherName" HeaderText="FatherName">
                                            <HeaderStyle HorizontalAlign="right" Width="20%" />
                                            <ItemStyle HorizontalAlign="right" Width="20%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DOB" HeaderText="Date of Birth">
                                            <HeaderStyle HorizontalAlign="right" Width="20%" />
                                            <ItemStyle HorizontalAlign="right" Width="20%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Category" HeaderText="Category">
                                            <HeaderStyle HorizontalAlign="Center" Width="11%" />
                                            <ItemStyle HorizontalAlign="Center" Width="11%" />
                                            </asp:BoundField>
                                        <%--    <asp:BoundField DataField="LiciencePeriod" HeaderText="Validity Upto">
                                            <HeaderStyle HorizontalAlign="Center" Width="11%" />
                                            <ItemStyle HorizontalAlign="Center" Width="11%" />
                                            </asp:BoundField>--%>
                                            <asp:TemplateField>
                                            <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="LinkButton4" Style="padding: 0px 5px 0px 5px; font-size: 18px; border-radius: 3px;" 
                                                Text="<i class='fa fa-edit' style='color:white !important;'></i>" CssClass='greenButton btn-primary' CommandName="Select" CommandArgument='<%# Eval("RegistrationId") %>' />
                                            <asp:LinkButton runat="server" ID="LinkButton5" Style="padding: 0px 5px 0px 5px; font-size: 18px; border-radius: 3px;" 
                                                Text="<i class='fa fa-duotone fa-trash'></i>" CommandName="Drop" CommandArgument='<%# Eval("RegistrationId") %>'  OnClientClick="return confirm('Are you sure you want to delete this record?');" CssClass='redButton btn-danger' />
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                        </Columns>
                                        <FooterStyle BackColor="White" ForeColor="#000066" />
                                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White"  HorizontalAlign="Center"/>
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
    <!-- partial -->
    <script>
        $('.select2').select2();
    </script>
</asp:Content>
