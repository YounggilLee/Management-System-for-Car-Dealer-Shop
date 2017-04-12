<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Invoice.aspx.cs" Inherits="OmegaC.SecurePages.Invoice" %>

<%@ Register src="../UserControls/HeaderUserControl.ascx" tagname="HeaderUserControl" tagprefix="uc1" %>

<%@ Register src="../UserControls/CalendarUserControl.ascx" tagname="CalendarUserControl" tagprefix="uc2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Invoice Management</title>
    <link rel="stylesheet" type="text/css" href="~/Styles/Styles.css">
    <style type="text/css">

        .auto-style2 {
            width: 44%;
        }
        .auto-style3 {
            height: 20px;
        }
        .auto-style4 {
            width: 326px;
        }
        .auto-style5 {
            height: 20px;
            width: 326px;
        }
        .auto-style6 {
            height: 36px;
        }
        .auto-style7 {
            width: 326px;
            height: 36px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <uc1:HeaderUserControl ID="HeaderUserControl1" runat="server" />
    
    </div>
        <table style="margin: auto;" class="auto-style2">
            <tr>
                <td colspan="2">
                    <h3 style="text-decoration: underline; color: #0000FF;">Invoice Management</h3>
                </td>
            </tr>
            <tr>
                <td>Invoice&nbsp; Number:</td>
                <td class="auto-style4">
                    <asp:TextBox ID="txtInvoiceNumber" runat="server" Width="63px"></asp:TextBox>
                    &nbsp;<asp:Button ID="btnLoad" runat="server" OnClick="btnLoad_Click" Text="Load" BackColor="#CCFF33" />
                </td>
            </tr>
            <tr>
                <td>Invoice&nbsp; Date:</td>
                <td class="auto-style4">
                    <uc2:CalendarUserControl ID="CalendarUserControl1" runat="server" />
                </td>
            </tr>
            <tr>
                <td>Net&nbsp;&nbsp;&nbsp;&nbsp; Price:</td>
                <td class="auto-style4">
                    <asp:TextBox ID="txtNetPrice" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Tax&nbsp;&nbsp;&nbsp;&nbsp; :</td>
                <td class="auto-style4">
                    <asp:TextBox ID="txtTax" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">Other&nbsp;&nbsp; Fees:</td>
                <td class="auto-style7">
                    <asp:TextBox ID="txtOtherFees" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Customer&nbsp; ID:</td>
                <td class="auto-style4">
                    <asp:DropDownList ID="ddlCustomers" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Car&nbsp; serial:</td>
                <td class="auto-style4">
                    <asp:DropDownList ID="ddlCarSerials" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">EmployeeID</td>
                <td class="auto-style5">
                    <asp:DropDownList ID="ddlEmployees" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnInsert" runat="server" OnClick="btnInsert_Click" Text="Insert" BackColor="#3399FF" />
                    &nbsp;<asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update" BackColor="Yellow" />
                    &nbsp;<asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete" BackColor="#FF0066" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <br />
<hr />

        <asp:GridView ID="grdInvoices" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" style="margin:auto" GridLines="Horizontal">
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
