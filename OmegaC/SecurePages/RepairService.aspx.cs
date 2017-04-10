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
            lblMessage.ForeColor = Color.Green;
        }

        protected void btnLoad_Click(object sender, EventArgs e)
        {

        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}