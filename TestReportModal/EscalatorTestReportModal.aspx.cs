using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.TestReportModal
{
    public partial class EscalatorTestReportModal : System.Web.UI.Page
    {
        CEI CEI = new CEI();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (Request.UrlReferrer != null)
                    {
                        Session["PreviousPage"] = Request.UrlReferrer.ToString();
                    }

                    //Session["EscalatorTestReportID"] = "TEC-00004";
                    string TestReportId = string.Empty;
                    if (Convert.ToString(Session["EscalatorTestReportID"]) != null && Convert.ToString(Session["EscalatorTestReportID"]) != "")
                    {
                        TestReportId = Session["EscalatorTestReportID"].ToString();
                        GetDetailswithId(TestReportId);
                        GetDocument(TestReportId);
                    }
                }
            }
            catch
            {

            }

        }
        private void GetDocument(string TestReportId)
        {
            DataTable ds = new DataTable();
            ds = CEI.GetAttachments(TestReportId.Trim());
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
        public void GetDetailswithId(string TestReportId)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = CEI.GetLiftTestReportModalData("Escalator", TestReportId);
                lbltestReportId.Text = ds.Tables[0].Rows[0]["TestReportId"].ToString();
                lblWorkIntimationId.Text = ds.Tables[0].Rows[0]["IntimationId"].ToString();
                ddlApplicantType.Text = ds.Tables[0].Rows[0]["ApplicantType"].ToString();
                txtInstallationFor.Text = ds.Tables[0].Rows[0]["ContractorType"].ToString();
                txtTypeOfControld.Text = ds.Tables[0].Rows[0]["TypeOfControl"].ToString();
                if (txtInstallationFor.Text == "Firm/Organization/Company/Department")
                {
                    agency.Visible = true;
                    individual.Visible = false;
                }
                else
                {
                    individual.Visible = true;
                    agency.Visible = false;
                }
                txtName.Text = ds.Tables[0].Rows[0]["NameOfOwner"].ToString();
                txtagency.Text = ds.Tables[0].Rows[0]["NameOfAgency"].ToString();
                txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                txtState.Text = "Haryana";
                txtDistrict.Text = ds.Tables[0].Rows[0]["District"].ToString();
                //txtEscalatorType.Text = ds.Tables[0].Rows[0]["TypeOfEscalator"].ToString();
                txtSerialNo.Text = ds.Tables[0].Rows[0]["SerialNo"].ToString();
                txtMake.Text = ds.Tables[0].Rows[0]["Make"].ToString();
                txtPin.Text = ds.Tables[0].Rows[0]["Pincode"].ToString();
                txtPhone.Text = ds.Tables[0].Rows[0]["ContactNo"].ToString();
                txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                string dp_Id1 = ds.Tables[0].Rows[0]["TypeOfInstallation1"].ToString();
                string dp_Id2 = ds.Tables[0].Rows[0]["TypeOfInstallation2"].ToString();
                string LocalAgent = ds.Tables[0].Rows[0]["NameandAddressofLocalAgent"].ToString();
                if (dp_Id1 != "")
                {
                    Installation.Visible = true;
                    installationType1.Visible = true;
                    txtinstallationNo1.Text = ds.Tables[0].Rows[0]["NumberOfInstallation1"].ToString();
                }
                else
                {
                    //Installation.Visible = false;
                    installationType1.Visible = false;
                }
                if (dp_Id2 != "")
                {
                    Installation.Visible = true;
                    installationType2.Visible = true;
                    txtinstallationNo2.Text = ds.Tables[0].Rows[0]["NumberOfInstallation2"].ToString();
                }
                else
                {

                    // Installation.Visible = false;
                    installationType2.Visible = false;
                }
                if (LocalAgent == "Yes")
                {
                    TxtAgentName.Text = ds.Tables[0].Rows[0]["NameofLocalAgent"].ToString();
                    txtAgentAddress.Text = ds.Tables[0].Rows[0]["AddressofLocalAgent"].ToString();
                    txtAgentPhone.Text = ds.Tables[0].Rows[0]["ContactNoofLocalAgent"].ToString();

                }
                else
                {
                    LocalAgentsouterDiv.Visible = false;
                    LocalAgents.Visible = false;
                }

                txtErectionDate.Text = ds.Tables[0].Rows[0]["DateofErection"].ToString();
                txtEscalatorType.Text = ds.Tables[0].Rows[0]["TypeofEscalatorErected"].ToString();
                txtEscalatorSpeedContract.Text = ds.Tables[0].Rows[0]["ContractSpeedofEscalatorMtrPrSec"].ToString();
                txtMaxPersonCapacity.Text = ds.Tables[0].Rows[0]["MaxPersonCapacitywithEscalatorOperator"].ToString();
                txtEscalatorLoad.Text = ds.Tables[0].Rows[0]["ContractLoadofEscalatorInKg"].ToString();
                txtWeight.Text = ds.Tables[0].Rows[0]["WeightofEscalatorCarwithContractLoadInKg"].ToString();
                txtCounterWeight.Text = ds.Tables[0].Rows[0]["WeightofCounterWeightInkg"].ToString();
                txtPitDepth.Text = ds.Tables[0].Rows[0]["DepthofPitInmm"].ToString();
                txtTravelDistance.Text = ds.Tables[0].Rows[0]["TravelDistanceofEscalatorInMtr"].ToString();
                txtFloorsServed.Text = ds.Tables[0].Rows[0]["NoofFloorsServedInMtr"].ToString();
                txtTotalHeadRoom.Text = ds.Tables[0].Rows[0]["TotalHeadRoomInmm"].ToString();
                txtMakeMainBreaker.Text = ds.Tables[0].Rows[0]["MakeMainBreaker"].ToString();
                txtTypeMainBreaker.Text = ds.Tables[0].Rows[0]["TypeMainBreaker"].ToString();
                TextBox4.Text = ds.Tables[0].Rows[0]["PolesMainBreaker"].ToString();
                txtratingMainBreaker.Text = ds.Tables[0].Rows[0]["CurrentRatingInAmps"].ToString();
                txtCapacityMainBreaker.Text = ds.Tables[0].Rows[0]["BreakingCapacityInKA"].ToString();
                txtMakeRCCBMainBreaker.Text = ds.Tables[0].Rows[0]["MakeRCCBMainBreaker"].ToString();
                txtRatingRCCBMainBreaker.Text = ds.Tables[0].Rows[0]["CurrentRCCBRatingInAmps"].ToString();
                txtfaultratingRCCBMainBreaker.Text = ds.Tables[0].Rows[0]["FaultRCCBCurrentRating"].ToString();
                txtMakeLoadBreaker.Text = ds.Tables[0].Rows[0]["LoadMakeMainBreaker"].ToString();
                txtTypeLoadBreaker.Text = ds.Tables[0].Rows[0]["LoadTypeMainBreaker"].ToString();
                TextBox6.Text = ds.Tables[0].Rows[0]["LoadPolesMainBreaker"].ToString();
                txtRatingLoadBreaker.Text = ds.Tables[0].Rows[0]["LoadCurrentRatingInAmps"].ToString();
                txtCapacityLoadBreaker.Text = ds.Tables[0].Rows[0]["LoadBreakingCapacityInKA"].ToString();
                txtMakeRCCBLoadBreaker.Text = ds.Tables[0].Rows[0]["LoadMakeRCCBMainBreaker"].ToString();
                TextBox5.Text = ds.Tables[0].Rows[0]["LoadPolesRCCBMainBreaker"].ToString();
                TextBox7.Text = ds.Tables[0].Rows[0]["LoadPolesRCCBMainBreaker"].ToString();
                txtRatingRCCBLoadBreaker.Text = ds.Tables[0].Rows[0]["LoadRCCBCurrentRatingInAmps"].ToString();
                txtFaultCurrentRCCBLoadBreaker.Text = ds.Tables[0].Rows[0]["LoadRCCBFaultCurrentRating"].ToString();
                txtwholeInstallation.Text = ds.Tables[0].Rows[0]["ForWholeInstallation"].ToString();
                txtRedYellow.Text = ds.Tables[0].Rows[0]["RedPhaseYellowPhaseInMohms"].ToString();
                txtRedBlue.Text = ds.Tables[0].Rows[0]["RedPhaseBluePhaseInMohms"].ToString();
                txtYellowBlue.Text = ds.Tables[0].Rows[0]["YellowPhaseBluePhaseInMohms"].ToString();
                txtRedEarth.Text = ds.Tables[0].Rows[0]["RedPhaseEarthWireInMohms"].ToString();
                txtYellowEarth.Text = ds.Tables[0].Rows[0]["YellowPhaseEarthWireInMohms"].ToString();
                txtBlueEarth.Text = ds.Tables[0].Rows[0]["BluePhaseEarthWirenMohms"].ToString();
                txtNeutralPhase.Text = ds.Tables[0].Rows[0]["NeutralandPhaseohms"].ToString();
                txtEarthPhase.Text = ds.Tables[0].Rows[0]["EarthandPhasemohms"].ToString();
                txtEarthing.Text = ds.Tables[0].Rows[0]["NumberofEarthing"].ToString();
                txtEarthingType1.Text = ds.Tables[0].Rows[0]["EarthingType1"].ToString();
                if (TextBox4.Text.Trim() == "DP")
                {
                    TPN1.Visible = true;
                    TPN2.Visible = true;

                    InDPO1.Visible = false;
                    InDPO2.Visible = false;
                }
                else
                {
                    TPN1.Visible = false;
                    TPN2.Visible = false;
                    InDPO1.Visible = true;
                    InDPO2.Visible = true;
                }
                GeneratingEarthing.Visible = true;
                txtEarthingType1.Text = ds.Tables[0].Rows[0]["EarthingType1"].ToString();
                txtEscalatorEarthing1.Text = ds.Tables[0].Rows[0]["Valueinohms1"].ToString();

                txtEarthingType2.Text = ds.Tables[0].Rows[0]["EarthingType2"].ToString();
                txtEscalatorEarthing2.Text = ds.Tables[0].Rows[0]["Valueinohms2"].ToString();
                txtEarthingType3.Text = ds.Tables[0].Rows[0]["EarthingType3"].ToString();
                txtEscalatorEarthing3.Text = ds.Tables[0].Rows[0]["Valueinohms3"].ToString();
                txtEarthingType4.Text = ds.Tables[0].Rows[0]["EarthingType4"].ToString();
                txtEscalatorEarthing4.Text = ds.Tables[0].Rows[0]["Valueinohms4"].ToString();
                txtEarthingType5.Text = ds.Tables[0].Rows[0]["EarthingType5"].ToString();
                txtEscalatorEarthing5.Text = ds.Tables[0].Rows[0]["Valueinohms5"].ToString();
                txtEarthingType6.Text = ds.Tables[0].Rows[0]["EarthingType6"].ToString();
                txtEscalatorEarthing6.Text = ds.Tables[0].Rows[0]["Valueinohms6"].ToString();
                txtEarthingType7.Text = ds.Tables[0].Rows[0]["EarthingType7"].ToString();
                txtEscalatorEarthing7.Text = ds.Tables[0].Rows[0]["Valueinohms7"].ToString();
                txtEarthingType8.Text = ds.Tables[0].Rows[0]["EarthingType8"].ToString();
                txtEscalatorEarthing8.Text = ds.Tables[0].Rows[0]["Valueinohms8"].ToString();

                txtEarthingType9.Text = ds.Tables[0].Rows[0]["EarthingType9"].ToString();
                txtEscalatorEarthing9.Text = ds.Tables[0].Rows[0]["Valueinohms9"].ToString();
                txtEarthingType10.Text = ds.Tables[0].Rows[0]["EarthingType10"].ToString();
                txtEscalatorEarthing10.Text = ds.Tables[0].Rows[0]["Valueinohms10"].ToString();
                txtNeutralPhase.ReadOnly = true;
                txtEarthPhase.ReadOnly = true;
                if (txtEarthing.Text.Trim() == "1")
                {
                    Limit.Visible = false;
                    EscalatorEarthing1.Visible = true;
                }
                else if (txtEarthing.Text.Trim() == "2")
                {
                    Limit.Visible = false;
                    EscalatorEarthing1.Visible = true;
                    EscalatorEarthing2.Visible = true;
                }
                else if (txtEarthing.Text.Trim() == "3")
                {
                    Limit.Visible = false;
                    EscalatorEarthing1.Visible = true;
                    EscalatorEarthing2.Visible = true;
                    EscalatorEarthing3.Visible = true;
                }
                else if (txtEarthing.Text.Trim() == "4")
                {
                    Limit.Visible = false;
                    EscalatorEarthing1.Visible = true;
                    EscalatorEarthing2.Visible = true;
                    EscalatorEarthing3.Visible = true;
                    EscalatorEarthing4.Visible = true;
                }
                else if (txtEarthing.Text.Trim() == "5")
                {
                    Limit.Visible = false;
                    EscalatorEarthing1.Visible = true;
                    EscalatorEarthing2.Visible = true;
                    EscalatorEarthing3.Visible = true;
                    EscalatorEarthing4.Visible = true;
                    EscalatorEarthing5.Visible = true;
                }
                else if (txtEarthing.Text.Trim() == "6")
                {
                    Limit.Visible = false;
                    EscalatorEarthing1.Visible = true;
                    EscalatorEarthing2.Visible = true;
                    EscalatorEarthing3.Visible = true;
                    EscalatorEarthing4.Visible = true;
                    EscalatorEarthing5.Visible = true;
                    EscalatorEarthing6.Visible = true;
                }
                else if (txtEarthing.Text.Trim() == "7")
                {
                    Limit.Visible = false;
                    EscalatorEarthing1.Visible = true;
                    EscalatorEarthing2.Visible = true;
                    EscalatorEarthing3.Visible = true;
                    EscalatorEarthing4.Visible = true;
                    EscalatorEarthing5.Visible = true;
                    EscalatorEarthing6.Visible = true;
                    EscalatorEarthing7.Visible = true;
                }
                else if (txtEarthing.Text.Trim() == "8")
                {
                    Limit.Visible = false;
                    EscalatorEarthing1.Visible = true;
                    EscalatorEarthing2.Visible = true;
                    EscalatorEarthing3.Visible = true;
                    EscalatorEarthing4.Visible = true;
                    EscalatorEarthing5.Visible = true;
                    EscalatorEarthing6.Visible = true;
                    EscalatorEarthing7.Visible = true;
                    EscalatorEarthing8.Visible = true;
                }
                else if (txtEarthing.Text.Trim() == "9")
                {
                    Limit.Visible = false;
                    EscalatorEarthing1.Visible = true;
                    EscalatorEarthing2.Visible = true;
                    EscalatorEarthing3.Visible = true;
                    EscalatorEarthing4.Visible = true;
                    EscalatorEarthing5.Visible = true;
                    EscalatorEarthing6.Visible = true;
                    EscalatorEarthing7.Visible = true;
                    EscalatorEarthing8.Visible = true;
                    EscalatorEarthing9.Visible = true;
                }
                else if (txtEarthing.Text.Trim() == "10")
                {
                    Limit.Visible = false;
                    EscalatorEarthing1.Visible = true;
                    EscalatorEarthing2.Visible = true;
                    EscalatorEarthing3.Visible = true;
                    EscalatorEarthing4.Visible = true;
                    EscalatorEarthing5.Visible = true;
                    EscalatorEarthing6.Visible = true;
                    EscalatorEarthing7.Visible = true;
                    EscalatorEarthing8.Visible = true;
                    EscalatorEarthing9.Visible = true;
                    EscalatorEarthing10.Visible = true;
                }
                else
                {
                    Limit.Visible = false;
                    EscalatorEarthing1.Visible = true;
                    EscalatorEarthing2.Visible = true;
                    EscalatorEarthing3.Visible = true;
                    EscalatorEarthing4.Visible = false;
                    EscalatorEarthing5.Visible = false;
                    EscalatorEarthing6.Visible = false;
                    EscalatorEarthing7.Visible = false;
                    EscalatorEarthing8.Visible = false;
                    EscalatorEarthing9.Visible = false;
                    EscalatorEarthing10.Visible = false;
                }
                txtContName.Text = ds.Tables[0].Rows[0]["ContractorName"].ToString();
                txtLicenseNo.Text = ds.Tables[0].Rows[0]["ContractorLicenseNumber"].ToString();
                txtContExp.Text = ds.Tables[0].Rows[0]["ContractorLicenseExpiryDate"].ToString();
                txtSupName.Text = ds.Tables[0].Rows[0]["SupervisorName"].ToString();
                txtSupLicenseNo.Text = ds.Tables[0].Rows[0]["SupervisorLicenseNumber"].ToString();
                txtSupExpiryDate.Text = ds.Tables[0].Rows[0]["SupervisorLicenseExpiryDate"].ToString();
            }
            catch
            {

            }
        }


        protected void Grd_Document_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                string fileName = "";
                fileName = "https://uat.ceiharyana.com" + e.CommandArgument.ToString();
                // fileName = "https://localhost:44393" + e.CommandArgument.ToString();
                string script = $@"<script>window.open('{fileName}','_blank');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenFileInNewTab", script);


            }
        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            if (Session["PreviousPage"] != null)
            {
                string previousPageUrl = Session["PreviousPage"].ToString();
                Response.Redirect(previousPageUrl, false);
                Session["PreviousInspPage"] = null;
            }
        }
    }
}