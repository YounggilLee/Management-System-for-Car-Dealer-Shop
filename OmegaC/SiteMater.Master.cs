using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OmegaC
{
    public partial class SiteMater : System.Web.UI.MasterPage
    {
        //public string TextBoxOnMasterPage
        //{
        //    get { return txtMasterPageTextBox.Text; }
        //}

        public string LabelOnMasterPage
        {
            set { lblMessage.Text = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //protected void btnOk_Click(object sender, EventArgs e)
        //{

        //}
    }
}