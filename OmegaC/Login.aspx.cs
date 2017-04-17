using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OmegaC
{
    // Author: Younggl Lee
    // Create user management page which have log-ing functions.
    // Prevent data injection from anonymous users using stored procedurs
    // and implement secure page.
    public partial class Login : System.Web.UI.Page
    {

        /// <summary>
        /// Stored connection string using data class as string
        /// </summary>
        string cs = Data.GetConnectionString();

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// The method is for user log-in. password is encryted by MD5 and 
        /// authenticate the uer. move the uer to secure page and save the username
        /// as ssession value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLogin_Click(object sender, EventArgs e)
        {

           //Input data from user
           string username = txtUserName.Text.Trim();
            
           // input data from user and then encrypt password using MD5
           string password = Encryptor.EncryptText(txtPassWord.Text.Trim());

            // pass input data to the method in order to authentication if the user is authenticated 
            if (AuthenticateUser(username, password))
            {
                //redirect user page to the sercure pages
                FormsAuthentication.RedirectFromLoginPage(username, false);              

                //stroed user name as session value
                Session["userName"] = username;              
               
            }
            //if failed,
            else
            {
                lblMessage.Text = "Login failed";
                lblMessage.ForeColor = Color.Red;
            }
        }

        /// <summary>
        /// The method is for authenticate login user
        /// </summary>
        /// <param name="username">the value from the user</param>
        /// <param name="password">the value from the user</param>
        /// <returns>true or false </returns>
        private bool AuthenticateUser(string username, string password)
        {          
            //stored result value of excutescalr
            int result = 0;

            // instance Sqlconnection using connection string
            using (SqlConnection conn = new SqlConnection(cs))
            {
               //instance sqlcommand using conn and stored procedures
                SqlCommand cmd = new SqlCommand("spAuthenticateUser", conn);               
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                
                //add values
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                //connection open
                conn.Open();

                //excute and get the result
                result = (int)cmd.ExecuteScalar();
               
            }

            //if find the user and match password
            if (result == 1)
                return true;
            else
                return false;

        }

        /// <summary>
        /// The method is executed by clicking the register button.
        /// Move the user to register page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void txtCreateUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Register.aspx");
        }
    }
}