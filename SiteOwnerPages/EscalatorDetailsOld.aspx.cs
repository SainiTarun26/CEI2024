﻿using CEI_PRoject;
using CEI_PRoject.Admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace CEIHaryana.SiteOwnerPages
{
    public partial class EscalatorDetails : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    ddlEarthing();
                    txtapplication.Text = Session["Application"].ToString().Trim();
                    txtInstallation.Text = Session["Typs"].ToString().Trim();
                    //txtid.Text = Session["Intimations"].ToString().Trim();
                    txtNOOfInstallation.Text = Session["NoOfInstallations"].ToString().Trim() + " Out of " + Session["TotalInstallation"].ToString().Trim();
                    BtnBack.Visible = true;
                    GetContractorDetails();
                    GetDocumentforlift();
                }
                GetDocumentforlift();
                BtnBack.Visible = true;
            }
            catch
            {

            }

        }
        protected void Grd_Document_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string fileName = "";
            try
            {
                if (e.CommandName == "Select")
                {
                    //ID = Session["InspectionId"].ToString();

                    //fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                    fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                    string script = $@"<script>window.open('{fileName}','_blank');</script>";
                    ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);

                }

            }
            catch (Exception ex)
            {
                // lblerror.Text = ex.Message.ToString()+"---"+ fileName;
            }
        }
        private void GetDocumentforlift()
        {
            DataTable ds = new DataTable();
            ds = CEI.GetDocumentforlift("Escalator");
            if (ds.Rows.Count > 0)
            {
                Grd_Document.DataSource = ds;
                Grd_Document.DataBind();
            }
            else
            {
                Grd_Document.DataSource = null;
                Grd_Document.DataBind();
                string script = "alert(\"No Record Found for document \");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
            ds.Dispose();
        }


        private void GetContractorDetails()
        {

            DataSet dsContractor = new DataSet();
            dsContractor = CEI.GetContractorData();
            ddlContName.DataSource = dsContractor;
            ddlContName.DataTextField = "ContractorData";
            ddlContName.DataValueField = "LicenseValue";
            ddlContName.DataBind();
            ddlContName.Items.Insert(0, new ListItem("Select", "0"));
            dsContractor.Clear();

        }
        private void GetSupervisorDetails(string value)
        {

            DataSet dsSupervisor = new DataSet();
            dsSupervisor = CEI.GetSupervisorDataatSiteOwner(value);
            ddlLicenseNo.DataSource = dsSupervisor;
            ddlLicenseNo.DataTextField = "SupervisorData";
            ddlLicenseNo.DataValueField = "LicenseValue";
            ddlLicenseNo.DataBind();
            ddlLicenseNo.Items.Insert(0, new ListItem("Select", "0"));
            dsSupervisor.Clear();

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
                string CreatedBy = Session["SiteOwnerId"].ToString();
                string count = Session["NoOfInstallations"].ToString();
                string installationNo = Session["IHID"].ToString();

                if (txtNeutralPhase.Text == "")
                {
                    txtNeutralPhase.Text = "0";
                    txtEarthPhase.Text = "0";
                }
                else
                {

                }
                // Helper function to safely parse decimal fields
                decimal ParseOrDefault(string input, decimal defaultValue = 0)
                {
                    return decimal.TryParse(input, out decimal result) ? result : defaultValue;
                } 
                int ParseintOrDefault(string input, int defaultValue = 0)
                {
                    return int.TryParse(input, out int result) ? result : defaultValue;
                }
                if (Session["Expired"].ToString() == "False")
                {
                    CEI.InsertNewEscalatorData(
                        count, IntimationId, RadioButtonList2.SelectedItem.Text, TxtAgentName.Text, txtAgentAddress.Text,
                        txtAgentPhone.Text, DateTime.Parse(txtErectionDate.Text), txtMake.Text, txtSerialNo.Text, ddlEscalatorType.SelectedItem.ToString(), "",
                        ParseOrDefault(""), txtMaxPersonCapacity.Text, ParseOrDefault(txtWeight.Text), ParseOrDefault(txtCounterWeight.Text),
                        ParseOrDefault(txtPitDepth.Text), ParseOrDefault(txtTravelDistance.Text), ParseOrDefault(txtFloorsServed.Text),
                        ParseOrDefault(txtTotalHeadRoom.Text), txtTypeofControll.Text, txtMakeMainBreaker.Text, txtTypeMainBreaker.Text, 
                        ddlPoleMainBreaker.SelectedItem.ToString(), txtratingMainBreaker.Text,
                        txtCapacityMainBreaker.Text, txtMakeRCCBMainBreaker.Text, ddlPolesRCCBMainBreaker.SelectedItem.ToString(),
                        txtRatingRCCBMainBreaker.Text, txtfaultratingRCCBMainBreaker.Text, txtMakeLoadBreaker.Text, txtTypeLoadBreaker.Text,
                        ddlPolesLoadBreaker.SelectedItem.ToString(), txtRatingLoadBreaker.Text, txtCapacityLoadBreaker.Text, txtMakeRCCBLoadBreaker.Text,
                        ddlpolesRCCBLoadBreaker.SelectedItem.ToString(), txtRatingRCCBLoadBreaker.Text, txtFaultCurrentRCCBLoadBreaker.Text,
                        txtwholeInstallation.Text, txtNeutralPhase.Text, txtEarthPhase.Text, ParseintOrDefault(txtRedYellow.Text),
                        ParseintOrDefault(txtRedBlue.Text), ParseintOrDefault(txtYellowBlue.Text),
                        ParseintOrDefault(txtRedEarth.Text), ParseintOrDefault(txtYellowEarth.Text),
                         ParseintOrDefault(txtBlueEarth.Text), ddlNoOfEarthing.SelectedItem.ToString(), ddlEarthingtype1.SelectedItem.ToString(), ParseOrDefault(txtearthingValue1.Text),
                        ddlEarthingtype2.SelectedItem.ToString(), ParseOrDefault(txtEarthingValue2.Text), ddlEarthingtype3.SelectedItem.ToString(),
                        ParseOrDefault(txtEarthingValue3.Text), ddlEarthingtype4.SelectedItem.ToString(), ParseOrDefault(txtEarthingValue4.Text),
                        ddlEarthingtype5.SelectedItem.ToString(), ParseOrDefault(txtEarthingValue5.Text), ddlEarthingtype6.SelectedItem.ToString(),
                        ParseOrDefault(txtEarthingValue6.Text), ddlEarthingtype7.SelectedItem.ToString(), ParseOrDefault(txtEarthingValue7.Text),
                        ddlEarthingtype8.SelectedItem.ToString(), ParseOrDefault(txtEarthingValue8.Text), ddlEarthingtype9.SelectedItem.ToString(),
                        ParseOrDefault(txtEarthingValue9.Text), ddlEarthingtype10.SelectedItem.ToString(), ParseOrDefault(txtEarthingValue10.Text),
                        CreatedBy, ddlContName.SelectedItem.ToString(), txtContName.Text, DateTime.Parse(txtContExp.Text), ddlLicenseNo.SelectedItem.ToString(),
                        txtSupLicenseNo.Text, DateTime.Parse(txtSupExpiryDate.Text)
                    );
                    CEI.UpdateLiftTestReportHistory("Escalator", IntimationId, count, CreatedBy);
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Test report has been Updated and is under review by the Contractor for final submission')", true);

                    //Response.Redirect("/Supervisor/TestReportHistory.aspx", false);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata();", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Sorry Your License Is Expired Please Contact Admin For saving This Information');", true);

                }
            }
            catch (Exception ex)
            {
                // Consider logging the exception for debugging purposes
                Console.WriteLine(ex.Message);
            }
        }
        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("LiftInstallationDetails.aspx", false);
        }
        protected void ddlContName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dt = new DataSet();
            dt = CEI.GetSupervisorandContractor("Contractor", ddlContName.SelectedValue.ToString());
            if (dt.Tables.Count > 0)
            {
                //txtContName.Text = dt.Tables[0].Rows[0]["Name"].ToString();
                txtContExp.Text = dt.Tables[0].Rows[0]["ExpiryDate"].ToString();
                txtContName.Text = dt.Tables[0].Rows[0]["Name"].ToString();
                if (DateTime.TryParse(txtContExp.Text, out DateTime expiryDate)) // Parse the expiry date
                {
                    Session["Expired"] = "true";
                    txtContExp.Text = expiryDate.ToString("yyyy-MM-dd"); // Set formatted date to TextBox

                    if (expiryDate <= DateTime.Now) // Compare with the current date
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Your License Is Expired Please Contact Admin');", true);
                    }
                    else
                    {
                        Session["Expired"] = "False";
                    }

                }


            }
            else
            {

            }
            GetSupervisorDetails(ddlContName.SelectedValue);
        }
        protected void ddlLicenseNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dt = new DataSet();
            dt = CEI.GetSupervisorandContractor("Supervisor", ddlLicenseNo.SelectedValue.ToString());
            if (dt.Tables[0].Rows.Count > 0)
            {
                //txtSupName.Text = dt.Tables[0].Rows[0]["Name"].ToString();
                txtSupExpiryDate.Text = dt.Tables[0].Rows[0]["DateofExpiry"].ToString();
                txtSupLicenseNo.Text = dt.Tables[0].Rows[0]["Name"].ToString();
                if (DateTime.TryParse(txtSupExpiryDate.Text, out DateTime expiryDate)) // Parse the expiry date
                {
                    Session["Expired"] = "true";
                    txtSupExpiryDate.Text = expiryDate.ToString("yyyy-MM-dd"); // Set formatted date to TextBox

                    if (expiryDate <= DateTime.Now) // Compare with the current date
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Your License Is Expired Please Contact Admin');", true);
                    }
                    else
                    {
                        Session["Expired"] = "False";
                    }

                }

            }
            else
            {

            }
        }
        protected void ddlPoleMainBreaker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPoleMainBreaker.SelectedValue == "1")
            {
                InDPO.Visible = true;
                TPN1.Visible = false;
                TPN2.Visible = false;
            }
            else
            {
                InDPO.Visible = false;
                TPN1.Visible = true;
                TPN2.Visible = true;
            }
        }
    }
}