using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OmegaC
{
    public partial class Login : System.Web.UI.Page
    {
        string cs = Data.GetConnectionString();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text.Trim();
            string password = txtPassWord.Text.Trim();

            if (AuthenticateUser(username, password))
            {
                lblMessage.Text = "Login success";
                lblMessage.ForeColor = Color.Green;

                Session["userName"] = username;
              
                Response.Redirect("~/MainPage.aspx");
            }
            else
            {
                lblMessage.Text = "Login failed";
                lblMessage.ForeColor = Color.Red;
            }
        }

        private bool AuthenticateUser(string username, string password)
        {          
           
            int result = 0;

            using (SqlConnection conn = new SqlConnection(cs))
            {
               
                SqlCommand cmd = new SqlCommand("spAuthenticateUser", conn);               
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                conn.Open();
                result = (int)cmd.ExecuteScalar();
               
            }

            if (result == 1)
                return true;
            else
                return false;

        }

        protected void txtCreateUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/CreateUser.aspx");
        }
    }
}