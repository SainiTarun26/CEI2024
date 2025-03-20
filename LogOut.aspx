<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogOut.aspx.cs" Inherits="CEIHaryana.LogOut" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
    <p class="style1">
        You are already logged in another tab.</p>
          Click  <asp:LinkButton ID="btnOk" runat="server" Text="OK"  OnClientClick="return checkLoginBeforeSubmit();" OnClick="btnOk_Click"></asp:LinkButton>
 for sign Out
        <span class="style2">&nbsp;From Previous Session</span>
</div>
        <div>
           
        </div>
    </form>
      <script>
      function checkLoginBeforeSubmit() {
          // Check if user is already logged in another tab
          localStorage.removeItem('activeSession');
          sessionStorage.clear();
          window.close();
      }
      </script>
</body>
</html>
