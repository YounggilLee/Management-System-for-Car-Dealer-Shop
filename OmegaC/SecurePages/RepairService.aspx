<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RepairService.aspx.cs" Inherits="OmegaC.SecurePages.RepairService" %>

<%@ Register src="../UserControls/HeaderUserControl.ascx" tagname="HeaderUserControl" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Repair Service Management</title>
    <style type="text/css">
        .auto-style2 {
            color: #0000FF;
            text-decoration: underline;
        }
    </style>
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
                    <h3 class="auto-style2">RepairService Management</h3>
                </td>
            </tr>
            <tr>
                <td>Service&nbsp;Number:</td>
                <td>
                    <asp:TextBox ID="txtServiceNumber" runat="server" Width="63px"></asp:TextBox>
                    &nbsp;<asp:Button ID="btnLoad" runat="server" OnClick="btnLoad_Click" Text="Load" BackColor="#99FF33" />
                </td>
            </tr>
            <tr>
                <td>Labor&nbsp; Price:</td>
                <td>
                    <asp:TextBox ID="txtLaborPrice" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Part&nbsp; Pirce:</td>
                <td>
                    <asp:TextBox ID="txtPartPrice" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Tax&nbsp;&nbsp;&nbsp; :</td>
                <td>
                    <asp:TextBox ID="txtTax" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Work Detail :</td>
                <td>
                    <asp:TextBox ID="txtWorkDetail" runat="server" Height="76px" TextMode="MultiLine" Width="173px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>CustomerID :</td>
                <td>
                    <asp:TextBox ID="txtCustomerID" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Car&nbsp; Serial :</td>
                <td>
                    <asp:TextBox ID="txtCarSerial" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnInsert" runat="server" OnClick="btnInsert_Click" Text="Insert" BackColor="Aqua" />
                    &nbsp;<asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update" BackColor="Yellow" />
                    &nbsp;<asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete" BackColor="Red" />
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

        <asp:GridView ID="grdServices" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" style="margin:auto" GridLines="Horizontal">
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
    </form>
</body>
</html>
