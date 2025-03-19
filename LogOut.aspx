<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogOut.aspx.cs" Inherits="CEIHaryana.LogOut" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <div class="col-md-12" style="text-align: left;">
     <h7 class="card-title fw-semibold mb-4" style="font-size: 20px !important;">You are already logged in another tab.</h7>\
                 <br />
     <h7 class="card-title fw-semibold mb-4" style="font-size: 20px !important;">Please Click <asp:LinkButton ID="btnOk" runat="server" Text="OK" OnClick="btnOk_Click"></asp:LinkButton> for sign Out</h7>
 </div>
        </div>
    </form>
</body>
</html>
