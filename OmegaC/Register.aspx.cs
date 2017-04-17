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

    // Author: Younggl Lee
    // Register user management page which have a register function.    
    public partial class CreateUser : System.Web.UI.Page
    {
        /// <summary>
        /// Stored connection string using data class as string
        /// </summary>
        string cs = Data.GetConnectionString();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// The method is executed by clicking the register button.
        /// To create new user.
        /// </summary>
        /// <param name="username">the data from the user</param>
        /// <param name="password">the data form the user</param>
        protected void btnCreateUser_Click(object sender, EventArgs e)
        {
            //set message color
            lblMessage.ForeColor = Color.Red;

            //stored user name
            string username = txtUserName.Text.Trim();
            
            //stored user password is encrypted
            string password = Encryptor.EncryptText(txtPassWord.Text.Trim());
          
            //if the user is already existed
            if (UserExists(username))
            {
                //diplay message
                lblMessage.Text = "This username is already taken. Please try again.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
            //if not 
            else
            {
                //if create the user
                if (CreateUsers(username, password))
                {
                    lblMessage.Text = "User registered";
                    lblMessage.ForeColor = System.Drawing.Color.Yellow;
                }
                else
                {
                    lblMessage.Text = "User not registered";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        /// <summary>
        /// The method is for checking the user is exsited
        /// </summary>
        /// <param name="query"> store sql aquery as string</param>
        /// <param name="result"> store result of executescalar</param>
        /// <returns>true or false </returns>
        private bool UserExists(string username)
        {
            //store sql query
            string query = "Select Count(Username) from users where Username = @Username;";

            //store result of executed sql query
            int result;

            // instance Sqlconnection using connection string
            using (SqlConnection conn = new SqlConnection(cs))
            {
                //instance sqlcommand using conn and query
                SqlCommand cmd = new SqlCommand(query, conn);
                
                //add value
                cmd.Parameters.AddWithValue("@Username", username);

                //connection open
                conn.Open();

                //execute and get the result
                result = (int)cmd.ExecuteScalar();
            }

            if (result == 1) return true;
            else return false;
        }


        /// <summary>
        /// The method is for create a user
        /// </summary>
        /// <param name="query"> store sql aquery as string</param>
        /// <param name="result"> store result of executescalar</param>
        /// <returns>true or false</returns>
        private bool CreateUsers(string username, string password)
        {
            //store sql query
            string query = "Insert into users (username, password) values (@Username, @Password);";

            //store result of executed sql query
            int result = 0;

            // instance Sqlconnection using connection string
            using (SqlConnection conn = new SqlConnection(cs))
            {
                //instance sqlcommand using conn and query
                SqlCommand cmd = new SqlCommand(query, conn);
                //add value
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);
                //connection open
                conn.Open();

                //execute and get the result
                result = (int)cmd.ExecuteNonQuery();
            }

            if (result == 1) return true;
            else return false;
        }

        /// <summary>
        /// move the user back to login page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx");
        }
    }
}