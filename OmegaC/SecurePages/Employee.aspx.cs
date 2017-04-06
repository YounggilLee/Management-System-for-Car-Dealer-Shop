using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;

namespace OmegaC.SecurePages
{
    public partial class Employee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void GetDataFromDB()
        {
            string cs = Data.GetConnectionString("OmegaWindConnectionString");
            SqlConnection con = new SqlConnection(cs);
            string selectQuery = "Select * from employee";
            SqlDataAdapter da = new SqlDataAdapter(selectQuery, con);

            DataSet ds = new DataSet();
            da.Fill(ds, "employee");

            ds.Tables["employee"].PrimaryKey = new DataColumn[] { ds.Tables["employee"].Columns["employeeID"] };

            Cache.Insert("DATASET", ds, null);

            grdEmployee.DataSource = ds;
            grdEmployee.DataBind();
            lblMessage.Text = " Data Loaded from Database";
            lblMessage.ForeColor = Color.Green;

            
        }

        private void GetDataFromCache()
        {
            if(Cache["DATASET"] != null)
            {
                DataSet ds = (DataSet)Cache["DATASET"];
                grdEmployee.DataSource = ds;
                grdEmployee.DataBind();
            }
        }

        protected void btnLoadData_Click(object sender, EventArgs e)
        {
            GetDataFromDB();
        }

        protected void grdEmployee_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void grdEmployee_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void grdEmployee_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected void grdEmployee_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}