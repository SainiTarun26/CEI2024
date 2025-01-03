using CEI_PRoject;
using CEIHaryana.SiteOwnerPages;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.TestReportModel_Industry
{
    public partial class LineTestReport_Industry : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        string ID = string.Empty;
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
                    if (Session["SiteOwnerId_Sld_Indus"] != null && Session["SiteOwnerId_Sld_Indus"].ToString() != "")
                    {
                        if (Request.UrlReferrer != null)
                        {
                            Session["PreviousPage_Industry"] = Request.UrlReferrer.ToString();
                        }

                        ID = Session["Line"].ToString();
                        GetDetailswithId();

                        ///SiteOwner.Visible = false;
                        SiteOwner2.Visible = true;
                        IntimationData.Visible = true;
                        ApprovalCard.Visible = true;
                        //CreatedDate.Visible = true; //Added
                        //SubmitDate.Visible = true;
                        //SubmitBy.Visible = true;
                    }
                    else if (Session["SiteOwnerId_Industry"] != null && Session["SiteOwnerId_Industry"].ToString() != "")
                    {
                        if (Request.UrlReferrer != null)
                        {
                            Session["PreviousPage_Industry"] = Request.UrlReferrer.ToString();
                        }

                        ID = Session["LineID_Industry"].ToString();
                        GetDetailswithId();

                       // SiteOwner.Visible = false;
                        SiteOwner2.Visible = true;
                        IntimationData.Visible = true;
                        ApprovalCard.Visible = true;
                        //CreatedDate.Visible = true; //Added
                        //SubmitDate.Visible = true;
                        //SubmitBy.Visible = true;
                    }

                }
            }
            catch { }
        }
        public void GetDetailswithId()
        {
            try
            {
                string value1 = Convert.ToString(Session["Approval"]);
                if (value1.Trim() == "Accept")
                {
                    //ddlType.Attributes.Add("disabled", "disabled");
                    // ddlType.Attributes.Add("Readonly", "true");
                    // ddlType.SelectedIndex = ddlType.Items.IndexOf(ddlType.Items.FindByText(value1));
                    
                }
                else if (value1.Trim() == "Reject")
                {
                    // ddlType.Attributes.Add("Readonly", "true");
                    // txtRejection.Attributes.Add("Readonly", "true");
                    //btnSubmit.Text = "Back";
                    // ddlType.Attributes.Add("disabled", "disabled");
                    // ddlType.SelectedIndex = ddlType.Items.IndexOf(ddlType.Items.FindByText(value1));
                    // Rejection.Visible = true;
                }
                if (value1.Trim() == "Submitted" || value1.Trim() == "Submit")
                {
                    ApprovalCard.Visible = true;
                    //btnSubmit.Text = "Back";
                }
                DataSet ds = new DataSet();
                //ds = CEI.LineDataWithId(int.Parse(ID)); gurmeet 
                ds = CEI.LineDataWithId(ID);
                string dp_Id = ds.Tables[0].Rows[0]["ContractorType"].ToString();
                txtInstallation.Text = dp_Id;
                if (dp_Id == "" || dp_Id == null)
                {
                    txtInstallation.Text = "Individual Person";
                }
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
                if (txtCableType.Text == "Other")
                {
                    OtherCable.Visible = true;
                    txtOtherCable.Text = ds.Tables[0].Rows[0]["OtherCable"].ToString();
                }
                txtSubmitteddate.Text = ds.Tables[0].Rows[0]["SubmittedDate"].ToString();
                txtSubmittedBy.Text = ds.Tables[0].Rows[0]["ContractorWhoCreated"].ToString();
                txtName.Text = ds.Tables[0].Rows[0]["NameOfOwner"].ToString();
                txtagency.Text = ds.Tables[0].Rows[0]["NameOfAgency"].ToString();
                txtPhone.Text = ds.Tables[0].Rows[0]["ContactNo"].ToString();
                txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                string dp_Id1 = ds.Tables[0].Rows[0]["Permises"].ToString();
                TxtPremises.Text = dp_Id1;
                //string dp_Id2 = ds.Tables[0].Rows[0]["OtherPremises"].ToString();
                string dp_Id3 = ds.Tables[0].Rows[0]["VoltageLevel"].ToString().Trim();
                txtVoltagelevel.Text = dp_Id3;
                string dp_Id4 = ds.Tables[0].Rows[0]["WorkStartDate"].ToString();
                txtStartDate.Text = DateTime.Parse(dp_Id4).ToString("dd-MM-yyyy");
                string dp_Id5 = ds.Tables[0].Rows[0]["CompletionDate"].ToString();
                txtCompletitionDate.Text = DateTime.Parse(dp_Id5).ToString("dd-MM-yyyy");
                txtLineVoltage.Text = ds.Tables[0].Rows[0]["Voltage"].ToString();
                DateTime createdDate = Convert.ToDateTime(ds.Tables[0].Rows[0]["CreatedDate"]);
                txtCreatedDate.Text = createdDate.ToString("dd-MM-yyyy");
                //TextStatus.Text = ds.Tables[0].Rows[0]["RejectOrApprovedFronContractor"].ToString();
                //TextReject.Text = ds.Tables[0].Rows[0]["ReasonForRejection"].ToString();
                if (txtLineVoltage.Text == "Other")
                {
                    divOtherVoltages.Visible = true;
                    OtherVoltage.Visible = true;
                }
                txtVotalgeType.Text = ds.Tables[0].Rows[0]["OtherVoltageType"].ToString();
                TxtOthervoltage.Text = ds.Tables[0].Rows[0]["OtherVoltage"].ToString();
                txtLineLength.Text = ds.Tables[0].Rows[0]["LineLength"].ToString();
                txtLineType.Text = ds.Tables[0].Rows[0]["LineType"].ToString();
                Session["InspectionType"] = ds.Tables[0].Rows[0]["InspectionType"].ToString();

                if (txtVotalgeType.Text == "V")
                {
                    if (int.TryParse(TxtOthervoltage.Text, out int value))
                    {
                        if (value > 440)
                        {
                            Insulation440vAbove.Visible = true;
                            Insulation220vAbove.Visible = false;
                        }
                        else if (value > 220)
                        {
                            Insulation440vAbove.Visible = false;
                            Insulation220vAbove.Visible = true;
                        }
                        else
                        {
                            Insulation440vAbove.Visible = true;
                            Insulation220vAbove.Visible = false;
                        }

                    }
                }
                else if (txtVotalgeType.Text.Trim() == "KV")
                {
                    Insulation440vAbove.Visible = true;
                    Insulation220vAbove.Visible = false;
                }
                else
                {
                    Insulation440vAbove.Visible = false;
                    Insulation220vAbove.Visible = false;
                }
                if (txtLineType.Text.Trim() == "Overhead")
                {
                    LineTypeOverhead.Visible = true;
                    LineTypeUnderground.Visible = false;
                    if (txtVotalgeType.Text.Trim() == "Other")
                    {
                        if (TxtOthervoltage.Text == "KV")
                        {

                            if (int.TryParse(TxtOthervoltage.Text, out int value))
                            {

                                Insulation220vAbove.Visible = false;
                                Insulation440vAbove.Visible = true;

                            }
                        }

                        else if (TxtOthervoltage.Text.Trim() == "V")
                        {
                            if (int.TryParse(TxtOthervoltage.Text, out int value))
                            {
                                if (value > 440)
                                {
                                    Insulation220vAbove.Visible = false;
                                    Insulation440vAbove.Visible = true;
                                }
                                else if (value > 220)
                                {
                                    Insulation440vAbove.Visible = false;
                                    Insulation220vAbove.Visible = true;
                                }


                            }
                        }
                    }
                    else if (txtLineVoltage.Text.Trim() == "220V")
                    {
                        Insulation220vAbove.Visible = true;
                        Insulation440vAbove.Visible = false;
                    }
                    else if (txtLineVoltage.Text.Trim() == "440V")
                    {
                        Insulation220vAbove.Visible = false;
                        Insulation440vAbove.Visible = true;
                    }
                    else if (txtLineVoltage.Text.Trim() == "11KV" || txtLineVoltage.Text.Trim() == "33KV" || txtLineVoltage.Text.Trim() == "66KV" ||
                        txtLineVoltage.Text.Trim() == "132KV" || txtLineVoltage.Text.Trim() == "220KV")
                    {
                        Insulation220vAbove.Visible = false;
                        Insulation440vAbove.Visible = true;
                    }

                }
                else if (txtLineType.Text.Trim() == "Underground")
                {


                    if (txtVotalgeType.Text == "Other")
                    {
                        if (TxtOthervoltage.Text.Trim() == "KV")
                        {

                            if (int.TryParse(TxtOthervoltage.Text, out int value))
                            {

                                Insulation440vAbove.Visible = true;
                                Insulation220vAbove.Visible = false;

                            }
                        }

                        else if (TxtOthervoltage.Text.Trim() == "V")
                        {
                            if (int.TryParse(TxtOthervoltage.Text, out int value))
                            {
                                if (value > 440)
                                {
                                    Insulation440vAbove.Visible = true;
                                    Insulation220vAbove.Visible = false;
                                }
                                else if (value > 220)
                                {
                                    Insulation440vAbove.Visible = false;
                                    Insulation220vAbove.Visible = true;
                                }
                                else
                                {
                                    Insulation440vAbove.Visible = true;
                                    Insulation220vAbove.Visible = false;
                                }

                            }
                        }
                    }
                    else if (txtLineVoltage.Text.Trim() == "220V")
                    {
                        Insulation220vAbove.Visible = true;
                        Insulation440vAbove.Visible = false;
                    }
                    else if (txtLineVoltage.Text.Trim() == "440V")
                    {
                        Insulation220vAbove.Visible = false;
                        Insulation440vAbove.Visible = true;
                    }
                    else if (txtLineVoltage.Text.Trim() == "11KV" || txtLineVoltage.Text.Trim() == "66KV" ||
                     txtLineVoltage.Text.Trim() == "132KV" || txtLineVoltage.Text.Trim() == "220KV")
                    {
                        Insulation220vAbove.Visible = false;
                        Insulation440vAbove.Visible = true;
                    }
                    LineTypeUnderground.Visible = true;
                    LineTypeOverhead.Visible = false;

                }
                else
                {

                    LineTypeOverhead.Visible = false;
                    LineTypeUnderground.Visible = false;
                    Insulation440vAbove.Visible = true;
                    Insulation220vAbove.Visible = false;
                    Earthing.Visible = false;
                }
                txtCircuit.Text = ds.Tables[0].Rows[0]["NoOfCircuit"].ToString();
                txtConductorType.Text = ds.Tables[0].Rows[0]["Conductortype"].ToString();
                //txtReportNo.Text = ds.Tables[0].Rows[0]["ID"].ToString(); gurmeet to showing new testreportid
                ////txtReportNo.Text = ds.Tables[0].Rows[0]["LineIdOther"].ToString();
                lblIntimationId.Text = ds.Tables[0].Rows[0]["IntimationId"].ToString();
                lblReportNo.Text = ds.Tables[0].Rows[0]["LineId"].ToString();
                txtPreparedby.Text = ds.Tables[0].Rows[0]["SupervisorWhoCreated"].ToString();
                txtPoleTowerNo.Text = ds.Tables[0].Rows[0]["NoofPoleTowerForOverheadCable"].ToString();
                if (txtConductorType.Text.Trim() == "Bare")
                {

                    OverheadBare.Visible = true;
                    OverheadCable.Visible = false;
                    txtPoleTowerNo.Text = ds.Tables[0].Rows[0]["NumberofPoleTower"].ToString();
                    txtPoleTower.Text = ds.Tables[0].Rows[0]["NumberofPoleTower"].ToString();
                }
                else if (txtConductorType.Text.Trim() == "Cable")
                {

                    OverheadCable.Visible = true;
                    OverheadBare.Visible = false;
                    txtPoleTowerNo.Text = ds.Tables[0].Rows[0]["NoofPoleTowerForOverheadCable"].ToString();
                    txtPoleTower.Text = ds.Tables[0].Rows[0]["NoofPoleTowerForOverheadCable"].ToString();
                }
                else
                {
                    OverheadBare.Visible = false;
                    OverheadCable.Visible = false;
                }
                txtConductorSize.Text = ds.Tables[0].Rows[0]["ConductorSize"].ToString();
                txtGroundWireSize.Text = ds.Tables[0].Rows[0]["GroundWireSize"].ToString();
                txtRailwayCrossingNo.Text = ds.Tables[0].Rows[0]["NmbrofRailwayCrossing"].ToString();
                txtRoadCrossingNo.Text = ds.Tables[0].Rows[0]["NmbrofRoadCrossing"].ToString();
                txtRiverCanalCrossing.Text = ds.Tables[0].Rows[0]["NmbrofRiverCanalCrossing"].ToString();
                txtPowerLineCrossing.Text = ds.Tables[0].Rows[0]["NmbrofPowerLineCrossing"].ToString();
                txtEarthing.Text = ds.Tables[0].Rows[0]["NmbrofEarthing"].ToString();
                txtTestReportCount.Text = ds.Tables[0].Rows[0]["Count"].ToString();
                txtApplicantType.Text = ds.Tables[0].Rows[0]["ApplicantType"].ToString();
                txtDistrict.Text = ds.Tables[0].Rows[0]["District"].ToString();
                txtDivision.Text = ds.Tables[0].Rows[0]["Area"].ToString();
          
                txtCableSize1.Text = ds.Tables[0].Rows[0]["CableSize"].ToString();
                txtRailwayCrossingNmbr.Text = ds.Tables[0].Rows[0]["RailwayCrossingNoForOC"].ToString();
                txtRoadCrossingNmbr.Text = ds.Tables[0].Rows[0]["RoadCrossingNoForOC"].ToString();
                txtRiverCanalCrossingNmber.Text = ds.Tables[0].Rows[0]["RiverCanalCrossingNoForOC"].ToString();
                txtPowerLineCrossingNmbr.Text = ds.Tables[0].Rows[0]["PowerLineCrossingNoForOc"].ToString();
                txtRedEarthWire.Text = ds.Tables[0].Rows[0]["RedPhaseEarthWire"].ToString();
                txtYellowEarthWire.Text = ds.Tables[0].Rows[0]["YellowPhaseEarth"].ToString();
                txtBlueEarthWire.Text = ds.Tables[0].Rows[0]["BluePhaseEarthWire"].ToString();
                txtRedYellowPhase.Text = ds.Tables[0].Rows[0]["RedPhaseYellowPhase"].ToString();
                txtBlueYellowPhase.Text = ds.Tables[0].Rows[0]["BluePhaseYellowPhase"].ToString();
                txtRedBluePhase.Text = ds.Tables[0].Rows[0]["RedPhaseBluePhase"].ToString();
                txtNeutralWire.Text = ds.Tables[0].Rows[0]["PhasewireNeutralwire"].ToString();
                txtEarthWire.Text = ds.Tables[0].Rows[0]["PhasewireEarth"].ToString();
                txtNeutralWireEarth.Text = ds.Tables[0].Rows[0]["NeutralwireEarth"].ToString();
                txtCableType.Text = ds.Tables[0].Rows[0]["TypeofCable"].ToString();
                if (txtCableType.Text == "Other")
                {
                    OtherCable.Visible = true;
                    txtOtherCable.Text = ds.Tables[0].Rows[0]["OtherCable"].ToString();
                }
                txtCableType.Text = ds.Tables[0].Rows[0]["TypeofCable"].ToString();
                txtOtherCable.Text = ds.Tables[0].Rows[0]["OtherCable"].ToString();
                txtCableSize.Text = ds.Tables[0].Rows[0]["SizeofCable"].ToString();
                txtCableLaid.Text = ds.Tables[0].Rows[0]["Cablelaidin"].ToString();

                txtApprovalDate.Text = ds.Tables[0].Rows[0]["Approvaldate"].ToString();
                txtApprovedBy.Text = ds.Tables[0].Rows[0]["ContractorWhoCreated"].ToString();
                lbltestReportId.Text = ds.Tables[0].Rows[0]["LineId"].ToString();
                lblWorkIntimationId.Text = ds.Tables[0].Rows[0]["IntimationId"].ToString();
                //txtRejection.Text = ds.Tables[0].Rows[0]["ReasonForRejection"].ToString();
                Session["Contact"] = ds.Tables[0].Rows[0]["ContractorContactNo"].ToString();
                Session["Email"] = ds.Tables[0].Rows[0]["ContractorEmail"].ToString();
                GetEarthingData();
                Session["Line"] = "";
                Session["LineID_Industry"] = "";
            }
            catch (Exception ex)
            {

            }
        }

        public void GetEarthingData()
        {

            DataSet ds = new DataSet();
            ds = CEI.GetEarthingData(ID);
            if (ds.Tables[0].Rows.Count > 0 && ds != null)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();

            }

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            string previousPageUrl = Session["PreviousPage"] as string;
            if (!string.IsNullOrEmpty(previousPageUrl))
            {

                Response.Redirect(previousPageUrl, false);
                Session["PreviousPage"] = null;
                // return;
            }
        }

        protected void btnBack2_Click(object sender, EventArgs e)
        {
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