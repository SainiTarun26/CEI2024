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
            SubstationEarthingDiv.Visible = true;

            int numberOfEarthing = int.Parse(ddlEarthingsubstation.SelectedValue.Trim());

            for (int i = 4; i <= 100; i++)
            {
                Control earthingType = FindControl("EarthingSubstation" + i);
                if (earthingType != null)
                {
                    earthingType.Visible = (i <= numberOfEarthing);
                }
            }
        }
        protected void ddlUsedFor_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = sender as DropDownList;
            if (ddl != null)
            {
                // Extract number from the dropdown ID (assuming they follow ddlUsedFor1, ddlUsedFor2, ...)
                string index = ddl.ID.Replace("ddlUsedFor", "");

                // Find corresponding TextBox and RequiredFieldValidator
                TextBox txtOtherEarthing = FindControl("txtOtherEarthing" + index) as TextBox;
                RequiredFieldValidator validator = FindControl("RequiredFieldValidator" + index) as RequiredFieldValidator;

                if (txtOtherEarthing != null && validator != null)
                {
                    bool isOtherSelected = ddl.SelectedItem.ToString() == "Other";
                    txtOtherEarthing.Visible = isOtherSelected;
                    validator.Visible = isOtherSelected;
                }
            }
        }
        protected void ddlUsedFor1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsedFor1.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing1.Visible = true;
                RequiredFieldValidator99.Visible = true;
            }
            else
            {
                txtOtherEarthing1.Visible = false;
                RequiredFieldValidator99.Visible = false;

            }
        }

        protected void ddlUsedFor2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsedFor2.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing2.Visible = true;
                RequiredFieldValidator98.Visible = true;
            }
            else
            {
                txtOtherEarthing2.Visible = false;
                RequiredFieldValidator98.Visible = false;
            }
        }

        protected void ddlUsedFor3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsedFor3.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing3.Visible = true;
                RequiredFieldValidator97.Visible = true;
            }
            else
            {
                txtOtherEarthing3.Visible = false;
                RequiredFieldValidator97.Visible = false;
            }
        }

        protected void ddlUsedFor4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsedFor4.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing4.Visible = true;
                RequiredFieldValidator96.Visible = false;
            }
            else
            {
                txtOtherEarthing4.Visible = false;
                RequiredFieldValidator96.Visible = false;
            }
        }

        protected void ddlUsedFor5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsedFor5.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing5.Visible = true;
                RequiredFieldValidator95.Visible = true;
            }
            else
            {
                txtOtherEarthing5.Visible = false;
                RequiredFieldValidator95.Visible = false;
            }
        }

        protected void ddlUsedFor6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsedFor6.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing6.Visible = true;
                RequiredFieldValidator79.Visible = true;
            }
            else
            {
                txtOtherEarthing6.Visible = false;
                RequiredFieldValidator79.Visible = false;
            }
        }
        protected void ddlUsedFor7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsedFor7.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing7.Visible = true;
                RequiredFieldValidator75.Visible = true;
            }
            else
            {
                txtOtherEarthing7.Visible = false;
                RequiredFieldValidator75.Visible = false;
            }
        }

        protected void ddlUsedFor8_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsedFor8.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing8.Visible = true;
                RequiredFieldValidator71.Visible = true;
            }
            else
            {
                txtOtherEarthing8.Visible = false;
                RequiredFieldValidator71.Visible = false;
            }
        }

        protected void ddlUsedFor9_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsedFor9.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing9.Visible = true;
                RequiredFieldValidator67.Visible = true;
            }
            else
            {
                txtOtherEarthing9.Visible = false;
                RequiredFieldValidator67.Visible = false;
            }
        }

        protected void ddlUsedFor10_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsedFor10.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing10.Visible = true;
                RequiredFieldValidator63.Visible = true;
            }
            else
            {
                txtOtherEarthing10.Visible = false;
                RequiredFieldValidator63.Visible = false;
            }

        }

        protected void ddlUsedFor11_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsedFor11.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing11.Visible = true;
                RequiredFieldValidator59.Visible = true;
            }
            else
            {
                txtOtherEarthing11.Visible = false;
                RequiredFieldValidator59.Visible = false;
            }
        }

        protected void ddlUsedFor12_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsedFor12.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing12.Visible = true;
                RequiredFieldValidator55.Visible = true;
            }
            else
            {
                txtOtherEarthing12.Visible = false;
                RequiredFieldValidator55.Visible = false;
            }
        }

        protected void ddlUsedFor13_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsedFor13.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing13.Visible = true;
                RequiredFieldValidator51.Visible = true;
            }
            else
            {
                txtOtherEarthing13.Visible = false;
                RequiredFieldValidator51.Visible = false;
            }
        }

        protected void ddlUsedFor14_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsedFor14.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing14.Visible = true;
                RequiredFieldValidator47.Visible = true;
            }
            else
            {
                txtOtherEarthing14.Visible = false;
                RequiredFieldValidator47.Visible = false;
            }
        }

        protected void ddlUsedFor15_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsedFor15.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing15.Visible = true;
                RequiredFieldValidator23.Visible = true;
            }
            else
            {
                txtOtherEarthing15.Visible = false;
                RequiredFieldValidator23.Visible = false;
            }

        }

        protected void ddlUsedFor16_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsedFor16.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing16.Visible = true;
                RequiredFieldValidator25.Visible = true;
            }
            else
            {
                txtOtherEarthing16.Visible = false;
                RequiredFieldValidator25.Visible = false;
            }
        }

        protected void ddlUsedFor17_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsedFor17.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing17.Visible = true;
                RequiredFieldValidator28.Visible = true;
            }
            else
            {
                txtOtherEarthing17.Visible = false;
                RequiredFieldValidator28.Visible = false;
            }
        }

        protected void ddlUsedFor18_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsedFor18.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing18.Visible = true;
                RequiredFieldValidator35.Visible = true;
            }
            else
            {
                txtOtherEarthing18.Visible = false;
                RequiredFieldValidator35.Visible = false;
            }

        }

        protected void ddlUsedFor19_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsedFor19.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing19.Visible = true;
                RequiredFieldValidator39.Visible = true;
            }
            else
            {
                txtOtherEarthing19.Visible = false;
                RequiredFieldValidator39.Visible = false;
            }
        }

        protected void ddlUsedFor20_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUsedFor20.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing20.Visible = true;
                RequiredFieldValidator43.Visible = true;
            }
            else
            {
                txtOtherEarthing20.Visible = false;
                RequiredFieldValidator43.Visible = false;
            }
        }


    }
}