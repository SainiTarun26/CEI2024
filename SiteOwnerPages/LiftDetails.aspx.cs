using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.SiteOwnerPages
{
    public partial class LiftDetails : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    ddlEarthing();
                    Session["SiteOwnerId"] = "1234";
                    //txtapplication.Text = Session["Application"].ToString().Trim();
                    //txtInstallation.Text = Session["Typs"].ToString().Trim();
                    //txtid.Text = Session["Intimations"].ToString().Trim();
                    //txtNOOfInstallation.Text = Session["NoOfInstallations"].ToString().Trim() + " Out of " + Session["TotalInstallation"].ToString().Trim();
                    //BtnBack.Visible = true;

                }
            }
            catch
            {

            }

        }

        private void ddlEarthing()
        {
            try
            {
                DataSet dsEarthing = new DataSet();
                dsEarthing = CEI.GetddlEarthing();
                if (dsEarthing.Tables[0].Rows.Count > 10)
                {
                    // Take only the first 10 rows
                    DataTable dtTop10 = dsEarthing.Tables[0].AsEnumerable().Take(10).CopyToDataTable();
                    ddlNoOfEarthing.DataSource = dtTop10;
                }
                else
                {
                    ddlNoOfEarthing.DataSource = dsEarthing;
                }
                ddlNoOfEarthing.DataTextField = "Numbers";
                ddlNoOfEarthing.DataValueField = "Id";
                ddlNoOfEarthing.DataBind();
                ddlNoOfEarthing.Items.Insert(0, new ListItem("Select", "0"));
                dsEarthing.Clear();
            }
            catch (Exception)
            {
                //msg.Text = ex.Message;
            }
        }

        protected void ddlNoOfEarthing_SelectedIndexChanged(object sender, EventArgs e)
        {
            LineEarthingdiv.Visible = true;

            // Store the Earthingtype controls in an array for easier manipulation
            Control[] earthingTypes = { Earthingtype1, Earthingtype2, Earthingtype3, Earthingtype4,
                                Earthingtype5, Earthingtype6, Earthingtype7, Earthingtype8,
                                Earthingtype9, Earthingtype10 };

            // First, hide all controls
            foreach (var earthingType in earthingTypes)
            {
                earthingType.Visible = false;
            }

            // Get the selected number of earthing types
            int numberOfEarthing = int.Parse(ddlNoOfEarthing.SelectedValue.Trim());

            // Show only the selected number of earthing types
            for (int i = 0; i < numberOfEarthing; i++)
            {
                earthingTypes[i].Visible = true;
            }
        }

        protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList2.SelectedValue == "1")
            {
                Name.Visible = true;
                Address.Visible = true;
                Contact.Visible = true;
            }
            else
            {
                Name.Visible = false;
                Address.Visible = false;
                Contact.Visible = false;

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string IntimationId = Session["id"].ToString();
                string CreatedBy = Session["SupervisorID"].ToString();
                string count = Session["NoOfInstallations"].ToString();
                string installationNo = Session["IHID"].ToString();

                // Helper function to safely parse decimal fields
                decimal ParseOrDefault(string input, decimal defaultValue = 0)
                {
                    return decimal.TryParse(input, out decimal result) ? result : defaultValue;
                }

                CEI.InsertNewLiftData(
                    count, IntimationId, RadioButtonList2.SelectedItem.Text, TxtAgentName.Text, txtAgentAddress.Text,
                    txtAgentPhone.Text, txtErectionDate.Text, ddlLiftErected.SelectedItem.ToString(), txtLiftSpeedContract.Text,
                    ParseOrDefault(txtLiftLoad.Text), txtMaxPersonCapacity.Text, ParseOrDefault(txtWeight.Text), ParseOrDefault(txtCounterWeight.Text),
                    ParseOrDefault(txtPitDepth.Text), ParseOrDefault(txtTravelDistance.Text), ParseOrDefault(txtFloorsServed.Text),
                    ParseOrDefault(txtTotalHeadRoom.Text), ParseOrDefault(txtNoofSuspension.Text), txtDescriptionOfSuspension.Text,
                    ParseOrDefault(txtSizeOfSuspension.Text), ParseOrDefault(txtBeamWeight.Text), ParseOrDefault(txtBeamSize.Text),
                    txtMakeMainBreaker.Text, txtTypeMainBreaker.Text, ddlPoleMainBreaker.SelectedItem.ToString(), txtratingMainBreaker.Text,
                    txtCapacityMainBreaker.Text, txtMakeRCCBMainBreaker.Text, ddlPolesRCCBMainBreaker.SelectedItem.ToString(),
                    txtRatingRCCBMainBreaker.Text, txtfaultratingRCCBMainBreaker.Text, txtMakeLoadBreaker.Text, txtTypeLoadBreaker.Text,
                    ddlPolesLoadBreaker.SelectedItem.ToString(), txtRatingLoadBreaker.Text, txtCapacityLoadBreaker.Text, txtMakeRCCBLoadBreaker.Text,
                    ddlpolesRCCBLoadBreaker.SelectedItem.ToString(), txtRatingRCCBLoadBreaker.Text, txtFaultCurrentRCCBLoadBreaker.Text,
                    txtwholeInstallation.Text, txtRedYellow.Text, txtRedBlue.Text, txtYellowBlue.Text, txtRedEarth.Text, txtYellowEarth.Text,
                    txtBlueEarth.Text, ddlNoOfEarthing.SelectedItem.ToString(), ddlEarthingtype1.SelectedItem.ToString(), ParseOrDefault(txtearthingValue1.Text),
                    ddlEarthingtype2.SelectedItem.ToString(), ParseOrDefault(txtEarthingValue2.Text), ddlEarthingtype3.SelectedItem.ToString(),
                    ParseOrDefault(txtEarthingValue3.Text), ddlEarthingtype4.SelectedItem.ToString(), ParseOrDefault(txtEarthingValue4.Text),
                    ddlEarthingtype5.SelectedItem.ToString(), ParseOrDefault(txtEarthingValue5.Text), ddlEarthingtype6.SelectedItem.ToString(),
                    ParseOrDefault(txtEarthingValue6.Text), ddlEarthingtype7.SelectedItem.ToString(), ParseOrDefault(txtEarthingValue7.Text),
                    ddlEarthingtype8.SelectedItem.ToString(), ParseOrDefault(txtEarthingValue8.Text), ddlEarthingtype9.SelectedItem.ToString(),
                    ParseOrDefault(txtEarthingValue9.Text), ddlEarthingtype10.SelectedItem.ToString(), ParseOrDefault(txtEarthingValue10.Text),
                    CreatedBy
                );
                CEI.UpdateInstallations(installationNo, IntimationId);
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Test report has been Updated and is under review by the Contractor for final submission')", true);

                //Response.Redirect("/Supervisor/TestReportHistory.aspx", false);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata();", true);
            }
            catch (Exception ex)
            {
                // Consider logging the exception for debugging purposes
                Console.WriteLine(ex.Message);
            }
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("InstallationDetails.aspx", false);
        }
    }
}