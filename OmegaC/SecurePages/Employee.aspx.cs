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

        string cs = Data.GetConnectionString("OmegaWindConnectionString");
        string query = "Select * from employee;";
        

        SqlConnection conn;
        SqlDataAdapter adapter;
        DataSet ds;
        SqlCommandBuilder cmdBuilder;
        DataTable tblEmployee;

        public Employee()
        {
            conn = new SqlConnection(cs);                   // connection object
            adapter = new SqlDataAdapter(query, conn);      // adapter object
            ds = new DataSet();                             // an empty dataset
            cmdBuilder = new SqlCommandBuilder(adapter);    // used to auto-generate SQL INSERT, UPDATE and DELETE queries based on the SELECT query
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void GetDataFromDB()
        {
            adapter.Fill(ds, "employee");
            tblEmployee = ds.Tables["employee"];

            // set the primary key
            tblEmployee.PrimaryKey = new DataColumn[] { tblEmployee.Columns["employeeID"] };
            Cache["tblemployee"] = tblEmployee;

            grdEmployee.DataSource = tblEmployee;
            grdEmployee.DataBind();

            lblMessage.Text = "Data loaded from database";
            lblMessage.ForeColor = Color.Yellow;
        }

        private void GetDataFromCache()
        {           

            if (Cache["tblemployee"] != null)
            {
                tblEmployee = (DataTable)Cache["tblemployee"];

                grdEmployee.DataSource = tblEmployee;
                grdEmployee.DataBind();

                lblMessage.Text = "Data loaded from cache";
                lblMessage.ForeColor = Color.Yellow;
            }
        }

        protected void btnLoadData_Click(object sender, EventArgs e)
        {
            GetDataFromDB();
        }

        protected void grdEmployee_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdEmployee.EditIndex = e.NewEditIndex;
            GetDataFromCache();
        }

        protected void grdEmployee_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            tblEmployee = (DataTable)Cache["tblemployee"];

            // find the row based on the primary key
            DataRow row = tblEmployee.Rows.Find(e.Keys["employeeID"]);
            
            row["firstName"] = e.NewValues["firstName"];
            row["lastName"] = e.NewValues["lastName"];
            row["salary"] = e.NewValues["salary"];
            row["sales"] = e.NewValues["sales"];
            row["commission"] = e.NewValues["commission"];

            grdEmployee.EditIndex = -1;
            GetDataFromCache();

            lblMessage.Text = "Record updated";
            lblMessage.ForeColor = Color.Yellow;
        }



        protected void grdEmployee_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdEmployee.EditIndex = -1;
            GetDataFromCache();
        }

        protected void grdEmployee_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            tblEmployee = (DataTable)Cache["tblemployee"];

            DataRow row = tblEmployee.Rows.Find(e.Keys["employeeID"]);
            row.Delete();

            GetDataFromCache();
            lblMessage.Text = "Record deleted";
            lblMessage.ForeColor = Color.Red;
        }

        protected void btnSaveData_Click(object sender, EventArgs e)
        {
            // save the changes back to the database
            tblEmployee = (DataTable)Cache["tblemployee"];

            adapter.UpdateCommand = cmdBuilder.GetUpdateCommand();
            adapter.DeleteCommand = cmdBuilder.GetDeleteCommand();

            int result = adapter.Update(tblEmployee);

            if (result > 0)
            {
                lblMessage.Text = "Data saved to database";
                lblMessage.ForeColor = Color.Yellow;
            }
            else
            {
                lblMessage.Text = "No changes were made in the gridview";
                lblMessage.ForeColor = Color.Red;
            }
        }

        protected void btnUndo_Click(object sender, EventArgs e)
        {
            tblEmployee = (DataTable)Cache["tblemployee"];

            tblEmployee.RejectChanges();
            GetDataFromCache();

            lblMessage.Text = "Changes undone";
            lblMessage.ForeColor = Color.Red;
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {

            try { 
            DataTable tblEmployee = (DataTable)Cache["tblemployee"];

            DataRow newRow = tblEmployee.NewRow();  // create a new row
            newRow["employeeID"] = txtEmployeeID.Text;
            newRow["firstName"] = txtFirstName.Text;
            newRow["lastName"] = txtLastName.Text;
            newRow["salary"] = txtSalary.Text;
            newRow["commission"] = txtCommission.Text;
            tblEmployee.Rows.Add(newRow);   // add the new row to the Rows collection

            adapter.InsertCommand = cmdBuilder.GetInsertCommand();
            int result = adapter.Update(tblEmployee);

            if (result == 1)
            {
                lblMessage.Text = "New Employee is inserted";
                lblMessage.ForeColor = Color.Yellow;

                grdEmployee.DataSource = tblEmployee;
                grdEmployee.DataBind();
            }
            else
            {
                lblMessage.Text = "New Employee is not inserted";
                lblMessage.ForeColor = Color.Red;
            }
            clearTextBox();

        }
            catch (SqlException sqlEx)
            {
                msgBox(sqlEx.ToString());
            }
            catch (Exception ex)
            {

                msgBox("Check the input");
}
        }


        private void clearTextBox()
        {
            txtEmployeeID.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtSalary.Text = string.Empty;
            txtCommission.Text = string.Empty;

        }

        //create by choongwon
        public void msgBox(string msg)
        {

            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message Box", "<script language='javascript'>alert('" + msg + "')</script>");
        }

    }

}