<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="OmegaC.MainPage" %>

<%@ Register src="../UserControls/HeaderUserControl.ascx" tagname="HeaderUserControl" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Main Page</title>
    <link rel="stylesheet" type="text/css" href="~/Styles/Styles.css">
</head>
<body>
    <form id="form1" runat="server">
        <uc1:HeaderUserControl ID="HeaderUserControl1" runat="server" />
      <div style="margin:0 auto 0 auto; width:400px;">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblLoginUser" runat="server"></asp:Label>
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
    
          <br />
          <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    
    </div>
        <p>
            &nbsp;</p>
             <div style="margin:0 auto 0 auto; width:400px;">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Image ID="Image1" runat="server" Height="74px" ImageUrl="~/Images/Omega.jpg" Width="155px" />
            <asp:Image ID="Image2" runat="server" Height="73px" ImageUrl="~/Images/car.jpg" Width="138px" />
                 </div>
    </form>
</body>
</html>
