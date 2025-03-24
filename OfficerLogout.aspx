<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OfficerLogout.aspx.cs" Inherits="CEIHaryana.OfficerLogout" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>
        <script>
window.onload = function() {
    checkLoginBeforeSubmit();
};

        function checkLoginBeforeSubmit() {
            debugger;
    // Check if user is already logged in another tab
    localStorage.removeItem('activeSession');
    sessionStorage.clear();
            window.location.href = 'Login.aspx';
}
        </script>

</body>
</html>
