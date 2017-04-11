<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OmegaC._default" %>

<%@ Register src="UserControls/HeaderUserControl.ascx" tagname="HeaderUserControl" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Welcom Page</title>
    <link rel="stylesheet" type="text/css" href="~/Styles/Styles.css">
    <style type="text/css">
        .auto-style3 {
            width: 608px;
            margin-left: 120px;
        }
        .auto-style4 {
            width: 398px;
            height: 29px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <uc1:HeaderUserControl ID="HeaderUserControl1" runat="server" />
    
    </div>

    <div style="margin:0 auto 0 auto; color: #FFFF00; font-size: medium;" class="auto-style4">
    <p> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Welcome OmegaC Management System!!</p>
        <p> &nbsp;</p>
        
        </div>
        <h3 style="text-align:center; color:darkred;">
            Please Log- in </h3>
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
