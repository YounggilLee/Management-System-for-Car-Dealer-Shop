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
            string password = Encryptor.EncryptText(txtPassWord.Text.Trim());
            //string password = txtPassWord.Text.Trim();

            if (UserExists(username))
            {
                lblMessage.Text = "This username is already taken. Please try again.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                if (CreateUsers(username, password))
                {
                    lblMessage.Text = "User registered";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblMessage.Text = "User not registered";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        private bool UserExists(string username)
        {
            string query = "Select Count(Username) from users where Username = @Username;";

            int result;

            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                conn.Open();

                result = (int)cmd.ExecuteScalar();
            }

            if (result == 1) return true;
            else return false;
        }

        private bool CreateUsers(string username, string password)
        {
            string query = "Insert into users (username, password) values (@Username, @Password);";
            int result = 0;

            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);
                conn.Open();

                result = (int)cmd.ExecuteNonQuery();
            }

            if (result == 1) return true;
            else return false;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx");
        }
    }
}