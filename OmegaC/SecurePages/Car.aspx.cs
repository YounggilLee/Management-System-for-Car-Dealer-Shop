using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OmegaC.dsOmegaCTableAdapters;
using System.Drawing;

namespace OmegaC.SecurePages
{
   
    using TableCars = dsOmegaC.carDataTable;

    public partial class Vehicle : System.Web.UI.Page
    {       
        carTableAdapter adpCars = new carTableAdapter();
        TableCars tblcars = new TableCars();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RefreshGridView();
            }
        }

        private void RefreshGridView()
        {
            adpCars.Fill(tblcars);  // Fill the data table
            grdCars.DataSource = tblcars;
            grdCars.DataBind();

            lblMessage.Text = "Data loaded";
            lblMessage.ForeColor = Color.Green;
        }

        protected void btnLoad_Click(object sender, EventArgs e)
        {
            string carSerial = txtCarSerial.Text;

            // Fill the data table with a row based on the carSerial
            adpCars.FillBy(tblcars, carSerial);

            // if something was fetched
            if (tblcars.Rows.Count > 0)
            {
                // assign the row to the Row object
                var row = tblcars[0];

                // assign the values from the row to the textboxes
                txtCarSerial.Text = row.serial;
                txtCarMake.Text = row.make;
                txtCarModel.Text = row.model;
                txtCarYear.Text = row.cyear.ToString();
                txtCarPrice.Text = row.price.ToString();               

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
            int result = adpCars.Insert(txtCarSerial.Text, txtCarMake.Text, txtCarModel.Text, Convert.ToDecimal(txtCarYear.Text), Convert.ToDecimal(txtCarPrice.Text));


            if (result == 1)
            {
                RefreshGridView();
                lblMessage.Text = "New Car Added";
                lblMessage.ForeColor = Color.Green;
            }
            else
            {
                lblMessage.Text = "New Car not Added";
                lblMessage.ForeColor = Color.Red;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string carSerial = txtCarSerial.Text;

            // Fill the data table with a row based on the carSerial
            adpCars.FillBy(tblcars, carSerial);

            // if something was fetched
            if (tblcars.Rows.Count > 0)
            {

                var row = tblcars[0];
                row.serial = txtCarSerial.Text;
                row.make = txtCarMake.Text;
                row.model = txtCarModel.Text;
                row.cyear = Convert.ToDecimal(txtCarYear.Text);
                row.price = Convert.ToDecimal(txtCarPrice.Text);

                int result = adpCars.Update(tblcars);

                if (result == 1)
                {
                    RefreshGridView();
                    lblMessage.Text = "Car updated";
                    lblMessage.ForeColor = Color.Green;
                }
                else
                {
                    lblMessage.Text = "Car not updated";
                    lblMessage.ForeColor = Color.Red;
                }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string carSerial = txtCarSerial.Text;

            int result = adpCars.Delete(carSerial);

            if (result == 1)
            {
                RefreshGridView();
                lblMessage.Text = "Car deleted";
                lblMessage.ForeColor = Color.Green;
            }
            else
            {
                lblMessage.Text = "Car not deleted";
                lblMessage.ForeColor = Color.Red;
            }
        }
    }
}