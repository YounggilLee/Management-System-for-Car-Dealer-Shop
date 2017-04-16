<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employee.aspx.cs" Inherits="OmegaC.SecurePages.Employee" %>

<%@ Register src="../UserControls/HeaderUserControl.ascx" tagname="HeaderUserControl" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee Management</title>
    <style type="text/css">

        .auto-style2 {
            height: 26px;
        }
        .auto-style3 {
            height: 29px;
        }
    </style>
    <link rel="stylesheet" type="text/css" href="~/Styles/Styles.css">
</head>
<body>
    <form id="form1" runat="server">
        <uc1:HeaderUserControl ID="HeaderUserControl1" runat="server" />
    <div>
    
        <table style="width: 40%; margin: auto;">
            <tr>
                <td colspan="2">
                    <h3 style="text-decoration: underline; color: #0000FF;">Employee Management</h3>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>Employee ID:</td>
                <td>
                    <asp:TextBox ID="txtEmployeeID" runat="server" Width="63px"></asp:TextBox>
                    &nbsp;<asp:Button ID="btnInsert" runat="server" OnClick="btnInsert_Click" Text="Insert" BackColor="#33CCFF" />
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmployeeID" ErrorMessage="EmployeeID is Required" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>First&nbsp;Name:</td>
                <td>
                    <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>Last&nbsp;Name:</td>
                <td>
                    <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">Salary :</td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtSalary" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">Sales :</td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtSales" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">Commission :</td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtCommission" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblMessage0" runat="server"></asp:Label>
                </td>
                <td style="text-decoration: underline"></td>
                <td style="text-decoration: underline">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
    
        <asp:Button ID="btnLoadData" runat="server" Text="LoadData" OnClick="btnLoadData_Click" BackColor="Lime" CausesValidation="False" />
                </td>
                <td>
        <asp:Button ID="btnUndo" runat="server" OnClick="btnUndo_Click" Text="Undo" BackColor="#FF0066" CausesValidation="False" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
        <br />
        <asp:GridView ID="grdEmployee" runat="server" AutoGenerateColumns="False" style="margin:auto" DataKeyNames="employeeID" EmptyDataText="There are no data records to display." OnRowCancelingEdit="grdEmployee_RowCancelingEdit" OnRowDeleting="grdEmployee_RowDeleting" OnRowEditing="grdEmployee_RowEditing" OnRowUpdating="grdEmployee_RowUpdating" Width="702px" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="employeeID" HeaderText="employeeID" ReadOnly="True" SortExpression="employeeID" />
                <asp:BoundField DataField="firstName" HeaderText="firstName" SortExpression="firstName" />
                <asp:BoundField DataField="lastName" HeaderText="lastName" SortExpression="lastName" />
                <asp:BoundField DataField="salary" HeaderText="salary" SortExpression="salary" />
                <asp:BoundField DataField="sales" HeaderText="sales" SortExpression="sales" />
                <asp:BoundField DataField="commission" HeaderText="commission" SortExpression="commission" />
            </Columns>
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
      
        <br />
        <table style="width: 40%; margin: auto;">
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
        <asp:Button ID="btnSaveData" runat="server" Text="SaveData" OnClick="btnSaveData_Click" BackColor="Yellow" CausesValidation="False" />
                </td>
                <td>
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
    
                </td>
            </tr>
        </table>
        <br />
    
    </div>
    </form>
</body>
</html>
