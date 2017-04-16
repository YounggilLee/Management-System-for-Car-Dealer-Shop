using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace OmegaC.UserControls
{
    public partial class HeaderUserControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["userName"] != null)
            {
                lblMessage.Text = "Login User ID :";
                lblUserName.Text =  Session["userName"].ToString();
                lblUserName.ForeColor = Color.Yellow;
                lblMessage.ForeColor = Color.WhiteSmoke;
                btnLogOut.Visible = true;

            }
            else
            {
                btnLogOut.Visible = false;
            }
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.Clear();           
            FormsAuthentication.SignOut();
            Response.Redirect("~/Login.aspx");
        }


       
    }
}