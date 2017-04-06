<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="OmegaC.Login" %>

<%@ Register src="UserControls/HeaderUserControl.ascx" tagname="HeaderUserControl" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 159px;
        }
        .auto-style2 {
            width: 331px;
        }
        .auto-style3 {
            width: 118px;
        }
        .auto-style4 {
            height: 20px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <uc1:HeaderUserControl ID="HeaderUserControl1" runat="server" />
        <br />
    
    </div>
        <div style="margin:0 auto 0 auto; width:400px;">
        <table style="width: auto; margin: auto;">
            <tr>
                <td class="auto-style4" colspan="3">
                    <h3 style="text-decoration: underline; color: #0000FF">Login Page</h3>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">UserName</td>
                <td class="auto-style1">
            <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style2">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserName" ErrorMessage="Username is required" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">PassWord </td>
                <td class="auto-style1">
            <asp:TextBox ID="txtPassWord" type="password" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style2">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassWord" ErrorMessage="Password is required" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
            <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Login" />
                </td>
                <td class="auto-style1">
            <asp:Button ID="txtCreateUser" runat="server" CausesValidation="False" OnClick="txtCreateUser_Click" Text="Register" />
                </td>
                <td class="auto-style2">
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
            </div>
        <p>
            &nbsp;</p>
    </form>
    
</body>
</html>
