using CEI_PRoject;
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
        protected void Page_Load(object sender, EventArgs e)
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

                if (Convert.ToString(Session["Id"]) == null || Convert.ToString(Session["Id"]) == "")
                {
                    // GetHistoryDataById();
                }
                else
                {
                    GetHistoryDataById();
                }

            }
        }


        private void GetHistoryDataById()
        {
            try
            {
                string Id = Session["Id"].ToString();
                if (Convert.ToString(Session["Value"]) == null || Convert.ToString(Session["Value"]) == "")
                {
                    //
                }
                else
                {
                    type = Session["Value"].ToString();
                }
                DataSet ds = new DataSet();
                ds = CEI.GetTestReportDataForUpdate(type, Id);
                if (ds.Tables.Count > 0)
                {
                    ddlLineVoltage.SelectedItem.Text = ds.Tables[0].Rows[0]["LineVoltage"].ToString();


                    if (ddlLineVoltage.SelectedItem.Text == "Other")
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
                    else if (ddlLineVoltage.SelectedItem.Text.Trim() == "11kV" || ddlLineVoltage.SelectedItem.Text.Trim() == "66kV" ||
                       ddlLineVoltage.SelectedItem.Text.Trim() == "132kV" || ddlLineVoltage.SelectedItem.Text.Trim() == "220kV")
                    {
                        Insulation220vAbove.Visible = false;
                        Insulation440vAbove.Visible = true;
                    }
                    else if (ddlLineVoltage.SelectedItem.Text.Trim() == "440V")
                    {
                        Insulation220vAbove.Visible = false;
                        Insulation440vAbove.Visible = true;
                    }
                    else if (ddlLineVoltage.SelectedItem.Text.Trim() == "220V")
                    {
                        Insulation220vAbove.Visible = true;
                        Insulation440vAbove.Visible = false;
                    }


                    txtLineLength.Text = ds.Tables[0].Rows[0]["LineLength"].ToString();
                    ddlLineType.SelectedItem.Text = ds.Tables[0].Rows[0]["LineType"].ToString();

                    //440v
                    txtRedEarthWire.Text = ds.Tables[0].Rows[0]["RedPhaseEarthWirefor440orAbove"].ToString();
                    txtYellowEarthWire.Text = ds.Tables[0].Rows[0]["YellowPhaseEarthWire440orAbove"].ToString();
                    txtBlueEarthWire.Text = ds.Tables[0].Rows[0]["BluePhaseEarthWire440orAbove"].ToString();
                    txtRedYellowPhase.Text = ds.Tables[0].Rows[0]["RedPhaseYellowPhase440orAbove"].ToString();
                    txtBlueYellowPhase.Text = ds.Tables[0].Rows[0]["BluePhaseYellowPhase440orAbove"].ToString();
                    txtRedBluePhase.Text = ds.Tables[0].Rows[0]["RedPhaseBluePhase440orAbove"].ToString();

                    //220v
                    txtNeutralWire.Text = ds.Tables[0].Rows[0]["PhasewireNeutralwire220OrAbove"].ToString();
                    txtEarthWire.Text = ds.Tables[0].Rows[0]["PhasewireEarth220OrAbove"].ToString();
                    txtNeutralWireEarth.Text = ds.Tables[0].Rows[0]["NeutralwireEarth220OrAbove"].ToString();


                    if (ddlLineType.SelectedItem.Text == "Overhead")
                    {
                        LineTypeOverhead.Visible = true;

                        ddlNmbrOfCircuit.SelectedItem.Text = ds.Tables[0].Rows[0]["NoOfCircuit"].ToString();
                        ddlConductorType.SelectedItem.Text = ds.Tables[0].Rows[0]["Conductortype"].ToString();
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
                    else if (ddlLineType.SelectedItem.Text == "Underground")
                    {
                        LineTypeUnderground.Visible = true;

                        ddlCableType.SelectedItem.Text = ds.Tables[0].Rows[0]["TypeofCable"].ToString();
                        if (ddlCableType.SelectedItem.Text == "Other")
                        {
                            OtherCable.Visible = true;
                            txtOtherCable.Text = ds.Tables[0].Rows[0]["OtherCable"].ToString();
                        }
                        txtCableSize.Text = ds.Tables[0].Rows[0]["SizeofCable"].ToString();
                        ddlCableLaid.SelectedItem.Text = ds.Tables[0].Rows[0]["Cablelaidin"].ToString();
                    }

                    ddlNoOfEarthing.SelectedItem.Text = ds.Tables[0].Rows[0]["NmbrofEarthing"].ToString();
                    if (ddlNoOfEarthing.SelectedItem.Text != "" && ddlNoOfEarthing.SelectedItem.Text != null)
                    {
                        Earthing.Visible = true;
                        LineEarthingdiv.Visible = true;
                    }
                    if (ddlNoOfEarthing.SelectedItem.Text == "1")
                    {
                        Earthingtype1.Visible = true;
                    }
                    else if (ddlNoOfEarthing.SelectedItem.Text == "2")
                    {
                        Earthingtype1.Visible = true;
                        Earthingtype2.Visible = true;
                    }
                    else if (ddlNoOfEarthing.SelectedItem.Text == "3")
                    {
                        Earthingtype1.Visible = true;
                        Earthingtype2.Visible = true;
                        Earthingtype3.Visible = true;
                    }
                    else if (ddlNoOfEarthing.SelectedItem.Text == "4")
                    {
                        Earthingtype1.Visible = true;
                        Earthingtype2.Visible = true;
                        Earthingtype3.Visible = true;
                        Earthingtype4.Visible = true;
                    }
                    else if (ddlNoOfEarthing.SelectedItem.Text == "5")
                    {
                        Earthingtype1.Visible = true;
                        Earthingtype2.Visible = true;
                        Earthingtype3.Visible = true;
                        Earthingtype4.Visible = true;
                        Earthingtype5.Visible = true;
                    }
                    else if (ddlNoOfEarthing.SelectedItem.Text == "6")
                    {
                        Earthingtype1.Visible = true;
                        Earthingtype2.Visible = true;
                        Earthingtype3.Visible = true;
                        Earthingtype4.Visible = true;
                        Earthingtype5.Visible = true;
                        Earthingtype6.Visible = true;
                    }
                    else if (ddlNoOfEarthing.SelectedItem.Text == "7")
                    {
                        Earthingtype1.Visible = true;
                        Earthingtype2.Visible = true;
                        Earthingtype3.Visible = true;
                        Earthingtype4.Visible = true;
                        Earthingtype5.Visible = true;
                        Earthingtype6.Visible = true;
                        Earthingtype7.Visible = true;
                    }
                    else if (ddlNoOfEarthing.SelectedItem.Text == "8")
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
                    else if (ddlNoOfEarthing.SelectedItem.Text == "9")
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
                    else if (ddlNoOfEarthing.SelectedItem.Text == "10")
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
                    else if (ddlNoOfEarthing.SelectedItem.Text == "11")
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
                    else if (ddlNoOfEarthing.SelectedItem.Text == "12")
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
                    else if (ddlNoOfEarthing.SelectedItem.Text == "13")
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
                    else if (ddlNoOfEarthing.SelectedItem.Text == "14")
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
                    else if (ddlNoOfEarthing.SelectedItem.Text == "15")
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
                    ddlEarthingtype1.SelectedItem.Text = ds.Tables[0].Rows[0]["EarthingType1"].ToString();
                    txtearthingValue1.Text = ds.Tables[0].Rows[0]["Valueinohms1"].ToString();
                    ddlEarthingtype2.SelectedItem.Text = ds.Tables[0].Rows[0]["EarthingType2"].ToString();
                    txtEarthingValue2.Text = ds.Tables[0].Rows[0]["Valueinohms2"].ToString();
                    ddlEarthingtype3.SelectedItem.Text = ds.Tables[0].Rows[0]["EarthingType3"].ToString();
                    txtEarthingValue3.Text = ds.Tables[0].Rows[0]["Valueinohms3"].ToString();
                    ddlEarthingtype4.SelectedItem.Text = ds.Tables[0].Rows[0]["EarthingType4"].ToString();
                    txtEarthingValue4.Text = ds.Tables[0].Rows[0]["Valueinohms4"].ToString();
                    ddlEarthingtype5.SelectedItem.Text = ds.Tables[0].Rows[0]["EarthingType5"].ToString();
                    txtEarthingValue5.Text = ds.Tables[0].Rows[0]["Valueinohms5"].ToString();
                    ddlEarthingtype6.SelectedItem.Text = ds.Tables[0].Rows[0]["EarthingType6"].ToString();
                    txtEarthingValue6.Text = ds.Tables[0].Rows[0]["Valueinohms6"].ToString();
                    ddlEarthingtype7.SelectedItem.Text = ds.Tables[0].Rows[0]["EarthingType7"].ToString();
                    txtEarthingValue7.Text = ds.Tables[0].Rows[0]["Valueinohms7"].ToString();
                    ddlEarthingtype8.SelectedItem.Text = ds.Tables[0].Rows[0]["EarthingType8"].ToString();
                    txtEarthingValue8.Text = ds.Tables[0].Rows[0]["Valueinohms8"].ToString();
                    ddlEarthingtype9.SelectedItem.Text = ds.Tables[0].Rows[0]["EarthingType9"].ToString();
                    txtEarthingValue9.Text = ds.Tables[0].Rows[0]["Valueinohms9"].ToString();
                    ddlEarthingtype10.SelectedItem.Text = ds.Tables[0].Rows[0]["EarthingType10"].ToString();
                    txtEarthingValue10.Text = ds.Tables[0].Rows[0]["Valueinohms10"].ToString();
                    ddlEarthingtype11.SelectedItem.Text = ds.Tables[0].Rows[0]["EarthingType11"].ToString();
                    txtEarthingValue11.Text = ds.Tables[0].Rows[0]["Valueinohms11"].ToString();
                    ddlEarthingtype12.SelectedItem.Text = ds.Tables[0].Rows[0]["EarthingType12"].ToString();
                    txtEarthingValue12.Text = ds.Tables[0].Rows[0]["Valueinohms12"].ToString();
                    ddlEarthingtype13.SelectedItem.Text = ds.Tables[0].Rows[0]["EarthingType13"].ToString();
                    txtEarthingValue13.Text = ds.Tables[0].Rows[0]["Valueinohms13"].ToString();
                    ddlEarthingtype14.SelectedItem.Text = ds.Tables[0].Rows[0]["EarthingType14"].ToString();
                    txtEarthingValue14.Text = ds.Tables[0].Rows[0]["Valueinohms14"].ToString();
                    ddlEarthingtype15.SelectedItem.Text = ds.Tables[0].Rows[0]["EarthingType15"].ToString();
                    txtEarthingValue15.Text = ds.Tables[0].Rows[0]["Valueinohms15"].ToString();


                    btnSubmit.Text = "Update";
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

                if (btnSubmit.Text.Trim() == "Update")
                {
                    IdUpdate = Session["Id"].ToString();
                }

                if (Declaration.Visible == true && CheckBox1.Checked == false)
                {
                    labelVerification.Visible = true;
                }
                else
                {
                    string LineId = string.Empty;
                    if (Convert.ToString(Session["LineId"]) == null || Convert.ToString(Session["LineId"]) == "")
                    {
                        LineId = CEI.GenerateUniqueID();
                        Session["LineId"] = LineId;
                    }
                    else
                    {
                        LineId = Session["LineId"].ToString();
                    }
                    string TestReportId = Session["TestReportId"].ToString();
                    string IntimationId = Session["id"].ToString();
                    string CreatedBy = Session["SupervisorID"].ToString();
                    CEI.InsertLineData(IdUpdate, LineId, TestReportId, IntimationId, ddlLineVoltage.SelectedItem.ToString(), ddlOtherVoltage.SelectedItem.ToString(), TxtOthervoltage.Text, txtLineLength.Text, ddlLineType.SelectedItem.ToString(),
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
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "showalert", "alert('Test report has been submitted and is under review by the Contractor for final submission')", true);

                        }
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
            catch (Exception ex) { }

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