using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OmegaC.dsOmegaCTableAdapters;

namespace OmegaC.SecurePages
{
    using System.Drawing;
    using TableCustomers = dsOmegaC.customerDataTable;

    public partial class Customer : System.Web.UI.Page
    {

        customerTableAdapter adpCustomers = new customerTableAdapter();
        TableCustomers tblCustomers = new TableCustomers();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                RefreshGridView();
            }

        }

        private void RefreshGridView()
        {
            adpCustomers.Fill(tblCustomers);  // Fill the data table
            grdCustomers.DataSource = tblCustomers;
            grdCustomers.DataBind();

            lblMessage.Text = "Data loaded";
        }

        protected void btnLoad_Click(object sender, EventArgs e)
        {
            Decimal customerID = Convert.ToDecimal(txtCustomerID.Text);

            // Fill the data table with a row based on the customer ID
            adpCustomers.FillBy(tblCustomers, customerID);

            // if something was fetched
            if (tblCustomers.Rows.Count > 0)
            {
                // assign the row to the Row object
                var row = tblCustomers[0];

                // assign the values from the row to the textboxes
                txtCustomerID.Text = row.customerID.ToString();
                txtFirstName.Text = row.firstName;
                txtLastName.Text = row.lastName;
                txtAddress.Text = row.address;
                txtPhone.Text = row.phone.ToString();

                lblMessage.Text = "Record found";
                lblMessage.ForeColor = Color.Green;
            }
            else
            {
                lblMessage.Text = "Record not found";
                lblMessage.ForeColor = Color.Red;
            }
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            // create a new row
            // fill the row
            // add the row to the data table
            //var newRow = tblProducts.NewProductsRow();
            //newRow.ProductName = txtProductName.Text;
            //newRow.UnitPrice = Convert.ToDecimal(txtProductPrice.Text);
            //newRow.UnitsInStock = Convert.ToInt16(txtProductQuantity.Text);
            //tblProducts.AddProductsRow(newRow);

            // call the Update() method execute the insert sql query on the database
            //int result = adpProducts.Update(tblProducts);

            // or, call the Insert() method on the adapter
            int result = adpCustomers.Insert(Convert.ToDecimal(txtCustomerID.Text), txtFirstName.Text, txtLastName.Text, txtAddress.Text, Convert.ToDecimal(txtPhone.Text));


            if (result == 1)
            {
                RefreshGridView();
                lblMessage.Text = "New Customer Added";
                lblMessage.ForeColor = Color.Green;
            }
            else
            {
                lblMessage.Text = "New Customer not Added";
                lblMessage.ForeColor = Color.Red;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            int customerID = Convert.ToInt16(txtCustomerID.Text);

            // Fill the data table with a row based on the customer ID
            adpCustomers.FillBy(tblCustomers, customerID);

            // if something was fetched
            if (tblCustomers.Rows.Count > 0)
            {
                // assign the row to the Row object
                var row = tblCustomers[0];
                row.customerID = Convert.ToDecimal(txtCustomerID.Text);
                row.firstName = txtFirstName.Text;
                row.lastName = txtLastName.Text;
                row.address = txtAddress.Text;
                row.phone = Convert.ToDecimal(txtPhone.Text);

                int result = adpCustomers.Update(tblCustomers);

                if (result == 1)
                {
                    RefreshGridView();
                    lblMessage.Text = "Customer updated";
                    lblMessage.ForeColor = Color.Green;
                }
                else
                {
                    lblMessage.Text = "Customer not updated";
                    lblMessage.ForeColor = Color.Red;
                }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int customerID = Convert.ToInt16(txtCustomerID.Text);

            int result = adpCustomers.Delete(customerID);

            if (result == 1)
            {
                RefreshGridView();
                lblMessage.Text = "Customer deleted";
                lblMessage.ForeColor = Color.Green;
            }
            else
            {
                lblMessage.Text = "Customer not deleted";
                lblMessage.ForeColor = Color.Red;
            }

        }
    }
}