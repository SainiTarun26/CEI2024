<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin_Master.Master" AutoEventWireup="true" CodeBehind="Division.aspx.cs" Inherits="CEIHaryana.Admin.Division" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="shortcut icon" type="image/png" href="/css2/style.min.css" />
    <link rel="stylesheet" href="/css2/style.css" />
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css" />
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
        .headercolor1 {
            text-align: initial !important;
        }

        td {
            padding: 10px !important;
        }

        .submit {
            border: 1px solid #563d7c;
            border-radius: 5px;
            color: white;
            padding: 5px 10px 5px 10px;
            background: left 3px top 5px no-repeat #563d7c;
        }

            .submit:hover {
                border: 1px solid #563d7c;
                border-radius: 5px;
                color: white;
                padding: 5px 10px 5px 10px;
                background: left 3px top 5px no-repeat #26005f;
                box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px;
            }

        .table-dark {
            text-align: center !important;
            background-color: #9292cc !important;
        }

        .col-4 {
            margin-bottom: 15px;
        }

        .form-control {
            box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
            margin-left: 0px !important;
            height: 30px;
            font-size: 13px;
        }

        select.form-control {
            box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
            margin-left: 0px !important;
            height: 30px;
        }

        label {
            font-size: 14px;
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
            font-size: 1rem !important;
        }

        .btn-primary:hover {
            box-shadow: rgba(50, 50, 93, 0.25) 0px 30px 60px -12px inset, rgba(0, 0, 0, 0.3) 0px 18px 36px -18px inset;
        }

        button.btn.btn-primary.mr-2 {
            padding: 10px 25px 10px 25px;
            font-size: 18px;
        }

        select.form-control.select-form.select2 {
            height: 30px !important;
            padding: 2px 0px 5px 10px;
        }

        ul.chosen-choices {
            border-radius: 5px;
        }

        input#customFile {
            padding: 0px 0px 0px 0px;
        }

        input#ContentPlaceHolder1_txtName {
            font-size: 12.5px !important;
        }


        input#ContentPlaceHolder1_txtagency {
            font-size: 12.5px;
        }

        .headercolor {
            background-color: #9292cc;
        }


        th {
            background: #9292cc;
        }

        .card .card-title {
            font-size: 20px !important;
            color: #010101;
            text-transform: capitalize;
            font-weight: 700;
        }

        div#row3 {
            margin-top: -20px;
        }

        svg#svgcross {
            height: 35px;
            width: 67px;
        }

        svg#svgcross1 {
            height: 35px;
            width: 67px;
        }

        svg#svgcross2 {
            height: 35px;
            width: 67px;
        }

        svg#search1:hover {
            height: 22px;
            width: 22px;
            fill: #4b49ac;
            transition: ease-out;
            margin-left: -2px;
            cursor: pointer;
        }

        th.textalignleft {
            text-align: justify !important;
            padding: 9px !important;
        }

        th.headercolor {
            width: 1% !important;
        }


        th {
            width: 1%;
        }


            th.headersizeSignature {
                width: 40% !important;
            }


        .input-box {
            display: flex;
            align-items: center;
            max-width: 300px;
            background: #fff;
            border: 1px solid #a0a0a0;
            border-radius: 4px;
            padding-left: 0.5rem;
            overflow: hidden;
            font-family: sans-serif;
        }

            .input-box .prefix {
                font-weight: 300;
                font-size: 14px;
                color: black;
            }

            .input-box input {
                flex-grow: 1;
                font-size: 14px;
                background: #fff;
                border: none;
                outline: none;
                padding: 0.5rem;
            }

            .input-box:focus-within {
                border-color: #777;
            }
            .row{
                margin-bottom:15px;
            }
    </style>
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
    <script type="text/javascript">
        function validateAlphanumeric(event) {
            var charCode = (event.which) ? event.which : event.keyCode;

            // Allow alphabets (A-Z, a-z), space, all special characters, and control keys
            if ((charCode >= 65 && charCode <= 90) || // Uppercase (A-Z)
                (charCode >= 97 && charCode <= 122) || // Lowercase (a-z)
                (charCode == 32) || // Space
                (charCode == 8 || charCode == 37 || charCode == 39 || charCode == 46) || // Backspace, Arrow keys, Delete
                (charCode >= 33 && charCode <= 47) || // Special characters like ! " # $ % & ' ( ) * + , - . /
                (charCode >= 58 && charCode <= 64) || // Special characters like : ; < = > ? @
                (charCode >= 91 && charCode <= 96) || // Special characters like [ \ ] ^ _
                (charCode >= 123 && charCode <= 126)) // Special characters like { | } ~
            {
                return true;
            } else {
                event.preventDefault();
                return false;
            }
        }
