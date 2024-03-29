<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testing.aspx.cs" Inherits="CEIHaryana.testing" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:PlaceHolder ID="FileUploadPlaceholder" runat="server">
        </div>
        <asp:Button ID="AddFileUploadButton" runat="server" Text="Add File Upload" OnClick="AddFileUploadButton_Click" />
         <asp:Button ID="SubmitButton" runat="server" Text="Submit" OnClick="SubmitButton_Click" />
        </asp:PlaceHolder>
    </form>
</body>
</html>
