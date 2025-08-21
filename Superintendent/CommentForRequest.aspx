<%@ Page Title="" Language="C#" MasterPageFile="~/Superintendent/Superintendent.Master" AutoEventWireup="true" CodeBehind="CommentForRequest.aspx.cs" Inherits="CEIHaryana.Superintendent.CommentForRequest" %>
<%@ Register Src="~/UserCPages/LicenceHeaderDetails.ascx" TagPrefix="uc" TagName="LicenceDetails" %>
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

        .col-md-4 {
            margin-bottom: 15px;
        }

        .form-control {
            box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
            margin-left: 0px !important;
            height: 30px;
        }

        select.form-control {
            box-shadow: rgba(0, 0, 0, 0.16) 0px 1px 4px;
            margin-left: 0px !important;
            height: 30px;
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

        input#ContentPlaceHolder1_RadioButtonList2_0 {
            margin-left: 10px;
            margin-right: 5px;
        }

        input#ContentPlaceHolder1_RadioButtonList2_1 {
            margin-left: 10px;
            margin-right: 5px;
        }

        input#ContentPlaceHolder1_RadioButtonList2_2 {
            margin-left: 10px;
            margin-right: 5px;
        }

        th.headercolor {
            background: #9292cc;
            color: white;
            width: 1% !important;
        }

        table#ContentPlaceHolder1_RadioButtonList2 {
            margin-top: 5px;
        }

        th.headercolor.thwidth {
            width: 1% !important;
            text-align: justify
        }
        th{
            width:1% !important;
            background:#8b8bc2 !important;
        }
    </style>

    <script type="text/javascript">
        function alertWithRedirectdata() {

            alert('Inspection Request is Successfully Accepted');
            window.location.href = "/Officers/NewApplications.aspx";
        }
        function alertWithRedirectdataReturn() {
            alert('Inspection Request is Returned to Site Owner');
            window.location.href = "/Officers/NewApplications.aspx";
        }

        function alertWithRedirectdataSupervisorReturn() {
            alert('Inspection Request is Returned to Supervisor');
            window.location.href = "/Officers/NewApplications.aspx";
        }
        function alertWithRedirectdataOfRejection() {
            alert('Inspection Request Rejected Successfully');
            window.location.href = "/Officers/NewApplications.aspx";
        }

        function alertWithRedirectdataCommonReturn() {
            alert('Inspection Request is Returned to Owner');
            window.location.href = "/Officers/NewApplications.aspx";
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="card-body" style="box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px; padding: 25px; margin-bottom: 25px; border-radius: 10px; margin-top: 10px;">
            <%-- <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
             <asp:UpdatePanel ID="UpdatePanel1" runat="server"></asp:UpdatePanel>--%>
            <div class="card-title" style="margin-bottom: 5px; font-size: 17px; margin-bottom: 20px; font-weight: 600; margin-left: -10px;">
                User Detail
            </div>
            <uc:LicenceDetails ID="ucLicenceDetails" runat="server" />
            <asp:HiddenField ID="hdnId" runat="server" />
            <asp:HiddenField ID="hdnApplicationId" runat="server" />
            <div class="card-title" style="margin-top: 15px; margin-bottom: 20px; font-size: 17px; font-weight: 600; margin-left: -10px;">
                Applications Status
            </div>
            <div class="card" style="margin: -11px; padding: 11px; margin-bottom: 20px;">
                <div class="row">
                    <div class="col-md-12">
                        <asp:GridView ID="GridView1" CssClass="table table-responsive table-bordered table-striped" runat="server" AutoGenerateColumns="False" EmptyDataText="No data to display.">
                            <Columns>
                                <asp:BoundField DataField="ActionTakenBy" HeaderText="Action Taken By" />
                                <asp:BoundField DataField="ApplicationStatus" HeaderText="Action Taken" />
                                <asp:BoundField DataField="Remarks" HeaderText="Comments" />
                                <asp:BoundField DataField="ActionDate" HeaderText="Action Date" DataFormatString="{0:dd-MMM-yy}" />
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

            <div id="SupComment" runat="server">
                <div class="card-title" style="margin-bottom: 5px; font-size: 17px; margin-bottom: 20px; font-weight: 600; margin-left: -10px;">
                    Comments Of Superintendent 
                </div>
                <div class="card" style="margin: -11px; padding: 11px; margin-bottom: 20px;">
                    <div class="row">
                        <div class="col-md-12" runat="server">

                            <asp:TextBox class="form-control" ID="txtComment" ReadOnly="false" TextMode="MultiLine" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div id="Status" runat="server" visible="false">
                <div class="row" style="margin-bottom: 15px;">
                    <div class="col-md-4">
                        <label>
                            Application Status
                        </label>
                        <asp:TextBox class="form-control" ID="txtStatus" TabIndex="8" ReadOnly="true" onkeydown="return preventEnterSubmit(event)" MaxLength="50" autocomplete="off" runat="server" Style="margin-left: 18px"></asp:TextBox>
                    </div>
                </div>
            </div>

        </div>
        <div class="row">
            <div class="col-md-4"></div>
            <div class="col-md-4" style="text-align: center;">
                <asp:Button ID="btnSubmit" Text="Submit" runat="server" class="btn btn-primary mr-2" ValidationGroup="Submit" OnClick="btnSubmit_Click" />
                <asp:Button ID="btnBack" Text="Back" runat="server" class="btn btn-primary mr-2" OnClick="btnBack_Click" />
            </div>
        </div>
    </div>

</asp:Content>
