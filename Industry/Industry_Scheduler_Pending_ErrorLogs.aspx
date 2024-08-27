<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Industry_Scheduler_Pending_ErrorLogs.aspx.cs" Inherits="CEIHaryana.Industry.Industry_Scheduler_Pending_ErrorLogs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
 <form id="form1" runat="server">
        <asp:HiddenField ID="hfTaskCompleted" runat="server" Value="false" />
    </form>
    <script type="text/javascript">
        window.onload = function() {
            var taskCompleted = document.getElementById('<%= hfTaskCompleted.ClientID %>').value;
            if (taskCompleted === "true") {
                window.open('', '_self', ''); // To enable closing the tab
                window.close(); // Close the tab
            }
        };
    </script>
</body>
</html>
