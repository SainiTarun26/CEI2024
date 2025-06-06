﻿using CEI_PRoject;
using CEIHaryana.Contractor;
using CEIHaryana.SiteOwnerPages;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.TestReportModal
{
    public partial class GeneratingSetTestReportModal : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        string ID = string.Empty;
        string id = string.Empty;
        bool OTPSEND = false;
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

                    if (Session["ContractorID"] != null && Convert.ToString(Session["ContractorID"]) != "")
                    {

                        Session["GeneratorSetOtp"] = "0";
                        ID = Session["GeneratingSetId"].ToString();
                        GetDetailswithId();
                        if (Convert.ToString(Session["Approval"]) == "Pending")
                        {
                            // Contractor.Visible = true;
                            Contractor3.Visible = true;
                            // CreatedDate.Visible = true;
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(Request.QueryString["Return"]))
                            {
                                string querystring = Request.QueryString["Return"].ToString();
                                if (!string.IsNullOrEmpty(querystring))
                                {
                                    Contractor3.Visible = false;
                                }
                            }
                            else
                            {
                                // Contractor.Visible = true;
                                Contractor2.Visible = true;
                                // CreatedDate.Visible = true;
                            }

                        }

                    }
                    //else if (Session["SiteOwnerId_Sld_Indus"] != null && Session["SiteOwnerId_Sld_Indus"].ToString() != "")
                    //{
                    //    if (Request.UrlReferrer != null)
                    //    {
                    //        Session["PreviousPage_Industry"] = Request.UrlReferrer.ToString();
                    //    }
                    //    ID = Session["GeneratingSetId"].ToString();
                    //    GetDetailswithId();
                    //    SiteOwner.Visible = false;
                    //    SiteOwner2.Visible = true;
                    //    IntimationData.Visible = true;
                    //    ApprovalCard.Visible = true;
                    //    //CreatedDate.Visible = true; //Added
                    //    //SubmitDate.Visible = true;
                    //    //SubmitBy.Visible = true;
                    //}
                    //else if (Session["SiteOwnerId_Industry"] != null && Session["SiteOwnerId_Industry"].ToString() != "")
                    //{
                    //    if (Request.UrlReferrer != null)
                    //    {
                    //        Session["PreviousPage_Industry"] = Request.UrlReferrer.ToString();
                    //    }

                    //    ID = Session["GeneratingSetId_Industry"].ToString();
                    //    GetDetailswithId();

                    //    SiteOwner.Visible = false;
                    //    SiteOwner2.Visible = true;
                    //    IntimationData.Visible = true;
                    //    ApprovalCard.Visible = true;
                    //    // CreatedDate.Visible = true; //Added
                    //    // SubmitDate.Visible = true;
                    //    // SubmitBy.Visible = true;

                    //}
                    else if (Session["SiteOwnerId"] != null && Session["SiteOwnerId"].ToString() != "")
                    {
                        ID = Session["GeneratingSetId"].ToString();
                        GetDetailswithId();

                        SiteOwner.Visible = false;
                        SiteOwner2.Visible = true;
                        IntimationData.Visible = true;
                        ApprovalCard.Visible = true;
                        // CreatedDate.Visible = true; //Added
                        // SubmitDate.Visible = true;
                        // SubmitBy.Visible = true;

                    }
                    
                    else if (Session["InspectionTestReportId"] != null && Session["InspectionTestReportId"].ToString() != "")
                    {
                        ID = Session["InspectionTestReportId"].ToString();
                        GetDetailswithId();
                        SiteOwner.Visible = true;
                        IntimationData.Visible = true;
                        ApprovalCard.Visible = true;
                        btnNext.Text = "Back";

                    }
                    else if (Session["IntimationForHistoryId"] != null && Session["IntimationForHistoryId"].ToString() != "")
                    {
                        ID = Session["IntimationForHistoryId"].ToString();
                        GetDetailswithId();
                        IntimationForHistory.Visible = true;
                    }
                    else if (Session["SupervisorID"] != null || Session["AdminID"] != null)

                    {
                        if (Session["SupervisorID"] != null && Session["SupervisorID"].ToString() != "")
                        {
                            //SubmitDate.Visible = true;
                            //SubmitBy.Visible = true;
                        }
                        if (Session["AdminID"] != null)
                        {
                            // Contractor.Visible = true;
                            //SubmitBy.Visible = true;
                            //SubmitDate.Visible = true;
                            //CreatedDate.Visible = true;
                        }
                        ID = Session["GeneratingSetId"].ToString();
                        GetDetailswithId();
                        Supervisor.Visible = true;
                        IntimationData.Visible = true;

                    }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/SiteOwnerLogout.aspx", false);

            }
        }
        private void GetDocumentUploadData()
        {
            OTP.Visible = false;
            DataTable ds = new DataTable();
            ds = CEI.GetDocumentlistforContractor(3);
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

            ScriptManager.RegisterStartupScript(this, this.GetType(), "focusGridView", "focusOnGridView();", true);
        }
        public void GetDetailswithId()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = CEI.GeneratingTestReportDataWithId(ID);
                string value1 = Convert.ToString(Session["Approval"]);
                if (value1.Trim() == "Accept")
                {
                    //ddlType.Attributes.Add("disabled", "disabled");
                    //ddlType.Attributes["onfocus"] = "this.size=3";                   
                    // ddlType.Attributes.Add("ReadOnly", "true");
                    // ddlType.Attributes.Add("disabled", "disabled");
                    //ddlType.SelectedIndex = ddlType.Items.IndexOf(ddlType.Items.FindByText(value1));
                    //BtnSubmitGeneratingSet.Text = "Back";


                }
                else if (value1.Trim() == "Reject")
                {

                    //ddlType.Attributes.Add("disabled", "disabled");
                    // ddlType.Attributes.Add("ReadOnly", "true");                   
                    // ddlType.SelectedIndex = ddlType.Items.IndexOf(ddlType.Items.FindByText(value1));
                    // Rejection.Visible = true;
                    // txtRejection.Attributes.Add("Readonly", "true");
                    BtnSubmitGeneratingSet.Text = "Back";

                }
                if (value1.Trim() == "Submitted" || value1.Trim() == "Submit")
                {
                    ApprovalCard.Visible = true;
                    BtnSubmitGeneratingSet.Text = "Back";
                }

                string dp_Id = ds.Tables[0].Rows[0]["ContractorType"].ToString();
                txtInstallation.Text = dp_Id;
                if (dp_Id == "Firm/Company")
                {
                    agency.Visible = true;
                    individual.Visible = false;
                }
                else
                {
                    individual.Visible = true;
                    agency.Visible = false;
                }

                Session["GSInspectionType"] = ds.Tables[0].Rows[0]["InspectionType"].ToString();

                txtName.Text = ds.Tables[0].Rows[0]["NameOfOwner"].ToString();
                txtagency.Text = ds.Tables[0].Rows[0]["NameOfAgency"].ToString();
                txtPhone.Text = ds.Tables[0].Rows[0]["ContactNo"].ToString();
                txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                string dp_Id1 = ds.Tables[0].Rows[0]["Permises"].ToString();
                TxtPremises.Text = dp_Id1;
                // string dp_Id2 = ds.Tables[0].Rows[0]["OtherPremises"].ToString();
                //string dp_Id3 = ds.Tables[0].Rows[0]["VoltageLevel"].ToString().Trim();
                string dp_Id3 = ds.Tables[0].Rows[0]["LevelVoltage"].ToString().Trim();
                txtVoltagelevel.Text = dp_Id3;

                string dp_Id4 = ds.Tables[0].Rows[0]["WorkStartDate"].ToString();

                if (!string.IsNullOrWhiteSpace(dp_Id4))
                {
                    txtStartDate.Text = DateTime.Parse(dp_Id4).ToString("dd-MM-yyyy");
                }
                else
                {
                    txtStartDate.Text = string.Empty;
                }


                string dp_Id5 = ds.Tables[0].Rows[0]["CompletionDate"].ToString();
                //txtCompletitionDate.Text = DateTime.Parse(dp_Id5).ToString("dd-MM-yyyy");

                if (!string.IsNullOrWhiteSpace(dp_Id5))
                {
                    txtCompletitionDate.Text = DateTime.Parse(dp_Id5).ToString("dd-MM-yyyy");
                }
                else
                {
                    txtCompletitionDate.Text = string.Empty;
                }


                txtCapacityType.Text = ds.Tables[0].Rows[0]["GeneratingSetCapacityType"].ToString();
                txtCapacity.Text = ds.Tables[0].Rows[0]["GeneratingSetCapacity"].ToString();
                txtSerialNoOfGenerator.Text = ds.Tables[0].Rows[0]["SerialNumbrOfAcGenerator"].ToString();
                txtGeneratingSetType.Text = ds.Tables[0].Rows[0]["GeneratingSetType"].ToString();
                //Textstatus.Text = ds.Tables[0].Rows[0]["ApprovedOrRejectFromContractor"].ToString();
                //TextReason.Text = ds.Tables[0].Rows[0]["ReasonForRejection"].ToString();

                //txtReportNo.Text = ds.Tables[0].Rows[0]["ID"].ToString(); gurmeet to showing new testreportid
                lbltestReportId.Text = ds.Tables[0].Rows[0]["TestReportId"].ToString();
                lblWorkIntimationId.Text = ds.Tables[0].Rows[0]["WorkIntimationId"].ToString();
                lblIntimationId.Text = ds.Tables[0].Rows[0]["WorkIntimationId"].ToString();
                lblReportNo.Text = ds.Tables[0].Rows[0]["TestReportId"].ToString();
                //txtReportNo.Text = ds.Tables[0].Rows[0]["GeneratingSetId"].ToString();

                txtPreparedby.Text = ds.Tables[0].Rows[0]["SupervisorWhoCreated"].ToString();
                txtSubmitteddate.Text = ds.Tables[0].Rows[0]["SubmittedDate"].ToString();       ///////////////
                txtSubmittedBy.Text = ds.Tables[0].Rows[0]["ContractorWhoCreated"].ToString();         //////////////
                DateTime createdDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["SubmittedDate"]);
                txtCreatedDate.Text = createdDate.ToString("dd-MM-yyyy");
                if (txtGeneratingSetType.Text.Trim() == "Solar Panel")
                {
                    SolarPanelGeneratingSet.Visible = true;
                }
                else
                {
                    SolarPanelGeneratingSet.Visible = false;
                }
                txtGeneratorVoltage.Text = ds.Tables[0].Rows[0]["GeneratorVoltageLevel"].ToString();
                txtCurrentCapacity.Text = ds.Tables[0].Rows[0]["CurrenntCapacityOfBreaker"].ToString();
                txtBreakingCapacity.Text = ds.Tables[0].Rows[0]["BreakingCapacityofBreaker"].ToString();
                txtPlantType.Text = ds.Tables[0].Rows[0]["TypeOfPlant"].ToString();
                txtPlantCapacityType.Text = ds.Tables[0].Rows[0]["CapacityOfPlantType"].ToString();
                txtPlantCapacity.Text = ds.Tables[0].Rows[0]["CapacityOfPlant"].ToString();
                txtDCString.Text = ds.Tables[0].Rows[0]["HighestVoltageLevelOfDCString"].ToString();
                txtLowestInsulation.Text = ds.Tables[0].Rows[0]["LowestInsulationBetweenDCWireToEarth"].ToString();
                txtPCVOrSolar.Text = ds.Tables[0].Rows[0]["NoOfPowerPCV"].ToString();
                txtLTACCapacity.Text = ds.Tables[0].Rows[0]["LTACBreakerCapacity"].ToString();
                txtLowestInsulationAC.Text = ds.Tables[0].Rows[0]["ACCablesLowestInsulation"].ToString();
                txtEarthing.Text = ds.Tables[0].Rows[0]["NumberOfEarthing"].ToString();
                lbltestReportId.Text = ds.Tables[0].Rows[0]["TestReportId"].ToString();
                Session["TestReportIds"] = lbltestReportId.Text.Trim();
                GeneratingEarthing.Visible = true;


                if (txtEarthing.Text.Trim() == "4")
                {
                    Limit.Visible = false;
                    GeneratingEarthing4.Visible = true;
                }
                else if (txtEarthing.Text.Trim() == "5")
                {
                    Limit.Visible = false;
                    GeneratingEarthing4.Visible = true;
                    GeneratingEarthing5.Visible = true;
                }
                else if (txtEarthing.Text.Trim() == "6")
                {
                    Limit.Visible = false;
                    GeneratingEarthing4.Visible = true;
                    GeneratingEarthing5.Visible = true;
                    GeneratingEarthing6.Visible = true;
                }
                else if (txtEarthing.Text.Trim() == "7")
                {
                    Limit.Visible = false;
                    GeneratingEarthing4.Visible = true;
                    GeneratingEarthing5.Visible = true;
                    GeneratingEarthing6.Visible = true;
                    GeneratingEarthing7.Visible = true;
                }
                else if (txtEarthing.Text.Trim() == "8")
                {
                    Limit.Visible = false;
                    GeneratingEarthing4.Visible = true;
                    GeneratingEarthing5.Visible = true;
                    GeneratingEarthing6.Visible = true;
                    GeneratingEarthing7.Visible = true;
                    GeneratingEarthing8.Visible = true;
                }
                else if (txtEarthing.Text.Trim() == "9")
                {
                    Limit.Visible = false;
                    GeneratingEarthing4.Visible = true;
                    GeneratingEarthing5.Visible = true;
                    GeneratingEarthing6.Visible = true;
                    GeneratingEarthing7.Visible = true;
                    GeneratingEarthing8.Visible = true;
                    GeneratingEarthing9.Visible = true;
                }
                else if (txtEarthing.Text.Trim() == "10")
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
                else if (txtEarthing.Text.Trim() == "11")
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
                else if (txtEarthing.Text.Trim() == "12")
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
                else if (txtEarthing.Text.Trim() == "13")
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
                else if (txtEarthing.Text.Trim() == "14")
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
                else if (txtEarthing.Text.Trim() == "15")
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

                else
                {
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
                }
                txtEarthingType1.Text = ds.Tables[0].Rows[0]["EarthingType1"].ToString();
                txtGeneratingEarthing1.Text = ds.Tables[0].Rows[0]["EarthingValue1"].ToString();
                txtEarthingUsed1.Text = ds.Tables[0].Rows[0]["UsedFor1"].ToString();
                if (txtEarthingUsed1.Text == "Other")
                {
                    txtOther1.Text = ds.Tables[0].Rows[0]["OtherEarthing1"].ToString();
                    txtOther1.Visible = true;
                    txtEarthingUsed1.Visible = false;

                }
                txtEarthingType2.Text = ds.Tables[0].Rows[0]["EarthingType2"].ToString();
                txtGeneratingEarthing2.Text = ds.Tables[0].Rows[0]["EarthingValue2"].ToString();
                txtEarthingUsed2.Text = ds.Tables[0].Rows[0]["UsedFor2"].ToString();
                if (txtEarthingUsed2.Text == "Other")
                {
                    txtOther2.Text = ds.Tables[0].Rows[0]["OtherEarthing2"].ToString();
                    txtOther2.Visible = true;
                    txtEarthingUsed2.Visible = false;

                }
                txtEarthingType3.Text = ds.Tables[0].Rows[0]["EarthingType3"].ToString();
                txtGeneratingEarthing3.Text = ds.Tables[0].Rows[0]["EarthingValue3"].ToString();
                txtEarthingUsed3.Text = ds.Tables[0].Rows[0]["UsedFor3"].ToString();
                if (txtEarthingUsed3.Text == "Other")
                {
                    textOther3.Text = ds.Tables[0].Rows[0]["OtherEarthing3"].ToString();
                    textOther3.Visible = true;
                    txtEarthingUsed3.Visible = false;

                }
                txtEarthingType4.Text = ds.Tables[0].Rows[0]["EarthingType4"].ToString();
                txtGeneratingEarthing4.Text = ds.Tables[0].Rows[0]["EarthingValue4"].ToString();
                txtEarthingUsed4.Text = ds.Tables[0].Rows[0]["UsedFor4"].ToString();
                if (txtEarthingUsed4.Text == "Other")
                {
                    txtOther4.Text = ds.Tables[0].Rows[0]["OtherEarthing4"].ToString();
                    txtOther4.Visible = true;
                    txtEarthingUsed4.Visible = false;

                }
                txtEarthingType5.Text = ds.Tables[0].Rows[0]["EarthingType5"].ToString();
                txtGeneratingEarthing5.Text = ds.Tables[0].Rows[0]["EarthingValue5"].ToString();
                txtEarthingUsed5.Text = ds.Tables[0].Rows[0]["UsedFor5"].ToString();
                if (txtEarthingUsed5.Text == "Other")
                {
                    txtOther5.Text = ds.Tables[0].Rows[0]["OtherEarthing5"].ToString();
                    txtOther5.Visible = true;
                    txtEarthingUsed5.Visible = false;

                }
                txtEarthingType6.Text = ds.Tables[0].Rows[0]["EarthingType6"].ToString();
                txtGeneratingEarthing6.Text = ds.Tables[0].Rows[0]["EarthingValue6"].ToString();
                txtEarthingUsed6.Text = ds.Tables[0].Rows[0]["UsedFor6"].ToString();
                if (txtEarthingUsed6.Text == "Other")
                {
                    txtOther6.Text = ds.Tables[0].Rows[0]["OtherEarthing6"].ToString();
                    txtOther6.Visible = true;
                    txtEarthingUsed6.Visible = false;

                }
                txtEarthingType7.Text = ds.Tables[0].Rows[0]["EarthingType7"].ToString();
                txtGeneratingEarthing7.Text = ds.Tables[0].Rows[0]["EarthingValue7"].ToString();
                txtEarthingUsed7.Text = ds.Tables[0].Rows[0]["UsedFor7"].ToString();
                if (txtEarthingUsed7.Text == "Other")
                {
                    txtOther7.Text = ds.Tables[0].Rows[0]["OtherEarthing7"].ToString();
                    txtOther7.Visible = true;
                    txtEarthingUsed7.Visible = false;

                }
                txtEarthingType8.Text = ds.Tables[0].Rows[0]["EarthingType8"].ToString();
                txtGeneratingEarthing8.Text = ds.Tables[0].Rows[0]["EarthingValue8"].ToString();
                txtEarthingUsed8.Text = ds.Tables[0].Rows[0]["UsedFor8"].ToString();
                if (txtEarthingUsed8.Text == "Other")
                {
                    txtOther8.Text = ds.Tables[0].Rows[0]["OtherEarthing8"].ToString();
                    txtOther8.Visible = true;
                    txtEarthingUsed8.Visible = false;

                }
                txtEarthingType9.Text = ds.Tables[0].Rows[0]["EarthingType9"].ToString();
                txtGeneratingEarthing9.Text = ds.Tables[0].Rows[0]["EarthingValue9"].ToString();
                txtEarthingUsed9.Text = ds.Tables[0].Rows[0]["UsedFor9"].ToString();
                if (txtEarthingUsed9.Text == "Other")
                {
                    txtOther9.Text = ds.Tables[0].Rows[0]["OtherEarthing9"].ToString();
                    txtOther9.Visible = true;
                    txtEarthingUsed9.Visible = false;

                }
                txtEarthingType10.Text = ds.Tables[0].Rows[0]["EarthingType10"].ToString();
                txtGeneratingEarthing10.Text = ds.Tables[0].Rows[0]["EarthingValue10"].ToString();
                txtEarthingUsed10.Text = ds.Tables[0].Rows[0]["UsedFor10"].ToString();
                if (txtEarthingUsed10.Text == "Other")
                {
                    txtOther10.Text = ds.Tables[0].Rows[0]["OtherEarthing10"].ToString();
                    txtOther10.Visible = true;
                    txtEarthingUsed10.Visible = false;

                }
                txtEarthingType11.Text = ds.Tables[0].Rows[0]["EarthingType11"].ToString();
                txtGeneratingEarthing11.Text = ds.Tables[0].Rows[0]["EarthingValue11"].ToString();
                txtEarthingUsed11.Text = ds.Tables[0].Rows[0]["UsedFor11"].ToString();
                if (txtEarthingUsed11.Text == "Other")
                {
                    txtOther11.Text = ds.Tables[0].Rows[0]["OtherEarthing11"].ToString();
                    txtOther11.Visible = true;
                    txtEarthingUsed11.Visible = false;

                }
                txtEarthingType12.Text = ds.Tables[0].Rows[0]["EarthingType12"].ToString();
                txtGeneratingEarthing12.Text = ds.Tables[0].Rows[0]["EarthingValue12"].ToString();
                txtEarthingUsed12.Text = ds.Tables[0].Rows[0]["UsedFor12"].ToString();
                if (txtEarthingUsed12.Text == "Other")
                {
                    txtOther12.Text = ds.Tables[0].Rows[0]["OtherEarthing12"].ToString();
                    txtOther12.Visible = true;
                    txtEarthingUsed12.Visible = false;

                }
                txtEarthingType13.Text = ds.Tables[0].Rows[0]["EarthingType13"].ToString();
                txtGeneratingEarthing13.Text = ds.Tables[0].Rows[0]["EarthingValue13"].ToString();
                txtEarthingUsed13.Text = ds.Tables[0].Rows[0]["UsedFor13"].ToString();
                if (txtEarthingUsed13.Text == "Other")
                {
                    txtOther13.Text = ds.Tables[0].Rows[0]["OtherEarthing13"].ToString();
                    txtOther13.Visible = true;
                    txtEarthingUsed13.Visible = false;

                }
                txtEarthingType14.Text = ds.Tables[0].Rows[0]["EarthingType14"].ToString();
                txtGeneratingEarthing14.Text = ds.Tables[0].Rows[0]["EarthingValue14"].ToString();
                txtEarthingUsed14.Text = ds.Tables[0].Rows[0]["UsedFor14"].ToString();
                if (txtEarthingUsed14.Text == "Other")
                {
                    txtOther14.Text = ds.Tables[0].Rows[0]["OtherEarthing14"].ToString();
                    txtOther14.Visible = true;
                    txtEarthingUsed14.Visible = false;

                }
                txtEarthingType15.Text = ds.Tables[0].Rows[0]["EarthingType15"].ToString();
                txtGeneratingEarthing15.Text = ds.Tables[0].Rows[0]["EarthingValue15"].ToString();
                txtEarthingUsed15.Text = ds.Tables[0].Rows[0]["UsedFor15"].ToString();
                if (txtEarthingUsed15.Text == "Other")
                {
                    txtOther15.Text = ds.Tables[0].Rows[0]["OtherEarthing15"].ToString();
                    txtOther15.Visible = true;
                    txtEarthingUsed15.Visible = false;

                }
                // txtRejection.Text = ds.Tables[0].Rows[0]["ReasonForRejection"].ToString();
                Session["Email"] = ds.Tables[0].Rows[0]["ContractorEmail"].ToString();

                Session["InspectionType"] = ds.Tables[0].Rows[0]["Inspectiontype"].ToString();
                txtApprovalDate.Text = ds.Tables[0].Rows[0]["ApprovalDate"].ToString();
                txtApprovedBy.Text = ds.Tables[0].Rows[0]["ContractorWhoCreated"].ToString();
                txtTestReportCount.Text = ds.Tables[0].Rows[0]["Count"].ToString();
                txtApplicantType.Text = ds.Tables[0].Rows[0]["ApplicantType"].ToString();
                txtDistrict.Text = ds.Tables[0].Rows[0]["District"].ToString();
                txtDivision.Text = ds.Tables[0].Rows[0]["Area"].ToString();

            }
            catch (Exception ex)
            {

            }
        }
        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (BtnSubmitGeneratingSet.Text.Trim() == "Back")
                {
                    Response.Redirect("/Contractor/Approved_Test_Reports.aspx");
                }
                else
                {
                    string InspectionType = Session["InspectionType"].ToString();
                    string InstallationInvoice = string.Empty;
                    string ManufacturingReport = string.Empty;
                    string id = Session["IntimationId"].ToString();
                    string Counts = Session["Counts"].ToString();
                    string ContractorId = Session["ContractorID"].ToString();
                    string TestReportIds = Session["TestReportIds"].ToString();
                    // CEI.UpdateGeneratingSetData(id, Counts, ddlType.SelectedItem.ToString(), txtRejection.Text);
                    if (InspectionType == "Existing")
                    {
                        CEI.InsertExistingInspectionData(lbltestReportId.Text, lblIntimationId.Text, txtTestReportCount.Text, txtApplicantType.Text, "Generating Set", txtVoltagelevel.Text.Trim(),
                           txtDistrict.Text, txtDivision.Text, TxtPremises.Text, ContractorId);
                    }
                    if (Session["GSInspectionType"] != null && Session["GSInspectionType"].ToString() != "Existing" && txtApplicantType.Text.Trim()!="Power Utility")
                    {
                        bool isValid = true;
                        int rowIndex = 0;
                        // Iterate through each row in the GridView
                        foreach (GridViewRow row in Grd_Document.Rows)
                        {
                            rowIndex++;

                            // Find FileUpload control within the row
                            FileUpload fileUpload = (FileUpload)row.FindControl("FileUpload1");

                            if (fileUpload != null && fileUpload.HasFile)
                            {
                                // File size validation (less than or equal to 1MB)
                                if (fileUpload.PostedFile.ContentLength > 1048576) // 1MB = 1048576 bytes
                                {
                                    isValid = false;
                                    string script = "alert('File size must be less than or equal to 1MB.');";
                                    ScriptManager.RegisterStartupScript(this, GetType(), "FileSizeExceeded", script, true);
                                    break;
                                }

                                // File type validation (only PDF allowed)
                                string fileExtension = Path.GetExtension(fileUpload.FileName).ToLower();
                                if (fileExtension != ".pdf")
                                {
                                    isValid = false;
                                    string script = "alert('Only PDF files are allowed.');";
                                    ScriptManager.RegisterStartupScript(this, GetType(), "InvalidFileType", script, true);
                                    break;
                                }

                                // Save the file based on the row index
                                string filename = Path.GetFileName(fileUpload.FileName);
                                string folderPath = string.Empty;
                                string fullFilePath = string.Empty;

                                if (rowIndex == 1)
                                {
                                    // Save InstallationInvoice
                                    string InstallationInvoiceFileName = "InstallationInvoice_" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + ".pdf";
                                    folderPath = Server.MapPath("~/Attachment/" + "Contractor" + "GeneratingSet" + TestReportIds + "/InstallationInvoice/");
                                    if (!Directory.Exists(folderPath))
                                    {
                                        Directory.CreateDirectory(folderPath);
                                    }
                                    fullFilePath = Path.Combine(folderPath, InstallationInvoiceFileName);
                                    fileUpload.SaveAs(fullFilePath);
                                    InstallationInvoice = "/Attachment/" + "Contractor" + "GeneratingSet" + TestReportIds + "/InstallationInvoice/" + InstallationInvoiceFileName;
                                }
                                else if (rowIndex == 2)
                                {
                                    // Save ManufacturingReport
                                    string ManufacturingReportFileName = "ManufacturingReport_" + DateTime.Now.ToString("yyyyMMddHHmmssFFF") + ".pdf";
                                    folderPath = Server.MapPath("~/Attachment/" + "Contractor" + "GeneratingSet" + TestReportIds + "/ManufacturingReport/");
                                    if (!Directory.Exists(folderPath))
                                    {
                                        Directory.CreateDirectory(folderPath);
                                    }
                                    fullFilePath = Path.Combine(folderPath, ManufacturingReportFileName);
                                    fileUpload.SaveAs(fullFilePath);
                                    ManufacturingReport = "/Attachment/" + "Contractor" + "GeneratingSet" + TestReportIds + "/ManufacturingReport/" + ManufacturingReportFileName;
                                }
                            }
                            else
                            {
                                isValid = false;
                                string script = "alert('Please upload the required document.');";
                                ScriptManager.RegisterStartupScript(this, GetType(), "FileUploadMissing", script, true);
                                break;
                            }
                        }

                        if (isValid && rowIndex == 2) // Ensure two files have been uploaded
                        {
                            CEI.UpdateGeneratingSetData(id, Counts, InstallationInvoice, ManufacturingReport);
                            Session["InspectionType"] = "";

                            string script = "alert('Test Report Approved Successfully'); window.location='/Contractor/Approved_Test_Reports.aspx';";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", script, true);
                        }
                        else if (rowIndex < 2)
                        {
                            string script = "alert('Please upload documents for both rows.');";
                            ScriptManager.RegisterStartupScript(this, GetType(), "IncompleteUpload", script, true);
                        }
                    }
                    else
                    {
                        CEI.UpdateGeneratingSetDataifExisting(id, Counts);
                        string script = "alert('Test Report Approved Successfully'); window.location='/Contractor/Approved_Test_Reports.aspx';";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", script, true);
                    }
                }
            }
            catch (Exception ex)
            {
                string script = $"alert('An error occurred: {ex.Message}');";
                ScriptManager.RegisterStartupScript(this, GetType(), "Error", script, true);
            }
        }

        protected void btnIntimationForHistoryBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Admin/IntimationForHistory.aspx", false);
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            if (btnNext.Text.Trim() == "Back")
            {

                if (Session["PreviousPage"] != null)
                {
                    string previousPageUrl = Session["PreviousPage"].ToString();
                    Response.Redirect(previousPageUrl, false);
                    Session["PreviousInspPage"] = null;
                }
                else
                {
                    Response.Redirect("/Officers/Inspection.aspx", false);
                }

            }
            else
            {
                id = Session["GeneratingSetId"].ToString();
                Response.Redirect("/SiteOwnerPages/CreateInspectionReport.aspx", false);
            }
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            if (Session["AdminID"] != null)
            {
                string previousPageUrl = Session["PreviousPage"] as string;
                if (!string.IsNullOrEmpty(previousPageUrl))
                {

                    Response.Redirect(previousPageUrl, false);
                    Session["PreviousInspPage"] = null;
                }
                //Response.Redirect("/Admin/TestReportHistoryFromSupervisor.aspx");
            }
            else
            {
                Response.Redirect("/Supervisor/TestReportHistory.aspx");
            }
        }
        protected void btnVerify_Click(object sender, EventArgs e)
        {
            try
            {
                OTP.Visible = true;
                btnVerify.Text = "Verify";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "focusOTP", "document.getElementById('" + txtOtp.ClientID + "').focus();", true);
                Session["GeneratorSetOtp"] = Convert.ToString(Convert.ToInt32(Session["GeneratorSetOtp"]) + 1);
                // OTP.Visible = true;
                if (Session["GeneratorSetOtp"].ToString() == "1")
                {
                    OTP.Visible = true;
                    string Email = Session["Email"].ToString().Trim();
                    if (Email.Trim() == "")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata();", true);
                    }
                    else
                    {
                        if (Session["Email"].ToString().Trim() != "OTPSEND") {
                            Session["OTP"] = CEI.ValidateOTPthroughEmail(Email);
                            Session["Email"] = "OTPSEND";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('OTP has been Sent to your registered email Id');", true);
                        
                        }
                        
                    }
                }
                else
                {
                    if (txtOtp.Text != "")
                    {
                        if (Session["OTP"].ToString().Trim() == txtOtp.Text.Trim())
                        {
                            Contractor2.Visible = true;
                            Contractor3.Visible = false;
                            if (Session["GSInspectionType"] != null && Session["GSInspectionType"].ToString() != "Existing"&&txtApplicantType.Text.Trim() != "Power Utility")
                            {
                                GetDocumentUploadData();
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "focusGridView", "focusOnGridView();", true);
                                Session["GeneratorSetOtp"] = null;
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Incorrect OTP. Please try again.');", true);
                        }
                    }

                }
            }
            catch
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('An Error Occured Please try again later')", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata();", true);

            }
        }

        protected void btnBack2_Click(object sender, EventArgs e)
        {

            // Response.Redirect("/SiteOwnerPages/GenerateInspection.aspx", false);
            try
            {
                string previousPageUrl = Session["PreviousPage"] as string;
                if (!string.IsNullOrEmpty(previousPageUrl))
                {

                    Response.Redirect(previousPageUrl, false);
                    Session["PreviousPage"] = null;

                }
            }
            catch { }
        }
    }
}
