﻿using CEI_PRoject;
using iText.Forms.Form.Element;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace CEIHaryana.Industry_Master
{
    public partial class GeneratingsetPeriodic_Industry : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        int x = 0;
        string sessionValue = string.Empty;
        string sessionName = string.Empty;
        string nextSessionName = string.Empty;
        string nextSessionValue = string.Empty;
        string type = string.Empty;
        string Generaterset_Id = string.Empty;
        string Id_Update = string.Empty;
        private static string ApplicantType, VoltageLevel, District, Division, Inspectiontype;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["TypeOfInspection_Industry"]?.ToString() == "Periodic")
                {
                    txtapplication.Text = Session["TypeOfInspection_Industry"].ToString().Trim();
                    txtInstallation.Text = Session["Installation_Industry"].ToString().Trim();
                    txtid.Text = Session["Intimation_Industry"].ToString().Trim();
                    txtNOOfInstallation.Text = Session["Count_Industry"].ToString();

                }
                else
                {

                    txtapplication.Text = Session["Application_Industry"].ToString().Trim();
                    txtInstallation.Text = Session["Typs_Industry"].ToString().Trim();
                    txtid.Text = Session["Intimations_Industry"].ToString().Trim();
                    txtNOOfInstallation.Text = Session["NoOfInstallations_Industry"].ToString().Trim() + " Out of " + Session["TotalInstallation_Industry"].ToString().Trim();
                }
            }
        }

        protected void ddlGeneratingSetType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string IntimationId = Session["intimationid_Industry"].ToString();
                string CreatedBy = Session["SiteOwnerId_Industry"].ToString();
                string installationNo = Session["IHID_Industry"].ToString();
                string count = Session["NoOfInstallations_Industry"].ToString();

                //string IntimationId = "101/2024/W0074";
                //string CreatedBy = "ABCDE5555N";
                //string installationNo = "1377";
                //string count = "1";
                DataSet ds = new DataSet();
                ds = CEI.GetIntimationDetails_Industries(IntimationId);

                ApplicantType = ds.Tables[0].Rows[0]["ApplicantType"].ToString();
                VoltageLevel = ds.Tables[0].Rows[0]["VoltageLevel"].ToString();
                District = ds.Tables[0].Rows[0]["District"].ToString();
                Division = ds.Tables[0].Rows[0]["Division"].ToString();
                Inspectiontype = ds.Tables[0].Rows[0]["PremisesType"].ToString();

                //int returnresult = CEI.InsertGeneratingSetData_Existing_HavingPreviousReport_Industries(Id_Update, count, IntimationId,
                //    ddlCapacity.SelectedItem.ToString(), txtCapacity.Text, txtSerialNoOfGenerator.Text, ddlGeneratingSetType.SelectedItem.ToString(),
                // txtGeneratorVoltage.Text, ddlPlantType.SelectedItem.ToString(),txtMake.Text.ToString(),CreatedBy);

                int returnresult = CEI.InsertGeneratingSetData_Existing_HavingPreviousReport_Industries(Id_Update, count, IntimationId,
                     ddlCapacity.SelectedItem.ToString(), txtCapacity.Text, txtSerialNoOfGenerator.Text, ddlGeneratingSetType.SelectedItem.ToString(),
                  txtGeneratorVoltage.Text, ddlPlantType.SelectedItem.ToString(), txtMake.Text.ToString(),
                  txtLastInspectionIssueDate.Text.ToString(), ApplicantType, VoltageLevel, District, Division, Inspectiontype,
                  CreatedBy);

                CEI.UpdateInstallations_Industries(installationNo, IntimationId);
                Reset();


                if (returnresult == 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectNextProcessExistingPage();", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdataRatingofinstallationPage();", true);
                }

            }
            catch (Exception ex)
            {
                DataSaved.Visible = false;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('" + ex.Message.ToString() + "')", true);
                return;
            }
        }

        public void Reset()
        {
            ddlCapacity.SelectedValue = "0";
            txtCapacity.Text = "";
            txtSerialNoOfGenerator.Text = "";
            ddlGeneratingSetType.SelectedValue = "0";
            txtGeneratorVoltage.Text = "";
            txtMake.Text = "";
            ddlPlantType.SelectedValue = "0";
        }

        protected void ddlCapacity_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlGeneratingSetType.Items.Clear();


            ddlGeneratingSetType.Items.Add(new ListItem("Select", "0"));


            if (ddlCapacity.SelectedValue == "3" || ddlCapacity.SelectedValue == "4")
            {
                ddlGeneratingSetType.Items.Add(new ListItem("Solar Panel", "3"));
                ddlGeneratingSetType.SelectedValue = "3";
                ddlGeneratingSetType.SelectedValue = "0";
            }
            else
            {

                ddlGeneratingSetType.Items.Add(new ListItem("Diesel Engine", "1"));
                ddlGeneratingSetType.Items.Add(new ListItem("Gas Engine", "2"));
                ddlGeneratingSetType.Items.Add(new ListItem("Bio Fuel", "4"));
                ddlGeneratingSetType.SelectedValue = "0";
            }

        }
    }
}