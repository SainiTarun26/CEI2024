<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="CEIHaryana.Admin.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <link href="/ScriptCalendar/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/ScriptCalendar/jquery-1.11.0.min.js"></script>
    <script type="text/javascript" src="/ScriptCalendar/jquery-ui.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            debugger;
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

    </script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="col-4">
            <label for="DateofIntialissue">Date of Intial issue</label>
            <asp:TextBox class="form-control" ID="txtDateofIntialissue" AutoPostBack="true" TabIndex="11" runat="server" Style="margin-left: 18px">

            </asp:TextBox>

        </div>
    </form>
</body>
</html>
