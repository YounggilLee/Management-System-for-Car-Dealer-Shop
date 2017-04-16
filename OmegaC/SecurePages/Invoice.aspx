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
            width: 117px;
            margin-left: 520px;
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
            width: 117px;
        }
        .auto-style7 {
            width: 326px;
            height: 36px;
        }
        .auto-style8 {
            height: 22px;
        }
        .auto-style9 {
            width: 358px;
        }
        .auto-style10 {
            width: 358px;
            height: 36px;
        }
        .auto-style11 {
            height: 20px;
            width: 358px;
        }
        .auto-style12 {
            width: 117px;
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
                <td colspan="2" class="auto-style8">
                    <h3 style="text-decoration: underline; color: #0000FF;">Invoice Management</h3>
                </td>
                <td class="auto-style8">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style12">Invoice&nbsp; Number:</td>
                <td class="auto-style9">
                    <asp:TextBox ID="txtInvoiceNumber" runat="server" Width="63px"></asp:TextBox>
                    &nbsp;<asp:Button ID="btnLoad" runat="server" OnClick="btnLoad_Click" Text="Load" BackColor="#CCFF33" />
                </td>
                <td class="auto-style4">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtInvoiceNumber" ErrorMessage="InvoiceNumber is Required" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style12">Invoice&nbsp; Date:</td>
                <td class="auto-style9">
                    <uc2:CalendarUserControl ID="CalendarUserControl1" runat="server" />
                </td>
                <td class="auto-style4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style12">Net&nbsp;&nbsp;&nbsp;&nbsp; Price:</td>
                <td class="auto-style9">
                    <asp:TextBox ID="txtNetPrice" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style12">Tax&nbsp;&nbsp;&nbsp;&nbsp; :</td>
                <td class="auto-style9">
                    <asp:TextBox ID="txtTax" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6">Other&nbsp;&nbsp; Fees:</td>
                <td class="auto-style10">
                    <asp:TextBox ID="txtOtherFees" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style7">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style12">Cust&nbsp; &nbsp; ID:</td>
                <td class="auto-style9">
                    <asp:DropDownList ID="ddlCustomers" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
                <td class="auto-style4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style12">Car&nbsp; serial:</td>
                <td class="auto-style9">
                    <asp:DropDownList ID="ddlCarSerials" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
                <td class="auto-style4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">EmployeeID</td>
                <td class="auto-style11">
                    <asp:DropDownList ID="ddlEmployees" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
                <td class="auto-style5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style11">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnInsert" runat="server" OnClick="btnInsert_Click" Text="Insert" BackColor="#3399FF" />
                    &nbsp;<asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update" BackColor="Yellow" />
                    &nbsp;<asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete" BackColor="#FF0066" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style12">&nbsp;</td>
                <td class="auto-style9">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
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
