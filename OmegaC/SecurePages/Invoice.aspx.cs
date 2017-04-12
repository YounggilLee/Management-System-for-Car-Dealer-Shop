using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OmegaC.dsOmegaCTableAdapters;
using System.Data.SqlClient;
using System.Drawing;

namespace OmegaC.SecurePages
{
    
    using TableInvoices = dsOmegaC.invoiceDataTable;
    using TableCars = dsOmegaC.carDataTable;
    using TableCustomers = dsOmegaC.customerDataTable;

    public partial class Invoice : System.Web.UI.Page
    {
        invoiceTableAdapter adpInvoices = new invoiceTableAdapter();
        carTableAdapter adpCars = new carTableAdapter();
        customerTableAdapter adpCustomers = new customerTableAdapter();

        TableInvoices tblInvoices = new TableInvoices();
        TableCars tblCars = new TableCars();
        TableCustomers tblCustomers = new TableCustomers();

        string cs = Data.GetConnectionString("OmegaWindConnectionString");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RefreshGridView();
                loadCarSerial();
                loadCustomerID();
                loadEmplyoeeID();
            }
        }


        private void RefreshGridView()
        {
            adpInvoices.Fill(tblInvoices);  // Fill the data table
            grdInvoices.DataSource = tblInvoices;
            grdInvoices.DataBind();

            lblMessage.Text = "Data loaded";
            lblMessage.ForeColor = Color.Yellow;
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


                ddlCustomers.SelectedIndex = ddlCustomers.Items.IndexOf(ddlCustomers.Items.FindByValue(InputData.dataInput(row.customerID)));
                ddlCarSerials.SelectedIndex = ddlCarSerials.Items.IndexOf(ddlCarSerials.Items.FindByValue(row.serial));
                ddlEmployees.SelectedIndex = ddlEmployees.Items.IndexOf(ddlEmployees.Items.FindByValue(InputData.dataInput(row.employeeID)));

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
            int result = adpInvoices.Insert(Convert.ToDecimal(txtInvoiceNumber.Text), Convert.ToDateTime(CalendarUserControl1.SelectedDate), Convert.ToDecimal(txtNetPrice.Text), Convert.ToDecimal(txtTax.Text), Convert.ToDecimal(txtOtherFees.Text), Convert.ToDecimal(ddlCustomers.SelectedItem.Text), ddlCarSerials.SelectedItem.Text, Convert.ToDecimal(ddlEmployees.SelectedItem.Text));


            if (result == 1)
            {
                RefreshGridView();
                lblMessage.Text = "New Customer Added";
                lblMessage.ForeColor = Color.Yellow;
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
                row.customerID = Convert.ToDecimal(ddlCustomers.SelectedItem.Text);
                row.serial = ddlCarSerials.SelectedItem.Text;
                row.employeeID = Convert.ToDecimal(ddlEmployees.SelectedItem.Text);

                int result = adpInvoices.Update(tblInvoices);

                if (result == 1)
                {
                    RefreshGridView();
                    lblMessage.Text = "Invoice updated";
                    lblMessage.ForeColor = Color.Yellow;
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
                lblMessage.Text = "Invoice deleted";
                lblMessage.ForeColor = Color.Yellow;
            }
            else
            {
                lblMessage.Text = "Invoice not deleted";
                lblMessage.ForeColor = Color.Red;
            }
        }

        // load carserial data on winform from datatable
        public void loadCarSerial()
        {
            adpCars.FillBySerial(tblCars);  // Fill the data table           
            ddlCarSerials.DataSource = tblCars.Rows;
            ddlCarSerials.DataTextField = "serial";
            ddlCarSerials.DataValueField = "serial";
            ddlCarSerials.DataBind();

            ListItem liSelected = new ListItem("Select a Car Serial ", "-1");
            ddlCarSerials.Items.Insert(0, liSelected);
      
        }

        // load Customers data on winform from datatable
        public void loadCustomerID()
        {
            adpCustomers.FillByCust(tblCustomers);  // Fill the data table           
            ddlCustomers.DataSource = tblCustomers.Rows;
            ddlCustomers.DataTextField = "customerID";
            ddlCustomers.DataValueField = "customerID";
            ddlCustomers.DataBind();

            ListItem liSelected = new ListItem("Select a CustomerID ", "-1");
            ddlCustomers.Items.Insert(0, liSelected);
        }

        // load Customers data on winform from datatable
        public void loadEmplyoeeID()
        {
            string query = "SELECT employeeID FROM employee;";

            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    ddlEmployees.DataSource = reader;
                    ddlEmployees.DataTextField = "employeeID";
                    ddlEmployees.DataValueField = "employeeID";
                    ddlEmployees.DataBind();
                }
                catch (SqlException sqlEx)
                {

                    throw new Exception(sqlEx.ToString());
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.ToString());
                }
            }

            ListItem liSelected = new ListItem("Select a EmployessID ", "-1");
            ddlEmployees.Items.Insert(0, liSelected);
        }

    }
}