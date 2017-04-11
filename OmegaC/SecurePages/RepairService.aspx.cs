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

    using TableService = dsOmegaC.serviceDataTable;

    public partial class RepairService : System.Web.UI.Page
    {
        serviceTableAdapter adpServices = new serviceTableAdapter();
        TableService tblservices = new TableService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RefreshGridView();
            }
        }

        private void RefreshGridView()
        {
            adpServices.Fill(tblservices);  // Fill the data table
            grdServices.DataSource = tblservices;
            grdServices.DataBind();

            lblMessage.Text = "Data loaded";
            lblMessage.ForeColor = Color.Yellow;
        }

        protected void btnLoad_Click(object sender, EventArgs e)
        {

            decimal servNum = Convert.ToInt16(txtServiceNumber.Text);

            // Fill the data table with a row based on the servNumber
            adpServices.FillBy(tblservices, servNum);

            // if something was fetched
            if (tblservices.Rows.Count > 0)
            {
                // assign the row to the Row object
                var row = tblservices[0];

                // assign the values from the row to the textboxes
                txtServiceNumber.Text = InputData.dataInput(row.servNum);
                txtLaborPrice.Text = InputData.dataInput(row.laborPrice);
                txtPartPrice.Text = InputData.dataInput(row.partPrice);
                txtTax.Text = InputData.dataInput(row.tax);
                txtWorkDetail.Text = InputData.dataInput(row.info);
                txtCustomerID.Text = InputData.dataInput(row.customerID);
                txtCarSerial.Text = InputData.dataInput(row.serial);

                lblMessage.Text = "Record found";
                lblMessage.ForeColor = Color.Yellow;
            }
            else
            {
                lblMessage.Text = "Record not found";
                lblMessage.ForeColor = Color.Red;
            }
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            int result = adpServices.Insert(Convert.ToDecimal(txtServiceNumber.Text), Convert.ToDecimal(txtLaborPrice.Text), Convert.ToDecimal(txtPartPrice.Text), Convert.ToDecimal(txtTax.Text),
                txtWorkDetail.Text, Convert.ToDecimal(txtCustomerID.Text),txtCarSerial.Text);


            if (result == 1)
            {
                RefreshGridView();
                lblMessage.Text = "New Recode Added";
                lblMessage.ForeColor = Color.Yellow;
            }
            else
            {
                lblMessage.Text = "New Recode not Added";
                lblMessage.ForeColor = Color.Red;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            decimal servNum = Convert.ToInt16(txtServiceNumber.Text);

            // Fill the data table with a row based on the servNumber
            adpServices.FillBy(tblservices, servNum);

            // if something was fetched
            if (tblservices.Rows.Count > 0)
            {

                var row = tblservices[0];


                row.servNum = Convert.ToDecimal(txtServiceNumber.Text);
                row.laborPrice = Convert.ToDecimal(txtLaborPrice.Text);
                row.partPrice = Convert.ToDecimal(txtPartPrice.Text);
                row.tax = Convert.ToDecimal(txtTax.Text);
                row.info = txtWorkDetail.Text;
                row.customerID = Convert.ToDecimal(txtCustomerID.Text);
                row.serial = txtCarSerial.Text;


                int result = adpServices.Update(tblservices);

                if (result == 1)
                {
                    RefreshGridView();
                    lblMessage.Text = "Record updated";
                    lblMessage.ForeColor = Color.Yellow;
                }
                else
                {
                    lblMessage.Text = "Record not updated";
                    lblMessage.ForeColor = Color.Red;
                }
            }

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            decimal servNum = Convert.ToInt16(txtServiceNumber.Text);

            int result = adpServices.Delete(servNum);

            if (result == 1)
            {
                RefreshGridView();
                lblMessage.Text = "Record deleted";
                lblMessage.ForeColor = Color.Yellow;
            }
            else
            {
                lblMessage.Text = "Record not deleted";
                lblMessage.ForeColor = Color.Red;
            }
        }
    }
}