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
            UserName &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserName" ErrorMessage="Username is required" ForeColor="Red"></asp:RequiredFieldValidator>
        </p>
        <p>
            PassWord&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtPassWord" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassWord" ErrorMessage="Password is required" ForeColor="Red"></asp:RequiredFieldValidator>
        </p>
        <p style="margin-left: 40px">
            <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Login" />
        &nbsp;&nbsp;&nbsp;
            <asp:Button ID="txtCreateUser" runat="server" CausesValidation="False" OnClick="txtCreateUser_Click" Text="CreateUser" />
        </p>
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
    </form>
</body>
</html>
