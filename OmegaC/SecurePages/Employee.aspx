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
        <br />
        <asp:GridView ID="grdEmployee" runat="server" AutoGenerateColumns="False" DataKeyNames="employeeID" EmptyDataText="There are no data records to display." Width="702px">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="employeeID" HeaderText="employeeID" ReadOnly="True" SortExpression="employeeID" />
                <asp:BoundField DataField="firstName" HeaderText="firstName" SortExpression="firstName" />
                <asp:BoundField DataField="lastName" HeaderText="lastName" SortExpression="lastName" />
                <asp:BoundField DataField="salary" HeaderText="salary" SortExpression="salary" />
                <asp:BoundField DataField="sales" HeaderText="sales" SortExpression="sales" />
                <asp:BoundField DataField="commission" HeaderText="commission" SortExpression="commission" />
            </Columns>
        </asp:GridView>
      
        <br />
        <br />
        <asp:Button ID="btnUpdate" runat="server" Text="UpdateData" />
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
    
    </div>
    </form>
</body>
</html>
