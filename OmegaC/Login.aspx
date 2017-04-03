<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="OmegaC.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h3>Login</h3>
    
    </div>
        <p>
            EmployeeID&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtEmployeeID" runat="server"></asp:TextBox>
        </p>
        <p>
            PassWord&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtPassWord" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Login" />
        </p>
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
    </form>
</body>
</html>
