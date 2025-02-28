using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Supervisor
{
    public partial class SwitchingSubstationTestReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    txtapplication.Text = Session["ApplicationForTestReport"].ToString().Trim();
                    txtInstallation.Text = Session["Typs"].ToString().Trim();
                    txtid.Text = Session["ID"].ToString().Trim();
                    txtNOOfInstallation.Text = Session["NoOfInstallations"].ToString().Trim() + " Out of " + Session["TotalInstallation"].ToString().Trim();
                    txtApplicantType.Text = Session["ApplicantType"].ToString().Trim();
                }
            }
            catch
            {
                Response.Redirect("/Login.aspx");
            }
        }
        protected void ddlEarthingsubstation_SelectedIndexChanged(object sender, EventArgs e)
        {
            EarthingSubstation.Visible = true;
            int selectedValue = Convert.ToInt32(ddlEarthingsubstation.SelectedValue);

            for (int i = 1; i <= 40; i++)
            {
                Control div = FindControl("EarthingSubstation" + i);
                if (div != null)
                {
                    div.Visible = (i <= selectedValue);
                }
            }
        }

    }
}