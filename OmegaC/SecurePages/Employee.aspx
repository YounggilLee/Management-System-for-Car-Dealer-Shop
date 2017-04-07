<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employee.aspx.cs" Inherits="OmegaC.SecurePages.Employee" %>

<%@ Register src="../UserControls/HeaderUserControl.ascx" tagname="HeaderUserControl" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <uc1:HeaderUserControl ID="HeaderUserControl1" runat="server" />
    <div>
    
        <asp:Button ID="btnLoadData" runat="server" Text="LoadData" OnClick="btnLoadData_Click" />
        <asp:Button ID="btnUndo" runat="server" OnClick="btnUndo_Click" Text="Undo" />
        <br />
        <asp:GridView ID="grdEmployee" runat="server" AutoGenerateColumns="False" DataKeyNames="employeeID" EmptyDataText="There are no data records to display." OnRowCancelingEdit="grdEmployee_RowCancelingEdit" OnRowDeleting="grdEmployee_RowDeleting" OnRowEditing="grdEmployee_RowEditing" OnRowUpdating="grdEmployee_RowUpdating" Width="702px" CellPadding="4" ForeColor="#333333" GridLines="None">
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
        <br />
        <asp:Button ID="btnSaveData" runat="server" Text="SaveData" OnClick="btnSaveData_Click" />
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
    
    </div>
    </form>
</body>
</html>
