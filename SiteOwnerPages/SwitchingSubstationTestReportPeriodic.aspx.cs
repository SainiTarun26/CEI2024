using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CEI_PRoject;

namespace CEIHaryana.SiteOwnerPages
{
    public partial class SwitchingSubstationTestReportPeriodic : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Convert.ToString(Session["SiteOwnerId"]) != null && Convert.ToString(Session["SiteOwnerId"]) != "")
                {
                   // ddlVoltageBind();
                    //ddlSecondarVoltage();

                    txtapplication.Text = Session["Application"].ToString().Trim();
                    txtInstallation.Text = Session["Typs"].ToString().Trim();
                    txtid.Text = Session["Intimations"].ToString().Trim();
                    txtNOOfInstallation.Text = Session["NoOfInstallations"].ToString().Trim() + " Out of " + Session["TotalInstallation"].ToString().Trim();
                }
                else
                {
                    Response.Redirect("/login.aspx", false);
                }
            }
        }

        //private void ddlVoltageBind()
        //{
        //    string Volts = string.Empty;
        //    if (Session["VoltageLevel"] != null)
        //    {
        //        Volts = Session["VoltageLevel"].ToString();
        //        DataSet dsVoltage = CEI.GetddlVotlageforSwitchingStation(Volts);
        //        if (dsVoltage != null && dsVoltage.Tables.Count > 0)
        //        {
        //            ddlVoltage.DataSource = dsVoltage;
        //            ddlVoltage.DataTextField = "Volts";
        //            ddlVoltage.DataValueField = "Volts";
        //            ddlVoltage.DataBind();
        //        }
        //        ddlVoltage.Items.Insert(0, new ListItem("Select", "0"));
        //        dsVoltage.Clear();
        //    }
        //    else
        //    {
        //        ddlVoltage.Items.Insert(0, new ListItem("Select Voltage Level", "0"));
        //    }
        //}

        protected void ddlBreakerType_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ddlBreakerType.SelectedValue == "3")
            {
                otherbreakertype.Visible = true;
            }
            else
            {
                otherbreakertype.Visible = false;

            }
        }
    }
}