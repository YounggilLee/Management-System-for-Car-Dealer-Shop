<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HeaderUserControl.ascx.cs" Inherits="OmegaC.UserControls.HeaderUserControl" %>
<h3>OmegaC Management System</h3>
<p>
    &nbsp;</p>
<asp:Menu ID="Menu1" runat="server" BackColor="#FFFBD6" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#990000" Orientation="Horizontal" StaticSubMenuIndent="10px">
    <DynamicHoverStyle BackColor="#990000" ForeColor="White" />
    <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
    <DynamicMenuStyle BackColor="#FFFBD6" />
    <DynamicSelectedStyle BackColor="#FFCC66" />
    <Items>
        <asp:MenuItem NavigateUrl="~/Default.aspx" Text="Home" Value="Home"></asp:MenuItem>
        <asp:MenuItem NavigateUrl="~/SecurePages/MainPage.aspx" Text="MainPage" Value="MainPage"></asp:MenuItem>
        <asp:MenuItem NavigateUrl="~/SecurePages/Vehicle.aspx" Text="Vehicle" Value="Vehicle"></asp:MenuItem>
        <asp:MenuItem NavigateUrl="~/SecurePages/Option.aspx" Text="Option" Value="Option"></asp:MenuItem>
        <asp:MenuItem NavigateUrl="~/SecurePages/Invoice.aspx" Text="Invoice" Value="Invoice"></asp:MenuItem>
        <asp:MenuItem NavigateUrl="~/SecurePages/RepairService.aspx" Text="RepairService" Value="RepairService"></asp:MenuItem>
        <asp:MenuItem NavigateUrl="~/SecurePages/Customer.aspx" Text="Customer" Value="Customer"></asp:MenuItem>
        <asp:MenuItem NavigateUrl="~/SecurePages/Customer.aspx" Text="Employee" Value="Employee"></asp:MenuItem>
        <asp:MenuItem NavigateUrl="~/Register.aspx" Text="Register" Value="Register"></asp:MenuItem>
        <asp:MenuItem NavigateUrl="~/Login.aspx" Text="Login" Value="Login"></asp:MenuItem>
    </Items>
    <StaticHoverStyle BackColor="#990000" ForeColor="White" />
    <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
    <StaticSelectedStyle BackColor="#FFCC66" />
</asp:Menu>
<hr />

