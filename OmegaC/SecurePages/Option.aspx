<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Option.aspx.cs" Inherits="OmegaC.SecurePages.Option" %>

<%@ Register src="../UserControls/HeaderUserControl.ascx" tagname="HeaderUserControl" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Option Management</title>
    <style type="text/css">
        .auto-style2 {
            height: 26px;
        }
        </style>
    <link rel="stylesheet" type="text/css" href="~/Styles/Styles.css">
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <uc1:HeaderUserControl ID="HeaderUserControl1" runat="server" />
    
        <br />
        <table style="width: 40%; margin: auto;">
            <tr>
                <td colspan="2">
                    <h3 style="text-align:center; color:blue; text-decoration: underline;">Option Management</h3>
                </td>
            </tr>
            <tr>
                <td>Option Codel:</td>
                <td>
                    <asp:TextBox ID="txtOptionCode" runat="server" Width="63px"></asp:TextBox>
                    &nbsp;<asp:Button ID="btnLoad" runat="server" OnClick="btnLoad_Click" Text="Load" BackColor="#99FF33" />
                </td>
            </tr>
            <tr>
                <td>Option&nbsp;Price:</td>
                <td>
                    <asp:TextBox ID="txtOptionPrice" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Option&nbsp;Desc:</td>
                <td>
                    <asp:TextBox ID="txtOptionDesc" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Car&nbsp; Serial:</td>
                <td class="auto-style2">
                    <asp:DropDownList ID="ddlCarSerials" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnInsert" runat="server" OnClick="btnInsert_Click" Text="Insert" BackColor="#33CCFF" />
                    &nbsp;<asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update" BackColor="Yellow" />
                    &nbsp;<asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete" BackColor="#FF5050" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                </td>
                <td style="text-decoration: underline"></td>
            </tr>
            <tr>
                <td colspan="2">
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
        <asp:GridView ID="grdOptions" runat="server" CellPadding="4" style="margin:auto" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
    </form>
</body>
</html>
