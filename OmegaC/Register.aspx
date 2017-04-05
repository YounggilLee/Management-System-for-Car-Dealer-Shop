<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="OmegaC.CreateUser" %><%@ Register src="UserControls/HeaderUserControl.ascx" tagname="HeaderUserControl" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            height: 70px;
        }
        .auto-style2 {
            width: 338px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <uc1:HeaderUserControl ID="HeaderUserControl1" runat="server" />
        <h3>Register Page</h3>
    
    </div>
&nbsp;<table class="auto-style1" style="width: auto; margin: auto;">
            <tr>
                <td>UserName </td>
                <td>
            <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style2">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserName" ErrorMessage="UserName is required" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>PassWord</td>
                <td>
            <asp:TextBox ID="txtPassWord" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style2">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassWord" ErrorMessage="Password is required" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Confirm PassWord</td>
                <td>
            <asp:TextBox ID="txtConfirmPassWord" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style2">
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassWord" ControlToValidate="txtConfirmPassWord" ErrorMessage="Password and confirm Password didnot match" ForeColor="Red"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td class="auto-style2">&nbsp;</td>
            </tr>
            <tr>
                <td>
        <asp:Button ID="btnCreateUser" runat="server" OnClick="btnCreateUser_Click" Text="Register" />
                </td>
                <td>
        <asp:Button ID="btnBack" runat="server" CausesValidation="False" Text="Back" OnClick="btnBack_Click" />
                </td>
                <td class="auto-style2">
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
