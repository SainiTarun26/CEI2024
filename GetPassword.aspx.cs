using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana
{
    public partial class GetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {

        }

        protected void ddluserCategary_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddluserCategary.SelectedValue =="1")
            {
                gstno.Visible = true;
                pantanno.Visible = false;
            }
            else if (ddluserCategary.SelectedValue == "2")
            {
                gstno.Visible = false;
                pantanno.Visible = false;
            }
            else if (ddluserCategary.SelectedValue == "3")
            {
                gstno.Visible = false;
                pantanno.Visible = true;
            }
            else if (ddluserCategary.SelectedValue == "4")
            {
                gstno.Visible = false;
                pantanno.Visible = false;
            }
        }
    }
}