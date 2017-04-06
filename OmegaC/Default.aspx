<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OmegaC._default" %>

<%@ Register src="UserControls/HeaderUserControl.ascx" tagname="HeaderUserControl" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <uc1:HeaderUserControl ID="HeaderUserControl1" runat="server" />
    
    </div>

    <div style="margin:0 auto 0 auto; width:400px; color: #0000FF; font-size: medium;">
    <p> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Welcome OmegaC Management System!!</p>
        <p> &nbsp;</p>
        <h3 class="auto-style1" style="color: #FF00FF"> Please Log- in </h3>
        </div>
        <p>
            &nbsp;</p>
        <p>
             <div style="margin:0 auto 0 auto; width:400px;">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Image ID="Image1" runat="server" Height="74px" ImageUrl="~/Images/Omega.jpg" Width="155px" />
            <asp:Image ID="Image2" runat="server" Height="73px" ImageUrl="~/Images/car.jpg" Width="138px" />
                 </div>
        </p>
    </form>

    </body>
</html>
