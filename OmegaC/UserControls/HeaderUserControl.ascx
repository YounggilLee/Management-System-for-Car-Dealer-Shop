<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HeaderUserControl.ascx.cs" Inherits="OmegaC.UserControls.HeaderUserControl" %>


<style type="text/css">
    .auto-style1 {
        width: 608px;
    }
    .auto-style3 {
        margin-left: 520px;
    }
</style>


<div style="margin:0 auto 0 auto; width:300px;">
<h3 style="background-color: #FFFF00; font-weight: bold; font-size: large" > &nbsp;&nbsp; OmegaC Management System</h3>
</div>
<p style="text-align:right">
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
    <asp:Label ID="lblUserName" runat="server"></asp:Label>
    <asp:Button ID="btnLogOut" runat="server" OnClick="btnLogOut_Click" Text="LogOut" />
</p>

<div style="margin:0 auto 0 auto; " class="auto-style1">
<asp:Menu ID="Menu1" runat="server" BackColor="#FFFBD6" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#990000" Orientation="Horizontal" StaticSubMenuIndent="10px" Width="110%">
    <DynamicHoverStyle BackColor="#990000" ForeColor="White" />
    <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
    <DynamicMenuStyle BackColor="#FFFBD6" />
    <DynamicSelectedStyle BackColor="#FFCC66" />
    <Items>
        <asp:MenuItem NavigateUrl="~/Default.aspx" Text="Home" Value="Home"></asp:MenuItem>
        <asp:MenuItem NavigateUrl="~/SecurePages/MainPage.aspx" Text="MainPage" Value="MainPage"></asp:MenuItem>
        <asp:MenuItem NavigateUrl="~/SecurePages/Car.aspx" Text="Car" Value="Car"></asp:MenuItem>
        <asp:MenuItem NavigateUrl="~/SecurePages/Option.aspx" Text="Option" Value="Option"></asp:MenuItem>
        <asp:MenuItem NavigateUrl="~/SecurePages/Invoice.aspx" Text="Invoice" Value="Invoice"></asp:MenuItem>
        <asp:MenuItem NavigateUrl="~/SecurePages/RepairService.aspx" Text="RepairService" Value="RepairService"></asp:MenuItem>
        <asp:MenuItem NavigateUrl="~/SecurePages/Customer.aspx" Text="Customer" Value="Customer"></asp:MenuItem>
        <asp:MenuItem NavigateUrl="~/SecurePages/Employee.aspx" Text="Employee" Value="Employee"></asp:MenuItem>
        <asp:MenuItem NavigateUrl="~/Register.aspx" Text="Register" Value="Register"></asp:MenuItem>
        <asp:MenuItem NavigateUrl="~/Login.aspx" Text="Login" Value="Login"></asp:MenuItem>
    </Items>
    <StaticHoverStyle BackColor="#990000" ForeColor="White" />
    <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
    <StaticSelectedStyle BackColor="#FFCC66" />
</asp:Menu>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </div>
<hr />

