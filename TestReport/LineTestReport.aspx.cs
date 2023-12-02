using CEI_PRoject;
using iTextSharp.text.pdf.parser;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace CEIHaryana.TestReport
{
    public partial class LineTestReport : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        int x = 0;
        string type = string.Empty;
        string sessionValue = string.Empty;
        string sessionName = string.Empty;
        string nextSessionName = string.Empty;
        string nextSessionValue = string.Empty;
        string currentSessionName = string.Empty;
        string IdUpdate = string.Empty;
        string LineId = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    // GetHistoryDataById();
                    ddlLoadBindVoltage();
                    ddlEarthing();
                    SessionValue();
                    PageWorking();
                    Insulation440vAbove.Visible = false;
                    Insulation220vAbove.Visible = false;
                    BtnBack.Visible = false;
                    if (Convert.ToString(Session["ValueId"]) == null || Convert.ToString(Session["ValueId"]) == "")
                    {
                        // GetHistoryDataById();
                    }
                    else
                    {
                        LineId = Session["ValueId"].ToString().Trim();
                        GetHistoryDataById();
                    }
                    if (Convert.ToString(Session["Approval"]) == "Reject")
                    {
                        LineId = Session["LineID"].ToString().Trim();
                        BtnBack.Visible = true;
                        GetHistoryDataById();

                    }
                    if (Convert.ToString(Session["ContractorID"]) == null || Convert.ToString(Session["ContractorID"]) == "")
                    {
                      
                    }
                    else
                    {
                        BtnBack.Visible = false;
                        btnVerify.Visible = false;
                        btnSubmit.Visible = false;
                    }

                }
            }
            catch
            {
                Response.Redirect("/Login.aspx");
            }
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Session["LineID"] = "";
            if (Session["TestReportHistory"] != null)
            {
                Response.Redirect("/Supervisor/TestReportHistory.aspx");
            }
            else
            {
                Response.Redirect("/Admin/TestHistoryReport.aspx", false);
            }
        }
        private void GetHistoryDataById()
        {
            try
            {
                if (Convert.ToString(Session["Value"]) == null || Convert.ToString(Session["Value"]) == "")
                {
                    //
                }
                else
                {
                    type = Session["Value"].ToString();
                }
                if(Convert.ToString(Session["Approval"]) == "Reject")
                {
                    type = "line";
                }
                DataSet ds = new DataSet();
                ds = CEI.GetTestReportDataForUpdate(type, LineId);

                if (ds.Tables.Count > 0)
                {
                    Session["Contact"] = ds.Tables[0].Rows[0]["ContractorContactNo"].ToString();
                    Session["GeneratedLineId"] = ds.Tables[0].Rows[0]["LineId"].ToString().Trim();
                    Session["TestReportId"] = ds.Tables[0].Rows[0]["TestReportId"].ToString().Trim();
                    Session["id"] = ds.Tables[0].Rows[0]["IntimationId"].ToString().Trim();
                    string lineVoltage = ds.Tables[0].Rows[0]["LineVoltage"].ToString();

                    ddlLoadBindVoltage();
                    ddlLineVoltage.SelectedIndex = ddlLineVoltage.Items.IndexOf(ddlLineVoltage.Items.FindByText(lineVoltage));
                    if (lineVoltage == "Other")
                    {
                        divOtherVoltages.Visible = true;
                        OtherVoltage.Visible = true;

                        ddlOtherVoltage.SelectedItem.Text = ds.Tables[0].Rows[0]["OtherVoltageType"].ToString();
                        TxtOthervoltage.Text = ds.Tables[0].Rows[0]["OtherVoltage"].ToString();

                        if (ddlOtherVoltage.SelectedItem.Text.Trim() == "KV")
                        {
                            Insulation440vAbove.Visible = true;
                            Insulation220vAbove.Visible = false;
                        }
                        else if (ddlOtherVoltage.SelectedItem.Text.Trim() == "V")
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
                    else if (lineVoltage == "11kV" || lineVoltage == "66kV" ||
                       lineVoltage == "132kV" || lineVoltage == "220kV")
                    {
                        Insulation220vAbove.Visible = false;
                        Insulation440vAbove.Visible = true;
                    }
                    else if (lineVoltage == "440V")
                    {
                        Insulation220vAbove.Visible = false;
                        Insulation440vAbove.Visible = true;
                    }
                    else if (lineVoltage == "220V")
                    {
                        Insulation220vAbove.Visible = true;
                        Insulation440vAbove.Visible = false;
                    }


                    txtLineLength.Text = ds.Tables[0].Rows[0]["LineLength"].ToString();
                    string LineType = ds.Tables[0].Rows[0]["LineType"].ToString();
                    ddlLineType.SelectedIndex = ddlLineType.Items.IndexOf(ddlLineType.Items.FindByText(LineType));
                    //440v
                    txtRedEarthWire.Text = ds.Tables[0].Rows[0]["RedPhaseEarthWire"].ToString();
                    txtYellowEarthWire.Text = ds.Tables[0].Rows[0]["YellowPhaseEarth"].ToString();
                    txtBlueEarthWire.Text = ds.Tables[0].Rows[0]["BluePhaseEarthWire"].ToString();
                    txtRedYellowPhase.Text = ds.Tables[0].Rows[0]["RedPhaseYellowPhase"].ToString();
                    txtBlueYellowPhase.Text = ds.Tables[0].Rows[0]["BluePhaseYellowPhase"].ToString();
                    txtRedBluePhase.Text = ds.Tables[0].Rows[0]["RedPhaseBluePhase"].ToString();

                    //220v
                    txtNeutralWire.Text = ds.Tables[0].Rows[0]["PhasewireNeutralwire"].ToString();
                    txtEarthWire.Text = ds.Tables[0].Rows[0]["PhasewireEarth"].ToString();
                    txtNeutralWireEarth.Text = ds.Tables[0].Rows[0]["NeutralwireEarth"].ToString();


                    if (LineType == "Overhead")
                    {
                        LineTypeOverhead.Visible = true;

                        ddlNmbrOfCircuit.SelectedItem.Text = ds.Tables[0].Rows[0]["NoOfCircuit"].ToString();
                        string ConductorType = ds.Tables[0].Rows[0]["Conductortype"].ToString();

                        ddlConductorType.SelectedIndex = ddlConductorType.Items.IndexOf(ddlConductorType.Items.FindByText(ConductorType));
                        if (ddlConductorType.SelectedItem.Text == "Bare")
                        {
                            OverheadBare.Visible = true;
                            OverheadCable.Visible = false;
                            txtPoleTowerNo.Text = ds.Tables[0].Rows[0]["NumberofPoleTower"].ToString();
                            txtConductorSize.Text = ds.Tables[0].Rows[0]["ConductorSize"].ToString();
                            txtGroundWireSize.Text = ds.Tables[0].Rows[0]["GroundWireSize"].ToString();
                            txtRailwayCrossingNo.Text = ds.Tables[0].Rows[0]["NmbrofRailwayCrossing"].ToString();
                            txtRoadCrossingNo.Text = ds.Tables[0].Rows[0]["NmbrofRoadCrossing"].ToString();
                            txtRiverCanalCrossing.Text = ds.Tables[0].Rows[0]["NmbrofRiverCanalCrossing"].ToString();
                            txtPowerLineCrossing.Text = ds.Tables[0].Rows[0]["NmbrofPowerLineCrossing"].ToString();
                        }
                        else
                        {
                            OverheadBare.Visible = false;
                            OverheadCable.Visible = true;
                            txtPoleTowerNo.Text = ds.Tables[0].Rows[0]["NoofPoleTowerForOverheadCable"].ToString();
                            txtCableSize1.Text = ds.Tables[0].Rows[0]["CableSize"].ToString();
                            txtRailwayCrossingNo.Text = ds.Tables[0].Rows[0]["RailwayCrossingNoForOC"].ToString();
                            txtRoadCrossingNo.Text = ds.Tables[0].Rows[0]["RoadCrossingNoForOC"].ToString();
                            txtRiverCanalCrossing.Text = ds.Tables[0].Rows[0]["RiverCanalCrossingNoForOC"].ToString();
                            txtPowerLineCrossing.Text = ds.Tables[0].Rows[0]["PowerLineCrossingNoForOc"].ToString();
                        }

                    }
                    else if (LineType == "Underground")
                    {
                        LineTypeUnderground.Visible = true;

                        string cableType = ds.Tables[0].Rows[0]["TypeofCable"].ToString();
                        ddlCableType.SelectedIndex = ddlCableType.Items.IndexOf(ddlCableType.Items.FindByText(cableType));
                        if (cableType == "Other")
                        {
                            OtherCable.Visible = true;
                            txtOtherCable.Text = ds.Tables[0].Rows[0]["OtherCable"].ToString();
                        }
                        txtCableSize.Text = ds.Tables[0].Rows[0]["SizeofCable"].ToString();

                        string cablelaidIn = ds.Tables[0].Rows[0]["Cablelaidin"].ToString();
                        ddlCableLaid.SelectedIndex = ddlCableLaid.Items.IndexOf(ddlCableLaid.Items.FindByText(cablelaidIn));
                    }

                    string NoOfEarthing = ds.Tables[0].Rows[0]["NmbrofEarthing"].ToString();
                    ddlEarthing();
                    ddlNoOfEarthing.SelectedIndex = ddlNoOfEarthing.Items.IndexOf(ddlNoOfEarthing.Items.FindByText(NoOfEarthing));
                    if (NoOfEarthing != "" && NoOfEarthing != null)
                    {
                        Earthing.Visible = true;
                        LineEarthingdiv.Visible = true;

                        if (NoOfEarthing == "1")
                        {
                            Earthingtype1.Visible = true;
                        }
                        else if (NoOfEarthing == "2")
                        {
                            Earthingtype1.Visible = true;
                            Earthingtype2.Visible = true;
                        }
                        else if (NoOfEarthing == "3")
                        {
                            Earthingtype1.Visible = true;
                            Earthingtype2.Visible = true;
                            Earthingtype3.Visible = true;
                        }
                        else if (NoOfEarthing == "4")
                        {
                            Earthingtype1.Visible = true;
                            Earthingtype2.Visible = true;
                            Earthingtype3.Visible = true;
                            Earthingtype4.Visible = true;
                        }
                        else if (NoOfEarthing == "5")
                        {
                            Earthingtype1.Visible = true;
                            Earthingtype2.Visible = true;
                            Earthingtype3.Visible = true;
                            Earthingtype4.Visible = true;
                            Earthingtype5.Visible = true;
                        }
                        else if (NoOfEarthing == "6")
                        {
                            Earthingtype1.Visible = true;
                            Earthingtype2.Visible = true;
                            Earthingtype3.Visible = true;
                            Earthingtype4.Visible = true;
                            Earthingtype5.Visible = true;
                            Earthingtype6.Visible = true;
                        }
                        else if (NoOfEarthing == "7")
                        {
                            Earthingtype1.Visible = true;
                            Earthingtype2.Visible = true;
                            Earthingtype3.Visible = true;
                            Earthingtype4.Visible = true;
                            Earthingtype5.Visible = true;
                            Earthingtype6.Visible = true;
                            Earthingtype7.Visible = true;
                        }
                        else if (NoOfEarthing == "8")
                        {
                            Earthingtype1.Visible = true;
                            Earthingtype2.Visible = true;
                            Earthingtype3.Visible = true;
                            Earthingtype4.Visible = true;
                            Earthingtype5.Visible = true;
                            Earthingtype6.Visible = true;
                            Earthingtype7.Visible = true;
                            Earthingtype8.Visible = true;
                        }
                        else if (NoOfEarthing == "9")
                        {
                            Earthingtype1.Visible = true;
                            Earthingtype2.Visible = true;
                            Earthingtype3.Visible = true;
                            Earthingtype4.Visible = true;
                            Earthingtype5.Visible = true;
                            Earthingtype6.Visible = true;
                            Earthingtype7.Visible = true;
                            Earthingtype8.Visible = true;
                            Earthingtype9.Visible = true;

                        }
                        else if (NoOfEarthing == "10")
                        {
                            Earthingtype1.Visible = true;
                            Earthingtype2.Visible = true;
                            Earthingtype3.Visible = true;
                            Earthingtype4.Visible = true;
                            Earthingtype5.Visible = true;
                            Earthingtype6.Visible = true;
                            Earthingtype7.Visible = true;
                            Earthingtype8.Visible = true;
                            Earthingtype9.Visible = true;
                            Earthingtype10.Visible = true;

                        }
                        else if (NoOfEarthing == "11")
                        {
                            Earthingtype1.Visible = true;
                            Earthingtype2.Visible = true;
                            Earthingtype3.Visible = true;
                            Earthingtype4.Visible = true;
                            Earthingtype5.Visible = true;
                            Earthingtype6.Visible = true;
                            Earthingtype7.Visible = true;
                            Earthingtype8.Visible = true;
                            Earthingtype9.Visible = true;
                            Earthingtype10.Visible = true;
                            Earthingtype11.Visible = true;
                        }
                        else if (NoOfEarthing == "12")
                        {
                            Earthingtype1.Visible = true;
                            Earthingtype2.Visible = true;
                            Earthingtype3.Visible = true;
                            Earthingtype4.Visible = true;
                            Earthingtype5.Visible = true;
                            Earthingtype6.Visible = true;
                            Earthingtype7.Visible = true;
                            Earthingtype8.Visible = true;
                            Earthingtype9.Visible = true;
                            Earthingtype10.Visible = true;
                            Earthingtype11.Visible = true;
                            Earthingtype12.Visible = true;
                        }
                        else if (NoOfEarthing == "13")
                        {
                            Earthingtype1.Visible = true;
                            Earthingtype2.Visible = true;
                            Earthingtype3.Visible = true;
                            Earthingtype4.Visible = true;
                            Earthingtype5.Visible = true;
                            Earthingtype6.Visible = true;
                            Earthingtype7.Visible = true;
                            Earthingtype8.Visible = true;
                            Earthingtype9.Visible = true;
                            Earthingtype10.Visible = true;
                            Earthingtype11.Visible = true;
                            Earthingtype12.Visible = true;
                            Earthingtype13.Visible = true;

                        }
                        else if (NoOfEarthing == "14")
                        {
                            Earthingtype1.Visible = true;
                            Earthingtype2.Visible = true;
                            Earthingtype3.Visible = true;
                            Earthingtype4.Visible = true;
                            Earthingtype5.Visible = true;
                            Earthingtype6.Visible = true;
                            Earthingtype7.Visible = true;
                            Earthingtype8.Visible = true;
                            Earthingtype9.Visible = true;
                            Earthingtype10.Visible = true;
                            Earthingtype11.Visible = true;
                            Earthingtype12.Visible = true;
                            Earthingtype13.Visible = true;
                            Earthingtype14.Visible = true;

                        }
                        else if (NoOfEarthing == "15")
                        {
                            Earthingtype1.Visible = true;
                            Earthingtype2.Visible = true;
                            Earthingtype3.Visible = true;
                            Earthingtype4.Visible = true;
                            Earthingtype5.Visible = true;
                            Earthingtype6.Visible = true;
                            Earthingtype7.Visible = true;
                            Earthingtype8.Visible = true;
                            Earthingtype9.Visible = true;
                            Earthingtype10.Visible = true;
                            Earthingtype11.Visible = true;
                            Earthingtype12.Visible = true;
                            Earthingtype13.Visible = true;
                            Earthingtype14.Visible = true;
                            Earthingtype15.Visible = true;
                        }

                        string EarthingType1 = ds.Tables[0].Rows[0]["EarthingType1"].ToString();
                        ddlEarthingtype1.SelectedIndex = ddlEarthingtype1.Items.IndexOf(ddlEarthingtype1.Items.FindByText(EarthingType1));
                        txtearthingValue1.Text = ds.Tables[0].Rows[0]["Valueinohms1"].ToString();

                        string EarthingType2 = ds.Tables[0].Rows[0]["EarthingType2"].ToString();
                        ddlEarthingtype2.SelectedIndex = ddlEarthingtype2.Items.IndexOf(ddlEarthingtype2.Items.FindByText(EarthingType2));
                        txtEarthingValue2.Text = ds.Tables[0].Rows[0]["Valueinohms2"].ToString();

                        string EarthingType3 = ds.Tables[0].Rows[0]["EarthingType3"].ToString();
                        ddlEarthingtype3.SelectedIndex = ddlEarthingtype3.Items.IndexOf(ddlEarthingtype3.Items.FindByText(EarthingType3));
                        txtEarthingValue3.Text = ds.Tables[0].Rows[0]["Valueinohms3"].ToString();

                        string EarthingType4 = ds.Tables[0].Rows[0]["EarthingType4"].ToString();
                        ddlEarthingtype4.SelectedIndex = ddlEarthingtype4.Items.IndexOf(ddlEarthingtype4.Items.FindByText(EarthingType4));
                        txtEarthingValue4.Text = ds.Tables[0].Rows[0]["Valueinohms4"].ToString();

                        string EarthingType5 = ds.Tables[0].Rows[0]["EarthingType5"].ToString();
                        ddlEarthingtype5.SelectedIndex = ddlEarthingtype5.Items.IndexOf(ddlEarthingtype5.Items.FindByText(EarthingType5));
                        txtEarthingValue5.Text = ds.Tables[0].Rows[0]["Valueinohms5"].ToString();

                        string EarthingType6 = ds.Tables[0].Rows[0]["EarthingType6"].ToString();
                        ddlEarthingtype6.SelectedIndex = ddlEarthingtype6.Items.IndexOf(ddlEarthingtype6.Items.FindByText(EarthingType6));
                        txtEarthingValue6.Text = ds.Tables[0].Rows[0]["Valueinohms6"].ToString();

                        string EarthingType7 = ds.Tables[0].Rows[0]["EarthingType7"].ToString();
                        ddlEarthingtype7.SelectedIndex = ddlEarthingtype7.Items.IndexOf(ddlEarthingtype7.Items.FindByText(EarthingType7));
                        txtEarthingValue7.Text = ds.Tables[0].Rows[0]["Valueinohms7"].ToString();

                        string EarthingType8 = ds.Tables[0].Rows[0]["EarthingType8"].ToString();
                        ddlEarthingtype8.SelectedIndex = ddlEarthingtype8.Items.IndexOf(ddlEarthingtype8.Items.FindByText(EarthingType8));
                        txtEarthingValue8.Text = ds.Tables[0].Rows[0]["Valueinohms8"].ToString();

                        string EarthingType9 = ds.Tables[0].Rows[0]["EarthingType9"].ToString();
                        ddlEarthingtype9.SelectedIndex = ddlEarthingtype9.Items.IndexOf(ddlEarthingtype9.Items.FindByText(EarthingType9));
                        txtEarthingValue9.Text = ds.Tables[0].Rows[0]["Valueinohms9"].ToString();

                        string EarthingType10 = ds.Tables[0].Rows[0]["EarthingType10"].ToString();
                        ddlEarthingtype10.SelectedIndex = ddlEarthingtype10.Items.IndexOf(ddlEarthingtype10.Items.FindByText(EarthingType10));
                        txtEarthingValue10.Text = ds.Tables[0].Rows[0]["Valueinohms10"].ToString();

                        string EarthingType11 = ds.Tables[0].Rows[0]["EarthingType11"].ToString();
                        ddlEarthingtype11.SelectedIndex = ddlEarthingtype11.Items.IndexOf(ddlEarthingtype11.Items.FindByText(EarthingType11));
                        txtEarthingValue11.Text = ds.Tables[0].Rows[0]["Valueinohms11"].ToString();

                        string EarthingType12 = ds.Tables[0].Rows[0]["EarthingType12"].ToString();
                        ddlEarthingtype12.SelectedIndex = ddlEarthingtype12.Items.IndexOf(ddlEarthingtype12.Items.FindByText(EarthingType12));
                        txtEarthingValue12.Text = ds.Tables[0].Rows[0]["Valueinohms12"].ToString();

                        string EarthingType13 = ds.Tables[0].Rows[0]["EarthingType13"].ToString();
                        ddlEarthingtype13.SelectedIndex = ddlEarthingtype13.Items.IndexOf(ddlEarthingtype13.Items.FindByText(EarthingType13));
                        txtEarthingValue13.Text = ds.Tables[0].Rows[0]["Valueinohms13"].ToString();

                        string EarthingType14 = ds.Tables[0].Rows[0]["EarthingType14"].ToString();
                        ddlEarthingtype14.SelectedIndex = ddlEarthingtype14.Items.IndexOf(ddlEarthingtype14.Items.FindByText(EarthingType14));
                        txtEarthingValue14.Text = ds.Tables[0].Rows[0]["Valueinohms14"].ToString();

                        string EarthingType15 = ds.Tables[0].Rows[0]["EarthingType15"].ToString();
                        ddlEarthingtype15.SelectedIndex = ddlEarthingtype15.Items.IndexOf(ddlEarthingtype15.Items.FindByText(EarthingType15));
                        txtEarthingValue15.Text = ds.Tables[0].Rows[0]["Valueinohms15"].ToString();

                    }


                    if (Session["Approval"].ToString().Trim() == "Reject")
                    {

                        btnSubmit.Text = "Update";
                    }
                    else
                    {
                        btnSubmit.Visible= false;
                        BtnBack.Visible = true;

                    }
                }
            }
            catch (Exception ex)
            {
                //abc
            }
        }
        private void ddlLoadBindVoltage()
        {

            DataSet dsVoltage = new DataSet();
            dsVoltage = CEI.GetddlVoltageForLine();
            ddlLineVoltage.DataSource = dsVoltage;
            ddlLineVoltage.DataTextField = "Voltage";
            ddlLineVoltage.DataValueField = "Id";
            ddlLineVoltage.DataBind();
            ddlLineVoltage.Items.Insert(0, new ListItem("Select", "0"));
            dsVoltage.Clear();

        }
        private void ddlEarthing()
        {
            try
            {
                DataSet dsEarthing = new DataSet();
                dsEarthing = CEI.GetddlEarthing();
                ddlNoOfEarthing.DataSource = dsEarthing;
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
        protected void ddlCableType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCableType.SelectedItem.ToString() == "Other")
            {
                OtherCable.Visible = true;
            }
            else
            {
                OtherCable.Visible = false;
            }
        }
         protected void ddlLineType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LineTypeOverhead.Visible = false;
            LineTypeUnderground.Visible = false;
            string userInput = TxtOthervoltage.Text;
            Earthing.Visible = true;
            ddlNoOfEarthing.SelectedValue = "0";
            LineEarthingdiv.Visible = false;
            Earthing.Visible = true;
            if (ddlLineType.SelectedValue == "1")
            {
                LineTypeOverhead.Visible = true;
                LineTypeUnderground.Visible = false;
                if (ddlLineVoltage.SelectedItem.ToString().Trim() == "Other")
                {
                    if (ddlOtherVoltage.SelectedValue == "2")
                    {

                        if (int.TryParse(TxtOthervoltage.Text, out int value))
                        {

                            Insulation220vAbove.Visible = false;
                            Insulation440vAbove.Visible = true;

                        }
                    }

                    else if (ddlOtherVoltage.SelectedValue == "1")
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
                            else
                            {
                                Insulation440vAbove.Visible = false;
                                Insulation220vAbove.Visible = false;
                            }

                        }
                    }
                }
                //else if (ddlLineVoltage.SelectedItem.ToString().Trim() == "220V")
                //{
                //    Insulation220vAbove.Visible = true;
                //    Insulation440vAbove.Visible = false;
                //}  
                //else if (ddlLineVoltage.SelectedItem.ToString().Trim() == "440V")
                //{
                //    Insulation220vAbove.Visible = false;
                //    Insulation440vAbove.Visible =true;
                //}
                //else if (ddlLineVoltage.SelectedValue == "0")
                //{
                //    Insulation220vAbove.Visible = false;
                //    Insulation440vAbove.Visible =false;
                //}
                //else
                //{
                //    Insulation220vAbove.Visible = false;
                //    Insulation440vAbove.Visible = true;
                //}

            }
            else if (ddlLineType.SelectedValue == "2")
            {

                LineTypeUnderground.Visible = true;
                LineTypeOverhead.Visible = false;
                if (ddlLineVoltage.SelectedItem.ToString().Trim() == "Other")
                {
                    if (ddlOtherVoltage.SelectedValue == "2")
                    {

                        if (int.TryParse(TxtOthervoltage.Text, out int value))
                        {

                            Insulation440vAbove.Visible = true;
                            Insulation220vAbove.Visible = false;

                        }
                    }

                    else if (ddlOtherVoltage.SelectedValue == "1")
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
                //else if (ddlLineVoltage.SelectedItem.ToString().Trim() == "220V")
                //{
                //    Insulation220vAbove.Visible = true;
                //    Insulation440vAbove.Visible = false;
                //}
                //else if ( ddlLineVoltage.SelectedItem.ToString().Trim() == "440V")
                //{
                //    Insulation220vAbove.Visible = false;
                //    Insulation440vAbove.Visible = true;
                //}
                //else if (ddlLineVoltage.SelectedValue == "0")
                //{
                //    Insulation220vAbove.Visible = false;
                //    Insulation440vAbove.Visible = false;
                //}
                //else
                //{
                //    Insulation220vAbove.Visible = false;
                //    Insulation440vAbove.Visible = true;
                //}
            }
            else
            {

                LineTypeOverhead.Visible = false;
                LineTypeUnderground.Visible = false;
                Insulation440vAbove.Visible = true;
                Insulation220vAbove.Visible = false;
                Earthing.Visible = false;
            }
        }
        protected void ddlConductorType_SelectedIndexChanged(object sender, EventArgs e)
        {
            OverheadCable.Visible = false;
            OverheadBare.Visible = false;

            if (ddlConductorType.SelectedValue == "1")
            {

                OverheadBare.Visible = true;
                OverheadCable.Visible = false;
                Earthing.Visible = true;
                ddlNoOfEarthing.SelectedValue = "0";
                LineEarthingdiv.Visible = false;

            }
            else if (ddlConductorType.SelectedValue == "2")
            {

                OverheadCable.Visible = true;
                OverheadBare.Visible = false;
                Earthing.Visible = true;
                ddlNoOfEarthing.SelectedValue = "0";
                LineEarthingdiv.Visible = false;
            }
            else
            {
                OverheadBare.Visible = false;
                OverheadCable.Visible = false;

                Earthing.Visible = true;
                ddlNoOfEarthing.SelectedValue = "0";
                LineEarthingdiv.Visible = false;
            }
        }
        protected void ddlNoOfEarthing_SelectedIndexChanged(object sender, EventArgs e)
        {
            LineEarthingdiv.Visible = true;
            Earthingtype1.Visible = false;
            Earthingtype2.Visible = false;
            Earthingtype3.Visible = false;
            Earthingtype4.Visible = false;
            Earthingtype5.Visible = false;
            Earthingtype6.Visible = false;
            Earthingtype7.Visible = false;
            Earthingtype8.Visible = false;
            Earthingtype9.Visible = false;
            Earthingtype10.Visible = false;
            Earthingtype11.Visible = false;
            Earthingtype12.Visible = false;
            Earthingtype13.Visible = false;
            Earthingtype14.Visible = false;
            Earthingtype15.Visible = false;
            if (ddlNoOfEarthing.SelectedValue.Trim() == "1")
            {
                Earthingtype1.Visible = true;
            }
            else if (ddlNoOfEarthing.SelectedValue.Trim() == "2")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Visible = true;

            }
            else if (ddlNoOfEarthing.SelectedValue.Trim() == "3")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Visible = true;
                Earthingtype3.Visible = true;

            }
            else if (ddlNoOfEarthing.SelectedValue.Trim() == "4")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Visible = true;
                Earthingtype3.Visible = true;
                Earthingtype4.Visible = true;

            }
            else if (ddlNoOfEarthing.SelectedValue.Trim() == "5")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Visible = true;
                Earthingtype3.Visible = true;
                Earthingtype4.Visible = true;
                Earthingtype5.Visible = true;

            }
            else if (ddlNoOfEarthing.SelectedValue.Trim() == "6")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Visible = true;
                Earthingtype3.Visible = true;
                Earthingtype4.Visible = true;
                Earthingtype5.Visible = true;
                Earthingtype6.Visible = true;

            }
            else if (ddlNoOfEarthing.SelectedValue.Trim() == "7")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Visible = true;
                Earthingtype3.Visible = true;
                Earthingtype4.Visible = true;
                Earthingtype5.Visible = true;
                Earthingtype6.Visible = true;
                Earthingtype7.Visible = true;

            }
            else if (ddlNoOfEarthing.SelectedValue.Trim() == "8")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Visible = true;
                Earthingtype3.Visible = true;
                Earthingtype4.Visible = true;
                Earthingtype5.Visible = true;
                Earthingtype6.Visible = true;
                Earthingtype7.Visible = true;
                Earthingtype8.Visible = true;

            }
            else if (ddlNoOfEarthing.SelectedValue.Trim() == "9")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Visible = true;
                Earthingtype3.Visible = true;
                Earthingtype4.Visible = true;
                Earthingtype5.Visible = true;
                Earthingtype6.Visible = true;
                Earthingtype7.Visible = true;
                Earthingtype8.Visible = true;
                Earthingtype9.Visible = true;

            }
            else if (ddlNoOfEarthing.SelectedValue.Trim() == "10")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Visible = true;
                Earthingtype3.Visible = true;
                Earthingtype4.Visible = true;
                Earthingtype5.Visible = true;
                Earthingtype6.Visible = true;
                Earthingtype7.Visible = true;
                Earthingtype8.Visible = true;
                Earthingtype9.Visible = true;
                Earthingtype10.Visible = true;

            }
            else if (ddlNoOfEarthing.SelectedValue.Trim() == "11")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Visible = true;
                Earthingtype3.Visible = true;
                Earthingtype4.Visible = true;
                Earthingtype5.Visible = true;
                Earthingtype6.Visible = true;
                Earthingtype7.Visible = true;
                Earthingtype8.Visible = true;
                Earthingtype9.Visible = true;
                Earthingtype10.Visible = true;
                Earthingtype11.Visible = true;

            }
            else if (ddlNoOfEarthing.SelectedValue.Trim() == "12")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Visible = true;
                Earthingtype3.Visible = true;
                Earthingtype4.Visible = true;
                Earthingtype5.Visible = true;
                Earthingtype6.Visible = true;
                Earthingtype7.Visible = true;
                Earthingtype8.Visible = true;
                Earthingtype9.Visible = true;
                Earthingtype10.Visible = true;
                Earthingtype11.Visible = true;
                Earthingtype12.Visible = true;

            }
            else if (ddlNoOfEarthing.SelectedValue.Trim() == "13")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Visible = true;
                Earthingtype3.Visible = true;
                Earthingtype4.Visible = true;
                Earthingtype5.Visible = true;
                Earthingtype6.Visible = true;
                Earthingtype7.Visible = true;
                Earthingtype8.Visible = true;
                Earthingtype9.Visible = true;
                Earthingtype10.Visible = true;
                Earthingtype11.Visible = true;
                Earthingtype12.Visible = true;
                Earthingtype13.Visible = true;

            }
            else if (ddlNoOfEarthing.SelectedValue.Trim() == "14")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Visible = true;
                Earthingtype3.Visible = true;
                Earthingtype4.Visible = true;
                Earthingtype5.Visible = true;
                Earthingtype6.Visible = true;
                Earthingtype7.Visible = true;
                Earthingtype8.Visible = true;
                Earthingtype9.Visible = true;
                Earthingtype10.Visible = true;
                Earthingtype11.Visible = true;
                Earthingtype12.Visible = true;
                Earthingtype14.Visible = true;

            }
            else if (ddlNoOfEarthing.SelectedValue.Trim() == "15")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Visible = true;
                Earthingtype3.Visible = true;
                Earthingtype4.Visible = true;
                Earthingtype5.Visible = true;
                Earthingtype6.Visible = true;
                Earthingtype7.Visible = true;
                Earthingtype8.Visible = true;
                Earthingtype9.Visible = true;
                Earthingtype10.Visible = true;
                Earthingtype11.Visible = true;
                Earthingtype12.Visible = true;
                Earthingtype15.Visible = true;

            }
        }
        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked == false)
            {
                labelVerification.Visible = true;
            }
            else
            {
                labelVerification.Visible = false;
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            try
            {

                //if (btnSubmit.Text.Trim() == "Update")
                //{
                //    IdUpdate = Session["Id"].ToString();
                //}

                if (Declaration.Visible == true && CheckBox1.Checked == false)
                {
                    labelVerification.Visible = true;
                }
                else
                {
                    string GeneratedLineId = string.Empty;
                    if (Convert.ToString(Session["GeneratedLineId"]) == null || Convert.ToString(Session["GeneratedLineId"]) == "")
                    {
                        GeneratedLineId = CEI.GenerateUniqueID();
                        Session["GeneratedLineId"] = LineId;
                    }
                    else
                    {
                        GeneratedLineId = Session["GeneratedLineId"].ToString();
                    }
                    string TestReportId = Session["TestReportId"].ToString();
                    string IntimationId = Session["id"].ToString();
                    string CreatedBy = Session["SupervisorID"].ToString();
                    CEI.InsertLineData(LineId, GeneratedLineId, TestReportId, IntimationId, ddlLineVoltage.SelectedItem.ToString(), ddlOtherVoltage.SelectedItem.ToString(), TxtOthervoltage.Text, txtLineLength.Text, ddlLineType.SelectedItem.ToString(),
                   ddlNmbrOfCircuit.SelectedItem.ToString(), ddlConductorType.SelectedItem.ToString(), txtPoleTower.Text, txtConductorSize.Text,
                  txtGroundWireSize.Text, txtRailwayCrossingNo.Text, txtRoadCrossingNo.Text, txtRiverCanalCrossing.Text, txtPowerLineCrossing.Text,
                   ddlNoOfEarthing.SelectedItem.ToString(), ddlEarthingtype1.SelectedItem.ToString(), txtearthingValue1.Text, ddlEarthingtype2.SelectedItem.ToString(),
                   txtEarthingValue2.Text, ddlEarthingtype3.SelectedItem.ToString(), txtEarthingValue3.Text, ddlEarthingtype4.SelectedItem.ToString(),
                  txtEarthingValue4.Text, ddlEarthingtype5.SelectedItem.ToString(), txtEarthingValue5.Text, ddlEarthingtype6.SelectedItem.ToString(),
                 txtEarthingValue6.Text, ddlEarthingtype7.SelectedItem.ToString(), txtEarthingValue7.Text, ddlEarthingtype8.SelectedItem.ToString(),
                 txtEarthingValue8.Text, ddlEarthingtype9.SelectedItem.ToString(), txtEarthingValue9.Text, ddlEarthingtype10.SelectedItem.ToString(),
                 txtEarthingValue10.Text, ddlEarthingtype11.SelectedItem.ToString(), txtEarthingValue11.Text, ddlEarthingtype12.SelectedItem.ToString(),
                 txtEarthingValue12.Text, ddlEarthingtype13.SelectedItem.ToString(), txtEarthingValue13.Text, ddlEarthingtype14.SelectedItem.ToString(),
                 txtEarthingValue14.Text, ddlEarthingtype15.SelectedItem.ToString(), txtEarthingValue15.Text, txtPoleTowerNo.Text, txtCableSize1.Text,
                 txtRailwayCrossingNmbr.Text, txtRoadCrossingNmbr.Text, txtRiverCanalCrossingNmber.Text, txtPowerLineCrossingNmbr.Text, txtRedEarthWire.Text,
                 txtYellowEarthWire.Text, txtBlueEarthWire.Text, txtRedYellowPhase.Text, txtRedBluePhase.Text, txtBlueYellowPhase.Text, txtNeutralWire.Text,
               txtEarthWire.Text, txtNeutralWireEarth.Text, ddlCableType.SelectedItem.ToString(), txtOtherCable.Text, txtCableSize.Text, ddlCableLaid.SelectedItem.ToString(),
               txtRedWire.Text, txtYellowWire.Text, txtBlueWire.Text, txtRedYellowWire.Text, txtRedBlueWire.Text, txtBlueYellowWire.Text,
               txtNeutralPhaseWire.Text, txtPhaseWireEarth.Text, txtNeutralWireEarthUnderground.Text, CreatedBy);
                    Page.Session["Visible"] = 1;
                    if (btnSubmit.Text.Trim() == "Submit" || btnSubmit.Text.Trim() == "Next")
                    {
                        Session["Page"] = Convert.ToInt32(Session["Page"]) + 1;
                        Reset();
                        DataSaved.Visible = true;
                        labelVerification.Visible = false;
                        PageWorking();
                        int currentValue = Convert.ToInt32(Session["Page"]);

                        if (currentValue == Convert.ToInt32(sessionValue))
                        {
                            Session["Count"] = Convert.ToInt32(Session["Count"]) + 1;
                            btnSubmit.Visible = false;
                            Session["SubmittedValue2"] = sessionValue;
                            divLine.Visible = false;
                            Session["LineId"] = "";
                            Session["TestReportId"] = TestReportId;
                            Page.Session["Page"] = 0;
                            if (nextSessionName.Trim() == "Substation Transformer")
                            {
                                Response.Redirect("SubstationTransformer.aspx", false);
                            }
                            else if (nextSessionName.Trim() == "Generating Station")
                            {
                                Response.Redirect("GeneratingSetTestReport.aspx", false);
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alertWithRedirect();", true);


                            }
                        }
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Test report has been submitted')", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Test report has been Updated and is under review by the Contractor for final submission')", true);

                        Response.Redirect("/Supervisor/TestReportHistory.aspx", false);
                    }
                }



            }
            catch (Exception Ex)
            {

                DataSaved.Visible = false;
            }
        }
        public void SessionValue()
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
        public void NextSessionValueAndName()
        {
            SessionValue();
            string[] installationNumbers = { "installationNo1", "installationNo2", "installationNo3", "installationNo4", "installationNo5", "installationNo6", "installationNo7", "installationNo8" };
            for (int i = 0; i < installationNumbers.Length; i++)
            {
                sessionName = Session["installationType" + (i + 1)] as string;
                sessionValue = Session[installationNumbers[i]] as string;

                if (!string.IsNullOrEmpty(sessionName))
                {
                    if (i < installationNumbers.Length - 1)
                    {
                        nextSessionName = Session["installationType" + (i + 1)] as string;
                        nextSessionValue = Session[installationNumbers[i + 1]] as string;
                        //if (nextSessionName == "Substation Transformer")
                        //{
                        //    Response.Redirect("SubstationTransformer.aspx");
                        //}
                        //else if (nextSessionName == "Generating Station")
                        //{
                        //    Response.Redirect("GeneratingSetTestReport.aspx");
                        //}
                        //else
                        //{
                        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Test report has been submitted and is under review by the Contractor for final submission')", true);

                        //}
                    }
                }
            }
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
                    btnSubmit.Text = "Submit";
                    btnSubmit.Attributes.Add("disabled", "true");
                    btnVerify.Visible = true;
                }
                else
                {
                    Declaration.Visible = false;
                    btnSubmit.Text = "Next";
                }
            }
            catch (Exception) { }

        }
        public void Reset()
        {
            txtLineLength.Text = "";
            ddlLineVoltage.SelectedValue = "0";
            txtLineLength.Text = ""; ddlLineType.SelectedValue = "0"; ddlNmbrOfCircuit.SelectedValue = "0"; ddlConductorType.SelectedValue = "0"; txtPoleTower.Text = ""; txtConductorSize.Text = "";
            txtGroundWireSize.Text = ""; txtRailwayCrossingNo.Text = ""; txtRoadCrossingNo.Text = ""; txtRiverCanalCrossing.Text = ""; txtPowerLineCrossing.Text = "";
            ddlNoOfEarthing.SelectedValue = "0"; ddlEarthingtype1.SelectedValue = "0"; txtearthingValue1.Text = ""; ddlEarthingtype2.SelectedValue = "0";
            txtEarthingValue2.Text = ""; ddlEarthingtype3.SelectedValue = "0"; txtEarthingValue3.Text = ""; ddlEarthingtype4.SelectedValue = "0";
            txtEarthingValue4.Text = ""; ddlEarthingtype5.SelectedValue = "0"; txtEarthingValue5.Text = ""; ddlEarthingtype6.SelectedValue = "0";
            txtEarthingValue6.Text = ""; ddlEarthingtype7.SelectedValue = "0"; txtEarthingValue7.Text = "";
            ddlEarthingtype8.SelectedValue = "0"; txtEarthingValue8.Text = ""; ddlEarthingtype9.SelectedValue = "0";
            txtEarthingValue9.Text = ""; ddlEarthingtype10.SelectedValue = "0"; txtEarthingValue10.Text = ""; ddlEarthingtype11.SelectedValue = "0";
            txtEarthingValue11.Text = ""; ddlEarthingtype12.SelectedValue = "0"; txtEarthingValue12.Text = ""; ddlEarthingtype13.SelectedValue = "0";
            txtEarthingValue13.Text = ""; ddlEarthingtype14.SelectedValue = "0"; txtEarthingValue14.Text = ""; ddlEarthingtype15.SelectedValue = "0";
            txtEarthingValue15.Text = ""; txtPoleTowerNo.Text = ""; txtCableSize1.Text = ""; txtRailwayCrossingNmbr.Text = ""; txtRoadCrossingNmbr.Text = "";
            txtRiverCanalCrossingNmber.Text = ""; txtPowerLineCrossingNmbr.Text = ""; txtRedEarthWire.Text = ""; txtYellowEarthWire.Text = "";
            txtBlueEarthWire.Text = ""; txtRedYellowPhase.Text = ""; txtRedBluePhase.Text = ""; txtBlueYellowPhase.Text = ""; txtNeutralWire.Text = "";
            txtEarthWire.Text = ""; txtNeutralWireEarth.Text = ""; ddlCableType.SelectedValue = "0"; txtCableSize.Text = ""; ddlCableLaid.SelectedValue = "0"; txtRedWire.Text = ""; txtYellowWire.Text = ""; txtBlueWire.Text = ""; txtRedYellowWire.Text = "";
            txtRedBlueWire.Text = ""; txtBlueYellowWire.Text = ""; txtNeutralPhaseWire.Text = ""; txtPhaseWireEarth.Text = ""; txtNeutralWireEarthUnderground.Text = "";
            OtherCable.Visible = false;
            Earthing.Visible = false;
            Insulation440vAbove.Visible = false;
            Insulation220vAbove.Visible = false;
            LineTypeUnderground.Visible = false;
            UndergroundInsulation440vAbove.Visible = false;
            UndergroundInsulation220vAbove.Visible = false;
            OtherCable.Visible = false;
            LineTypeOverhead.Visible = false;
            OverheadBare.Visible = false;
            OverheadCable.Visible = false;
            Earthing.Visible = false;
            LineEarthingdiv.Visible = false;
            Insulation440vAbove.Visible = false;
            Insulation220vAbove.Visible = false;
            LineTypeUnderground.Visible = false;
            UndergroundInsulation440vAbove.Visible = false;
            UndergroundInsulation220vAbove.Visible = false;
        }

        protected void ddlLineVoltage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlLineVoltage.SelectedItem.ToString().Trim() == "220V")
            {
                Insulation220vAbove.Visible = true;
                Insulation440vAbove.Visible = false;
            }
            else if (ddlLineVoltage.SelectedItem.ToString().Trim() == "440V")
            {
                Insulation220vAbove.Visible = false;
                Insulation440vAbove.Visible = true;
            }
            else if (ddlLineVoltage.SelectedItem.ToString().Trim() == "Other")
            {
                divOtherVoltages.Visible = true;
                OtherVoltage.Visible = true;

                Insulation440vAbove.Visible = false;
                Insulation220vAbove.Visible = false;

            }
            else if (ddlLineVoltage.SelectedValue == "0")
            {
                Insulation220vAbove.Visible = false;
                Insulation440vAbove.Visible = false;
                divOtherVoltages.Visible = false;
                OtherVoltage.Visible = false;
            }
            else
            {
                Insulation220vAbove.Visible = false;
                Insulation440vAbove.Visible = true;
                divOtherVoltages.Visible = false;
                OtherVoltage.Visible = false;
            }

        }

        protected void ddlCableType_SelectedIndexChanged1(object sender, EventArgs e)
        {
            if (ddlCableType.SelectedItem.ToString().Trim() == "Other")
            {
                OtherCable.Visible = true;
            }
            else
            {
                OtherCable.Visible = false;
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
                        btnSubmit.Attributes.Remove("disabled");
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