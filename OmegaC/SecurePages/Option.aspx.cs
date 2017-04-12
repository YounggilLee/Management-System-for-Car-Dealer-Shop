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
    using TableCars = dsOmegaC.carDataTable;

    public partial class Option : System.Web.UI.Page
    {
        carTableAdapter adpCars = new carTableAdapter();   
        optionsTableAdapter adpOptions = new optionsTableAdapter();

        TableOptions tblOptions = new TableOptions();
        TableCars tblCars = new TableCars();

       // string cs = Data.GetConnectionString("OmegaWindConnectionString");


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RefreshGridView();
                loadCarSerial();

            }

          
        }

        private void RefreshGridView()
        {
            adpOptions.Fill(tblOptions);  // Fill the data table
            grdOptions.DataSource = tblOptions;
            grdOptions.DataBind();
            

            lblMessage.Text = "Data loaded";
            lblMessage.ForeColor = Color.Yellow;


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
                ddlCarSerials.SelectedIndex = ddlCarSerials.Items.IndexOf(ddlCarSerials.Items.FindByValue(row.serial));

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
            int result = adpOptions.Insert(txtOptionCode.Text, Convert.ToDecimal(txtOptionPrice.Text), txtOptionDesc.Text, ddlCarSerials.SelectedItem.Text);


            if (result == 1)
            {
                RefreshGridView();
                lblMessage.Text = "New Option Added";
                lblMessage.ForeColor = Color.Yellow;
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
                row.serial = ddlCarSerials.SelectedItem.Text;

                int result = adpOptions.Update(tblOptions);

                if (result == 1)
                {
                    RefreshGridView();
                    lblMessage.Text = "Option updated";
                    lblMessage.ForeColor = Color.Yellow;
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
                lblMessage.ForeColor = Color.Yellow;
            }
            else
            {
                lblMessage.Text = "Option not deleted";
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


    }
}