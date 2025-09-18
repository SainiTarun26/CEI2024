<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GuestAdminLogout.aspx.cs" Inherits="CEIHaryana.GuestAdminLogout" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
     <form id="form1" runat="server">
     <div>
         <p class="style1">
             Log Out Successfull................</p>
             <span class="style2"><a href="/SiteOwnerLogout.aspx">Click Here</a></span>
             <span class="style2">&nbsp;to go Login Page</span>
     </div>
 </form>
         <script>
             window.onload = function () {
                 checkLoginBeforeSubmit();
             };

             function checkLoginBeforeSubmit() {
                 // Check if user is already logged in another tab
                 localStorage.removeItem('activeSession');
                 sessionStorage.clear();
                 window.location.href = 'Login.aspx';
             }
         </script>

</body>
</html>