</script>
    <script type="text/javascript">
        function preventEnterSubmit(e) {

            if (e.keyCode === 13) {
                e.preventDefault();
                return false;
            }
            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="card" style="box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px; border-radius: 5px !important">
            <div class="card-body">
                <div class="row">
                    <div class="col-12" style="text-align: center;">
                        <h7 class="card-title fw-semibold mb-4" id="maincard">DIVISION MASTER</h7>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4"></div>
                    <div class="col-sm-4" style="text-align: center;">
                        <label id="DataUpdated" runat="server" visible="false" style="color: red; font-size: 1.125rem">
                            Data Updated Successfully !!!.
                        </label>
                        <label id="DataSaved" runat="server" visible="false" style="color: red; font-size: 1.125rem">
                            Data Saved Successfully !!!.
                        </label>
                        </label>
                    </div>
                </div>
                 <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
                <div class="card-body" style="box-shadow: rgba(149, 157, 165, 0.2) 0px 8px 24px; border-radius: 5px !important">

                    <div class="row">
                        <div class="col-md-6">
                            <label>
                                Power Utility
             <samp style="color: red">* </samp>
                            </label>
                            <asp:DropDownList class="form-control  select-form select2" AutoPostBack="true" Style="width: 100% !important;" ID="ddlUtility" TabIndex="2" runat="server" OnSelectedIndexChanged="ddlUtility_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator26" Text="Please Select Utility name" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlUtility" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                        </div>
                        <div class="col-md-6">
                            <label>
                                Wing
          <samp style="color: red">* </samp>
                            </label>
                            <asp:DropDownList class="form-control  select-form select2" AutoPostBack="true" Style="width: 100% !important;" ID="ddlWing" TabIndex="2" runat="server" OnSelectedIndexChanged="ddlWing_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Text="Please Select Wing name" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlWing" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <label>
                                Zone 
        <samp style="color: red">* </samp>
                            </label>
                            <asp:DropDownList class="form-control  select-form select2" AutoPostBack="true" Style="width: 100% !important;" ID="ddlZone" TabIndex="2" runat="server" OnSelectedIndexChanged="ddlZone_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Text="Please Select Zone name" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlZone" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                        </div>
                        <div class="col-md-6">
                            <label>
                                Circle
           <samp style="color: red">* </samp>
                            </label>
                            <asp:DropDownList class="form-control  select-form select2" AutoPostBack="true" Style="width: 100% !important;" ID="ddlCircle" TabIndex="2" runat="server" OnSelectedIndexChanged="ddlCircle_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Text="Please Select Circle name" ErrorMessage="RequiredFieldValidator" ControlToValidate="ddlCircle" runat="server" InitialValue="0" Display="Dynamic" ValidationGroup="Submit" ForeColor="Red" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <label for="Division">
                                Division Name<samp style="color: red"> * </samp>
                            </label>
                      <asp:TextBox class="form-control" ID="txtDivisionName"  onkeydown="return preventEnterSubmit(event)" onKeyPress="return validateAlphanumeric(event);" TabIndex="8" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                           
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDivisionName" ErrorMessage="RequiredFieldValidator" ValidationGroup="Submit" ForeColor="Red">Please Enter Division Name</asp:RequiredFieldValidator>
                        </div>
                                           </div>
                     <div class="row">
     <div class="col-md-12" style="text-align: center;">
         <asp:Button type="submit" ID="btnSubmit" TabIndex="22" ValidationGroup="Submit" Text="Submit" runat="server" class="btn btn-primary mr-2" OnClick="btnSubmit_Click" />
     </div>
 </div>
                </div>
                         <div class="card-body" id="Circle" runat="server" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
    <asp:GridView class="table-responsive table table-striped table-hover" ID="GridView1" runat="server" Width="100%"
        AutoGenerateColumns="false"  BorderWidth="1px" BorderColor="#dbddff">
        <Columns>
          
            <asp:TemplateField HeaderText="SNo">
                <HeaderStyle Width="5%" CssClass="headercolor" />
                <ItemStyle Width="5%" />
                <ItemTemplate>
                    <%#Container.DataItemIndex+1 %>
                </ItemTemplate>
            </asp:TemplateField>
          
            <asp:BoundField DataField="Id" HeaderText="Division Id">
                <HeaderStyle HorizontalAlign="center" Width="28%" CssClass="headercolor" />
                <ItemStyle HorizontalAlign="center" Width="28%" />
            </asp:BoundField>
            <asp:BoundField DataField="DivisionName" HeaderText="Division Name">
                <HeaderStyle HorizontalAlign="center" Width="32%" CssClass="headercolor" />
                <ItemStyle HorizontalAlign="center" Width="32%" />
           </asp:BoundField>
             <asp:BoundField DataField="UtilityId" HeaderText="Utility Id">
     <HeaderStyle HorizontalAlign="center" Width="32%" CssClass="headercolor" />
     <ItemStyle HorizontalAlign="center" Width="32%" />
    </asp:BoundField>
     <asp:BoundField DataField="WingId" HeaderText="Wing Id">
 <HeaderStyle HorizontalAlign="center" Width="32%" CssClass="headercolor" />
 <ItemStyle HorizontalAlign="center" Width="32%" />
</asp:BoundField>
      <asp:BoundField DataField="ZoneId" HeaderText="Zone Id">
 <HeaderStyle HorizontalAlign="center" Width="32%" CssClass="headercolor" />
 <ItemStyle HorizontalAlign="center" Width="32%" />
</asp:BoundField>
            <asp:BoundField DataField="CircleId" HeaderText="Circle Id">
 <HeaderStyle HorizontalAlign="center" Width="32%" CssClass="headercolor" />
 <ItemStyle HorizontalAlign="center" Width="32%" />
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
                </ContentTemplate></asp:UpdatePanel>
                <asp:HiddenField ID="hdnId" runat="server" />
                <asp:HiddenField ID="hdnId2" runat="server" />
                <div>
                </div>
            </div>
        </div>
    </div>
    <footer class="footer">
    </footer>


    <script src="/Assets/js/chart.js/Chart.min.js"></script>
    <script src="/Assets/js/datatables.net/jquery.dataTables.js"></script>
    <script src="/Assets/js/datatables.net-bs4/dataTables.bootstrap4.js"></script>
    <script src="/Assets/js/dataTables.select.min.js"></script>
    <script src="/Assets/js/off-canvas.js"></script>
    <script src="/Assets/js/hoverable-collapse.js"></script>
    <script src="/Assets/js/template.js"></script>
    <script src="/Assets/js/settings.js"></script>
    <script src="/Assets/js/todolist.js"></script>
    <script src="/Assets/js/dashboard.js"></script>
    <script src="/Assets/js/Chart.roundedBarCharts.js"></script>
</asp:Content>
