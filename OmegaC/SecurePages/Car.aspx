<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Car.aspx.cs" Inherits="OmegaC.SecurePages.Vehicle" %>

<%@ Register src="../UserControls/HeaderUserControl.ascx" tagname="HeaderUserControl" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Car Management</title>
    <link rel="stylesheet" type="text/css" href="~/Styles/Styles.css">
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <uc1:HeaderUserControl ID="HeaderUserControl1" runat="server" />
    
    </div>
        <table style="width: 40%; margin: auto;">
            <tr>
                <td colspan="2">
                    <h3 style="text-decoration: underline; color: #0000FF;">Car Management System&nbsp;</h3>
                </td>
            </tr>
            <tr>
                <td>Car&nbsp; Serial:</td>
                <td>
                    <asp:TextBox ID="txtCarSerial" runat="server" Width="63px"></asp:TextBox>
                    &nbsp;<asp:Button ID="btnLoad" runat="server" OnClick="btnLoad_Click" Text="Load" BackColor="#66FF33" />
                </td>
            </tr>
            <tr>
                <td>Car&nbsp; Make:</td>
                <td>
                    <asp:TextBox ID="txtCarMake" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Car&nbsp; Model:</td>
                <td>
                    <asp:TextBox ID="txtCarModel" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Car&nbsp; Year:</td>
                <td>
                    <asp:TextBox ID="txtCarYear" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Car&nbsp; Price:</td>
                <td>
                    <asp:TextBox ID="txtCarPrice" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnInsert" runat="server" OnClick="btnInsert_Click" Text="Insert" BackColor="#00CCFF" />
                    &nbsp;<asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update" BackColor="Yellow" />
                    &nbsp;<asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete" BackColor="#FF5050" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td style="text-decoration: underline"></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <br />
<hr />

        <asp:GridView ID="grdCars" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" style="margin:auto" GridLines="Horizontal">
            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FFF1D4" />
            <SortedAscendingHeaderStyle BackColor="#B95C30" />
            <SortedDescendingCellStyle BackColor="#F1E5CE" />
            <SortedDescendingHeaderStyle BackColor="#93451F" />
        </asp:GridView>
        <br />
    </form>
</body>
</html>
