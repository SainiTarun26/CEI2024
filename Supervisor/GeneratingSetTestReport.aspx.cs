using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Supervisor
{
    public partial class GeneratingSetTestReport : System.Web.UI.Page
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
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["SupervisorID"] != null || Request.Cookies["SupervisorID"] != null)
                {
                    if (!IsPostBack)
                    {
                        ddlEarthing();
                        SessionValue();
                        PageWorking();
                        if (Convert.ToString(Session["ValueId"]) == null || Convert.ToString(Session["ValueId"]) == "")
                        {

                        }
                        else
                        {
                            Generaterset_Id = Session["GeneratingSetId"].ToString().Trim();
                            GetHistoryDataById();
                        }
                        if (Convert.ToString(Session["Approval"]) == "Reject")
                        {
                            Generaterset_Id = Session["GeneratingSetId"].ToString().Trim();
                            Session["Application"] = Session["ApplicationForTestReport"].ToString().Trim();
                            Session["Typs"] = Session["TypeOf"].ToString().Trim();
                            Session["Intimations"] = Session["ID"].ToString().Trim();
                            Session["IHID"] = Session["IHIDs"].ToString().Trim();
                            Session["NoOfInstallations"] = Session["NoOfInstallation"].ToString().Trim();
                            GetHistoryDataById();
                            BtnBack.Visible = true;
                            // BtnSubmitGeneratingSet.Text = "Update";


                        }
                        else
                        {

                        }
                        if (Convert.ToString(Session["ContractorID"]) == null || Convert.ToString(Session["ContractorID"]) == "")
                        {

                        }
                        else
                        {

                            BtnBack.Visible = false;
                            btnVerify.Visible = false;
                            // BtnSubmitGeneratingSet.Visible = false;

                        }
                        txtapplication.Text = Session["Application"].ToString().Trim();
                        txtInstallation.Text = Session["Typs"].ToString().Trim();
                        txtid.Text = Session["Intimations"].ToString().Trim();
                        txtNOOfInstallation.Text = Session["NoOfInstallations"].ToString().Trim() + " Out of " + Session["TotalInstallation"].ToString().Trim();

                    }
                }
                else
                {
                    Response.Redirect("/Login.aspx");
                }
            }
            catch
            {
                Response.Redirect("/Login.aspx");
            }
        }

        private void GetHistoryDataById()
        {
            try
            {

                //if (Convert.ToString(Session["value"]) == null || Convert.ToString(Session["value"]) == "")
                //{

                //}
                //else
                //{
                //    type = Session["value"].ToString();
                //}
                Generaterset_Id = Session["GeneratingSetId"].ToString().Trim();
                type = "Generating Station";
                //if (Convert.ToString(Session["Approval"]) == "Reject")
                //{
                //    type = "Generating Station";
                //}

                DataSet ds = new DataSet();
                ds = CEI.GetTestReportDataForUpdate(type, Generaterset_Id);
                if (ds.Tables.Count > 0)
                {
                    Session["Contact"] = ds.Tables[0].Rows[0]["ContractorContactNo"].ToString();
                    Session["TestReportId"] = ds.Tables[0].Rows[0]["TestReportId"].ToString().Trim();

                    string Capacity = ds.Tables[0].Rows[0]["GeneratingSetCapacityType"].ToString();
                    ddlCapacity.SelectedIndex = ddlCapacity.Items.IndexOf(ddlCapacity.Items.FindByText(Capacity));
                    txtCapacity.Text = ds.Tables[0].Rows[0]["GeneratingSetCapacity"].ToString();
                    txtSerialNoOfGenerator.Text = ds.Tables[0].Rows[0]["SerialNumbrOfAcGenerator"].ToString();

                    txtGeneratorVoltage.Text = ds.Tables[0].Rows[0]["GeneratorVoltageLevel"].ToString();
                    txtCurrentCapacity.Text = ds.Tables[0].Rows[0]["CurrenntCapacityOfBreaker"].ToString();
                    txtBreakingCapacity.Text = ds.Tables[0].Rows[0]["BreakingCapacityofBreaker"].ToString();

                    string generaterType = ds.Tables[0].Rows[0]["GeneratingSetType"].ToString();
                    ddlGeneratingSetType.SelectedIndex = ddlGeneratingSetType.Items.IndexOf(ddlGeneratingSetType.Items.FindByText(generaterType));
                    if (generaterType == "Solar Panel")
                    {
                        SolarPanelGeneratingSet.Visible = true;

                        string TypeOfPlant = ds.Tables[0].Rows[0]["TypeOfPlant"].ToString();
                        ddlPlantType.SelectedIndex = ddlPlantType.Items.IndexOf(ddlPlantType.Items.FindByText(TypeOfPlant));

                        string CapacityOfPlant = ds.Tables[0].Rows[0]["CapacityOfPlantType"].ToString();
                        ddlPlantCapacity.SelectedIndex = ddlPlantCapacity.Items.IndexOf(ddlPlantCapacity.Items.FindByText(CapacityOfPlant));

                        txtPlantCapacity.Text = ds.Tables[0].Rows[0]["CapacityOfPlant"].ToString();
                        txtDCString.Text = ds.Tables[0].Rows[0]["HighestVoltageLevelOfDCString"].ToString();
                        txtLowestInsulation.Text = ds.Tables[0].Rows[0]["LowestInsulationBetweenDCWireToEarth"].ToString();
                        txtPCVOrSolar.Text = ds.Tables[0].Rows[0]["NoOfPowerPCV"].ToString();
                        txtLTACCapacity.Text = ds.Tables[0].Rows[0]["LTACBreakerCapacity"].ToString();
                        txtLowestInsulationAC.Text = ds.Tables[0].Rows[0]["ACCablesLowestInsulation"].ToString();
                    }
                    string NoOfEarthing = ds.Tables[0].Rows[0]["NumberOfEarthing"].ToString();
                    ddlGeneratingEarthing.SelectedIndex = ddlGeneratingEarthing.Items.IndexOf(ddlGeneratingEarthing.Items.FindByText(NoOfEarthing));
                    if (NoOfEarthing != null)
                    {
                        GeneratingEarthing.Visible = true;
                        if (NoOfEarthing == "4")
                        {
                            GeneratingEarthing4.Visible = true;
                        }
                        else if (NoOfEarthing == "5")
                        {
                            GeneratingEarthing4.Visible = true;
                            GeneratingEarthing5.Visible = true;
                        }
                        else if (NoOfEarthing == "6")
                        {
                            GeneratingEarthing4.Visible = true;
                            GeneratingEarthing5.Visible = true;
                            GeneratingEarthing6.Visible = true;
                        }
                        else if (NoOfEarthing == "7")
                        {
                            GeneratingEarthing4.Visible = true;
                            GeneratingEarthing5.Visible = true;
                            GeneratingEarthing6.Visible = true;
                            GeneratingEarthing7.Visible = true;
                        }
                        else if (NoOfEarthing == "8")
                        {
                            GeneratingEarthing4.Visible = true;
                            GeneratingEarthing5.Visible = true;
                            GeneratingEarthing6.Visible = true;
                            GeneratingEarthing7.Visible = true;
                            GeneratingEarthing8.Visible = true;
                        }
                        else if (NoOfEarthing == "9")
                        {
                            GeneratingEarthing4.Visible = true;
                            GeneratingEarthing5.Visible = true;
                            GeneratingEarthing6.Visible = true;
                            GeneratingEarthing7.Visible = true;
                            GeneratingEarthing8.Visible = true;
                            GeneratingEarthing9.Visible = true;
                        }
                        else if (NoOfEarthing == "10")
                        {
                            GeneratingEarthing4.Visible = true;
                            GeneratingEarthing5.Visible = true;
                            GeneratingEarthing6.Visible = true;
                            GeneratingEarthing7.Visible = true;
                            GeneratingEarthing8.Visible = true;
                            GeneratingEarthing9.Visible = true;
                            GeneratingEarthing10.Visible = true;
                        }
                        else if (NoOfEarthing == "11")
                        {
                            GeneratingEarthing4.Visible = true;
                            GeneratingEarthing5.Visible = true;
                            GeneratingEarthing6.Visible = true;
                            GeneratingEarthing7.Visible = true;
                            GeneratingEarthing8.Visible = true;
                            GeneratingEarthing9.Visible = true;
                            GeneratingEarthing10.Visible = true;
                            GeneratingEarthing11.Visible = true;
                        }
                        else if (NoOfEarthing == "12")
                        {
                            GeneratingEarthing4.Visible = true;
                            GeneratingEarthing5.Visible = true;
                            GeneratingEarthing6.Visible = true;
                            GeneratingEarthing7.Visible = true;
                            GeneratingEarthing8.Visible = true;
                            GeneratingEarthing9.Visible = true;
                            GeneratingEarthing10.Visible = true;
                            GeneratingEarthing11.Visible = true;
                            GeneratingEarthing12.Visible = true;
                        }
                        else if (NoOfEarthing == "13")
                        {
                            GeneratingEarthing4.Visible = true;
                            GeneratingEarthing5.Visible = true;
                            GeneratingEarthing6.Visible = true;
                            GeneratingEarthing7.Visible = true;
                            GeneratingEarthing8.Visible = true;
                            GeneratingEarthing9.Visible = true;
                            GeneratingEarthing10.Visible = true;
                            GeneratingEarthing11.Visible = true;
                            GeneratingEarthing12.Visible = true;
                            GeneratingEarthing13.Visible = true;
                        }
                        else if (NoOfEarthing == "14")
                        {
                            GeneratingEarthing4.Visible = true;
                            GeneratingEarthing5.Visible = true;
                            GeneratingEarthing6.Visible = true;
                            GeneratingEarthing7.Visible = true;
                            GeneratingEarthing8.Visible = true;
                            GeneratingEarthing9.Visible = true;
                            GeneratingEarthing10.Visible = true;
                            GeneratingEarthing11.Visible = true;
                            GeneratingEarthing12.Visible = true;
                            GeneratingEarthing13.Visible = true;
                            GeneratingEarthing14.Visible = true;
                        }
                        else if (NoOfEarthing == "15")
                        {
                            GeneratingEarthing4.Visible = true;
                            GeneratingEarthing5.Visible = true;
                            GeneratingEarthing6.Visible = true;
                            GeneratingEarthing7.Visible = true;
                            GeneratingEarthing8.Visible = true;
                            GeneratingEarthing9.Visible = true;
                            GeneratingEarthing10.Visible = true;
                            GeneratingEarthing11.Visible = true;
                            GeneratingEarthing12.Visible = true;
                            GeneratingEarthing13.Visible = true;
                            GeneratingEarthing14.Visible = true;
                            GeneratingEarthing15.Visible = true;
                        }

                        string EarthingType1 = ds.Tables[0].Rows[0]["EarthingType1"].ToString();
                        ddlGeneratingEarthing1.SelectedIndex = ddlGeneratingEarthing1.Items.IndexOf(ddlGeneratingEarthing1.Items.FindByText(EarthingType1));
                        txtGeneratingEarthing1.Text = ds.Tables[0].Rows[0]["EarthingValue1"].ToString();
                        string UsedFor1 = ds.Tables[0].Rows[0]["UsedFor1"].ToString();
                        ddlGeneratingEarthingUsed1.SelectedIndex = ddlGeneratingEarthingUsed1.Items.IndexOf(ddlGeneratingEarthingUsed1.Items.FindByText(UsedFor1));
                        if (UsedFor1 == "Other")
                        {
                            txtOtherEarthing1.Visible = true;
                            txtOtherEarthing1.Text = ds.Tables[0].Rows[0]["OtherEarthing1"].ToString();
                        }
                        string EarthingType2 = ds.Tables[0].Rows[0]["EarthingType2"].ToString();
                        ddlGeneratingEarthing2.SelectedIndex = ddlGeneratingEarthing2.Items.IndexOf(ddlGeneratingEarthing2.Items.FindByText(EarthingType2));
                        txtGeneratingEarthing2.Text = ds.Tables[0].Rows[0]["EarthingValue2"].ToString();
                        string UsedFor2 = ds.Tables[0].Rows[0]["UsedFor2"].ToString();
                        ddlGeneratingEarthingUsed2.SelectedIndex = ddlGeneratingEarthingUsed2.Items.IndexOf(ddlGeneratingEarthingUsed2.Items.FindByText(UsedFor2));
                        if (UsedFor2 == "Other")
                        {
                            txtOtherEarthing2.Visible = true;
                            txtOtherEarthing2.Text = ds.Tables[0].Rows[0]["OtherEarthing2"].ToString();
                        }
                        string EarthingType3 = ds.Tables[0].Rows[0]["EarthingType3"].ToString();
                        ddlGeneratingEarthing3.SelectedIndex = ddlGeneratingEarthing3.Items.IndexOf(ddlGeneratingEarthing3.Items.FindByText(EarthingType3));
                        txtGeneratingEarthing3.Text = ds.Tables[0].Rows[0]["EarthingValue3"].ToString();
                        string UsedFor3 = ds.Tables[0].Rows[0]["UsedFor3"].ToString();
                        ddlGeneratingEarthingUsed3.SelectedIndex = ddlGeneratingEarthingUsed3.Items.IndexOf(ddlGeneratingEarthingUsed3.Items.FindByText(UsedFor3));
                        if (UsedFor3 == "Other")
                        {
                            txtOtherEarthing3.Visible = true;
                            txtOtherEarthing3.Text = ds.Tables[0].Rows[0]["OtherEarthing3"].ToString();
                        }
                        string EarthingType4 = ds.Tables[0].Rows[0]["EarthingType4"].ToString();
                        ddlGeneratingEarthing4.SelectedIndex = ddlGeneratingEarthing4.Items.IndexOf(ddlGeneratingEarthing4.Items.FindByText(EarthingType4));
                        txtGeneratingEarthing4.Text = ds.Tables[0].Rows[0]["EarthingValue4"].ToString();
                        string UsedFor4 = ds.Tables[0].Rows[0]["UsedFor4"].ToString();
                        ddlGeneratingEarthingUsed4.SelectedIndex = ddlGeneratingEarthingUsed4.Items.IndexOf(ddlGeneratingEarthingUsed4.Items.FindByText(UsedFor4));
                        if (UsedFor4 == "Other")
                        {
                            txtOtherEarthing4.Visible = true;
                            txtOtherEarthing4.Text = ds.Tables[0].Rows[0]["OtherEarthing4"].ToString();
                        }
                        string EarthingType5 = ds.Tables[0].Rows[0]["EarthingType5"].ToString();
                        ddlGeneratingEarthing5.SelectedIndex = ddlGeneratingEarthing4.Items.IndexOf(ddlGeneratingEarthing4.Items.FindByText(EarthingType5));
                        txtGeneratingEarthing5.Text = ds.Tables[0].Rows[0]["EarthingValue5"].ToString();
                        string UsedFor5 = ds.Tables[0].Rows[0]["UsedFor5"].ToString();
                        ddlGeneratingEarthingUsed5.SelectedIndex = ddlGeneratingEarthingUsed5.Items.IndexOf(ddlGeneratingEarthingUsed5.Items.FindByText(UsedFor5));
                        if (UsedFor5 == "Other")
                        {
                            txtOtherEarthing5.Visible = true;
                            txtOtherEarthing5.Text = ds.Tables[0].Rows[0]["OtherEarthing5"].ToString();
                        }
                        string EarthingType6 = ds.Tables[0].Rows[0]["EarthingType6"].ToString();
                        ddlGeneratingEarthing6.SelectedIndex = ddlGeneratingEarthing4.Items.IndexOf(ddlGeneratingEarthing4.Items.FindByText(EarthingType6));
                        txtGeneratingEarthing6.Text = ds.Tables[0].Rows[0]["EarthingValue6"].ToString();
                        string UsedFor6 = ds.Tables[0].Rows[0]["UsedFor6"].ToString();
                        ddlGeneratingEarthingUsed6.SelectedIndex = ddlGeneratingEarthingUsed6.Items.IndexOf(ddlGeneratingEarthingUsed6.Items.FindByText(UsedFor6));
                        if (UsedFor6 == "Other")
                        {
                            txtOtherEarthing6.Visible = true;
                            txtOtherEarthing6.Text = ds.Tables[0].Rows[0]["OtherEarthing6"].ToString();
                        }
                        string EarthingType7 = ds.Tables[0].Rows[0]["EarthingType7"].ToString();
                        ddlGeneratingEarthing7.SelectedIndex = ddlGeneratingEarthing4.Items.IndexOf(ddlGeneratingEarthing4.Items.FindByText(EarthingType7));
                        txtGeneratingEarthing7.Text = ds.Tables[0].Rows[0]["EarthingValue7"].ToString();
                        string UsedFor7 = ds.Tables[0].Rows[0]["UsedFor7"].ToString();
                        ddlGeneratingEarthingUsed7.SelectedIndex = ddlGeneratingEarthingUsed7.Items.IndexOf(ddlGeneratingEarthingUsed7.Items.FindByText(UsedFor7));
                        if (UsedFor7 == "Other")
                        {
                            txtOtherEarthing7.Visible = true;
                            txtOtherEarthing7.Text = ds.Tables[0].Rows[0]["OtherEarthing7"].ToString();
                        }
                        string EarthingType8 = ds.Tables[0].Rows[0]["EarthingType8"].ToString();
                        ddlGeneratingEarthing8.SelectedIndex = ddlGeneratingEarthing8.Items.IndexOf(ddlGeneratingEarthing8.Items.FindByText(EarthingType8));
                        txtGeneratingEarthing8.Text = ds.Tables[0].Rows[0]["EarthingValue8"].ToString();
                        string UsedFor8 = ds.Tables[0].Rows[0]["UsedFor8"].ToString();
                        ddlGeneratingEarthingUsed8.SelectedIndex = ddlGeneratingEarthingUsed8.Items.IndexOf(ddlGeneratingEarthingUsed8.Items.FindByText(UsedFor8));
                        if (UsedFor8 == "Other")
                        {
                            txtOtherEarthing8.Visible = true;
                            txtOtherEarthing8.Text = ds.Tables[0].Rows[0]["OtherEarthing8"].ToString();
                        }
                        string EarthingType9 = ds.Tables[0].Rows[0]["EarthingType9"].ToString();
                        ddlGeneratingEarthing9.SelectedIndex = ddlGeneratingEarthing9.Items.IndexOf(ddlGeneratingEarthing9.Items.FindByText(EarthingType6));
                        txtGeneratingEarthing9.Text = ds.Tables[0].Rows[0]["EarthingValue9"].ToString();
                        string UsedFor9 = ds.Tables[0].Rows[0]["UsedFor9"].ToString();
                        ddlGeneratingEarthingUsed9.SelectedIndex = ddlGeneratingEarthingUsed9.Items.IndexOf(ddlGeneratingEarthingUsed9.Items.FindByText(UsedFor9));
                        if (UsedFor9 == "Other")
                        {
                            txtOtherEarthing9.Visible = true;
                            txtOtherEarthing9.Text = ds.Tables[0].Rows[0]["OtherEarthing9"].ToString();
                        }
                        string EarthingType10 = ds.Tables[0].Rows[0]["EarthingType10"].ToString();
                        ddlGeneratingEarthing10.SelectedIndex = ddlGeneratingEarthing4.Items.IndexOf(ddlGeneratingEarthing10.Items.FindByText(EarthingType10));
                        txtGeneratingEarthing10.Text = ds.Tables[0].Rows[0]["EarthingValue10"].ToString();
                        string UsedFor10 = ds.Tables[0].Rows[0]["UsedFor10"].ToString();
                        ddlGeneratingEarthingUsed10.SelectedIndex = ddlGeneratingEarthingUsed10.Items.IndexOf(ddlGeneratingEarthingUsed10.Items.FindByText(UsedFor10));
                        if (UsedFor10 == "Other")
                        {
                            txtOtherEarthing10.Visible = true;
                            txtOtherEarthing10.Text = ds.Tables[0].Rows[0]["OtherEarthing10"].ToString();
                        }
                        string EarthingType11 = ds.Tables[0].Rows[0]["EarthingType11"].ToString();
                        ddlGeneratingEarthing11.SelectedIndex = ddlGeneratingEarthing11.Items.IndexOf(ddlGeneratingEarthing11.Items.FindByText(EarthingType11));
                        txtGeneratingEarthing11.Text = ds.Tables[0].Rows[0]["EarthingValue11"].ToString();
                        string UsedFor11 = ds.Tables[0].Rows[0]["UsedFor11"].ToString();
                        ddlGeneratingEarthingUsed11.SelectedIndex = ddlGeneratingEarthingUsed11.Items.IndexOf(ddlGeneratingEarthingUsed11.Items.FindByText(UsedFor11));
                        if (UsedFor11 == "Other")
                        {
                            txtOtherEarthing11.Visible = true;
                            txtOtherEarthing11.Text = ds.Tables[0].Rows[0]["OtherEarthing11"].ToString();
                        }
                        string EarthingType12 = ds.Tables[0].Rows[0]["EarthingType12"].ToString();
                        ddlGeneratingEarthing12.SelectedIndex = ddlGeneratingEarthing12.Items.IndexOf(ddlGeneratingEarthing12.Items.FindByText(EarthingType12));
                        txtGeneratingEarthing12.Text = ds.Tables[0].Rows[0]["EarthingValue12"].ToString();
                        string UsedFor12 = ds.Tables[0].Rows[0]["UsedFor12"].ToString();
                        ddlGeneratingEarthingUsed12.SelectedIndex = ddlGeneratingEarthingUsed12.Items.IndexOf(ddlGeneratingEarthingUsed12.Items.FindByText(UsedFor12));
                        if (UsedFor12 == "Other")
                        {
                            txtOtherEarthing12.Visible = true;
                            txtOtherEarthing12.Text = ds.Tables[0].Rows[0]["OtherEarthing12"].ToString();
                        }
                        string EarthingType13 = ds.Tables[0].Rows[0]["EarthingType13"].ToString();
                        ddlGeneratingEarthing13.SelectedIndex = ddlGeneratingEarthing13.Items.IndexOf(ddlGeneratingEarthing13.Items.FindByText(EarthingType13));
                        txtGeneratingEarthing13.Text = ds.Tables[0].Rows[0]["EarthingValue13"].ToString();
                        string UsedFor13 = ds.Tables[0].Rows[0]["UsedFor13"].ToString();
                        ddlGeneratingEarthingUsed13.SelectedIndex = ddlGeneratingEarthingUsed13.Items.IndexOf(ddlGeneratingEarthingUsed13.Items.FindByText(UsedFor13));
                        if (UsedFor13 == "Other")
                        {
                            txtOtherEarthing13.Visible = true;
                            txtOtherEarthing13.Text = ds.Tables[0].Rows[0]["OtherEarthing13"].ToString();
                        }
                        string EarthingType14 = ds.Tables[0].Rows[0]["EarthingType14"].ToString();
                        ddlGeneratingEarthing14.SelectedIndex = ddlGeneratingEarthing14.Items.IndexOf(ddlGeneratingEarthing14.Items.FindByText(EarthingType14));
                        txtGeneratingEarthing14.Text = ds.Tables[0].Rows[0]["EarthingValue14"].ToString();
                        string UsedFor14 = ds.Tables[0].Rows[0]["UsedFor14"].ToString();
                        ddlGeneratingEarthingUsed14.SelectedIndex = ddlGeneratingEarthingUsed14.Items.IndexOf(ddlGeneratingEarthingUsed14.Items.FindByText(UsedFor14));
                        if (UsedFor14 == "Other")
                        {
                            txtOtherEarthing14.Visible = true;
                            txtOtherEarthing14.Text = ds.Tables[0].Rows[0]["OtherEarthing14"].ToString();
                        }
                        string EarthingType15 = ds.Tables[0].Rows[0]["EarthingType15"].ToString();
                        ddlGeneratingEarthing15.SelectedIndex = ddlGeneratingEarthing4.Items.IndexOf(ddlGeneratingEarthing15.Items.FindByText(EarthingType15));
                        txtGeneratingEarthing15.Text = ds.Tables[0].Rows[0]["EarthingValue15"].ToString();
                        string UsedFor15 = ds.Tables[0].Rows[0]["UsedFor15"].ToString();
                        ddlGeneratingEarthingUsed15.SelectedIndex = ddlGeneratingEarthingUsed15.Items.IndexOf(ddlGeneratingEarthingUsed15.Items.FindByText(UsedFor15));
                        if (UsedFor15 == "Other")
                        {
                            txtOtherEarthing15.Visible = true;
                            txtOtherEarthing15.Text = ds.Tables[0].Rows[0]["OtherEarthing15"].ToString();
                        }
                    }

                    if (Session["Approval"].ToString().Trim() == "Reject")
                    {
                        btnSubmit.Text = "Update";
                        //BtnSubmitGeneratingSet.Text = "Update";
                    }
                    else
                    {
                        //BtnSubmitGeneratingSet.Visible = false;
                        BtnBack.Visible = true;

                    }

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
                dsEarthing = CEI.GetddlEarthingSubstation();
                ddlGeneratingEarthing.DataSource = dsEarthing;
                ddlGeneratingEarthing.DataTextField = "NumberOfEarthing";
                ddlGeneratingEarthing.DataValueField = "NumberOfEarthing";
                ddlGeneratingEarthing.DataBind();
                ddlGeneratingEarthing.Items.Insert(0, new ListItem("Select", "0"));
                dsEarthing.Clear();
            }
            catch (Exception)
            {
                //msg.Text = ex.Message;
            }
        }
        protected void BtnBack_Click(object sender, EventArgs e)
        {
            if (Session["TestReportHistory"] != null)
            {
                Response.Redirect("/Supervisor/TestReportHistory.aspx", false);
            }
            else if (Session["TestReportHistory"] == null)
            {
                Response.Redirect("/Supervisor/InstallationDetails.aspx", false);
            }
            else
            {
                // Response.Redirect("/Admin/TestHistoryReport.aspx", false);

            }
        }
        protected void ddlGeneratingSetType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlGeneratingSetType.SelectedValue == "3")
            {
                SolarPanelGeneratingSet.Visible = true;
                // ddlGeneratingEarthing.SelectedValue = "0";             
                GeneratingEarthing.Visible = false;
            }
            else
            {
                SolarPanelGeneratingSet.Visible = false;
            }

        }
        protected void ddlGeneratingEarthing_SelectedIndexChanged(object sender, EventArgs e)

        {
            GeneratingEarthing.Visible = true;
            GeneratingEarthing4.Visible = false;
            GeneratingEarthing5.Visible = false;
            GeneratingEarthing6.Visible = false;
            GeneratingEarthing7.Visible = false;
            GeneratingEarthing8.Visible = false;
            GeneratingEarthing9.Visible = false;
            GeneratingEarthing10.Visible = false;
            GeneratingEarthing11.Visible = false;
            GeneratingEarthing12.Visible = false;
            GeneratingEarthing13.Visible = false;
            GeneratingEarthing14.Visible = false;
            GeneratingEarthing15.Visible = false;
            Limit.Visible = false;
            if (ddlGeneratingEarthing.SelectedItem.ToString() == "4")
            {
                Limit.Visible = false;
                GeneratingEarthing4.Visible = true;
            }
            else if (ddlGeneratingEarthing.SelectedItem.ToString() == "5")
            {
                Limit.Visible = false;
                GeneratingEarthing4.Visible = true;
                GeneratingEarthing5.Visible = true;
            }
            else if (ddlGeneratingEarthing.SelectedItem.ToString() == "6")
            {
                Limit.Visible = false;
                GeneratingEarthing4.Visible = true;
                GeneratingEarthing5.Visible = true;
                GeneratingEarthing6.Visible = true;
            }
            else if (ddlGeneratingEarthing.SelectedItem.ToString() == "7")
            {
                Limit.Visible = false;
                GeneratingEarthing4.Visible = true;
                GeneratingEarthing5.Visible = true;
                GeneratingEarthing6.Visible = true;
                GeneratingEarthing7.Visible = true;
            }
            else if (ddlGeneratingEarthing.SelectedItem.ToString() == "8")
            {
                Limit.Visible = false;
                GeneratingEarthing4.Visible = true;
                GeneratingEarthing5.Visible = true;
                GeneratingEarthing6.Visible = true;
                GeneratingEarthing7.Visible = true;
                GeneratingEarthing8.Visible = true;
            }
            else if (ddlGeneratingEarthing.SelectedItem.ToString() == "9")
            {
                Limit.Visible = false;
                GeneratingEarthing4.Visible = true;
                GeneratingEarthing5.Visible = true;
                GeneratingEarthing6.Visible = true;
                GeneratingEarthing7.Visible = true;
                GeneratingEarthing8.Visible = true;
                GeneratingEarthing9.Visible = true;
            }
            else if (ddlGeneratingEarthing.SelectedItem.ToString() == "10")
            {
                Limit.Visible = false;
                GeneratingEarthing4.Visible = true;
                GeneratingEarthing5.Visible = true;
                GeneratingEarthing6.Visible = true;
                GeneratingEarthing7.Visible = true;
                GeneratingEarthing8.Visible = true;
                GeneratingEarthing9.Visible = true;
                GeneratingEarthing10.Visible = true;
            }
            else if (ddlGeneratingEarthing.SelectedItem.ToString() == "11")
            {
                Limit.Visible = false;
                GeneratingEarthing4.Visible = true;
                GeneratingEarthing5.Visible = true;
                GeneratingEarthing6.Visible = true;
                GeneratingEarthing7.Visible = true;
                GeneratingEarthing8.Visible = true;
                GeneratingEarthing9.Visible = true;
                GeneratingEarthing10.Visible = true;
                GeneratingEarthing11.Visible = true;
            }
            else if (ddlGeneratingEarthing.SelectedItem.ToString() == "12")
            {
                Limit.Visible = false;
                GeneratingEarthing4.Visible = true;
                GeneratingEarthing5.Visible = true;
                GeneratingEarthing6.Visible = true;
                GeneratingEarthing7.Visible = true;
                GeneratingEarthing8.Visible = true;
                GeneratingEarthing9.Visible = true;
                GeneratingEarthing10.Visible = true;
                GeneratingEarthing11.Visible = true;
                GeneratingEarthing12.Visible = true;
            }
            else if (ddlGeneratingEarthing.SelectedItem.ToString() == "13")
            {
                Limit.Visible = false;
                GeneratingEarthing4.Visible = true;
                GeneratingEarthing5.Visible = true;
                GeneratingEarthing6.Visible = true;
                GeneratingEarthing7.Visible = true;
                GeneratingEarthing8.Visible = true;
                GeneratingEarthing9.Visible = true;
                GeneratingEarthing10.Visible = true;
                GeneratingEarthing11.Visible = true;
                GeneratingEarthing12.Visible = true;
                GeneratingEarthing13.Visible = true;
            }
            else if (ddlGeneratingEarthing.SelectedItem.ToString() == "14")
            {
                Limit.Visible = false;
                GeneratingEarthing4.Visible = true;
                GeneratingEarthing5.Visible = true;
                GeneratingEarthing6.Visible = true;
                GeneratingEarthing7.Visible = true;
                GeneratingEarthing8.Visible = true;
                GeneratingEarthing9.Visible = true;
                GeneratingEarthing10.Visible = true;
                GeneratingEarthing11.Visible = true;
                GeneratingEarthing12.Visible = true;
                GeneratingEarthing13.Visible = true;
                GeneratingEarthing14.Visible = true;
            }
            else if (ddlGeneratingEarthing.SelectedItem.ToString() == "15")
            {
                Limit.Visible = false;
                GeneratingEarthing4.Visible = true;
                GeneratingEarthing5.Visible = true;
                GeneratingEarthing6.Visible = true;
                GeneratingEarthing7.Visible = true;
                GeneratingEarthing8.Visible = true;
                GeneratingEarthing9.Visible = true;
                GeneratingEarthing10.Visible = true;
                GeneratingEarthing11.Visible = true;
                GeneratingEarthing12.Visible = true;
                GeneratingEarthing13.Visible = true;
                GeneratingEarthing14.Visible = true;
                GeneratingEarthing15.Visible = true;
            }





        }
        protected void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox3.Checked == false)
            {
                label2.Visible = true;
            }
            else
            {
                label2.Visible = false;
            }
        }
        protected void BtnSubmitGeneratingSet_Click(object sender, EventArgs e)
        {
            try
            {

                if (Declaration.Visible == true && CheckBox3.Checked == false)
                {

                    label2.Visible = true;

                }
                else
                {
                    if (Check.Checked == true)
                    {


                        string GeneratingSetId = string.Empty;
                        if (Convert.ToString(Session["GeneratingSetId"]) == null || Convert.ToString(Session["GeneratingSetId"]) == "")
                        {
                            GeneratingSetId = CEI.GenerateUniqueGeneratingSetId();
                            Session["GeneratingSetId"] = GeneratingSetId;
                        }
                        else
                        {
                            GeneratingSetId = Session["GeneratingSetId"].ToString();
                        }
                        //string TestReportId = Session["TestReportId"].ToString();
                        string IntimationId = Session["id"].ToString();
                        string CreatedBy = Session["SupervisorID"].ToString();
                        string installationNo = Session["IHID"].ToString();
                        string count = Session["NoOfInstallations"].ToString();
                        CEI.InsertGeneratingSetData(Id_Update, count, GeneratingSetId, IntimationId,
                            ddlCapacity.SelectedItem.ToString(), txtCapacity.Text, txtSerialNoOfGenerator.Text, ddlGeneratingSetType.SelectedItem.ToString(),
                   txtGeneratorVoltage.Text, txtCurrentCapacity.Text, txtBreakingCapacity.Text, ddlPlantType.SelectedItem.ToString(), ddlPlantCapacity.SelectedItem.ToString(),
                  txtPlantCapacity.Text, txtDCString.Text, txtLowestInsulation.Text, txtPCVOrSolar.Text, txtLTACCapacity.Text, txtLowestInsulationAC.Text,
                  ddlGeneratingEarthing.SelectedItem.ToString(), ddlGeneratingEarthing1.SelectedItem.ToString(), txtGeneratingEarthing1.Text, ddlGeneratingEarthingUsed1.SelectedItem.ToString(), txtOtherEarthing1.Text,
                  ddlGeneratingEarthing2.SelectedItem.ToString(), txtGeneratingEarthing2.Text, ddlGeneratingEarthingUsed2.SelectedItem.ToString(), txtOtherEarthing2.Text, ddlGeneratingEarthing3.SelectedItem.ToString(), txtGeneratingEarthing3.Text, ddlGeneratingEarthingUsed3.SelectedItem.ToString(), txtOtherEarthing3.Text,
                 ddlGeneratingEarthing4.SelectedItem.ToString(), txtGeneratingEarthing4.Text, ddlGeneratingEarthingUsed4.SelectedItem.ToString(), txtOtherEarthing4.Text, ddlGeneratingEarthing5.SelectedItem.ToString(), txtGeneratingEarthing5.Text, ddlGeneratingEarthingUsed5.SelectedItem.ToString(), txtOtherEarthing5.Text,
              ddlGeneratingEarthing6.SelectedItem.ToString(), txtGeneratingEarthing6.Text, ddlGeneratingEarthingUsed6.SelectedItem.ToString(), txtOtherEarthing6.Text, ddlGeneratingEarthing7.SelectedItem.ToString(), txtGeneratingEarthing7.Text, ddlGeneratingEarthingUsed7.SelectedItem.ToString(), txtOtherEarthing7.Text,
              ddlGeneratingEarthing8.SelectedItem.ToString(), txtGeneratingEarthing8.Text, ddlGeneratingEarthingUsed8.SelectedItem.ToString(), txtOtherEarthing8.Text, ddlGeneratingEarthing9.SelectedItem.ToString(), txtGeneratingEarthing9.Text, ddlGeneratingEarthingUsed9.SelectedItem.ToString(), txtOtherEarthing9.Text,
               ddlGeneratingEarthing10.SelectedItem.ToString(), txtGeneratingEarthing10.Text, ddlGeneratingEarthingUsed10.SelectedItem.ToString(), txtOtherEarthing10.Text, ddlGeneratingEarthing11.SelectedItem.ToString(), txtGeneratingEarthing11.Text, ddlGeneratingEarthingUsed11.SelectedItem.ToString(), txtOtherEarthing11.Text,
                ddlGeneratingEarthing12.SelectedItem.ToString(), txtGeneratingEarthing12.Text, ddlGeneratingEarthingUsed12.SelectedItem.ToString(), txtOtherEarthing12.Text, ddlGeneratingEarthing13.SelectedItem.ToString(), txtGeneratingEarthing13.Text, ddlGeneratingEarthingUsed13.SelectedItem.ToString(), txtOtherEarthing13.Text,
               ddlGeneratingEarthing14.SelectedItem.ToString(), txtGeneratingEarthing14.Text, ddlGeneratingEarthingUsed14.SelectedItem.ToString(), txtOtherEarthing14.Text, ddlGeneratingEarthing15.SelectedItem.ToString(), txtGeneratingEarthing15.Text, ddlGeneratingEarthingUsed15.SelectedItem.ToString(), txtOtherEarthing15.Text, CreatedBy);

                        CEI.UpdateInstallations(installationNo, IntimationId);
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Test report has been Updated and is under review by the Contractor for final submission')", true);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata();", true);
                        //Response.Redirect("/Supervisor/InstallationDetails.aspx", false);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert()", "alert('You have to check the declaration first !!!')", true);
                    }
                }
            }
            catch (Exception)
            {

                DataSaved.Visible = false;
            }
        }
        public void Reset()
        {
            ddlCapacity.SelectedValue = "0"; txtCapacity.Text = ""; txtSerialNoOfGenerator.Text = ""; ddlGeneratingSetType.SelectedValue = "0";
            txtGeneratorVoltage.Text = ""; txtCurrentCapacity.Text = ""; txtBreakingCapacity.Text = ""; ddlPlantType.SelectedValue = "0"; ddlPlantCapacity.SelectedValue = "0";
            txtPlantCapacity.Text = ""; txtDCString.Text = ""; txtLowestInsulation.Text = ""; txtPCVOrSolar.Text = ""; txtLTACCapacity.Text = ""; txtLowestInsulationAC.Text = "";
            ddlGeneratingEarthing.SelectedValue = "0"; ddlGeneratingEarthing1.SelectedValue = "0"; txtGeneratingEarthing1.Text = ""; ddlGeneratingEarthingUsed1.SelectedValue = "0"; txtOtherEarthing1.Text = "";
            ddlGeneratingEarthing2.SelectedValue = "0"; txtGeneratingEarthing2.Text = ""; ddlGeneratingEarthingUsed2.SelectedValue = "0"; txtOtherEarthing2.Text = ""; ddlGeneratingEarthing3.SelectedValue = "0"; txtGeneratingEarthing3.Text = ""; ddlGeneratingEarthingUsed3.SelectedValue = "0"; txtOtherEarthing3.Text = "";
            ddlGeneratingEarthing4.SelectedValue = "0"; txtGeneratingEarthing4.Text = ""; ddlGeneratingEarthingUsed4.SelectedValue = "0"; txtOtherEarthing4.Text = ""; ddlGeneratingEarthing5.SelectedValue = "0"; txtGeneratingEarthing5.Text = ""; ddlGeneratingEarthingUsed5.SelectedValue = "0"; txtOtherEarthing5.Text = "";
            ddlGeneratingEarthing6.SelectedValue = "0"; txtGeneratingEarthing6.Text = ""; ddlGeneratingEarthingUsed6.SelectedValue = "0"; txtOtherEarthing6.Text = ""; ddlGeneratingEarthing7.SelectedValue = "0"; txtGeneratingEarthing7.Text = ""; ddlGeneratingEarthingUsed7.SelectedValue = "0"; txtOtherEarthing7.Text = "";
            ddlGeneratingEarthing8.SelectedValue = "0"; txtGeneratingEarthing8.Text = ""; ddlGeneratingEarthingUsed8.SelectedValue = "0"; txtOtherEarthing8.Text = ""; ddlGeneratingEarthing9.SelectedValue = "0"; txtGeneratingEarthing9.Text = ""; ddlGeneratingEarthingUsed9.SelectedValue = "0"; txtOtherEarthing9.Text = "";
            ddlGeneratingEarthing10.SelectedValue = "0"; txtGeneratingEarthing10.Text = ""; ddlGeneratingEarthingUsed10.SelectedValue = "0"; txtOtherEarthing10.Text = ""; ddlGeneratingEarthing11.SelectedValue = "0"; txtGeneratingEarthing11.Text = ""; ddlGeneratingEarthingUsed11.SelectedValue = "0"; txtOtherEarthing11.Text = "";
            ddlGeneratingEarthing12.SelectedValue = "0"; txtGeneratingEarthing12.Text = ""; ddlGeneratingEarthingUsed12.SelectedValue = "0"; txtOtherEarthing12.Text = ""; ddlGeneratingEarthing13.SelectedValue = "0"; txtGeneratingEarthing13.Text = ""; ddlGeneratingEarthingUsed13.SelectedValue = "0"; txtOtherEarthing13.Text = "";
            ddlGeneratingEarthing14.SelectedValue = "0"; txtGeneratingEarthing14.Text = ""; ddlGeneratingEarthingUsed14.SelectedValue = "0"; txtOtherEarthing14.Text = ""; ddlGeneratingEarthing15.SelectedValue = "0"; txtGeneratingEarthing15.Text = ""; ddlGeneratingEarthingUsed15.SelectedValue = "0"; txtOtherEarthing15.Text = "";

            txtOtherEarthing3.Visible = false; txtOtherEarthing11.Visible = false; txtOtherEarthing2.Visible = false; txtOtherEarthing10.Visible = false;
            txtOtherEarthing5.Visible = false; txtOtherEarthing13.Visible = false; txtOtherEarthing4.Visible = false; txtOtherEarthing12.Visible = false;
            txtOtherEarthing7.Visible = false; txtOtherEarthing15.Visible = false; txtOtherEarthing6.Visible = false; txtOtherEarthing14.Visible = false;
            txtOtherEarthing9.Visible = false; txtOtherEarthing8.Visible = false; txtOtherEarthing1.Visible = false;

            SolarPanelGeneratingSet.Visible = false;
            GeneratingEarthing.Visible = false;

        }
        public void NextSessionValueAndName()
        {
            string[] installationNumbers = { "installationNo1", "installationNo2", "installationNo3", "installationNo4", "installationNo5", "installationNo6", "installationNo7", "installationNo8" };

            for (int i = 0; i < installationNumbers.Length; i++)
            {
                sessionName = Session["installationType" + (i + 1)] as string;
                sessionValue = Session[installationNumbers[i]] as string;

                if (!string.IsNullOrEmpty(sessionName))
                {
                    if (i < installationNumbers.Length - 1) // Check if there are more sessions left
                    {
                        nextSessionName = Session["installationType" + (i + 2)] as string;
                        nextSessionValue = Session[installationNumbers[i + 1]] as string;

                    }
                    else
                    {
                        nextSessionName = "";
                        nextSessionValue = "";
                    }

                }
            }
        }
        public void SessionValue()
        {
            try
            {
                string[] installationTypes = { "installationType1", "installationType2", "installationType3", "installationType4", "installationType5", "installationType7", "installationType8", "installationNo8" };
                string[] installationNumbers = { "installationNo1", "installationNo2", "installationNo3", "installationNo4", "installationNo5", "installationNo6", "installationNo7", "installationNo8" };

                int count = Convert.ToInt32(Session["Count"]);
                for (int i = count; i < installationNumbers.Length; i++)
                {
                    sessionName = Session[installationTypes[i]] as string;
                    sessionValue = Session[installationNumbers[i]] as string;
                    if (!string.IsNullOrEmpty(sessionName))
                    {
                        nextSessionName = Session[installationTypes[i + 1]] as string;
                        nextSessionValue = Session[installationNumbers[i + 1]] as string;
                        break;
                    }
                }
            }
            catch { }
        }
        public void PageWorking()
        {
            try
            {
                SessionValue();
                x = Convert.ToInt32(Session["Page"]);
                if (x + 1 == int.Parse(sessionValue) && nextSessionName == "")
                {
                    Declaration.Visible = true;
                    // BtnSubmitGeneratingSet.Text = "Submit";
                    //BtnSubmitGeneratingSet.Attributes.Add("disabled", "true");
                    btnVerify.Visible = true;
                }
                else
                {
                    Declaration.Visible = false;
                    //BtnSubmitGeneratingSet.Text = "Next";
                }
            }
            catch (Exception) { }
        }
        protected void ddlGeneratingEarthingUsed1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlGeneratingEarthingUsed1.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing1.Visible = true;
                RequiredFieldValidator61.Visible = true;
            }
            else
            {
                txtOtherEarthing1.Visible = false;
                RequiredFieldValidator61.Visible = false;
            }
        }

        protected void ddlGeneratingEarthingUsed2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlGeneratingEarthingUsed2.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing2.Visible = true;
                RequiredFieldValidator62.Visible = true;
            }
            else
            {
                txtOtherEarthing2.Visible = false;
                RequiredFieldValidator62.Visible = false;
            }
        }

        protected void ddlGeneratingEarthingUsed3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlGeneratingEarthingUsed3.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing3.Visible = true;
                RequiredFieldValidator63.Visible = true;
            }
            else
            {
                txtOtherEarthing3.Visible = false;
                RequiredFieldValidator63.Visible = false;
            }
        }

        protected void ddlGeneratingEarthingUsed4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlGeneratingEarthingUsed4.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing4.Visible = true;
                RequiredFieldValidator64.Visible = true;
            }
            else
            {
                txtOtherEarthing4.Visible = false;
                RequiredFieldValidator64.Visible = false;
            }
        }

        protected void ddlGeneratingEarthingUsed5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlGeneratingEarthingUsed5.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing5.Visible = true;
                RequiredFieldValidator65.Visible = true;
            }
            else
            {
                txtOtherEarthing5.Visible = false;
                RequiredFieldValidator65.Visible = false;
            }
        }

        protected void ddlGeneratingEarthingUsed6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlGeneratingEarthingUsed6.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing6.Visible = true;
                RequiredFieldValidator66.Visible = true;
            }
            else
            {
                txtOtherEarthing6.Visible = false;
                RequiredFieldValidator66.Visible = false;
            }
        }

        protected void ddlGeneratingEarthingUsed7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlGeneratingEarthingUsed7.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing7.Visible = true;
                RequiredFieldValidator67.Visible = true;
            }
            else
            {
                txtOtherEarthing7.Visible = false;
                RequiredFieldValidator67.Visible = false;
            }
        }

        protected void ddlGeneratingEarthingUsed8_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlGeneratingEarthingUsed8.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing8.Visible = true;
                RequiredFieldValidator68.Visible = true;
            }
            else
            {
                txtOtherEarthing8.Visible = false;
                RequiredFieldValidator68.Visible = false;
            }
        }

        protected void ddlGeneratingEarthingUsed10_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlGeneratingEarthingUsed10.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing10.Visible = true;
                RequiredFieldValidator70.Visible = true;
            }
            else
            {
                txtOtherEarthing10.Visible = false;
                RequiredFieldValidator70.Visible = false;
            }
        }

        protected void ddlGeneratingEarthingUsed11_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlGeneratingEarthingUsed11.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing11.Visible = true;
                RequiredFieldValidator71.Visible = true;
            }
            else
            {
                txtOtherEarthing11.Visible = false;
                RequiredFieldValidator71.Visible = false;
            }
        }

        protected void ddlGeneratingEarthingUsed12_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlGeneratingEarthingUsed12.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing12.Visible = true;
                RequiredFieldValidator72.Visible = true;
            }
            else
            {
                txtOtherEarthing12.Visible = false;
                RequiredFieldValidator72.Visible = false;
            }
        }

        protected void ddlGeneratingEarthingUsed13_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlGeneratingEarthingUsed13.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing13.Visible = true;
                RequiredFieldValidator73.Visible = true;
            }
            else
            {
                txtOtherEarthing13.Visible = false;
                RequiredFieldValidator73.Visible = false;
            }
        }

        protected void ddlGeneratingEarthingUsed14_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlGeneratingEarthingUsed14.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing14.Visible = true;
                RequiredFieldValidator6.Visible = true;
            }
            else
            {
                txtOtherEarthing14.Visible = false;
                RequiredFieldValidator6.Visible = false;
            }
        }

        protected void ddlGeneratingEarthingUsed15_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlGeneratingEarthingUsed15.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing15.Visible = true;
                RequiredFieldValidator7.Visible = true;
            }
            else
            {
                txtOtherEarthing15.Visible = false;
                RequiredFieldValidator7.Visible = false;
            }
        }

        protected void ddlGeneratingEarthingUsed9_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlGeneratingEarthingUsed9.SelectedItem.ToString() == "Other")
            {
                txtOtherEarthing9.Visible = true;
                RequiredFieldValidator69.Visible = true;
            }
            else
            {
                txtOtherEarthing9.Visible = false;
                RequiredFieldValidator69.Visible = false;
            }
        }

        protected void btnVerify_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(Session["OTP"]) == null || Convert.ToString(Session["OTP"]) == "")
                {
                    OTP.Visible = true;
                    string id = Session["SupervisorID"].ToString();
                    DataSet ds = new DataSet();
                    ds = CEI.GetSuperVisorContact(id);
                    string Contact = ds.Tables[0].Rows[0]["PhoneNo"].ToString();
                    string mobilenumber = Contact.Trim();
                    Session["OTP"] = CEI.ValidateOTP(mobilenumber);
                }
                else
                {
                    if (Session["OTP"].ToString() == txtOTP.Text.Trim())
                    {
                        //  BtnSubmitGeneratingSet.Attributes.Remove("disabled");
                        btnVerify.Attributes.Add("disabled", "true");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('InvalidOTP Please Try Again')", true);

                    }

                }
            }
            catch
            {

            }


        }
      
    }
}