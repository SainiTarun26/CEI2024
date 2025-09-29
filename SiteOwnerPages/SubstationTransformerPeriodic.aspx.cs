﻿using CEI_PRoject;
using CEIHaryana.Admin;
using iText.Forms.Form.Element;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace CEIHaryana.SiteOwnerPages
{
    public partial class SubstationTransformerPeriodic : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        int x = 0;
        string sessionValue = string.Empty;
        string sessionName = string.Empty;
        string nextSessionName = string.Empty;
        string nextSessionValue = string.Empty;
        string currentSessionName = string.Empty;
        string Type = string.Empty;
        string SubStationID = string.Empty;
        private static string _PrimaryVoltage, _SecondaryVoltage, ApplicantType, VoltageLevel, District, Division, Inspectiontype;

        string IdUpdate = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Session["VoltageLevel"] = "Above 650 V and up to 11 KV";
                ddlPrimaryVoltage();
                ddlSecondarVoltage();

                if (Session["TypeOfInspection"]?.ToString() == "Periodic")
                {
                    txtapplication.Text = Session["TypeOfInspection"].ToString().Trim();
                    txtInstallation.Text = Session["Installation"].ToString().Trim();
                    txtid.Text = Session["Intimation"].ToString().Trim();
                    txtNOOfInstallation.Text = Session["Count"].ToString();

                }
                else
                {
                    txtapplication.Text = Session["Application"].ToString().Trim();
                    txtInstallation.Text = Session["Typs"].ToString().Trim();
                    txtid.Text = Session["Intimations"].ToString().Trim();
                    txtNOOfInstallation.Text = Session["NoOfInstallations"].ToString().Trim() + " Out of " + Session["TotalInstallation"].ToString().Trim();

                }

            }
        }
        private void ddlPrimaryVoltage()
        {
            string Volts = string.Empty;
            Volts = Session["VoltageLevel"].ToString();
            DataSet dsPrimaryVoltage = new DataSet();
            dsPrimaryVoltage = CEI.GetddlPrimaryVotlage(Volts);
            PrimaryVoltage.DataSource = dsPrimaryVoltage;
            PrimaryVoltage.DataTextField = "Volts";
            PrimaryVoltage.DataValueField = "Volts";
            PrimaryVoltage.DataBind();
            PrimaryVoltage.Items.Insert(0, new ListItem("Select", "0"));
            dsPrimaryVoltage.Clear();

        }
        private void ddlSecondarVoltage()
        {
            string Volts = string.Empty;
            Volts = Session["VoltageLevel"].ToString();
            DataSet dsSecondaryVoltage = new DataSet();
            dsSecondaryVoltage = CEI.GetddlSecondaryVotlage(Volts);
            ddlSecondaryVoltage.DataSource = dsSecondaryVoltage;
            ddlSecondaryVoltage.DataTextField = "Volts";
            ddlSecondaryVoltage.DataValueField = "Volts";
            ddlSecondaryVoltage.DataBind();
            ddlSecondaryVoltage.Items.Insert(0, new ListItem("Select", "0"));
            dsSecondaryVoltage.Clear();

        }
        protected void ddltransformerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (Convert.ToString(Session["VoltageLevel"]) == "upto 650 V" && ddltransformerType.SelectedValue == "1")
            //    {
            //        PrimaryVoltageLevel.Visible = false;
            //        InCaseOfOil.Visible = true;
            //        Capacity.Visible = true;
            //        BDV.Visible = true;

            //    }
            //    else if (Convert.ToString(Session["VoltageLevel"]) != null && ddltransformerType.SelectedValue == "1")
            //    {
            //        PrimaryVoltageLevel.Visible = true;
            //        InCaseOfOil.Visible = true;
            //        Capacity.Visible = true;
            //        BDV.Visible = true;
            //    }
            //    else if (Convert.ToString(Session["VoltageLevel"]) == "upto 650 V" && ddltransformerType.SelectedValue == "2")
            //    {
            //        PrimaryVoltageLevel.Visible = false;
            //        InCaseOfOil.Visible = true;
            //        Capacity.Visible = false;
            //        BDV.Visible = false;
            //    }
            //    else if (Convert.ToString(Session["VoltageLevel"]) != null && ddltransformerType.SelectedValue == "2")
            //    {
            //        PrimaryVoltageLevel.Visible = true;
            //        InCaseOfOil.Visible = true;
            //        Capacity.Visible = false;
            //        BDV.Visible = false;
            //    }
            //    else
            //    {
            //    }
            //}
            //catch (Exception ex) { }
        }
        protected void txtTransformerCapacity_TextChanged(object sender, EventArgs e)
        {
            //int capacity = Convert.ToInt32(txtTransformerCapacity.Text.ToString());
            //if (capacity >= 1000)
            //{
            //    ddlHTType.Items.Clear();
            //    ddlHTType.Items.Add(new ListItem("Select", "0"));
            //    ddlHTType.Items.Add(new ListItem("Breaker", "3"));
            //}
            //else
            //{
            //    ddlHTType.Items.Add(new ListItem("GO Switch", "1"));
            //    ddlHTType.Items.Add(new ListItem("3Pole Linked Switch(GODO)", "2"));
            //    ddlHTType.Visible = true;
            //}


        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {

                string IntimationId = Session["intimationid"].ToString();
                string CreatedBy = Session["SiteOwnerId"].ToString();
                string installationNo = Session["IHID"].ToString();
                string count = Session["NoOfInstallations"].ToString();

                //string TestReportId = "101/2024/W0074";
                //string IntimationId = "101/2024/W0074";
                //string CreatedBy = "ABCDE5555N";
                //string installationNo = "1376";
                //string count = "1";

                DataSet ds = new DataSet();
                ds = CEI.GetIntimationDetails(IntimationId);

                ApplicantType = ds.Tables[0].Rows[0]["ApplicantType"].ToString();
                VoltageLevel = ds.Tables[0].Rows[0]["VoltageLevel"].ToString();
                District = ds.Tables[0].Rows[0]["District"].ToString();
                Division = ds.Tables[0].Rows[0]["Division"].ToString();
                Inspectiontype = ds.Tables[0].Rows[0]["PremisesType"].ToString();

                string Primaryvoltage, SecondaryVoltage;
                Primaryvoltage = PrimaryVoltage.SelectedItem.ToString().Trim();
                _PrimaryVoltage = Primaryvoltage.Substring(0, Primaryvoltage.Length - 6);

                SecondaryVoltage = ddlSecondaryVoltage.SelectedValue.ToString().Trim();
                _SecondaryVoltage = SecondaryVoltage.Substring(0, SecondaryVoltage.Length - 6);

                int returnresult = CEI.InsertSubstationData_Existing_HavingPreviousReport(IdUpdate, count, IntimationId, txtTransformerSerialNumber.Text, ddltransformerCapacity.SelectedItem.ToString(), txtTransformerCapacity.Text, ddltransformerType.SelectedItem.ToString(), txtManufacturingyear.Text.Trim(),
                    _PrimaryVoltage, _SecondaryVoltage, txtMake.Text.ToString(),
                    txtLastInspectionIssueDate.Text.ToString(), ApplicantType, VoltageLevel, District, Division,
                    Inspectiontype,
                    CreatedBy);
                CEI.UpdateInstallations(installationNo, IntimationId);

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
            ddltransformerCapacity.SelectedValue = "0";
            txtTransformerCapacity.Text = "";
            ddltransformerType.SelectedValue = "0";
            txtMake.Text = "";
            txtTransformerSerialNumber.Text = "";
            ddlPrimaryVoltage();
            ddlSecondarVoltage();
        }


    }
}