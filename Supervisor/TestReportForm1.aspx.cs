using CEI_PRoject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CEIHaryana.Supervisor
{
    public partial class TestReportForm1 : System.Web.UI.Page
    {
        CEI CEI = new CEI();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (Session["AdminID"] != null || Request.Cookies["AdminID"] != null)
                //{
                    ddlLoadBindVoltage();
                    ddlLoadBindState();
                ddlEarthingSubstation();
                //}
            }
        }
       
        private void ddlLoadBindState()
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
        protected void ddlLineType_SelectedIndexChanged(object sender, EventArgs e)
        {

            string userInput = TxtOthervoltage.Text;
            Earthing.Visible = true;
            if (ddlLineType.SelectedValue == "1")
            {
                LineTypeOverhead.Visible = true;
                LineTypeUnderground.Visible = false;
                if (userInput.EndsWith("kV", StringComparison.OrdinalIgnoreCase))
                {

                    if (int.TryParse(userInput.TrimEnd('k', 'K', 'v', 'V'), out int value))
                    {

                        Insulation220vAbove.Visible = false;
                        Insulation440vAbove.Visible = true;

                    }
                }

                else if (userInput.EndsWith("v", StringComparison.OrdinalIgnoreCase))
                {
                    // Input ends with "v", perform the "v" check
                    if (int.TryParse(userInput.TrimEnd('v', 'V'), out int value))
                    {
                        if (value > 440)
                        {
                            Insulation220vAbove.Visible = true;
                            Insulation440vAbove.Visible = false;
                        }
                        else if (value > 220)
                        {
                            Insulation440vAbove.Visible = true;
                            Insulation220vAbove.Visible = false;
                        }

                    }

                }
            }
            else if (ddlLineType.SelectedValue == "2")
            {

                LineTypeUnderground.Visible = true;
                LineTypeOverhead.Visible = false;
                if (userInput.EndsWith("kV", StringComparison.OrdinalIgnoreCase))
                {

                    if (int.TryParse(userInput.TrimEnd('k', 'K', 'v', 'V'), out int value))
                    {

                        UndergroundInsulation220vAbove.Visible = false;
                        UndergroundInsulation440vAbove.Visible = true;

                    }
                }

                else if (userInput.EndsWith("v", StringComparison.OrdinalIgnoreCase))
                {
                    // Input ends with "v", perform the "v" check
                    if (int.TryParse(userInput.TrimEnd('v', 'V'), out int value))
                    {
                        if (value > 440)
                        {
                            UndergroundInsulation220vAbove.Visible = true;
                            UndergroundInsulation440vAbove.Visible = false;
                        }
                        else if (value > 220)
                        {
                            UndergroundInsulation440vAbove.Visible = true;
                            UndergroundInsulation220vAbove.Visible = false;
                        }

                    }

                }
            }
            else
            {
                LineTypeOverhead.Visible = false;
                LineTypeUnderground.Visible = false;
                UndergroundInsulation220vAbove.Visible = false;
                UndergroundInsulation440vAbove.Visible = false;
                Insulation440vAbove.Visible = false;
                Insulation220vAbove.Visible = false;
                Earthing.Visible = false;
            }
        }

        protected void ddlConductorType_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ddlConductorType.SelectedValue == "1")
            {

                OverheadBare.Visible = true;
                OverheadCable.Visible = false;

            }
            else if (ddlConductorType.SelectedValue == "2")
            {

                OverheadCable.Visible = true;
                OverheadBare.Visible = false;
            }
            else
            {
                OverheadBare.Visible = false;
                OverheadCable.Visible = false;
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

        protected void ddlLineVoltage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlLineVoltage.SelectedItem.ToString() == "Other")
            {
                OtherVoltage.Visible = true;
            }
            else
            {
                OtherVoltage.Visible = false;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                CEI.InsertLineData(txtLineLength.Text, ddlLineVoltage.SelectedItem.ToString(), txtLineLength.Text, ddlLineType.SelectedItem.ToString(),
     ddlNmbrOfCircuit.SelectedItem.ToString(), ddlConductorType.SelectedItem.ToString(), txtPoleTower.Text, txtConductorSize.Text,
    txtGroundWireSize.Text, txtRailwayCrossingNo.Text, txtRoadCrossingNo.Text, txtRiverCanalCrossing.Text, txtPowerLineCrossing.Text,
     ddlNoOfEarthing.SelectedItem.ToString(), ddlEarthingtype1.SelectedItem.ToString(), txtearthingValue1.Text, ddlEarthingtype2.SelectedItem.ToString(),
     txtEarthingValue2.Text, ddlEarthingtype3.SelectedItem.ToString(), txtEarthingValue3.Text, ddlEarthingtype4.SelectedItem.ToString(),
    txtEarthingValue4.Text, ddlEarthingtype5.SelectedItem.ToString(), txtEarthingValue5.Text, ddlEarthingtype6.SelectedItem.ToString(),
   txtEarthingValue6.Text, ddlEarthingtype7.SelectedItem.ToString(), txtEarthingValue7.Text,
    ddlEarthingtype8.SelectedItem.ToString(), txtEarthingValue8.Text, ddlEarthingtype9.SelectedItem.ToString(),
    txtEarthingValue9.Text, ddlEarthingtype10.SelectedItem.ToString(), txtEarthingValue10.Text, ddlEarthingtype11.SelectedItem.ToString(),
    txtEarthingValue11.Text, ddlEarthingtype12.SelectedItem.ToString(), txtEarthingValue12.Text, ddlEarthingtype13.SelectedItem.ToString(),
    txtEarthingValue13.Text, ddlEarthingtype14.SelectedItem.ToString(), txtEarthingValue14.Text, ddlEarthingtype15.SelectedItem.ToString(),
   txtEarthingValue15.Text, txtPoleTowerNo.Text, txtCableSize1.Text, txtRailwayCrossingNmbr.Text, txtRoadCrossingNmbr.Text,
     txtRiverCanalCrossingNmber.Text, txtPowerLineCrossingNmbr.Text, txtRedEarthWire.Text, txtYellowEarthWire.Text,
 txtBlueEarthWire.Text, txtRedYellowPhase.Text, txtRedBluePhase.Text, txtBlueYellowPhase.Text, txtNeutralWire.Text,
 txtEarthWire.Text, txtNeutralWireEarth.Text, ddlCableType.SelectedItem.ToString(), txtCableSize.Text, ddlCableLaid.SelectedItem.ToString(), txtRedWire.Text, txtYellowWire.Text, txtBlueWire.Text, txtRedYellowWire.Text,
  txtRedBlueWire.Text, txtBlueYellowWire.Text, txtNeutralPhaseWire.Text, txtPhaseWireEarth.Text, txtNeutralWireEarthUnderground.Text);

                DataSaved.Visible = true;

            }
            catch (Exception Ex)
            {

                DataSaved.Visible = false;
            }
        }

        protected void ddlNoOfEarthing_SelectedIndexChanged(object sender, EventArgs e)
        {
            LineEarthingdiv.Visible = true;
            if (ddlNoOfEarthing.SelectedItem.ToString() == "1")
            {
                Earthingtype1.Visible = true;
            }
            else if (ddlNoOfEarthing.SelectedItem.ToString() == "2")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Style.Add("display", "table-row");

            }
            else if (ddlNoOfEarthing.SelectedItem.ToString() == "3")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Style.Add("display", "table-row");
                Earthingtype3.Style.Add("display", "table-row");

            }
            else if (ddlNoOfEarthing.SelectedItem.ToString() == "4")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Style.Add("display", "table-row");
                Earthingtype3.Style.Add("display", "table-row");
                Earthingtype4.Style.Add("display", "table-row");

            }
            else if (ddlNoOfEarthing.SelectedItem.ToString() == "5")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Style.Add("display", "table-row");
                Earthingtype3.Style.Add("display", "table-row");
                Earthingtype4.Style.Add("display", "table-row");
                Earthingtype5.Style.Add("display", "table-row");

            }
            else if (ddlNoOfEarthing.SelectedItem.ToString() == "6")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Style.Add("display", "table-row");
                Earthingtype3.Style.Add("display", "table-row");
                Earthingtype4.Style.Add("display", "table-row");
                Earthingtype5.Style.Add("display", "table-row");
                Earthingtype6.Style.Add("display", "table-row");

            }
            else if (ddlNoOfEarthing.SelectedItem.ToString() == "7")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Style.Add("display", "table-row");
                Earthingtype3.Style.Add("display", "table-row");
                Earthingtype4.Style.Add("display", "table-row");
                Earthingtype5.Style.Add("display", "table-row");
                Earthingtype6.Style.Add("display", "table-row");
                Earthingtype7.Style.Add("display", "table-row");

            }
            else if (ddlNoOfEarthing.SelectedItem.ToString() == "8")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Style.Add("display", "table-row");
                Earthingtype3.Style.Add("display", "table-row");
                Earthingtype4.Style.Add("display", "table-row");
                Earthingtype5.Style.Add("display", "table-row");
                Earthingtype6.Style.Add("display", "table-row");
                Earthingtype7.Style.Add("display", "table-row");
                Earthingtype8.Style.Add("display", "table-row");

            }
            else if (ddlNoOfEarthing.SelectedItem.ToString() == "9")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Style.Add("display", "table-row");
                Earthingtype3.Style.Add("display", "table-row");
                Earthingtype4.Style.Add("display", "table-row");
                Earthingtype5.Style.Add("display", "table-row");
                Earthingtype6.Style.Add("display", "table-row");
                Earthingtype7.Style.Add("display", "table-row");
                Earthingtype8.Style.Add("display", "table-row");
                Earthingtype9.Style.Add("display", "table-row");

            }
            else if (ddlNoOfEarthing.SelectedItem.ToString() == "10")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Style.Add("display", "table-row");
                Earthingtype3.Style.Add("display", "table-row");
                Earthingtype4.Style.Add("display", "table-row");
                Earthingtype5.Style.Add("display", "table-row");
                Earthingtype6.Style.Add("display", "table-row");
                Earthingtype7.Style.Add("display", "table-row");
                Earthingtype8.Style.Add("display", "table-row");
                Earthingtype9.Style.Add("display", "table-row");
                Earthingtype10.Style.Add("display", "table-row");

            }
            else if (ddlNoOfEarthing.SelectedItem.ToString() == "11")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Style.Add("display", "table-row");
                Earthingtype3.Style.Add("display", "table-row");
                Earthingtype4.Style.Add("display", "table-row");
                Earthingtype5.Style.Add("display", "table-row");
                Earthingtype6.Style.Add("display", "table-row");
                Earthingtype7.Style.Add("display", "table-row");
                Earthingtype8.Style.Add("display", "table-row");
                Earthingtype9.Style.Add("display", "table-row");
                Earthingtype10.Style.Add("display", "table-row");
                Earthingtype11.Style.Add("display", "table-row");

            }
            else if (ddlNoOfEarthing.SelectedItem.ToString() == "12")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Style.Add("display", "table-row");
                Earthingtype3.Style.Add("display", "table-row");
                Earthingtype4.Style.Add("display", "table-row");
                Earthingtype5.Style.Add("display", "table-row");
                Earthingtype6.Style.Add("display", "table-row");
                Earthingtype7.Style.Add("display", "table-row");
                Earthingtype8.Style.Add("display", "table-row");
                Earthingtype9.Style.Add("display", "table-row");
                Earthingtype10.Style.Add("display", "table-row");
                Earthingtype11.Style.Add("display", "table-row");
                Earthingtype12.Style.Add("display", "table-row");

            }
            else if (ddlNoOfEarthing.SelectedItem.ToString() == "13")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Style.Add("display", "table-row");
                Earthingtype3.Style.Add("display", "table-row");
                Earthingtype4.Style.Add("display", "table-row");
                Earthingtype5.Style.Add("display", "table-row");
                Earthingtype6.Style.Add("display", "table-row");
                Earthingtype7.Style.Add("display", "table-row");
                Earthingtype8.Style.Add("display", "table-row");
                Earthingtype9.Style.Add("display", "table-row");
                Earthingtype10.Style.Add("display", "table-row");
                Earthingtype11.Style.Add("display", "table-row");
                Earthingtype12.Style.Add("display", "table-row");
                Earthingtype13.Style.Add("display", "table-row");

            }
            else if (ddlNoOfEarthing.SelectedItem.ToString() == "14")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Style.Add("display", "table-row");
                Earthingtype3.Style.Add("display", "table-row");
                Earthingtype4.Style.Add("display", "table-row");
                Earthingtype5.Style.Add("display", "table-row");
                Earthingtype6.Style.Add("display", "table-row");
                Earthingtype7.Style.Add("display", "table-row");
                Earthingtype8.Style.Add("display", "table-row");
                Earthingtype9.Style.Add("display", "table-row");
                Earthingtype10.Style.Add("display", "table-row");
                Earthingtype11.Style.Add("display", "table-row");
                Earthingtype12.Style.Add("display", "table-row");
                Earthingtype14.Style.Add("display", "table-row");

            }
            else if (ddlNoOfEarthing.SelectedItem.ToString() == "15")
            {
                Earthingtype1.Visible = true;
                Earthingtype2.Style.Add("display", "table-row");
                Earthingtype3.Style.Add("display", "table-row");
                Earthingtype4.Style.Add("display", "table-row");
                Earthingtype5.Style.Add("display", "table-row");
                Earthingtype6.Style.Add("display", "table-row");
                Earthingtype7.Style.Add("display", "table-row");
                Earthingtype8.Style.Add("display", "table-row");
                Earthingtype9.Style.Add("display", "table-row");
                Earthingtype10.Style.Add("display", "table-row");
                Earthingtype11.Style.Add("display", "table-row");
                Earthingtype12.Style.Add("display", "table-row");
                Earthingtype15.Style.Add("display", "table-row");

            }
        }

        public void Reset()
        {
            txtLineLength.Text=""; 
            ddlLineVoltage.SelectedValue = "0";
            txtLineLength.Text="";ddlLineType.SelectedValue = "0"; ddlNmbrOfCircuit.SelectedValue = "0"; ddlConductorType.SelectedValue = "0"; txtPoleTower.Text=""; txtConductorSize.Text="";
    txtGroundWireSize.Text=""; txtRailwayCrossingNo.Text=""; txtRoadCrossingNo.Text=""; txtRiverCanalCrossing.Text=""; txtPowerLineCrossing.Text="";
     ddlNoOfEarthing.SelectedValue = "0"; ddlEarthingtype1.SelectedValue = "0"; txtearthingValue1.Text=""; ddlEarthingtype2.SelectedValue = "0";
     txtEarthingValue2.Text=""; ddlEarthingtype3.SelectedValue = "0"; txtEarthingValue3.Text=""; ddlEarthingtype4.SelectedValue = "0";
    txtEarthingValue4.Text=""; ddlEarthingtype5.SelectedValue = "0"; txtEarthingValue5.Text=""; ddlEarthingtype6.SelectedValue = "0";
   txtEarthingValue6.Text=""; ddlEarthingtype7.SelectedValue = "0"; txtEarthingValue7.Text="";
    ddlEarthingtype8.SelectedValue = "0"; txtEarthingValue8.Text=""; ddlEarthingtype9.SelectedValue = "0";
    txtEarthingValue9.Text=""; ddlEarthingtype10.SelectedValue = "0"; txtEarthingValue10.Text=""; ddlEarthingtype11.SelectedValue = "0";
    txtEarthingValue11.Text=""; ddlEarthingtype12.SelectedValue = "0"; txtEarthingValue12.Text=""; ddlEarthingtype13.SelectedValue = "0";
    txtEarthingValue13.Text=""; ddlEarthingtype14.SelectedValue = "0"; txtEarthingValue14.Text=""; ddlEarthingtype15.SelectedValue = "0";
   txtEarthingValue15.Text=""; txtPoleTowerNo.Text=""; txtCableSize1.Text=""; txtRailwayCrossingNmbr.Text=""; txtRoadCrossingNmbr.Text="";
     txtRiverCanalCrossingNmber.Text=""; txtPowerLineCrossingNmbr.Text=""; txtRedEarthWire.Text=""; txtYellowEarthWire.Text="";
 txtBlueEarthWire.Text=""; txtRedYellowPhase.Text=""; txtRedBluePhase.Text=""; txtBlueYellowPhase.Text=""; txtNeutralWire.Text="";
 txtEarthWire.Text=""; txtNeutralWireEarth.Text=""; ddlCableType.SelectedValue = "0"; txtCableSize.Text=""; ddlCableLaid.SelectedValue = "0"; txtRedWire.Text=""; txtYellowWire.Text=""; txtBlueWire.Text=""; txtRedYellowWire.Text="";
  txtRedBlueWire.Text=""; txtBlueYellowWire.Text=""; txtNeutralPhaseWire.Text=""; txtPhaseWireEarth.Text=""; txtNeutralWireEarthUnderground.Text = "";
        }
        protected void ddltransformerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtTransformerCapacity.Text, out int value))
            {
             
                if (value > 1000)
                {
                    
                    ddlBreaker.Visible = true;
                    ddlHTType.Visible = false;
                    Breaker.Visible = true;
                }
                else
                {
                    ddlBreaker.Visible = false;
                    TypeOfHTBreaker.Visible = false;
                }
            }
            else
            {
                
            }
            if (ddltransformerType.SelectedValue == "1")
            {
                InCaseOfOil.Visible = true;
                Capacity.Visible = true;
            }
            else
            {
                InCaseOfOil.Visible = true;
                Capacity.Visible = false;
            }
        } 
        protected void ddlLTProtection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlLTProtection.SelectedValue == "1")
            {
                FuseUnit.Visible = true;
                Breaker.Visible = false;
            }
            else if (ddlLTProtection.SelectedValue == "2")
            {
                FuseUnit.Visible = false;
                Breaker.Visible = true;
            }
            else
            {
                FuseUnit.Visible = false;
                Breaker.Visible = false;
            }
        }
        protected void ddlHTType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlHTType.SelectedValue == "3")
            {
                Breaker.Visible = true;
                FuseUnit.Visible= false;
            }
            else
            {
                FuseUnit.Visible = false;
                Breaker.Visible = false;
            }
        }

        private void ddlEarthingSubstation()
        {

            DataSet dsEarthing= new DataSet();
            dsEarthing = CEI.GetddlEarthingSubstation();
            ddlEarthingsubstation.DataSource = dsEarthing;
            ddlEarthingsubstation.DataTextField = "NumberOfEarthing";
            ddlEarthingsubstation.DataValueField = "NumberOfEarthing";
            ddlEarthingsubstation.DataBind();
            ddlEarthingsubstation.Items.Insert(0, new ListItem("Select", "0"));
            dsEarthing.Clear();

        }
        protected void ddlEarthingsubstation_SelectedIndexChanged(object sender, EventArgs e)
        {
            SubstationEarthingDiv.Visible = true;
            if (ddlEarthingsubstation.SelectedItem.ToString() == "4")
            {
                EarthingSubstation4.Visible = true;
            }
            else if (ddlEarthingsubstation.SelectedItem.ToString() == "5")
            {
                EarthingSubstation4.Visible = true;
                EathingSubstation5.Visible= true;
            }
           else if (ddlEarthingsubstation.SelectedItem.ToString() == "6")
            {
                EarthingSubstation4.Visible = true;
                EathingSubstation5.Visible = true;
                EathingSubstation6.Visible= true;
            }
           else if (ddlEarthingsubstation.SelectedItem.ToString() == "7")
            {
                EarthingSubstation4.Visible = true;
                EathingSubstation5.Visible = true;
                EathingSubstation6.Visible = true;
                EathingSubstation7.Visible= true;
            }
           else if (ddlEarthingsubstation.SelectedItem.ToString() == "8")
            {
                EarthingSubstation4.Visible = true;
                EathingSubstation5.Visible = true;
                EathingSubstation6.Visible = true;
                EathingSubstation7.Visible = true;
                EathingSubstation8.Visible= true;
            }
           else if (ddlEarthingsubstation.SelectedItem.ToString() == "9")
            {
                EarthingSubstation4.Visible = true;
                EathingSubstation5.Visible = true;
                EathingSubstation6.Visible = true;
                EathingSubstation7.Visible = true;
                EathingSubstation8.Visible = true;
                EathingSubstation9.Visible= true;
            }
           else if (ddlEarthingsubstation.SelectedItem.ToString() == "10")
            {
                EarthingSubstation4.Visible = true;
                EathingSubstation5.Visible = true;
                EathingSubstation6.Visible = true;
                EathingSubstation7.Visible = true;
                EathingSubstation8.Visible = true;
                EathingSubstation9.Visible = true;
                EathingSubstation10.Visible= true;
            }
           else if (ddlEarthingsubstation.SelectedItem.ToString() == "11")
            {
                EarthingSubstation4.Visible = true;
                EathingSubstation5.Visible = true;
                EathingSubstation6.Visible = true;
                EathingSubstation7.Visible = true;
                EathingSubstation8.Visible = true;
                EathingSubstation9.Visible = true;
                EathingSubstation10.Visible = true;
                EathingSubstation11.Visible= true;
            }
           else if (ddlEarthingsubstation.SelectedItem.ToString() == "12")
            {
                EarthingSubstation4.Visible = true;
                EathingSubstation5.Visible = true;
                EathingSubstation6.Visible = true;
                EathingSubstation7.Visible = true;
                EathingSubstation8.Visible = true;
                EathingSubstation9.Visible = true;
                EathingSubstation10.Visible = true;
                EathingSubstation11.Visible = true;
                EathingSubstation12.Visible= true;
            }
           else if (ddlEarthingsubstation.SelectedItem.ToString() == "13")
            {
                EarthingSubstation4.Visible = true;
                EathingSubstation5.Visible = true;
                EathingSubstation6.Visible = true;
                EathingSubstation7.Visible = true;
                EathingSubstation8.Visible = true;
                EathingSubstation9.Visible = true;
                EathingSubstation10.Visible = true;
                EathingSubstation11.Visible = true;
                EathingSubstation12.Visible = true;
                EathingSubstation13.Visible= true;
            }
           else if (ddlEarthingsubstation.SelectedItem.ToString() == "14")
            {
                EarthingSubstation4.Visible = true;
                EathingSubstation5.Visible = true;
                EathingSubstation6.Visible = true;
                EathingSubstation7.Visible = true;
                EathingSubstation8.Visible = true;
                EathingSubstation9.Visible = true;
                EathingSubstation10.Visible = true;
                EathingSubstation11.Visible = true;
                EathingSubstation12.Visible = true;
                EathingSubstation13.Visible = true;
                EathingSubstation14.Visible= true;
            }
           else if (ddlEarthingsubstation.SelectedItem.ToString() == "15")
            {
                EarthingSubstation4.Visible = true;
                EathingSubstation5.Visible = true;
                EathingSubstation6.Visible = true;
                EathingSubstation7.Visible = true;
                EathingSubstation8.Visible = true;
                EathingSubstation9.Visible = true;
                EathingSubstation10.Visible = true;
                EathingSubstation11.Visible = true;
                EathingSubstation12.Visible = true;
                EathingSubstation13.Visible = true;
                EathingSubstation14.Visible = true;
                EathingSubstation15.Visible= true;
            }
           else if (ddlEarthingsubstation.SelectedItem.ToString() == "16")
            {
                EarthingSubstation4.Visible = true;
                EathingSubstation5.Visible = true;
                EathingSubstation6.Visible = true;
                EathingSubstation7.Visible = true;
                EathingSubstation8.Visible = true;
                EathingSubstation9.Visible = true;
                EathingSubstation10.Visible = true;
                EathingSubstation11.Visible = true;
                EathingSubstation12.Visible = true;
                EathingSubstation13.Visible = true;
                EathingSubstation14.Visible = true;
                EathingSubstation15.Visible = true;
                EathingSubstation16.Visible= true;
            }
           else if (ddlEarthingsubstation.SelectedItem.ToString() == "17")
            {
                EarthingSubstation4.Visible = true;
                EathingSubstation5.Visible = true;
                EathingSubstation6.Visible = true;
                EathingSubstation7.Visible = true;
                EathingSubstation8.Visible = true;
                EathingSubstation9.Visible = true;
                EathingSubstation10.Visible = true;
                EathingSubstation11.Visible = true;
                EathingSubstation12.Visible = true;
                EathingSubstation13.Visible = true;
                EathingSubstation14.Visible = true;
                EathingSubstation15.Visible = true;
                EathingSubstation16.Visible = true;
                EathingSubstation17.Visible= true;
            }
           else if (ddlEarthingsubstation.SelectedItem.ToString() == "18")
            {
                EarthingSubstation4.Visible = true;
                EathingSubstation5.Visible = true;
                EathingSubstation6.Visible = true;
                EathingSubstation7.Visible = true;
                EathingSubstation8.Visible = true;
                EathingSubstation9.Visible = true;
                EathingSubstation10.Visible = true;
                EathingSubstation11.Visible = true;
                EathingSubstation12.Visible = true;
                EathingSubstation13.Visible = true;
                EathingSubstation14.Visible = true;
                EathingSubstation15.Visible = true;
                EathingSubstation16.Visible = true;
                EathingSubstation17.Visible = true;
                EathingSubstation18.Visible= true;
            }
           else if (ddlEarthingsubstation.SelectedItem.ToString() == "19")
            {
                EarthingSubstation4.Visible = true;
                EathingSubstation5.Visible = true;
                EathingSubstation6.Visible = true;
                EathingSubstation7.Visible = true;
                EathingSubstation8.Visible = true;
                EathingSubstation9.Visible = true;
                EathingSubstation10.Visible = true;
                EathingSubstation11.Visible = true;
                EathingSubstation12.Visible = true;
                EathingSubstation13.Visible = true;
                EathingSubstation14.Visible = true;
                EathingSubstation15.Visible = true;
                EathingSubstation16.Visible = true;
                EathingSubstation17.Visible = true;
                EathingSubstation18.Visible = true;
                EathingSubstation19.Visible= true;
            }
           else if (ddlEarthingsubstation.SelectedItem.ToString() == "20")
            {
                EarthingSubstation4.Visible = true;
                EathingSubstation5.Visible = true;
                EathingSubstation6.Visible = true;
                EathingSubstation7.Visible = true;
                EathingSubstation8.Visible = true;
                EathingSubstation9.Visible = true;
                EathingSubstation10.Visible = true;
                EathingSubstation11.Visible = true;
                EathingSubstation12.Visible = true;
                EathingSubstation13.Visible = true;
                EathingSubstation14.Visible = true;
                EathingSubstation15.Visible = true;
                EathingSubstation16.Visible = true;
                EathingSubstation17.Visible = true;
                EathingSubstation18.Visible = true;
                EathingSubstation19.Visible = true;
                EathingSubstation20.Visible= true;
            }
            else
            {
                EarthingSubstation4.Visible = false;
                EathingSubstation5.Visible = false;
                EathingSubstation6.Visible = false;
                EathingSubstation7.Visible = false;
                EathingSubstation8.Visible = false;
                EathingSubstation9.Visible = false;
                EathingSubstation10.Visible = false;
                EathingSubstation11.Visible = false;
                EathingSubstation12.Visible = false;
                EathingSubstation13.Visible = false;
                EathingSubstation14.Visible = false;
                EathingSubstation15.Visible = false;
                EathingSubstation16.Visible = false;
                EathingSubstation17.Visible = false;
                EathingSubstation18.Visible = false;
                EathingSubstation19.Visible = false;
                EathingSubstation20.Visible = false;
            }
           
        }
    }
}