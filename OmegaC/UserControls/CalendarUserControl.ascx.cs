using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OmegaC.UserControls
{
    public partial class CalendarUserControl : System.Web.UI.UserControl
    {
        //property that returns the value of the date text box
        public string SelectedDate
        {
            get { return txtDate.Text; }
            set { txtDate.Text = value; }

        }



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // hide the calendar on page load
                Calendar1.Visible = false;
            }
        }

        protected void ibtnCalendar_Click(object sender, ImageClickEventArgs e)
        {
            // toggle the visibility of the calendar
            Calendar1.Visible = !Calendar1.Visible;
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            // assign the selected date to the text box
            //txtDate.Text = Calendar1.SelectedDate.ToShortDateString();
            txtDate.Text = Calendar1.SelectedDate.ToString("MM/dd/yyyy");
            Calendar1.Visible = false;
        }
    }
}