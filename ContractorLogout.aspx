<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContractorLogout.aspx.cs" Inherits="CEIHaryana.ContractorLogout" %>

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
