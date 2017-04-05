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
    public partial class CreateUser : System.Web.UI.Page
    {

        string cs = Data.GetConnectionString();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreateUser_Click(object sender, EventArgs e)
        {
            lblMessage.ForeColor = Color.Red;
            string username = txtUserName.Text.Trim();
            string password = txtPassWord.Text.Trim();

            int result = 0;

            string query = "INSERT INTO users(username, password)VALUES(@username,@password);" ;

            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                conn.Open();            
                result = cmd.ExecuteNonQuery();
            }
            if (result == 0)
            {
                lblMessage.Text = "Not creates the user";
                
            }
            else
            {
                lblMessage.Text = "The user is Created";
            }

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx");
        }
    }
}