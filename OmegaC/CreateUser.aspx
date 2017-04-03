<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateUser.aspx.cs" Inherits="OmegaC.CreateUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h3>Create User Page</h3>
    
    </div>
        <p>
            UserName&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserName" ErrorMessage="UserName is required" ForeColor="Red"></asp:RequiredFieldValidator>
        </p>
        <p>
            PassWord&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtPassWord" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassWord" ErrorMessage="Password is required" ForeColor="Red"></asp:RequiredFieldValidator>
        </p>
        <p>
            Confirm PassWord&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtConfirmPassWord" runat="server"></asp:TextBox>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassWord" ControlToValidate="txtConfirmPassWord" ErrorMessage="Password and confirm Password didnot match" ForeColor="Red"></asp:CompareValidator>
        </p>
        <p>
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </p>
        <asp:Button ID="btnCreateUser" runat="server" OnClick="btnCreateUser_Click" Text="Create" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnBack" runat="server" CausesValidation="False" Text="Back" />
    </form>
</body>
</html>
