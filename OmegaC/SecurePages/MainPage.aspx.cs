using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OmegaC
{
    public partial class MainPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string loginUserName = Session["userName"] + "\t\t";
            lblLoginUser.Text = loginUserName;
            lblLoginUser.ForeColor = Color.Red;
            lblMessage.Text = "Welcome OmegaC System!!";
           

        }
    }
}