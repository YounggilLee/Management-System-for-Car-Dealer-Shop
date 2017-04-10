using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OmegaC.dsOmegaCTableAdapters;

namespace OmegaC.SecurePages
{
    using TableOptions = dsOmegaC.optionsDataTable;
    public partial class Option : System.Web.UI.Page
    {
        optionsTableAdapter adpOptions = new optionsTableAdapter();
        TableOptions tblOptions = new TableOptions();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RefreshGridView();
            }
        }

        private void RefreshGridView()
        {
            adpOptions.Fill(tblOptions);  // Fill the data table
            grdOptions.DataSource = tblOptions;
            grdOptions.DataBind();

            lblMessage.Text = "Data loaded";
            lblMessage.ForeColor = Color.Green;
        }

        protected void btnLoad_Click(object sender, EventArgs e)
        {
            string optionCode = txtOptionCode.Text;

            // Fill the data table with a row based on the optioncode
            adpOptions.FillBy(tblOptions, optionCode);

            // if something was fetched
            if (tblOptions.Rows.Count > 0)
            {
                // assign the row to the Row object
                var row = tblOptions[0];

                // assign the values from the row to the textboxes
              
                txtOptionCode.Text = InputData.dataInput(row.optionCode);
                txtOptionPrice.Text = InputData.dataInput(row.optionPrice);
                txtOptionDesc.Text = InputData.dataInput(row.OptionDesc);              
                txtCarSerial.Text = InputData.dataInput(row.serial);

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
            int result = adpOptions.Insert(txtOptionCode.Text, Convert.ToDecimal(txtOptionPrice.Text), txtOptionDesc.Text, txtCarSerial.Text);


            if (result == 1)
            {
                RefreshGridView();
                lblMessage.Text = "New Option Added";
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
            string optionCode = txtOptionCode.Text;

            // Fill the data table with a row based on the Optioncode
            adpOptions.FillBy(tblOptions, optionCode);

            // if something was fetched
            if (tblOptions.Rows.Count > 0)
            {

                var row = tblOptions[0];
                
                row.optionCode = txtOptionCode.Text;
                row.optionPrice = Convert.ToDecimal(txtOptionPrice.Text);
                row.OptionDesc = txtOptionDesc.Text;
                row.serial = txtCarSerial.Text;

                int result = adpOptions.Update(tblOptions);

                if (result == 1)
                {
                    RefreshGridView();
                    lblMessage.Text = "Option updated";
                    lblMessage.ForeColor = Color.Green;
                }
                else
                {
                    lblMessage.Text = "Option not updated";
                    lblMessage.ForeColor = Color.Red;
                }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string optionCode = txtOptionCode.Text;

            // Fill the data table with a row based on the Optioncode
            adpOptions.FillBy(tblOptions, optionCode);

            // if something was fetched
            if (tblOptions.Rows.Count > 0)
            {
                
                RefreshGridView();
                lblMessage.Text = "Option deleted";
                lblMessage.ForeColor = Color.Green;
            }
            else
            {
                lblMessage.Text = "Option not deleted";
                lblMessage.ForeColor = Color.Red;
            }
        }
    }
}