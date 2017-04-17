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
    /// <summary>
    /// create a class alias name
    /// </summary>
    using TableOptions = dsOmegaC.optionsDataTable;
    using TableCars = dsOmegaC.carDataTable;


    // Author: Younggl Lee
    // Create car option management page which have functions(load, 
    // insert, update and delete. Prevent the input error by using exception handling
    // and the use from the wrong input by using drop down box which have foreign keys.
    public partial class Option : System.Web.UI.Page
    {
        /// <summary>
        /// table adapter and data table objects
        /// </summary>
        optionsTableAdapter adpOptions = new optionsTableAdapter();
        carTableAdapter adpCars = new carTableAdapter();
        TableOptions tblOptions = new TableOptions();
        TableCars tblCars = new TableCars();

        /// <summary>
        /// Refresh the gridview when the page loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RefreshGridView();
                loadCarSerial();
            }
        }

        /// <summary>
        /// The method is for show option data in database
        /// </summary>
        private void RefreshGridView()
        {
            // Fill the data table
            adpOptions.Fill(tblOptions);  
            grdOptions.DataSource = tblOptions;
            grdOptions.DataBind();

            // Display status of option data loaded
            lblMessage.Text = "Data loaded";
            lblMessage.ForeColor = Color.Yellow;
        }

        /// <summary>
        /// The load method is executed by clicking the load button with 
        /// the input data(Option code). 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLoad_Click(object sender, EventArgs e)
        {
            //stroe option code
            string optionCode = txtOptionCode.Text;

            // Fill the data table with a row based on the optioncode
            adpOptions.FillBy(tblOptions, optionCode);


            // if something was fetched
            if (tblOptions.Rows.Count > 0)
            {
                //assign the row to the Row object
                var row = tblOptions[0];

                // assign the values from the row to the textboxes
                txtOptionCode.Text = InputData.dataInput(row.optionCode);
                txtOptionPrice.Text = InputData.dataInput(row.optionPrice);
                txtOptionDesc.Text = InputData.dataInput(row.OptionDesc);
                ddlCarSerials.SelectedIndex = ddlCarSerials.Items.IndexOf(ddlCarSerials.Items.FindByValue(row.serial));

                // Display status of option data
                lblMessage.Text = "Record found";
                lblMessage.ForeColor = Color.Yellow;
            }
            //if sometihg was not fetched
            else
            {
                // Display status of option data
                lblMessage.Text = "Record not found";
                lblMessage.ForeColor = Color.Red;
            }
        }

        /// <summary>
        /// The insert method is executed by clicking the insert button with 
        /// the input data. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            //implement the exception handling
            try
            {
                //Insert data and get the result of data insertion
                int result = adpOptions.Insert(txtOptionCode.Text, Convert.ToDecimal(txtOptionPrice.Text), txtOptionDesc.Text, ddlCarSerials.SelectedItem.Text);

                //if the insertion is successful
                if (result == 1)
                {
                    RefreshGridView();
                    lblMessage.Text = "New Option Added";
                    lblMessage.ForeColor = Color.Yellow;
                }
                //if failed, show failiure messgae
                else
                {
                    lblMessage.Text = "New Car not Added";
                    lblMessage.ForeColor = Color.Red;
                }

                // clear the all input text boxes
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

        /// <summary>
        /// The update method is executed by clicking the update button with 
        /// the input data. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //implement the exception handling
            try
            {
                // Stroed the option value
                string optionCode = txtOptionCode.Text;

                // Fill the data table with a row based on the Optioncode
                adpOptions.FillBy(tblOptions, optionCode);

                // if something was fetched
                if (tblOptions.Rows.Count > 0)
                {
                    //assign the row to the Row object
                    var row = tblOptions[0];

                    // put the values in tbloption
                    row.optionCode = txtOptionCode.Text;
                    row.optionPrice = Convert.ToDecimal(txtOptionPrice.Text);
                    row.OptionDesc = txtOptionDesc.Text;
                    row.serial = ddlCarSerials.SelectedItem.Text;


                    //update data and get the result
                    int result = adpOptions.Update(tblOptions);

                    //if the update is successful
                    if (result == 1)
                    {
                        RefreshGridView();
                        lblMessage.Text = "Option updated";
                        lblMessage.ForeColor = Color.Yellow;
                    }
                    //if failed, show failiure messgae
                    else
                    {
                        lblMessage.Text = "Option not updated";
                        lblMessage.ForeColor = Color.Red;
                    }

                }
                // clear the all input text boxes
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


        /// <summary>
        /// The delete method is executed by clicking the delete button with 
        /// the input data.  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
               //implement the exception handling
            try
            {
                // Stroed the option value
                string optionCode = txtOptionCode.Text;

                //Delet data and get the result of data insertion
                int result = adpOptions.Delete(optionCode);

                //if the delete is successful
                if (result == 1)
                {
                    RefreshGridView();
                    lblMessage.Text = "Record deleted";
                    lblMessage.ForeColor = Color.Yellow;
                }
                //if failed, show failiure messgae
                else
                {
                    lblMessage.Text = "Record not deleted";
                    lblMessage.ForeColor = Color.Red;
                }
                //if failed, show failiure messgae
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



        /// <summary>
        /// The methode is for load carserial data on winform from datatable
        /// </summary>
        public void loadCarSerial()
        {
            // Fill the data table 
            adpCars.FillBySerial(tblCars);

            //assign data(serial column to grid view            
            ddlCarSerials.DataSource = tblCars.Rows;

            //set text,value field as the column 
            ddlCarSerials.DataTextField = "serial";
            ddlCarSerials.DataValueField = "serial";
            ddlCarSerials.DataBind();

            //set drop down box first index
            ListItem liSelected = new ListItem("Select a Car Serial ", "-1");
            ddlCarSerials.Items.Insert(0, liSelected);

        }

        /// <summary>
        /// The method is for clear the all text boxes when a task is done
        /// and make drop down box first index
        /// </summary>
        private void clearTextBox()
        {

            txtOptionCode.Text = string.Empty;
            txtOptionPrice.Text = string.Empty;
            txtOptionDesc.Text = string.Empty;
            ddlCarSerials.SelectedValue = "-1";

        }

        /// <summary>
        /// Author: Choongwon Lee
        /// Display warning by using alert box when exception happens
        /// </summary>
        /// <param name="msg"></param>
        public void msgBox(string msg)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), 
           "Message Box", "<script language='javascript'>alert('" + msg + "')</script>");
        }

    }
}