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
    using TableInvoices = dsOmegaC.invoiceDataTable;

    public partial class Invoice : System.Web.UI.Page
    {
        invoiceTableAdapter adpInvoices = new invoiceTableAdapter();
        TableInvoices tblInvoices = new TableInvoices();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RefreshGridView();
            }
        }


        private void RefreshGridView()
        {
            adpInvoices.Fill(tblInvoices);  // Fill the data table
            grdInvoices.DataSource = tblInvoices;
            grdInvoices.DataBind();

            lblMessage.Text = "Data loaded";
        }


        protected void btnLoad_Click(object sender, EventArgs e)
        {
            Decimal invoiceNumber = Convert.ToDecimal(txtInvoiceNumber.Text);

            // Fill the data table with a row based on the invoice number
            adpInvoices.FillBy(tblInvoices, invoiceNumber);

            // if something was fetched
            if (tblInvoices.Rows.Count > 0)
            {
                // assign the row to the Row object
                var row = tblInvoices[0];

                // assign the values from the row to the textboxes
                txtInvoiceNumber.Text =InputData.dataInput(row.invNum);
                CalendarUserControl1.SelectedDate = row.invDate.ToString();
                txtNetPrice.Text = InputData.dataInput(row.netPrice);
                txtTax.Text = InputData.dataInput(row.tax);
                txtOtherFees.Text = InputData.dataInput(row.otherFees);
                txtCustomerID.Text = InputData.dataInput(row.customerID);
                txtCarSerial.Text = InputData.dataInput(row.serial);
                txtEmployeeID.Text = InputData.dataInput(row.employeeID);

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
            int result = adpInvoices.Insert(Convert.ToDecimal(txtInvoiceNumber.Text), Convert.ToDateTime(CalendarUserControl1.SelectedDate), Convert.ToDecimal(txtNetPrice.Text), Convert.ToDecimal(txtTax.Text), Convert.ToDecimal(txtOtherFees.Text), Convert.ToDecimal(txtCustomerID.Text), txtCarSerial.Text, Convert.ToDecimal(txtEmployeeID.Text));


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
            Decimal invoiceNumber = Convert.ToDecimal(txtInvoiceNumber.Text);

            // Fill the data table with a row based on the invoice number
            adpInvoices.FillBy(tblInvoices, invoiceNumber);

            // if something was fetched
            if (tblInvoices.Rows.Count > 0)
            {
                // assign the row to the Row object
                var row = tblInvoices[0];
                row.invNum = Convert.ToDecimal(txtInvoiceNumber.Text);
                row.invDate = Convert.ToDateTime(CalendarUserControl1.SelectedDate);
                row.netPrice = Convert.ToDecimal(txtNetPrice.Text);
                row.tax = Convert.ToDecimal(txtTax.Text);
                row.otherFees = Convert.ToDecimal(txtOtherFees.Text);
                row.customerID = Convert.ToDecimal(txtCustomerID.Text);
                row.serial = txtCarSerial.Text;
                row.employeeID = Convert.ToDecimal(txtEmployeeID.Text);

                int result = adpInvoices.Update(tblInvoices);

                if (result == 1)
                {
                    RefreshGridView();
                    lblMessage.Text = "Invoice updated";
                    lblMessage.ForeColor = Color.Green;
                }
                else
                {
                    lblMessage.Text = "Invoice not updated";
                    lblMessage.ForeColor = Color.Red;
                }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Decimal invoiceNumber = Convert.ToDecimal(txtInvoiceNumber.Text);

            int result = adpInvoices.Delete(invoiceNumber);

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