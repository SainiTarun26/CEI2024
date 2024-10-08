
using CEI_PRoject;
using CEIHaryana.Admin;
using CEIHaryana.Contractor;
using CEIHaryana.SiteOwnerPages;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.TestReportModal
{
    public partial class LineTestReportModal : System.Web.UI.Page
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

                    if (Session["ContractorID"] != null && Convert.ToString(Session["ContractorID"]) != "")
                    {
                        //HiddenField1.Value = "0";
                        Session["LineOtp"] = "0";
                        ID = Session["LineID"].ToString();
                        GetDetailswithId();
                        GetEarthingData();
                        if (Convert.ToString(Session["Approval"]) == "Pending")
                        {
                            //Contractor.Visible = true;
                            //CreatedDate.Visible = true;
                            ToOTPVerify.Visible = true;
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(Request.QueryString["Return"]))
                            {
                            }
                            else
                            {
                                //Contractor.Visible = true;
                                //CreatedDate.Visible = true;
                                FinalSubmit.Visible = true;
                            }
                        }
                    }
                    else if (Session["SiteOwnerId"] != null && Session["SiteOwnerId"].ToString() != "")
                    {
                        ID = Session["LineID"].ToString();
                        GetDetailswithId();
                        GetEarthingData();

                        SiteOwner.Visible = false;
                        SiteOwner2.Visible = true;
                        IntimationData.Visible = true;
                        ApprovalCard.Visible = true;
                        ////CreatedDate.Visible = true; //Added
                        ////SubmitDate.Visible = true;
                        ////SubmitBy.Visible = true;//Added
                    }
                    else if (Session["SiteOwnerId_Industry"] != null && Session["SiteOwnerId_Industry"].ToString() != "")
                    {
                        if (Request.UrlReferrer != null)
                        {
                            Session["PreviousPage_Industry"] = Request.UrlReferrer.ToString();
                        }

                        ID = Session["LineID_Industry"].ToString();
                        GetDetailswithId();
                        GetEarthingData();

                        SiteOwner.Visible = false;
                        SiteOwner2.Visible = true;
                        IntimationData.Visible = true;
                        ApprovalCard.Visible = true;
                        ////CreatedDate.Visible = true; //Added
                        ////SubmitDate.Visible = true;
                        ////SubmitBy.Visible = true;//Added
                    }
                    else if (Session["InspectionTestReportId"] != null && Session["InspectionTestReportId"].ToString() != "")
                    {
                        ID = Session["InspectionTestReportId"].ToString();
                        GetDetailswithId();
                        GetEarthingData();
                        SiteOwner.Visible = true;
                        IntimationData.Visible = true;
                        ApprovalCard.Visible = true;
                        btnNext.Text = "Back";
                    }
                    else if (Session["IntimationForHistoryId"] != null && Session["IntimationForHistoryId"].ToString() != "")
                    {
                        ID = Session["IntimationForHistoryId"].ToString();
                        GetDetailswithId();
                        GetEarthingData();
                        IntimationForHistory.Visible = true;
                        Session["IntimationForHistoryId"] = null;
                    }
                    else if (Session["SupervisorID"] != null || Session["AdminID"] != null)
                    {
                        if (Session["SupervisorID"] != null && Session["SupervisorID"].ToString() != "")
                        {
                            ////SubmitDate.Visible = true;
                            ////SubmitBy.Visible = true;
                        }
                        if (Session["AdminID"] != null)
                        {
                            ////Contractor.Visible = true;
                            ////SubmitBy.Visible = true;
                            ////SubmitDate.Visible = true;
                            ////CreatedDate.Visible = true;
                        }
                        ID = Session["LineID"].ToString();
                        GetDetailswithId();
                        GetEarthingData();
                        Supervisor.Visible = true;
                        IntimationData.Visible = true;

                    }
                }
            }
            catch
            {
                Response.Redirect("/Login.aspx", false);
            }


        }
        protected void btnIntimationForHistoryBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Admin/IntimationForHistory.aspx", false);
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
                    btnSubmit.Text = "Back";
                }
                else if (value1.Trim() == "Reject")
                {
                    // ddlType.Attributes.Add("Readonly", "true");
                    // txtRejection.Attributes.Add("Readonly", "true");
                    btnSubmit.Text = "Back";
                    // ddlType.Attributes.Add("disabled", "disabled");
                    // ddlType.SelectedIndex = ddlType.Items.IndexOf(ddlType.Items.FindByText(value1));
                    // Rejection.Visible = true;
                }
                if (value1.Trim() == "Submitted" || value1.Trim() == "Submit")
                {
                    ApprovalCard.Visible = true;
                    btnSubmit.Text = "Back";
                }
                DataSet ds = new DataSet();
                //ds = CEI.LineDataWithId(int.Parse(ID)); gurmeet 
                ds = CEI.LineDataWithId(ID);
                string dp_Id = ds.Tables[0].Rows[0]["ContractorType"].ToString();
                txtInstallation.Text = dp_Id;
                if (dp_Id == "Firm/Organization/Company/Department")
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
                    else if (txtLineVoltage.Text.Trim() == "11kV" || txtLineVoltage.Text.Trim() == "33kV" || txtLineVoltage.Text.Trim() == "66kV" ||
                        txtLineVoltage.Text.Trim() == "132kV" || txtLineVoltage.Text.Trim() == "220kV")
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
                    else if (txtLineVoltage.Text.Trim() == "11kV" || txtLineVoltage.Text.Trim() == "66kV" ||
                     txtLineVoltage.Text.Trim() == "132kV" || txtLineVoltage.Text.Trim() == "220kV")
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
                if (txtConductorType.Text.Trim() == "Bare")
                {

                    OverheadBare.Visible = true;
                    OverheadCable.Visible = false;

                }
                else if (txtConductorType.Text.Trim() == "Cable")
                {

                    OverheadCable.Visible = true;
                    OverheadBare.Visible = false;
                }
                else
                {
                    OverheadBare.Visible = false;
                    OverheadCable.Visible = false;
                }
                txtPoleTower.Text = ds.Tables[0].Rows[0]["NumberofPoleTower"].ToString();
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
                //if (txtEarthing.Text == "1")
                //{
                //    Earthingtype1.Visible = true;
                //}
                //else if (txtEarthing.Text == "2")
                //{
                //    Earthingtype1.Visible = true;
                //    Earthingtype2.Style.Add("display", "table-row");

                //}
                //else if (txtEarthing.Text == "3")
                //{
                //    Earthingtype1.Visible = true;
                //    Earthingtype2.Style.Add("display", "table-row");
                //    Earthingtype3.Style.Add("display", "table-row");

                //}
                //else if (txtEarthing.Text == "4")
                //{
                //    Earthingtype1.Visible = true;
                //    Earthingtype2.Style.Add("display", "table-row");
                //    Earthingtype3.Style.Add("display", "table-row");
                //    Earthingtype4.Style.Add("display", "table-row");

                //}
                //else if (txtEarthing.Text == "5")
                //{
                //    Earthingtype1.Visible = true;
                //    Earthingtype2.Style.Add("display", "table-row");
                //    Earthingtype3.Style.Add("display", "table-row");
                //    Earthingtype4.Style.Add("display", "table-row");
                //    Earthingtype5.Style.Add("display", "table-row");

                //}
                //else if (txtEarthing.Text == "6")
                //{
                //    Earthingtype1.Visible = true;
                //    Earthingtype2.Style.Add("display", "table-row");
                //    Earthingtype3.Style.Add("display", "table-row");
                //    Earthingtype4.Style.Add("display", "table-row");
                //    Earthingtype5.Style.Add("display", "table-row");
                //    Earthingtype6.Style.Add("display", "table-row");

                //}
                //else if (txtEarthing.Text == "7")
                //{
                //    Earthingtype1.Visible = true;
                //    Earthingtype2.Style.Add("display", "table-row");
                //    Earthingtype3.Style.Add("display", "table-row");
                //    Earthingtype4.Style.Add("display", "table-row");
                //    Earthingtype5.Style.Add("display", "table-row");
                //    Earthingtype6.Style.Add("display", "table-row");
                //    Earthingtype7.Style.Add("display", "table-row");

                //}
                //else if (txtEarthing.Text == "8")
                //{
                //    Earthingtype1.Visible = true;
                //    Earthingtype2.Style.Add("display", "table-row");
                //    Earthingtype3.Style.Add("display", "table-row");
                //    Earthingtype4.Style.Add("display", "table-row");
                //    Earthingtype5.Style.Add("display", "table-row");
                //    Earthingtype6.Style.Add("display", "table-row");
                //    Earthingtype7.Style.Add("display", "table-row");
                //    Earthingtype8.Style.Add("display", "table-row");

                //}
                //else if (txtEarthing.Text == "9")
                //{
                //    Earthingtype1.Visible = true;
                //    Earthingtype2.Style.Add("display", "table-row");
                //    Earthingtype3.Style.Add("display", "table-row");
                //    Earthingtype4.Style.Add("display", "table-row");
                //    Earthingtype5.Style.Add("display", "table-row");
                //    Earthingtype6.Style.Add("display", "table-row");
                //    Earthingtype7.Style.Add("display", "table-row");
                //    Earthingtype8.Style.Add("display", "table-row");
                //    Earthingtype9.Style.Add("display", "table-row");

                //}
                //else if (txtEarthing.Text == "10")
                //{
                //    Earthingtype1.Visible = true;
                //    Earthingtype2.Style.Add("display", "table-row");
                //    Earthingtype3.Style.Add("display", "table-row");
                //    Earthingtype4.Style.Add("display", "table-row");
                //    Earthingtype5.Style.Add("display", "table-row");
                //    Earthingtype6.Style.Add("display", "table-row");
                //    Earthingtype7.Style.Add("display", "table-row");
                //    Earthingtype8.Style.Add("display", "table-row");
                //    Earthingtype9.Style.Add("display", "table-row");
                //    Earthingtype10.Style.Add("display", "table-row");

                //}
                //else if (txtEarthing.Text == "11")
                //{
                //    Earthingtype1.Visible = true;
                //    Earthingtype2.Style.Add("display", "table-row");
                //    Earthingtype3.Style.Add("display", "table-row");
                //    Earthingtype4.Style.Add("display", "table-row");
                //    Earthingtype5.Style.Add("display", "table-row");
                //    Earthingtype6.Style.Add("display", "table-row");
                //    Earthingtype7.Style.Add("display", "table-row");
                //    Earthingtype8.Style.Add("display", "table-row");
                //    Earthingtype9.Style.Add("display", "table-row");
                //    Earthingtype10.Style.Add("display", "table-row");
                //    Earthingtype11.Style.Add("display", "table-row");

                //}
                //else if (txtEarthing.Text == "12")
                //{
                //    Earthingtype1.Visible = true;
                //    Earthingtype2.Style.Add("display", "table-row");
                //    Earthingtype3.Style.Add("display", "table-row");
                //    Earthingtype4.Style.Add("display", "table-row");
                //    Earthingtype5.Style.Add("display", "table-row");
                //    Earthingtype6.Style.Add("display", "table-row");
                //    Earthingtype7.Style.Add("display", "table-row");
                //    Earthingtype8.Style.Add("display", "table-row");
                //    Earthingtype9.Style.Add("display", "table-row");
                //    Earthingtype10.Style.Add("display", "table-row");
                //    Earthingtype11.Style.Add("display", "table-row");
                //    Earthingtype12.Style.Add("display", "table-row");

                //}
                //else if (txtEarthing.Text == "13")
                //{
                //    Earthingtype1.Visible = true;
                //    Earthingtype2.Style.Add("display", "table-row");
                //    Earthingtype3.Style.Add("display", "table-row");
                //    Earthingtype4.Style.Add("display", "table-row");
                //    Earthingtype5.Style.Add("display", "table-row");
                //    Earthingtype6.Style.Add("display", "table-row");
                //    Earthingtype7.Style.Add("display", "table-row");
                //    Earthingtype8.Style.Add("display", "table-row");
                //    Earthingtype9.Style.Add("display", "table-row");
                //    Earthingtype10.Style.Add("display", "table-row");
                //    Earthingtype11.Style.Add("display", "table-row");
                //    Earthingtype12.Style.Add("display", "table-row");
                //    Earthingtype13.Style.Add("display", "table-row");

                //}
                //else if (txtEarthing.Text == "14")
                //{
                //    Earthingtype1.Visible = true;
                //    Earthingtype2.Style.Add("display", "table-row");
                //    Earthingtype3.Style.Add("display", "table-row");
                //    Earthingtype4.Style.Add("display", "table-row");
                //    Earthingtype5.Style.Add("display", "table-row");
                //    Earthingtype6.Style.Add("display", "table-row");
                //    Earthingtype7.Style.Add("display", "table-row");
                //    Earthingtype8.Style.Add("display", "table-row");
                //    Earthingtype9.Style.Add("display", "table-row");
                //    Earthingtype10.Style.Add("display", "table-row");
                //    Earthingtype11.Style.Add("display", "table-row");
                //    Earthingtype12.Style.Add("display", "table-row");
                //    Earthingtype14.Style.Add("display", "table-row");

                //}
                //else if (txtEarthing.Text == "15")
                //{
                //    Earthingtype1.Visible = true;
                //    Earthingtype2.Style.Add("display", "table-row");
                //    Earthingtype3.Style.Add("display", "table-row");
                //    Earthingtype4.Style.Add("display", "table-row");
                //    Earthingtype5.Style.Add("display", "table-row");
                //    Earthingtype6.Style.Add("display", "table-row");
                //    Earthingtype7.Style.Add("display", "table-row");
                //    Earthingtype8.Style.Add("display", "table-row");
                //    Earthingtype9.Style.Add("display", "table-row");
                //    Earthingtype10.Style.Add("display", "table-row");
                //    Earthingtype11.Style.Add("display", "table-row");
                //    Earthingtype12.Style.Add("display", "table-row");
                //    Earthingtype15.Style.Add("display", "table-row");

                //}
                //txtEarthingType1.Text = ds.Tables[0].Rows[0]["EarthingType1"].ToString();
                //txtearthingValue1.Text = ds.Tables[0].Rows[0]["Valueinohms1"].ToString();
                //txtEarthingType2.Text = ds.Tables[0].Rows[0]["EarthingType2"].ToString();
                //txtEarthingValue2.Text = ds.Tables[0].Rows[0]["Valueinohms2"].ToString();
                //txtEarthingType3.Text = ds.Tables[0].Rows[0]["EarthingType3"].ToString();
                //txtEarthingValue3.Text = ds.Tables[0].Rows[0]["Valueinohms3"].ToString();
                //txtEarthingType4.Text = ds.Tables[0].Rows[0]["EarthingType4"].ToString();
                //txtEarthingValue4.Text = ds.Tables[0].Rows[0]["Valueinohms4"].ToString();
                //txtEarthingType5.Text = ds.Tables[0].Rows[0]["EarthingType5"].ToString();
                //txtEarthingValue5.Text = ds.Tables[0].Rows[0]["Valueinohms5"].ToString();
                //txtEarthingType6.Text = ds.Tables[0].Rows[0]["EarthingType6"].ToString();
                //txtEarthingValue6.Text = ds.Tables[0].Rows[0]["Valueinohms6"].ToString();
                //txtEarthingType7.Text = ds.Tables[0].Rows[0]["EarthingType7"].ToString();
                //txtEarthingValue7.Text = ds.Tables[0].Rows[0]["Valueinohms7"].ToString();
                //txtEarthingType8.Text = ds.Tables[0].Rows[0]["EarthingType8"].ToString();
                //txtEarthingValue8.Text = ds.Tables[0].Rows[0]["Valueinohms8"].ToString();
                //txtEarthingType9.Text = ds.Tables[0].Rows[0]["EarthingType9"].ToString();
                //txtEarthingValue9.Text = ds.Tables[0].Rows[0]["Valueinohms9"].ToString();
                //txtEarthingType10.Text = ds.Tables[0].Rows[0]["EarthingType10"].ToString();
                //txtEarthingValue10.Text = ds.Tables[0].Rows[0]["Valueinohms10"].ToString();
                //txtEarthingType11.Text = ds.Tables[0].Rows[0]["EarthingType11"].ToString();
                //txtEarthingValue11.Text = ds.Tables[0].Rows[0]["Valueinohms11"].ToString();
                //txtEarthingType12.Text = ds.Tables[0].Rows[0]["EarthingType12"].ToString();
                //txtEarthingValue12.Text = ds.Tables[0].Rows[0]["Valueinohms12"].ToString();
                //txtEarthingType13.Text = ds.Tables[0].Rows[0]["EarthingType13"].ToString();
                //txtEarthingValue13.Text = ds.Tables[0].Rows[0]["Valueinohms13"].ToString();
                //txtEarthingType14.Text = ds.Tables[0].Rows[0]["EarthingType14"].ToString();
                //txtEarthingValue14.Text = ds.Tables[0].Rows[0]["Valueinohms14"].ToString();
                //txtEarthingType15.Text = ds.Tables[0].Rows[0]["EarthingType15"].ToString();
                //txtEarthingValue15.Text = ds.Tables[0].Rows[0]["Valueinohms15"].ToString();
                txtPoleTowerNo.Text = ds.Tables[0].Rows[0]["NoofPoleTowerForOverheadCable"].ToString();
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
            }
            catch (Exception ex)
            {

            }
        }
        protected void btnReject_Click(object sender, EventArgs e)
        {
            //Rejection.Visible = true;
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

        protected void btnAccept_Click(object sender, EventArgs e)
        {
            if (btnSubmit.Text == "Back")
            {
                Response.Redirect("/Contractor/Approved_Test_Reports.aspx");
            }
            else
            {
                string InspectionType = Session["InspectionType"].ToString();
                string id = Session["IntimationId"].ToString();
                string Counts = Session["Counts"].ToString();
                string ContractorId = Session["ContractorID"].ToString();
                //CEI.UpdateLineData(id, Counts, ddlType.SelectedItem.ToString(), txtRejection.Text);
                //CEI.UpdateLineData(id, Counts);
                if (InspectionType == "Existing")
                {
                    CEI.InsertExistingInspectionData(lbltestReportId.Text, lblIntimationId.Text, txtTestReportCount.Text, txtApplicantType.Text,"Line", txtVoltagelevel.Text.Trim(),
                       txtDistrict.Text, txtDivision.Text, TxtPremises.Text, ContractorId);

                }
                CEI.UpdateLineData(id, Counts);
                Session["InspectionType"] = "";
                string script = "alert('Test Report Approved  Successfully'); window.location='/Contractor/Approved_Test_Reports.aspx';";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", script, true);
                // Response.Redirect("/Contractor/Approved_Test_Reports.aspx");
            }
        }

        //protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if(ddlType.SelectedValue == "2")
        //    {
        //        Rejection.Visible =true;
        //    }
        //    else
        //    {
        //        Rejection.Visible = false;
        //    }
        //}

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
                    Session["PreviousPage"] = null;
                    // return;
                }
                // Response.Redirect("/Admin/TestReportHistoryFromSupervisor.aspx");
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
                //OTP.Visible = true;
                //HiddenField1.Value = Convert.ToString(Convert.ToInt32(HiddenField1.Value) + 1);

                Session["LineOtp"] = Convert.ToString(Convert.ToInt32(Session["LineOtp"]) + 1);
                //if (btnVerify.Text == "SendOTP" && HiddenField1.Value == "1")
                //{
                if (btnVerify.Text == "SendOTP" && Session["LineOtp"].ToString() == "1")
                {

                    OTP.Visible = true;
                    string Email = Session["Email"].ToString();
                    if (Email.Trim() == "")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirectdata();", true);
                    }
                    else
                    {
                        Session["OTP"] = CEI.ValidateOTPthroughEmail(Email);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('OTP has been Sent to your registered email Id');", true);
                        btnVerify.Text = "Verify";
                    }
                }
                else
                {
                    if (txtOtp.Text != "")
                    {
                        if (Session["OTP"].ToString() == txtOtp.Text)
                        {
                            FinalSubmit.Visible = true;
                            ToOTPVerify.Visible = false;
                            //Session["LineOtp"] = null;
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Incorrect OTP. Please try again.');", true);
                        }
                    }
                    Session["LineOtp"] = null;
                }

            }
            catch (Exception ex)
            {
                Session["LineOtp"] = null;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('An Error Occured Please try again later')", true);

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
