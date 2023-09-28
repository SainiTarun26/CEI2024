using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.TestReport
{
    public partial class TestReport : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RedirectPages();
        }
        public void RedirectPages()
        {
            try
            {
                if (Session["installationType1"].ToString().Trim() == "Line" || Session["installationType2"].ToString().Trim() == "Line"
                    || Session["installationType3"].ToString().Trim() == "Line" || Session["installationType4"].ToString().Trim() == "Line"
                    || Session["installationType5"].ToString().Trim() == "Line" || Session["installationType6"].ToString().Trim() == "Line"
                    || Session["installationType7"].ToString().Trim() == "Line" || Session["installationType8"].ToString().Trim() == "Line")
                {
                    if (Convert.ToString(Session["SubmittedValue2"]) != null && Convert.ToString(Session["SubmittedValue2"]) != "")
                    {
                        lblLinePage.Visible = false;
                    }
                    else
                    {
                        lblLinePage.Visible = true;
                    }



                }
                if (Session["installationType1"].ToString().Trim() == "Substation Transformer" || Session["installationType2"].ToString().Trim() == "Substation Transformer"
                   || Session["installationType3"].ToString().Trim() == "Substation Transformer" || Session["installationType4"].ToString().Trim() == "Substation Transformer"
                   || Session["installationType5"].ToString().Trim() == "Substation Transformer" || Session["installationType6"].ToString().Trim() == "Substation Transformer"
                   || Session["installationType7"].ToString().Trim() == "Substation Transformer" || Session["installationType8"].ToString().Trim() == "Substation Transformer")
                {
                    if (Convert.ToString(Session["SubmittedValue"]) != null && Convert.ToString(Session["SubmittedValue"]) != "")
                    {
                        lblSubStationPage.Visible = false;
                    }
                    else
                    {
                        lblSubStationPage.Visible = true;
                    }




                }
                if (Session["installationType1"].ToString().Trim() == "Generating Station" || Session["installationType2"].ToString().Trim() == "Generating Station"
                   || Session["installationType3"].ToString().Trim() == "Generating Station" || Session["installationType4"].ToString().Trim() == "Generating Station"
                   || Session["installationType5"].ToString().Trim() == "Generating Station" || Session["installationType6"].ToString().Trim() == "Generating Station"
                   || Session["installationType7"].ToString().Trim() == "Generating Station" || Session["installationType8"].ToString().Trim() == "Generating Station")
                {
                    if (Convert.ToString(Session["SubmittedValue3"]) != null && Convert.ToString(Session["SubmittedValue3"]) != "")
                    {
                        lblGeneratingSet.Visible = false;
                    }
                    else
                    {
                        lblGeneratingSet.Visible = true;
                    }
                   

                }
                if (Session["installationType1"].ToString().Trim() == "Single/ Three Phase" || Session["installationType2"].ToString().Trim() == "Single/ Three Phase"
                   || Session["installationType3"].ToString().Trim() == "Single/ Three Phase" || Session["installationType4"].ToString().Trim() == "Single/ Three Phase"
                   || Session["installationType5"].ToString().Trim() == "Single/ Three Phase" || Session["installationType6"].ToString().Trim() == "Single/ Three Phase"
                   || Session["installationType7"].ToString().Trim() == "Single/ Three Phase" || Session["installationType8"].ToString().Trim() == "Single/ Three Phase")
                {
                    lblPhses.Visible = true;

                }
                //if (Session["installationType1"].ToString().Trim() == "Lift " || Session["installationType2"].ToString().Trim() == "Lift"
                //   || Session["installationType3"].ToString().Trim() == "Lift" || Session["installationType4"].ToString().Trim() == "Lift"
                //   || Session["installationType5"].ToString().Trim() == "Lift" || Session["installationType6"].ToString().Trim() == "Lift"
                //   || Session["installationType7"].ToString().Trim() == "Lift" || Session["installationType8"].ToString().Trim() == "Lift")
                //{
                //    Response.Redirect("/TestReport/SubstationTransformer.aspx");
                //}
                //if (Session["installationType1"].ToString().Trim() == "LPI(upto250V)" || Session["installationType2"].ToString().Trim() == "LPI(upto250V)"
                //   || Session["installationType3"].ToString().Trim() == "LPI(upto250V)" || Session["installationType4"].ToString().Trim() == "LPI(upto250V)"
                //   || Session["installationType5"].ToString().Trim() == "LPI(upto250V)" || Session["installationType6"].ToString().Trim() == "LPI(upto250V)"
                //   || Session["installationType7"].ToString().Trim() == "LPI(upto250V)" || Session["installationType8"].ToString().Trim() == "LPI(upto250V)")
                //{
                //    Response.Redirect("/TestReport/SubstationTransformer.aspx");
                //}
                //if (Session["installationType1"].ToString().Trim() == "MPI(251Vto650V)" || Session["installationType2"].ToString().Trim() == "MPI(251Vto650V)"
                //   || Session["installationType3"].ToString().Trim() == "MPI(251Vto650V)" || Session["installationType4"].ToString().Trim() == "MPI(251Vto650V)"
                //   || Session["installationType5"].ToString().Trim() == "MPI(251Vto650V)" || Session["installationType6"].ToString().Trim() == "MPI(251Vto650V)"
                //   || Session["installationType7"].ToString().Trim() == "MPI(251Vto650V)" || Session["installationType8"].ToString().Trim() == "MPI(251Vto650V)")
                //{
                //    Response.Redirect("/TestReport/SubstationTransformer.aspx");
                //}
                //if (Session["installationType1"].ToString().Trim() == "SolarPowerPlant" || Session["installationType2"].ToString().Trim() == "SolarPowerPlant"
                //   || Session["installationType3"].ToString().Trim() == "SolarPowerPlant" || Session["installationType4"].ToString().Trim() == "SolarPowerPlant"
                //   || Session["installationType5"].ToString().Trim() == "SolarPowerPlant" || Session["installationType6"].ToString().Trim() == "SolarPowerPlant"
                //   || Session["installationType7"].ToString().Trim() == "SolarPowerPlant" || Session["installationType8"].ToString().Trim() == "SolarPowerPlant")
                //{
                //    Response.Redirect("/TestReport/SubstationTransformer.aspx");
                //}
            }
            catch
            {

            }
        }

    }
}